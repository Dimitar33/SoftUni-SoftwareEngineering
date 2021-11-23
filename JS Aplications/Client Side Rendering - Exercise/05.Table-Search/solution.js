import { html, render } from './node_modules/lit-html/lit-html.js';

solve();

function solve() {

   const url = `http://localhost:3030/jsonstore/advanced/table`;
   const studentsList = document.querySelector(`tbody`);
   const searchTerm = document.getElementById(`searchField`);

   const studentCard = (student) => html`
           <tr>
                <td>${student.firstName} ${student.lastName}</td>
                <td>${student.email}</td>
                <td>${student.course}</td>
            </tr>
   `;

   fetch(url)
      .then(x => x.json())
      .then(x => {

         let students = Object.values(x);

         render(html`${students.map(studentCard)}`, studentsList);
      });

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
     
      Array.from(studentsList.children).forEach(c => {

         c.classList.remove(`select`);
      });

      Array.from(studentsList.children).forEach(el => {
        
         Array.from(el.children).forEach(st => {

            if (searchTerm.value && st.textContent.toLowerCase().includes(searchTerm.value.toLowerCase())) {

               el.classList.add(`select`);
            }
         });
      });
      searchTerm.value = ``;
   }
}