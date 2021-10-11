function validate() {

    const usernameRegex = /^[\w]{3,20}$/;
    const passRegex = /^[\w]{5,15}$/;
    const emailRegex = /^[^@.]+@[^@]*\.[^@]*$/;

    let userInfo = document.querySelectorAll(`#userInfo div`);

    let username = userInfo[0].children[1];
    let email = userInfo[1].children[1];
    let password = userInfo[2].children[1];
    let confirmPass = userInfo[3].children[1];
    let companyCheck = userInfo[4].children[1];

    document.getElementById(`companyNumber`).addEventListener(`change`, (el) => {


        if (el.target.value < 1000 || el.target.value >= 10000) {

            el.target.style.borderColor = `red`;
        }
        else {
            
            el.target.style.borderColor = ``;
        }

        console.log(el.target.value)


    })

    document.getElementById(`userInfo`).addEventListener(`change`, (el) => {

        if (el.target == username) {

            if (usernameRegex.test(el.target.value)) {

                el.target.style.borderColor = ``;
            }
            else {

                el.target.style.borderColor = `red`;
            }
        }

        if (el.target == email) {

            if (emailRegex.test(el.target.value)) {

                el.target.style.borderColor = ``;
            }
            else {

                el.target.style.borderColor = `red`;
            }
        }

        if (el.target == password) {

            if (passRegex.test(el.target.value)) {

                el.target.style.borderColor = ``;
            }
            else {

                el.target.style.borderColor = `red`;
            }
        }

        if (el.target == confirmPass) {

            if (el.target.value != document.getElementById(`password`).value) {

                el.target.style.borderColor = `red`;
            }
            else {

                el.target.style.borderColor = ``;
            }
        }

        if (el.target == companyCheck) {

            if (el.target.checked == true) {

                document.getElementById(`companyInfo`).style.display = `block`;
            }
            else {

                document.getElementById(`companyInfo`).style.display = `none`;
            }
        }


    })



}
