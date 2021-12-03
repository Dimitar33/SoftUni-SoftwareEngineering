import * as api from './api/data.js';
window.api = api;


import { page , render} from './util.js';
import { searchPage } from './views/byYear.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { myCarsPage } from './views/myCars.js';
import { updateNavBar } from './views/navBar.js';
import { registerPage } from './views/register.js';

const root = document.getElementById(`site-content`);

page(decorateContext);
page(`/`, homePage);
page(`/login`, loginPage);
page(`/register`, registerPage);
page(`/catalog`, catalogPage);
page(`/create`, createPage);
page(`/edit/:id`, editPage);
page(`/details/:id`, detailsPage);
page(`/myCars`, myCarsPage);
page(`/byYear`, searchPage);

page.start();
updateNavBar();

function decorateContext(ctx, next){

    ctx.render = (content) => render(content, root)

    next();
}