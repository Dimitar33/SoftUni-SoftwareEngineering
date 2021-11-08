async function attachEvents() {

    let url = `http://localhost:3030/jsonstore/messenger`;

    const authorInput = document.querySelector(`[name="author"]`);
    const contetentInput = document.querySelector(`[name="content"]`);
    const messages = document.getElementById(`messages`);
    const sendBtn = document.getElementById(`submit`);
    const refreshBtn = document.getElementById(`refresh`);

    sendBtn.addEventListener(`click`, async () => {

        if (!authorInput.value || !contetentInput.value) {

            return alert(`Author and input fields must not be empty`);

        }

        await fetch(url, {
            method: `post`,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ author: authorInput.value, content: contetentInput.value })
        });

        authorInput.value = ``;
        contetentInput.value = ``;
    })

    refreshBtn.addEventListener(`click`, async () => {

        const data = await fetch(url);
        const res = await data.json();

        messages.value = Object.values(res).map(x => `${x.author}: ${x.content}`).join(`\n`);

    })

}

attachEvents();