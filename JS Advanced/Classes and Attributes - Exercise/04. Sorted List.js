class List {

    constructor() {

        this.size = 0;
        this.list = [];
    }


    add(el) {

        this.list.push(el);
        this.size++;
        this.list.sort((a, b) => a - b);

        return this;
    }

    remove(index) {

        if (index >= 0 && index < this.list.length) {

            this.list.splice(index, 1)
            this.size--;
            this.list.sort((a, b) => a - b);

            return this;
        }
    }

    get(index) {

        if (index >= 0 && index < this.list.length) {

            return this.list[index];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
