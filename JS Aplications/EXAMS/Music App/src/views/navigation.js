import { logout } from '../api/api.js';
import { page } from '../lib.js';


export function updateNavBar() {

    if (sessionStorage.getItem(`token`)) {

        document.getElementById(`homePage`).children[2].style.display = `none`;
        document.getElementById(`homePage`).children[3].style.display = `none`;

        document.getElementById(`homePage`).children[4].style.display = `inline-block`;
        document.getElementById(`homePage`).children[5].style.display = `inline-block`;
    }
    else {
        document.getElementById(`homePage`).children[2].style.display = `inline-block`;
        document.getElementById(`homePage`).children[3].style.display = `inline-block`;

        document.getElementById(`homePage`).children[4].style.display = `none`;
        document.getElementById(`homePage`).children[5].style.display = `none`;
    }
}

document.getElementById(`logoutBtn`).addEventListener(`click`, async () => {

    if (sessionStorage.getItem(`token`)) {
        
        await logout();
        updateNavBar();
        page.redirect(`/`);
    }
})
