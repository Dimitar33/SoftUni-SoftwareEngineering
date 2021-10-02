function addItem() {

    let newItem = document.getElementById(`newItemText`).value;

    // document.getElementById(`items`).innerHTML += `<li>${newItem}</li>`; ==> another solution

    let li = document.createElement(`li`);

    li.appendChild(document.createTextNode(newItem))
  
    document.getElementById(`items`).appendChild(li);

    document.getElementById(`newItemText`).value = ``;
}