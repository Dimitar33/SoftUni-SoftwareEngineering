function solve() {

    let task = document.getElementById(`task`);
    let description = document.getElementById(`description`);
    let date = document.getElementById(`date`);
    let open = document.querySelectorAll(`section`)[1].children[1];
    let inProgress = document.querySelectorAll(`section`)[2].children[1];
    let complete = document.querySelectorAll(`section`)[3].children[1];

    let addBtn = document.getElementById(`add`);

    addBtn.addEventListener(`click`, function (ev) {
        ev.preventDefault();

        if (task.value && description.value && date.value) {


            let article = document.createElement(`article`);

            let h3 = document.createElement(`h3`);
            h3.textContent = task.value;
            task.value = ``;

            let desc = document.createElement(`p`);
            desc.textContent = `Description: ${description.value}`;
            description.value = ``;

            let dueData = document.createElement(`p`);
            dueData.textContent = `Due Date: ${date.value}`;
            date.value = ``;

            let startBtn = document.createElement(`button`);
            startBtn.classList.add(`green`);
            startBtn.textContent = `Start`;

            let deleteBtn = document.createElement(`button`);
            deleteBtn.classList.add(`red`);
            deleteBtn.textContent = `Delete`;

            let divBtns = document.createElement(`div`);
            divBtns.classList.add(`flex`);

            divBtns.appendChild(startBtn);
            divBtns.appendChild(deleteBtn);

            article.appendChild(h3);
            article.appendChild(desc);
            article.appendChild(dueData);
            article.appendChild(divBtns);

            open.appendChild(article);

            deleteBtn.addEventListener(`click`, (ev) => {

                ev.target.parentNode.parentNode.remove();

                console.log(ev.target.parentNode.parentNode)
            })

            startBtn.addEventListener(`click`, function(ev){

                let finishBtn = document.createElement(`button`);
                finishBtn.classList.add(`orange`);
                finishBtn.textContent = `Finish`;

                let targetNode = ev.target.parentNode.parentNode;
                targetNode.children[3].children[0].remove();
                targetNode.children[3].appendChild(finishBtn);
                inProgress.appendChild(targetNode);


                finishBtn.addEventListener(`click`, (ev) => {

                    let finishTarget = ev.target.parentNode.parentNode;
                    finishTarget.children[3].remove();

                    complete.appendChild(finishTarget);

                })
            })
        }
    })

    console.log("//TODO")
}