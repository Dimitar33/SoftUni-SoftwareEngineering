function main(cardValue, suit) {


    const cardValues = [2, 3, 4, 5, 6, 7, 8, 9, 10, "J", "Q", "K", "A"]
    const suits = {

        "S": "\u2660",
        "H:": "\u2665",
        "D": "\u2666",
        "C": "\u2663"
    }

    if (!cardValues.includes(cardValue)) {
        
        throw new Error (`Error`);
    }

    if (!Object.keys(suits).includes(suit)) {
        
        throw new Error (`Error`);
    }

    return cardValue + suits[suit];
}

console.log(main("A", "C"));