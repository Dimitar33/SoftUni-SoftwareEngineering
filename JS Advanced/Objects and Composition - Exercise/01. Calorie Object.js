function main(arr){

    let food = {};

    for (let i = 0; i < arr.length -1; i+=2) {
       
        const name = arr[i];
        const calories = Number(arr[i + 1]);
        
        food[name] = calories;

    }

    console.log(food)
}

main(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);