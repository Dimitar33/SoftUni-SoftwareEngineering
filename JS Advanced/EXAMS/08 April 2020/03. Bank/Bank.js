class Bank {

    constructor(bankName) {
        this._bankName = bankName; // private !!!
        this.allCustomers = [];
    }

    newCustomer(customer) {

        let person = this.allCustomers.find(x => x.personalId == customer.personalId);
        if (person) {

            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }
        customer.transactions = [];
        customer.totalMoney = 0;
        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {

        let person = this.allCustomers.find(x => x.personalId == personalId);

        if (!person) {

            throw new Error(`We have no customer with this ID!`);
        }

        person.totalMoney += Number(amount);
        person.transactions.unshift(`${person.transactions.length + 1}. ${person.firstName} ${person.lastName} made deposit of ${amount}$!`);

        return `${person.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {

        let person = this.allCustomers.find(x => x.personalId == personalId);

        if (!person) {

            throw new Error(`We have no customer with this ID!`)
        }

        if (person.totalMoney < amount) {

            throw new Error(`${person.firstName} ${person.lastName} does not have enough money to withdraw that amount!`)
        }

        person.totalMoney -= amount;
        person.transactions.unshift(`${person.transactions.length + 1}. ${person.firstName} ${person.lastName} withdrew ${amount}$!`)

        return `${person.totalMoney}$`;
    }

    customerInfo(personalId) {

        let person = this.allCustomers.find(x => x.personalId == personalId);
        if (!person) {

            throw new Error(`We have no customer with this ID!`)
        }

        let result = `Bank name: ${this._bankName}\nCustomer name: ${person.firstName} ${person.lastName}\nCustomer ID: ${person.personalId}\nTotal Money: ${person.totalMoney}$\nTransactions:\n${person.transactions.join(`\n`).trim()}`;

        return result.trim();
    }
}

let bank = new Bank(`SoftUni Bank`);

console.log(bank.newCustomer({ firstName: `Svetlin`, lastName: `Nakov`, personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: `Mihaela`, lastName: `Mileva`, personalId: 4151596 }));

bank.depositMoney(6233267, 0);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
