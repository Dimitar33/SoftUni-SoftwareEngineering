function extract(content) {

    const text = document.getElementById(content).textContent;
    const regex = RegExp(/\((.+?)\)/g);
    let match = regex.exec(text);
    let result = '';

    while (match != null) {
        
        result += match + `; `;
        
        match = regex.exec(text);
    }

    return result;
}