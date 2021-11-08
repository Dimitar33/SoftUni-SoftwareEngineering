function attachEvents() {

    const personInput = document.getElementById(`person`);
    const phonenput = document.getElementById(`phone`);
    const phonebook = document.getElementById(`phonebook`);

    const loadBtn = document.getElementById(`btnLoad`);
    const createBtn = document.getElementById(`btnCreate`);

    const url = `http://localhost:3030/jsonstore/phonebook`;


    loadBtn.addEventListener(`click`, async load => {

        phonebook.replaceChildren();

        let res = await fetch(url);
        let data = await res.json();
        console.log(Object.values(data));

        Object.values(data).forEach(el => {

            let li = document.createElement(`li`);
            li.textContent = `${el[`person`]}: ${el[`phone`]}`

            let delBtn = document.createElement(`button`);
            delBtn.setAttribute(`id`, el[`_id`]);
            delBtn.textContent = `Delete`;

            li.appendChild(delBtn);
            phonebook.appendChild(li);

            delBtn.addEventListener(`click`, async (ev) =>{

                let targetUrl = `http://localhost:3030/jsonstore/phonebook/${ev.target.id}`;

                await fetch(targetUrl, {
                    method: `delete`
                })
                
                ev.target.parentNode.remove();
                console.log(ev.target.parentNode)
            })
        });
    })
    
    createBtn.addEventListener(`click`, async () => {

        if (!personInput.value || !phonenput.value) {
            
           return alert(`All fields must be filled`);
        }

        await fetch(url, {
            method: `post`,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person: personInput.value, phone: phonenput.value })
        })

        personInput.value = ``;
        phonenput.value = ``;

        loadBtn.click();
    })
}

attachEvents();