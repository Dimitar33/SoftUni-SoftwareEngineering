
const uri = "https://localhost:44397/users";

function GetItems(){
    fetch(uri)
    .then(response => response.json())
    .then(data => console.log(JSON.stringify(data)))
    .catch(error => console.error('Unable to get items.', error));
}