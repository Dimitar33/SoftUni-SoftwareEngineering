import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import * as api from './api/data.js';
window.api = api;

import { loginPage } from './views/login.js';
import { homePage } from './views/home.js';
import { registerPage } from './views/register.js';
import { userNav } from './views/navigation.js';
import { createPage } from './views/create.js';
import { editPage } from './views/edit.js';
import { detailsPage } from './views/details.js';
import { myBooksPage } from './views/myBooks.js';

const root = document.getElementById(`site-content`);

page(decorateContext);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/details/:id', detailsPage);
page(`/myBooks`, myBooksPage);

userNav();
page.start();

function decorateContext(ctx, next) {

    ctx.render = (content) => render(content, root);

    next();
}