window.addEventListener('load', solve);

function solve() {

    let genreInput = document.getElementById(`genre`);
    let nameInput = document.getElementById(`name`);
    let authorInput = document.getElementById(`author`);
    let dateInput = document.getElementById(`date`);

    let allHits = document.getElementsByClassName(`all-hits-container`)[0];
    let savedHits = document.getElementsByClassName(`saved-container`)[0];
    let likes = document.getElementsByClassName(`likes`)[0].children[0];
    let likesCount = 0;

    let addBtn = document.getElementById(`add-btn`);

    addBtn.addEventListener(`click`, (ev) => {
        ev.preventDefault();

        if (!genreInput.value || !nameInput.value || !authorInput.value || !dateInput.value) {
            
            return;
        }

        let div = document.createElement(`div`);
        div.classList.add(`hits-info`)

        let img = document.createElement(`img`);
        img.src = `./static/img/img.png`;

        let genre = document.createElement(`h2`);
        genre.textContent = `Genre: ${genreInput.value}`;
        genreInput.value = ``;

        let name = document.createElement(`h2`);
        name.textContent = `Name: ${nameInput.value}`;
        nameInput.value =``;

        let author = document.createElement(`h2`);
        author.textContent = `Author: ${authorInput.value}`;
        authorInput.value = ``;

        let date = document.createElement(`h3`);
        date.textContent = `Date: ${dateInput.value}`;
        dateInput.value = ``;

        let saveBtn = document.createElement(`button`);
        saveBtn.classList.add(`save-btn`);
        saveBtn.textContent = `Save song`;

        let likeBtn = document.createElement(`button`);
        likeBtn.classList.add(`like-btn`);
        likeBtn.textContent = `Like song`;

        let delBtn = document.createElement(`button`);
        delBtn.classList.add(`delete-btn`);
        delBtn.textContent = `Delete`;

        div.appendChild(img);
        div.appendChild(genre);
        div.appendChild(name);
        div.appendChild(author);
        div.appendChild(date);
        div.appendChild(saveBtn);
        div.appendChild(likeBtn);
        div.appendChild(delBtn);

        allHits.appendChild(div);

        likeBtn.addEventListener(`click`, (ev) => {

            likesCount++;
            likes.textContent = `Total Likes: ${likesCount}`;
            ev.target.disabled = true;
        })

        saveBtn.addEventListener(`click`, (ev) => {

            let song = ev.target.parentNode;
            savedHits.appendChild(ev.target.parentNode);

            song.querySelector(`.like-btn`).remove();
            song.querySelector(`.save-btn`).remove();
        })

        delBtn.addEventListener(`click`, (ev) => {

            ev.target.parentNode.remove();
        })
    })
}