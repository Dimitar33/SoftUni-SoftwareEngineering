import * as api from './api/data.js';
import { page, render } from './lib.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
window.api = api;

const root = document.getElementById(`main-content`);


import { HomePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { updateNavBar } from './views/navigation.js';
import { registerPage } from './views/register.js';
import { searchPage } from './views/search.js';

page(decorateContext);
page(`/`, HomePage);
page(`/catalog`, catalogPage);
page(`/login`, loginPage);
page(`/register`, registerPage);
page(`/create`, createPage);
page(`/details/:id`, detailsPage);
page(`/edit/:id`, editPage);
page(`/search`, searchPage);

page.start();
updateNavBar();

function decorateContext(ctx, next){

    ctx.render = (content) => render(content, root);

    next();
}