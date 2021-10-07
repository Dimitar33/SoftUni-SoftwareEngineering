function solution() {

    let word = ``;

    return {

        append(str) {

            word += str;
        },

        removeStart(str) {

            word = word.substring(str);
        },

        removeEnd(str) {

            word = word.slice(0, -str)
        },

        print() {

            console.log(word);
        }
    }
}



let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
