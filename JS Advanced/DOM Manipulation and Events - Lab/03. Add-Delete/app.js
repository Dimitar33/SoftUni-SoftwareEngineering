function addItem() {

    let newItem = document.getElementById(`newItemText`).value;

    if (!newItem) {

        return;
    }
  
    
    let li = document.createElement(`li`);

    li.appendChild(document.createTextNode(newItem));
    
    let del = document.createElement(`a`);
    del.href = `#`;
    del.textContent = `[DELETE]`;

    del.addEventListener(`click`, deleteItem)

    function deleteItem(){
        
        li.remove();
    }

    li.appendChild(del);

    document.getElementById(`items`).appendChild(li);

    document.getElementById(`newItemText`).value = ``;
}