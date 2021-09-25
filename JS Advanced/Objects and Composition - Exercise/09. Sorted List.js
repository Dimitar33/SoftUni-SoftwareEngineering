function createSortedList() {

    
    let myList = {

        list: [],
        size: 0,

        add: function (arg) {

            this.list.push(arg);
            this.list.sort((a, b) => a - b)
            this.size++;
        },

        remove: function (index) {

            if (index >= 0 && index < this.size) {

                this.list.splice(index, 1);
                this.size--;
            }

        },

        get: function (index) {

            if (index >= 0 && index < this.size) {

                return this.list[index];
            }
        }
    }

    return myList;
   
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
