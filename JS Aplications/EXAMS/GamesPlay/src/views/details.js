import { createComment, deleteGame, gameComments, getGame } from "../api/data.js";
import { html } from "../util.js";

const detailsTemplate = (isOwner, game, userId, comments, onDelete) => html`
        <section id="game-details">
            <h1>Game Details</h1>
            <div class="info-section">

                <div class="game-header">
                    <img class="game-img" src="${game.imageUrl}" />
                    <h1>${game.title}</h1>
                    <span class="levels">MaxLevel: ${game.maxLevel}</span>
                    <p class="type">${game.category}</p>
                </div>

                <p class="text">
                   ${game.summary}
                </p>

                <!-- Bonus ( for Guests and Users ) -->
                <div class="details-comments">
                    <h2>Comments:</h2>
                    ${comments.length == 0
        ? html`<p class="no-comment">No comments.</p>`
        : html`${comments.map(commentTemplate)}`}
                       
                </div>
        
                ${ownerControls(isOwner, game, userId, onDelete)}
                
            </div>
        </section>`;

const commentTemplate = (coment) => html`
                            <li class="comment">
                                 <p>Content:${coment.comment}</p>
                            </li>`;

function ownerControls(isOwner, game, userId, onDelete) {



    if (isOwner) {

        return html`
                <div class="buttons">
                     <a href="/edit/${game._id}" class="button">Edit</a>
                     <a href="javascript:void(0)" @click=${onDelete} class="button">Delete</a>
                 </div>`;
    }
    else if (userId) {

        return html`
             <article class="create-comment">
                <label>Add new comment:</label>
                    <form  class="form">
                      <textarea id="coment" name="comment" placeholder="Comment......"></textarea>
                      <input id="commentBtn" class="btn submit" type="submit" value="Add Comment">
                    </form>
               </article>`;
    }
}

export async function detailsPage(ctx) {

    const id = ctx.params.id;
    const game = await getGame(id);
    const comments = await gameComments(id);

    console.log(comments);

    const userId = sessionStorage.getItem(`userId`);
    const isOwner = userId && userId == game._ownerId;

    ctx.render(detailsTemplate(isOwner, game, userId, comments, onDelete));

    async function onDelete() {

        const confirmed = confirm(`Are you shure you want to delete that game`);

        if (confirmed) {

            await deleteGame(id);
            ctx.page.redirect(`/`);
        }
    }


    document.getElementById(`commentBtn`).addEventListener(`click`, async () => {

        const coment = {

            gameId: id,
            comment: document.getElementById(`coment`).value

        }

        if (!coment.comment) {

            return alert(`Write a comment`);
        }

        await createComment(coment);
        ctx.page.redirect(`/details`);
    })



}