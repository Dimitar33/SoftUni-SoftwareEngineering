import * as api from './api/data.js'
window.api = api;

import { page, render } from './util.js';

import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { gamesPage } from './views/games.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { updateNavBar } from './views/navigation.js';
import { registerPage } from './views/register.js';

const root = document.getElementById(`main-content`);

page(decorateContext);
page('/', homePage);
page(`/login`, loginPage);
page(`/register`, registerPage);
page(`/games`, gamesPage);
page(`/create`, createPage);
page(`/details/:id`, detailsPage);
page(`/edit/:id`, editPage);

page.start();
updateNavBar();

function decorateContext(ctx, next) {

    ctx.render = (content) => render(content, root);

    next();
}