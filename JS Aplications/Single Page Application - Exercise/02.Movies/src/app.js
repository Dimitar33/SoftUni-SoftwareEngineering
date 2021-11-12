

import { showDetails } from "./details.js";
import { showLogin } from "./login.js";
import { showRegister } from "./register.js";
import { showHome } from "./home.js";

const views = {

    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister
}
const nav = document.querySelector(`nav`);

nav.addEventListener(`click`, (ev) => {
    const view = views[ev.target.id]

    if (typeof view == `function`) {

        ev.preventDefault();
        view();
    }
});
updateNav();
showHome();

export function updateNav() {

    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData != null) {
        document.getElementById(`welcome`).textContent = `${userData.email}`;
        [...nav.querySelectorAll(`.user`)].forEach(e => e.style.display = `block`);
        [...nav.querySelectorAll(`.guest`)].forEach(e => e.style.display = `none`);
    }
    else{
        [...nav.querySelectorAll(`.user`)].forEach(e => e.style.display = `none`);
        [...nav.querySelectorAll(`.guest`)].forEach(e => e.style.display = `block`);
    }
}