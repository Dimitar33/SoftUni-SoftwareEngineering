function main() {

    class Person {

        constructor(name, email) {

            this.name = name;
            this.email = email;

        }

        toString(){

           let result = Object.keys(this).reduce((inf, key) => {

                inf.push(`${key}: ${this[key]}`)
                return inf;
            }, []).join(`, `);

            return `${this.constructor.name} (${result})`
        }
    }

    class Teacher extends Person {

        constructor(name, email, subject){

            super(name,email);
            this.subject = subject;
        }
    }

    class Student extends Person{

        constructor(name, email, course){

            super(name, email);
            this.course = course;
        }
    }

    return {

        Person,
        Teacher,
        Student
    }

}

let pers = main()
stud = new pers.Student(`Pesho`, `Peshev`, `math`)
console.log(stud.toString())