function solve() {

  let createBtn = document.getElementById(`exercise`).children[2];
  let buyBtn = document.getElementById(`exercise`).children[5];

  createBtn.addEventListener(`click`, create);
  buyBtn.addEventListener(`click`, buy);

  function create() {

    let input = document.getElementById(`exercise`).children[1].value;
    newFurniture = JSON.parse(input);
    let table = document.querySelector(`.table tbody`);

    for (const furn of newFurniture) {

      let tr = document.createElement(`tr`);
      table.appendChild(tr);

      let img = document.createElement(`td`);
      img.innerHTML = '<img src="' + furn.img + '"/>';
      tr.appendChild(img);

      let name = document.createElement(`td`);
      name.textContent = `${furn.name}`;
      tr.appendChild(name);

      let price = document.createElement(`td`);
      price.textContent = `${furn.price}`;
      tr.appendChild(price);

      let decFactor = document.createElement(`td`);
      decFactor.textContent = `${furn.decFactor}`;
      tr.appendChild(decFactor);

      let mark = document.createElement(`td`);
      mark.innerHTML = '<input type="checkbox" />';
      tr.appendChild(mark);
    }
  }

  function buy() {

    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]'));
    let names = [];
    let totalPrice = 0;
    let avgDecFactor = 0;

    for (const box of checkboxes) {

      let parent = box.parentNode.parentNode.getElementsByTagName('td');

      if (box.checked === true) {

        let name = parent[1].textContent;
        let price = Number(parent[2].textContent);
        let decFactor = Number(parent[3].textContent);

        names.push(name);
        totalPrice += price;
        avgDecFactor += decFactor;

      }
    }

    let result = `Bought furniture: ${names.join(', ')}\n`;

    result += `Total price: ${totalPrice.toFixed(2)}\n`;

    avgDecFactor /= names.length;

    result += `Average decoration factor: ${avgDecFactor}`;

    let ouput = document.getElementsByTagName('textarea')[1];

    ouput.textContent = result;


  }
}