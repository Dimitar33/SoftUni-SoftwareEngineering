class Company {

    departments = {};

    addEmployee(name, salary, position, department) {

        if ([name, salary, position, department].some(x => !x || x == ``)) {

            throw new Error(`Invalid input!`)
        }
        if (salary < 0) {

            throw new Error(`Invalid input!`)
        }

        let emplyee = {

            name,
            salary,
            position
        }

        if (!this.departments[department]) {

            this.departments[department] = {emplyees: [], Salary: 0};
        }
        this.departments[department].emplyees.push(emplyee);
        this.departments[department].Salary += salary;

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    bestDepartment() {

        let bestSal = 0;
        let bestCompany = ``;

        for (const i in this.departments) {

            let avgSalary = this.departments[i].Salary / this.departments[i].emplyees.length;
            
            if (bestSal < avgSalary) {
                
                bestSal = avgSalary
                bestCompany = i;
            }

        }

       let sorted = this.departments[bestCompany].emplyees
        .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
             
        
        return `Best Department is: ${bestCompany}\nAverage salary: ${bestSal.toFixed(2)}\n${sorted.map(x => `${x.name} ${x.salary} ${x.position}`).join(`\n`)}`
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
