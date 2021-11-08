
document.getElementById(`logout`).style.display = `none`;

document.querySelector(`form`).addEventListener(`submit`, async (ev) => {
    ev.preventDefault();

    let url = `http://localhost:3030/users/register`;

    const dataForm = new FormData(ev.target);

    const email = dataForm.get('email');
    const password = dataForm.get('password');
    const rePass = dataForm.get('rePass');

    if (password != rePass) {

        return alert(`Passwords didnt match`);
    }

    let res = await fetch(url, {
        method: `post`,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password})
    })

    if (res.ok != true) {

        let error = await res.json();
        return alert(error.message)
    }


    let data = await res.json();

    let user = {
        email: data.email,
        userId: data._id,
        token: data.accessToken
    }

    console.log(user)
    sessionStorage.setItem('user', JSON.stringify(user));
    //sessionStorage.setItem(`userId`, data._id);

    window.location = './index.html';

});



