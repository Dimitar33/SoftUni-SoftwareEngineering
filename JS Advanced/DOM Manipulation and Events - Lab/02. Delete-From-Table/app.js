function deleteByEmail() {
    
    let input = document.getElementsByName(`email`)[0].value;
    let emails = document.querySelectorAll(`#customers tr td:nth-child(2)`)

    emails.forEach(td => {
        
        if (td.textContent == input) {
            
            client = td.parentNode;
            client.parentNode.removeChild(client);
            document.getElementById(`result`).textContent = `Deleted`
            return;
        }
        
        document.getElementById(`result`).textContent = `Not found.`
    });
    
}