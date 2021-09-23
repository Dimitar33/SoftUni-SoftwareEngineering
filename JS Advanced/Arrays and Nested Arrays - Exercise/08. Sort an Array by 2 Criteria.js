function main(arr){

    arr.sort((a, b) => a.localeCompare(b)).sort((a, b) => a.length - b.length);

    arr.forEach(element => {
        
        console.log(element);
    });
}

main(['test', 
'Deny', 
'omen', 
'default']
);