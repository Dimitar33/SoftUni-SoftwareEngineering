import { towns as townsData } from './towns.js';
import { html, render } from './node_modules/lit-html/lit-html.js';

const townsLi = (town) => html`<li>${town}</li>`;


const root = document.getElementById(`towns`);
console.log(townsData)
render(html`<ul>${townsData.map(townsLi)}</ul>`, root);

document.querySelector(`button`).addEventListener(`click`, (ev) => {
   ev.preventDefault();

   const searchTerm = document.getElementById(`searchText`).value;
   const result = document.getElementById(`result`);
   let matches = 0;

   Array.from(root.children[0].children).forEach(el => {

      if (searchTerm && el.textContent.toLowerCase().includes(searchTerm.toLowerCase())) {
         
         el.classList.add(`active`);
         matches++;
      }
      else{
         el.classList.remove(`active`);
      }
   });

   result.innerHTML = `${matches} matches found`;
});

function search() {



}
