async function submit() {

    let reults = document.getElementById(`results`).children[1];
    let submBtn = document.getElementById(`submit`);

    const fNameInput = document.querySelector(`.inputs`).children[0];
    const lNameInput = document.querySelector(`.inputs`).children[1];
    const FN_Input = document.querySelector(`.inputs`).children[2];
    const gradeInput = document.querySelector(`.inputs`).children[3];

    const url = `http://localhost:3030/jsonstore/collections/students`;

    let res = await fetch(url);
    let data = await res.json();

    submBtn.addEventListener(`click`, async () => {

        if (!fNameInput.value || !lNameInput.value ||
            !FN_Input.value || !gradeInput.value) {

            return alert(`All fields are required`);
        }

        if (isNaN(FN_Input.value) || isNaN(gradeInput.value)) {

           return alert(`Faculty number and grade must be numbers`);
        }

        fetch(url, {
            method: `post`,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                firstName: fNameInput.value,
                lastName: lNameInput.value,
                facultyNumber: FN_Input.value,
                grade: gradeInput.value
            })
        })
    })

    Object.values(data).forEach(el => {

        let tr = document.createElement(`tr`);

        let firstName = document.createElement(`th`);
        firstName.textContent = el[`firstName`];

        let lastName = document.createElement(`th`);
        lastName.textContent = el[`lastName`];

        let facNumber = document.createElement(`th`);
        facNumber.textContent = el[`facultyNumber`];

        let grade = document.createElement(`th`);
        grade.textContent = Number(el[`grade`]).toFixed(2);

        tr.appendChild(firstName);
        tr.appendChild(lastName);
        tr.appendChild(facNumber);
        tr.appendChild(grade);

        reults.appendChild(tr);

        console.log(el);
    });
}

submit();