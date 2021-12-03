import { logout } from "../api/api.js";
import { page} from "../util.js";

export function updateNavBar() {

    const username = sessionStorage.getItem(`username`);

    if (username) {

        document.getElementById(`profile`).style.display = `inline-block`;
        document.getElementById(`guest`).style.display = `none`;
        document.querySelector(`#profile a`).textContent = username;
    }
    else {

        document.getElementById(`profile`).style.display = `none`;
        document.getElementById(`guest`).style.display = `inline-block`;
    }
}

document.getElementById(`logoutBtn`).addEventListener(`click`, async () => {

    const token = sessionStorage.getItem(`token`);

    if (token) {

        await logout();
        updateNavBar();
        page.redirect(`/`);
    }
})