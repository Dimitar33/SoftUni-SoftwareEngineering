
import { showView } from './dom.js';
import { showHome } from './home.js';

let section = document.getElementById(`form-login`);
const form = document.querySelector(`form`);
form.addEventListener(`submit`, onLogin)
section.remove();

export function showLogin() {

    showView(section);
}

async function onLogin(ev) {
    ev.preventDefault();

    const formData = new formData(form);

    const email = formData.get(`email`).trim();
    const pass = formData.get(`password`).trim();

    try {
        
        const res = await fetch(`http://localhost:3030/users/login`, {
            method: `post`,
            headers: { 'Content-Tye': 'application/json'},
            body: JSON.stringify({email, pass})
        });

        if (!res.ok) {
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
        showHome();
    } catch (er) {
        
        alert(er.message)
    }

}