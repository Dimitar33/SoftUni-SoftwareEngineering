
import { updateNav } from './app.js';
import { showView } from './dom.js';
import { showHome } from './home.js';

let section = document.getElementById(`form-login`);
const form = document.getElementById(`loginForm`);
form.addEventListener(`submit`, onLogin)
section.remove();

export function showLogin() {

    showView(section);
}

async function onLogin(ev) {
    ev.preventDefault();

    const formData = new FormData(form);

    const email = formData.get(`email`);
    const password = formData.get(`password`);

    try {
        
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        });

        if (res.ok == false) {
            const error = await res.json();
            throw new Error(error.message)
        }

        const data = await res.json();

        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }))

        form.reset();
        updateNav();
        showHome();
    } catch (er) {
        
        alert(er.message)
    }

}