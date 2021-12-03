import { logout } from "../api/api.js";
import { page } from "../util.js";

document.getElementById(`logoutBtn`).addEventListener(`click`, async () => {

    if (sessionStorage.getItem(`token`)) {

        await logout();
        updateNavBar();
        page.redirect('/');

    }
})

export function updateNavBar() {

    const isUser = sessionStorage.getItem(`token`);

    if (isUser) {

        document.getElementById(`user`).style.display = `inline-block`;
        document.getElementById(`guest`).style.display = `none`;
    }
    else {

        document.getElementById(`user`).style.display = `none`;
        document.getElementById(`guest`).style.display = `inline-block`;
    }
}