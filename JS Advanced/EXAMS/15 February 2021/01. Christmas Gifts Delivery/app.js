function solution() {

    let giftInput = document.querySelector('[placeholder="Gift name"]');
    let listOfGfts = document.querySelectorAll(`ul`)[0];
    let sendGfts = document.querySelectorAll(`ul`)[1];
    let discardedGfts = document.querySelectorAll(`ul`)[2];
    let addBtn = document.querySelector(`button`);

    addBtn.addEventListener(`click`, function (ev) {
        ev.preventDefault();

        let li = document.createElement(`li`);
        li.classList.add(`gift`);
        li.textContent = giftInput.value;
        giftInput.value = ``;

        let sendBtn = document.createElement(`button`);
        sendBtn.id = `sendButton`;
        sendBtn.textContent = `Send`;
        li.appendChild(sendBtn);

        let discardBtn = document.createElement(`button`);
        discardBtn.id = `discardButton`;
        discardBtn.textContent = `Discard`;
        li.appendChild(discardBtn);

        listOfGfts.appendChild(li);

        Array.from(listOfGfts.children)
        .sort((a,b) => a.textContent.localeCompare(b.textContent))
        .forEach(li => listOfGfts.appendChild(li));

        sendBtn.addEventListener(`click`, function (ev) {

            let li = ev.target.parentNode;
            li.removeChild(li.lastChild);
            li.removeChild(li.lastChild);
           
            sendGfts.appendChild(li);
        });

        discardBtn.addEventListener(`click`, function (ev) {
           
            let li = ev.target.parentNode;
            li.removeChild(li.lastChild);
            li.removeChild(li.lastChild);
           
            discardedGfts.appendChild(li);
        });

    })

}