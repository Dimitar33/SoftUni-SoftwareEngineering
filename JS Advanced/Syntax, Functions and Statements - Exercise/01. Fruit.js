function main(fruit, grams , price){

    let weight = grams / 1000;
    let money = weight * price;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

main('apple', 1563, 2.35);