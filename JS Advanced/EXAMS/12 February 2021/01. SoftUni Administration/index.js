function solve() {

    // SORT NOT DONE !!


    let lectureInput = document.getElementsByName(`lecture-name`)[0];
    let dateInput = document.getElementsByName(`lecture-date`)[0];
    let moduleInput = document.getElementsByName(`lecture-module`)[0];
    let modules = document.getElementsByClassName(`modules`)[0];
    let addBtn = document.querySelector(`button`);

    let modulesArr = [];

    addBtn.addEventListener(`click`, (ev) => {
        ev.preventDefault();

        if (!lectureInput.value || !dateInput.value || moduleInput.value == `Select module`) {
            
            return;
        }

        let currModule = `${moduleInput.value.toUpperCase()}-MODULE`;

        if (!modulesArr.includes(currModule)) {

            div = document.createElement(`div`);
            div.classList.add(`module`);

            const h3 = document.createElement(`h3`);
            h3.textContent = currModule;

            let ul = document.createElement(`ul`);

            div.appendChild(h3);
            div.appendChild(ul);

            modules.appendChild(div);

            modulesArr.push(currModule);
        }

        let allModules = document.querySelectorAll(`h3`);

        for (let i = 0; i < allModules.length; i++) {

            if (allModules[i].textContent === currModule) {

                ul = allModules[i].parentNode.children[1];
            }
        }

        const h4 = document.createElement(`h4`);
        let myDate = new Date(dateInput.value);
        let properDateFormat = `${myDate.getFullYear()}/${myDate.getMonth() + 1}/${myDate.getDate()} - ${myDate.getHours()}:${myDate.getMinutes()}`;
        h4.textContent = `${lectureInput.value} - ${properDateFormat}`;

        const delBtn = document.createElement(`button`);
        delBtn.classList.add(`red`);
        delBtn.textContent = `Del`;

        const li = document.createElement(`li`);
        li.classList.add(`flex`);
        li.appendChild(h4);
        li.appendChild(delBtn);

        ul.appendChild(li);

        Array.from(ul.children)
        .sort((a,b) => {

            let index = a.children[0].textContent.indexOf(`-`) + 2;
           return a.children[0].textContent.slice(index).localeCompare(b.children[0].textContent.slice(index))
        })
        .forEach(x => ul.appendChild(x));

        delBtn.addEventListener(`click`, (ev) => {

            if (ev.target.parentNode.parentNode.children.length == 1) {

                ev.target.parentNode.parentNode.parentNode.remove();

                modulesArr = modulesArr.filter(x => x != ev.target.parentNode.parentNode.parentNode.children[0].textContent);
            }
            else {

                ev.target.parentNode.remove();
            }
        })

    })
};