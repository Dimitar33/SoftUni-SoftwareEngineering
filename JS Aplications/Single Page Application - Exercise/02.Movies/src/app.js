

import { showDetails } from "./details.js";
import { showLogin } from "./login.js";
import { showRegister } from "./register.js";
import { showHome } from "./home.js";

const views = {

    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister
}

document.querySelector(`nav`).addEventListener(`click`, (ev) => {
    const view = views[ev.target.id]

    if (typeof view == `function`) {
        
        ev.preventDefault();
        view();
    }
});

showHome();

function updateNav(){

    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData != null) {
        
    }
}