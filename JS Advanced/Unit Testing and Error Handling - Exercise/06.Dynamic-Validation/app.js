function validate() {
    
    let email = document.getElementById(`email`);
    let validate = /^[a-z]+@[a-z]+\.[a-z]+/;

    email.addEventListener(`change`, () => {

        if (!validate.test(email.value)) {
            
            email.className = `error`;
        }
        else{
            email.className = ``;
        }

    })
}