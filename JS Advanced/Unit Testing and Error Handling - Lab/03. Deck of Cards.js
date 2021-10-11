function main(arr){

    let deck = [];

    for (const i of arr) {
        
        let cardValue = i.slice(0, -1);
        let suit = i.charAt(i.length - 1);

        deck.push(create(cardValue, suit));
    }

    function create(cardValue, suit) {


        const cardValues = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"]
        const suits = {
    
            "S": "\u2660",
            "H": "\u2665",
            "D": "\u2666",
            "C": "\u2663"
        }
    
        if (!cardValues.includes(cardValue)) {
            
           return  `Invalid card: ${cardValue + suit}`;
        }
    
        if (!Object.keys(suits).includes(suit)) {
            
            return`Invalid card: ${cardValue + suit}`;
        }
    
        return cardValue + suits[suit];
    }

    console.log(deck.join(` `));
}

main(['AS', '10D', 'KH', '2C']);
main(['5S', '3D', 'QD', '1C']);