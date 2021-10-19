window.addEventListener('load', solution);

function solution() {

    const fullName = document.querySelector('#fname');
    const email = document.querySelector('#email');
    const phoneNumber = document.querySelector('#phone');
    const address = document.querySelector('#address');
    const postalCode = document.querySelector('#code');

    const submitBtn = document.querySelector('#submitBTN');
    //submitBtn.setAttribute('disabled');
    const continueBtn = document.querySelector('#continueBTN');
    const editBtn = document.querySelector('#editBTN');

    //console.log(editBtn);

    const infoPreview = document.querySelector('#infoPreview');
    const blockDiv = document.querySelector('#block');



    let liFullName;
    let liEmail;
    let liPhone;
    let liAddress;
    let liCode;

    submitBtn.addEventListener('click', (event) => {
        event.preventDefault();

        if (fullName.value != '' && email.value != '') {

            liFullName = document.createElement('li');
            liFullName.textContent = 'Full Name: ' + fullName.value;
            infoPreview.appendChild(liFullName);
            fullName.value = '';

            liEmail = document.createElement('li');
            liEmail.textContent = 'Email: ' + email.value;
            infoPreview.appendChild(liEmail);
            email.value = '';

            liPhone = document.createElement('li');
            liPhone.textContent = 'Phone Number: ' + phoneNumber.value;
            infoPreview.appendChild(liPhone);
            phoneNumber.value = '';

            liAddress = document.createElement('li');
            liAddress.textContent = 'Address: ' + address.value;
            infoPreview.appendChild(liAddress);
            address.value = '';

            liCode = document.createElement('li');
            liCode.textContent = 'Postal Code: ' + postalCode.value;
            infoPreview.appendChild(liCode);
            postalCode.value = '';

            editBtn.disabled = false;
            continueBtn.disabled = false;
            submitBtn.disabled = true;
        }
    });


    editBtn.addEventListener('click', (event) => {
        event.preventDefault(); //???

        fullName.value = (liFullName.textContent).slice(11);
        liFullName.remove();

        email.value = (liEmail.textContent).slice(6);
        liEmail.remove();

        phoneNumber.value = (liPhone.textContent).slice(14);
        liPhone.remove();

        address.value = (liAddress.textContent).slice(9);
        liAddress.remove();

        postalCode.value = (liCode.textContent).slice(13);
        liCode.remove();

        editBtn.disabled = true;
        continueBtn.disabled = true;
        submitBtn.disabled = false;

    });


    continueBtn.addEventListener('click', (event) => {
        event.preventDefault();

        blockDiv.innerHTML = '';

        let h3Element = document.createElement('h3');
        h3Element.textContent = 'Thank you for your reservation!';

        blockDiv.appendChild(h3Element);
    })



}

// function solution() {

  
//   let form = document.getElementById(`form`).children;
//   let infoPrv = document.getElementById(`infoPreview`);
//   let blok = document.getElementById(`block`);

//   let submitBtn = document.getElementById(`submitBTN`);
//   let editBtn = document.getElementById(`editBTN`);
//   let continueBtn = document.getElementById(`continueBTN`);


//   submitBtn.addEventListener(`click`, function (ev) {
//     ev.preventDefault();

//     if (form[0].children[1].value != `` || form[1].children[1].value != ``) {

//       for (let i = 0; i < 5; i++) {

//         let info = form[i].children[1];
//         let li = document.createElement(`li`);
//         li.textContent = form[i].children[0].innerHTML + ` ` + info.value;
//         info.value = ``;

//         infoPrv.appendChild(li);
//         console.log('TODO: Write the missing functionality!');
//       }

//       submitBtn.disabled = true;
//       editBtn.disabled = false;
//       continueBtn.disabled = false;
//     }
//   });

//   editBtn.addEventListener(`click`, function (ev) {
//     ev.preventDefault();

//     form[0].children[1].value = infoPrv.children[0].innerHTML.slice(11);
//     form[1].children[1].value = infoPrv.children[1].innerHTML.slice(6);
//     form[2].children[1].value = infoPrv.children[2].innerHTML.slice(14);
//     form[3].children[1].value = infoPrv.children[3].innerHTML.slice(9);
//     form[4].children[1].value = infoPrv.children[4].innerHTML.slice(13);

//     let count = 4;

//     while (count >= 0) {

//       infoPrv.children[count].remove();
//       count--;
//     }

//     submitBtn.disabled = false;
//     editBtn.disabled = true;
//     continueBtn.disabled = true;
//   });

//   continueBtn.addEventListener(`click`, function (ev) {
//     ev.preventDefault();

//     let h3 = document.createElement(`h3`);
//     h3.textContent = `Thank you for your reservation!`

//     blok.innerHTML = ``;
//     block.appendChild(h3);

//   });

// }
