
import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/data.js";
import { userNav } from "./navigation.js";

const loginTemplate = (onSubmit) => html`
        <section id="login-page" class="login">
            <form @submit=${onSubmit} id="login-form" action="" method="">
                <fieldset>
                    <legend>Login Form</legend>
                    <p class="field">
                        <label for="email">Email</label>
                        <span class="input">
                            <input type="text" name="email" id="email" placeholder="Email">
                        </span>
                    </p>
                    <p class="field">
                        <label for="password">Password</label>
                        <span class="input">
                            <input type="password" name="password" id="password" placeholder="Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Login">
                </fieldset>
            </form>
        </section>`;

export function loginPage(ctx) {

    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
        
        console.log(ev.target)
        const formData = new FormData(ev.target);

        const email = formData.get('email')
        const password = formData.get('password')

        if (!email || !password) {

            return alert(`All fields are required`);
        }

        await login(email, password);
        userNav();
        ctx.page.redirect('/');

    }
}
