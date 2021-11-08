
document.getElementById(`logout`).style.display = `none`;

document.querySelector(`form`).addEventListener(`submit`, async (ev) => {
    ev.preventDefault();

    let url = `http://localhost:3030/users/login`;

    const form = new FormData(ev.target);

    const email = form.get(`email`);
    const password = form.get(`password`);

    let res = await fetch(url, {
        method: `post`,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    if (!res.ok) {
        let error = await res.json();
        return alert(error.message);
    }

    let data = await res.json();

    let user = {
        email: data.email,
        userId: data._id,
        token: data.accessToken
    }

    sessionStorage.setItem('user', JSON.stringify(user));

    window.location = `./index.html`;

})

