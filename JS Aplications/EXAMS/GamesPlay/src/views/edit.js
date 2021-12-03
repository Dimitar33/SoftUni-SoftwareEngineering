import { editGame, getGame } from "../api/data.js";
import { html } from "../util.js";

const editTemplate = (gameData, onSubmit) => html`
        <section id="edit-page" class="auth">
            <form @submit=${onSubmit} id="edit">
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" value="${gameData.title}">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" value="${gameData.category}">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" value="${gameData.maxLevel}">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" value="${gameData.imageUrl}">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary">${gameData.summary}</textarea>
                    <input class="btn submit" type="submit" value="Edit Game">

                </div>
            </form>
        </section>`;

export async function editPage(ctx) {

    const id = ctx.params.id;
    const gameData = await getGame(id);

    ctx.render(editTemplate(gameData, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);

        const game = {

            title: formData.get(`title`).trim(),
            category: formData.get(`category`).trim(),
            maxLevel: formData.get(`maxLevel`).trim(),
            imageUrl: formData.get(`imageUrl`).trim(),
            summary: formData.get(`summary`).trim(),
        }

        if (!game.title || !game.category || !game.maxLevel || !game.imageUrl || !game.summary) {

            return alert(`All fields are required`);
        }
        
        await editGame(id, game);
        ctx.page.redirect(`/`);
    }
}