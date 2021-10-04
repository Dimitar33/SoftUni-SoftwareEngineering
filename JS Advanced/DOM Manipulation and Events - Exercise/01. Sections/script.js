function create(words) {

   let content = document.getElementById(`content`);

   words.forEach(el => {

      let p = document.createElement(`p`);
      p.textContent = el;
      p.style.display = `none`;
      let div = document.createElement(`div`);
      div.appendChild(p);
      content.appendChild(div);

   });

   content.addEventListener(`click`, el => {

      if (el.target.tagName == `DIV` && el.target != content) {

         el.target.children[0].style.display = `block`;
      }

   });


}