import { register } from "../api/api.js";
import { html } from "../util.js";
import { updateNavBar } from "./navBar.js";

const registerTemplate = (onSubmit) =>html`
        <section id="register">
            <div class="container">
                <form @submit=${onSubmit} id="register-form">
                    <h1>Register</h1>
                    <p>Please fill in this form to create an account.</p>
                    <hr>

                    <p>Username</p>
                    <input type="text" placeholder="Enter Username" name="username" required>

                    <p>Password</p>
                    <input type="password" placeholder="Enter Password" name="password" required>

                    <p>Repeat Password</p>
                    <input type="password" placeholder="Repeat Password" name="repeatPass" required>
                    <hr>

                    <input type="submit" class="registerbtn" value="Register">
                </form>
                <div class="signin">
                    <p>Already have an account?
                        <a href="#">Sign in</a>.
                    </p>
                </div>
            </div>
        </section>`;

export function registerPage(ctx){

    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(ev){
        ev.preventDefault();

        const formData = new FormData(ev.target);

        const username = formData.get(`username`);
        const password = formData.get(`password`);
        const rePass = formData.get(`repeatPass`);

        if (!username || !password) {
            
            return alert(`All fields are required`);
        }

        if (password != rePass) {
            
            return alert(`Passwords dont match`);
        }

        await register(username, password);
        updateNavBar();
        ctx.page.redirect(`/catalog`);
    }
}