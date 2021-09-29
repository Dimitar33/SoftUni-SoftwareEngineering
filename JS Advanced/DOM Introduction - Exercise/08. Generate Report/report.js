function generateReport() {
   
    let headers = Array.from(document.querySelectorAll(`th`)).map(x => x.children[0]);

    let rows = Array.from(document.querySelectorAll(`tbody tr`));

    let result = [];

    rows.forEach(el => {
        
        let currRow = Array.from(el.children).reduce((obj, prop, index) => {

            if (headers[index].checked) {
                
                let headerName = headers[index].name;
                obj[headerName] = prop.innerText;
            }

            return obj;
        }, {});

        result.push(currRow);
    });

    document.querySelector(`#output`).value = JSON.stringify(result);
}