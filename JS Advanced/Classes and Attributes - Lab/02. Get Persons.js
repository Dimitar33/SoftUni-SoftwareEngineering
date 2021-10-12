function main() {

    let ppl = [];

    class Person {

        constructor(firstName, lastName, age, email) {

            this.firstName = firstName,
                this.lastName = lastName,
                this.age = age,
                this.email = email

        }

        toString() {

            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }

    }

    let person = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    let person1 = new Person('SoftUni');
    let person2 = new Person('Stephan', 'Johnson', 25);
    let person3 = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');

    ppl.push(person);
    ppl.push(person1);
    ppl.push(person2);
    ppl.push(person3);

    return ppl;
}

console.log(main())



