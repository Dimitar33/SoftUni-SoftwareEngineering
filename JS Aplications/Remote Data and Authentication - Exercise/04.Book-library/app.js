async function main() {

    const url = `http://localhost:3030/jsonstore/collections/books`;

    const formName = document.querySelector(`form`).children[0];
    const titleInput = document.querySelector(`form`).children[2];
    const authorInput = document.querySelector(`form`).children[4];
    const books = document.querySelector(`tbody`);

    let loadBtn = document.getElementById(`loadBooks`);
    let submitBtn = document.querySelector(`form`).children[5];
    let bookId = ``;

    let saveBtn = document.createElement(`button`);
    saveBtn.textContent = `Save`;
    saveBtn.style.display = `none`;

    document.querySelector(`form`).appendChild(saveBtn)

    loadBtn.addEventListener(`click`, async () => {

        titleInput.value = ``;
        authorInput.value = ``;

        let res = await fetch(url);
        let data = await res.json();

        books.replaceChildren();

        formName.textContent = `FORM`;
        submitBtn.style.display = `block`;
        saveBtn.style.display = `none`;

        Object.entries(data).forEach(el => {

            let tr = document.createElement(`tr`);

            let title = document.createElement(`td`);
            title.textContent = el[1][`title`];

            let author = document.createElement(`td`);
            author.textContent = el[1][`author`];

            let editBtn = document.createElement(`button`);
            editBtn.setAttribute(`id`, el[0]);
            editBtn.textContent = `Edit`;

            editBtn.addEventListener(`click`, async (event) => {
                event.preventDefault();

                formName.textContent = `Edit FORM`;

                submitBtn.style.display = `none`;
                saveBtn.style.display = `block`;

                let title = event.target.parentNode.parentNode.children[0].textContent;
                let author = event.target.parentNode.parentNode.children[1].textContent;
                bookId = event.target.id;

                titleInput.value = title;
                authorInput.value = author;

                console.log(event.target.id)

            })

            let deleteBtn = document.createElement(`button`);
            deleteBtn.textContent = `Delete`;
            deleteBtn.setAttribute(`id`, el[0]);

            deleteBtn.addEventListener(`click`, async (ev) => {
                ev.preventDefault();

                let delUrl = `http://localhost:3030/jsonstore/collections/books/${ev.target.id}`;

                let res = await fetch(delUrl, {
                    method: `delete`
                })

                if (!res.ok) {
                    let error = await res.json();
                    return alert(error.message);
                }

                ev.target.parentNode.parentNode.remove();

            })

            let buttons = document.createElement(`td`);
            buttons.appendChild(editBtn);
            buttons.appendChild(deleteBtn);

            tr.appendChild(title);
            tr.appendChild(author);
            tr.appendChild(buttons);

            books.appendChild(tr);

        });
    })

    submitBtn.addEventListener(`click`, async () => {

        if (!titleInput.value || !authorInput.value) {

            return alert(`All fields are required`);
        }

        let res = await fetch(url, {
            method: `post`,
            headers: { 'Content-type': 'aplication/json' },
            body: JSON.stringify({ title: titleInput.value, author: authorInput.value })
        })

        if (!res.ok) {
            let error = await res.json();
            return alert(error.message);
        }
    })

    saveBtn.addEventListener(`click`, async (ev) => {
        ev.preventDefault();

        if (!titleInput.value || !authorInput.value) {
            
            return alert(`Empty Field`)
        }

        let res = await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
            method: `put`,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: titleInput.value, author: authorInput.value })
        })

        if (!res.ok) {
            let error = await res.json();
            return alert(error.message);
        }

        loadBtn.click();
    })
    loadBtn.click();
}

main();