function solve() {

   let creator = document.getElementById(`creator`);
   let title = document.getElementById(`title`);
   let category = document.getElementById(`category`);
   let content = document.getElementById(`content`);

   let posts = document.querySelectorAll('section')[1];
   let archive = document.querySelector('ol');


   let createBtn = document.getElementsByClassName(`btn create`)[0];

   createBtn.addEventListener(`click`, function (ev) {
      ev.preventDefault();

      let article = document.createElement(`article`);

      let h1 = document.createElement(`h1`);
      h1.textContent = title.value;
      title.value = ``;

      let pCat = document.createElement(`p`);
      pCat.textContent = `Category: `;
      let strongCat = document.createElement(`strong`);
      strongCat.textContent = category.value;
      category.value = ``;
      pCat.appendChild(strongCat);

      let pCreator = document.createElement(`p`);
      pCreator.textContent = `Creator: `;
      let strongCreator = document.createElement(`strong`);
      strongCreator.textContent = creator.value;
      creator.value = ``;
      pCreator.appendChild(strongCreator);

      let pCont = document.createElement(`p`);
      pCont.textContent = content.value;
      content.value = ``;

      let delBtn = document.createElement(`button`);
      delBtn.className = `btn delete`;
      delBtn.textContent = `Delete`;
      delBtn.addEventListener(`click`, function (ev) {

         ev.target.parentNode.parentNode.remove();
      })

      let arcBtn = document.createElement(`button`);
      arcBtn.className = `btn archive`;
      arcBtn.textContent = `Archive`;
      arcBtn.addEventListener(`click`, function (ev) {

         let li = document.createElement(`li`);
         li.textContent = ev.target.parentNode.parentNode.children[0].textContent;

         archive.appendChild(li);
         ev.target.parentNode.parentNode.remove();

         let ol = document.querySelector(`ol`);
         Array.from(archive.children)
         .sort((a,b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => ol.appendChild(li));

      })

      let divBtns = document.createElement(`div`);
      divBtns.className = `buttons`;
      divBtns.appendChild(delBtn);
      divBtns.appendChild(arcBtn);

      article.appendChild(h1);
      article.appendChild(pCat);
      article.appendChild(pCreator);
      article.appendChild(pCont);
      article.appendChild(divBtns);

      posts.appendChild(article);
   })
}
