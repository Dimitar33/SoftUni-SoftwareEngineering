import { logout } from "../api/data.js";
import page from "../../node_modules/page/page.mjs";

document.getElementById(`logoutBtn`).addEventListener(`click`, async () => {

    const token = sessionStorage.getItem(`token`);
    if (token) {

        await logout();
        userNav();
        page.redirect('/');
    }
})


export function userNav() {

    const email = sessionStorage.getItem('email');

    if (email) {

        document.getElementById(`guest`).style.display = `none`;
        document.getElementById(`user`).style.display = `inline-block`;
        document.querySelector(`#user span`).textContent =`Welcome,` + ` ` + email;
    }
    else {

        document.getElementById(`guest`).style.display = `inline-block`;
        document.getElementById(`user`).style.display = `none`;
    }
}

