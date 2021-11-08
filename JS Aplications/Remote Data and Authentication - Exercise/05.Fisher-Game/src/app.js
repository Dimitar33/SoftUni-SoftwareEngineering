
let user = JSON.parse(sessionStorage.getItem('user'));

let catches = document.getElementById(`catches`);

let logoutBtn = document.getElementById(`logout`);
let registerBtn = document.getElementById(`register`);
let logInBtn = document.getElementById(`login`);
let addBtn = document.querySelector(`.add`);
let loadBtn = document.querySelector(`.load`);

logoutBtn.style.display = `none`;

catches.innerHTML = ``;

if (user) {

    document.querySelector(`span`).textContent = user.email;

    logoutBtn.style.display = `block`;
    registerBtn.style.display = `none`;
    logInBtn.style.display = `none`;
    addBtn.disabled = false;



    logoutBtn.addEventListener(`click`, async () => {

        let res = await fetch(`http://localhost:3030/users/logout`, {

            method: `get`,
            headers: { 'X-Authorization': user.token }
        })

        if (!res.ok) {
            error = await res.json();
            return alert(error.message);
        }

        sessionStorage.removeItem(`user`);

        window.location = `./index.html`
    })
}

loadBtn.addEventListener(`click`, async (ev) => {

    catches.innerHTML = ``;

    

    let res = await fetch(`http://localhost:3030/data/catches`);
    let data = await res.json();

    Object.values(data).forEach(el => {

        let isOwner = (user && el[`_ownerId`] == user.userId);

        let catchDiv = document.createElement(`div`);
        catchDiv.classList.add(`catch`);
        catchDiv.innerHTML =
            `<label>Angler</label>
        <input type="text" class="angler" value="${el[`angler`]}"${isOwner ? ``: `disabled`}>
        <label>Weight</label>
        <input type="text" class="weight" value="${el[`weight`]}"${isOwner ? ``: `disabled`}>
        <label>Species</label>
        <input type="text" class="species" value="${el[`species`]}"${isOwner ? ``: `disabled`}>
        <label>Location</label>
        <input type="text" class="location" value="${el[`location`]}"${isOwner ? ``: `disabled`}>
        <label>Bait</label>
        <input type="text" class="bait" value="${el[`bait`]}"${isOwner ? ``: `disabled`}>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${el[`captureTime`]}"${isOwner ? ``: `disabled`}>
        <button class="update" data-id="${el[`_id`]}"${isOwner ? ``: `disabled`}>Update</button>
        <button class="delete" data-id="${el[`_id`]}"${isOwner ? ``: `disabled`}>Delete</button>
    </div>`

        let updateBtn = catchDiv.querySelector(`.update`);
        let deleteBtn = catchDiv.querySelector(`.delete`);

        deleteBtn.addEventListener(`click`, async (ev) => {

            let id = ev.target.dataset.id;

            let res = await fetch(`http://localhost:3030/data/catches/${id}`, {
                method: `delete`,
                headers: { 'X-Authorization': user.token }
            })

            if (!res.ok) {
                let error = await res.json();
                return alert(error.message);
            }

            ev.target.parentNode.remove();
        })

        updateBtn.addEventListener(`click`, async (ev) => {

            const angler = ev.target.parentNode.children[1].value;
            const weight = ev.target.parentNode.children[3].value;
            const species = ev.target.parentNode.children[5].value;
            const location = ev.target.parentNode.children[7].value;
            const bait = ev.target.parentNode.children[9].value;
            const captureTime = ev.target.parentNode.children[11].value;

            let id = ev.target.dataset.id;
            let res = await fetch(`http://localhost:3030/data/catches/${id}`, {
                method: `put`,
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': user.token
                },
                body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
            });
            console.log(angler)
            loadBtn.click();
        })

        catches.appendChild(catchDiv);
    });
})

addBtn.addEventListener(`click`, async (ev) => {
    ev.preventDefault();

    const angler = document.querySelector(`[name="angler"]`).value;
    const weight = document.querySelector(`[name="weight"]`).value;
    const species = document.querySelector(`[name="species"]`).value;
    const location = document.querySelector(`[name="location"]`).value;
    const bait = document.querySelector(`[name="bait"]`).value;
    const captureTime = document.querySelector(`[name="captureTime"]`).value;

    if (!angler || !weight || !species || !location || !bait || !captureTime) {

        return alert(`Empty field`)
    }

    const res = await fetch(`http://localhost:3030/data/catches`, {
        method: `post`,
        headers: { 'Content-Type': 'application/json', 'X-Authorization': user.token },
        body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
    });

    if (!res.ok) {
        let error = await res.json();
        return alert(error.message);
    }

    document.querySelector(`[name="angler"]`).value = ``;
    document.querySelector(`[name="weight"]`).value = ``;
    document.querySelector(`[name="species"]`).value = ``;
    document.querySelector(`[name="location"]`).value = ``;
    document.querySelector(`[name="bait"]`).value = ``;
    document.querySelector(`[name="captureTime"]`).value = ``;

    loadBtn.click();
})
