function main(text){

    let result = text.match(/\w+/g);

    console.log(result.join(`, `).toUpperCase());
}

main('Hi, how are you?');