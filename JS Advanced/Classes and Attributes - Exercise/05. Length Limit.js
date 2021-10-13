class Stringer {

    constructor(text, lenght) {

        this.innerString = text;
        this.innerLength = lenght;
    }

    increase(length){
 
        this.innerLength += length;
    }

    decrease(length){

        this.innerLength -= length;
        this.innerLength < 0 ? this.innerLength = 0 : this.innerLength;
    }

    toString(){

        if ( this.innerString.length > this.innerLength) {
            
            return this.innerString.substr(0, this.innerLength) + `...`
        }
        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
