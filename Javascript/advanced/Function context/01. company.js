class Company{
    constructor(){
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if(!this._checkInput(username, salary, position, department)) throw new Error("Invalid input!");
        if(salary < 0) throw new Error("Invalid input!");

        let current = this.departments.find(d => d.name === department);
        if(current === undefined){
            current = {
                name: department,
                employees: []
            }
            this.departments.push(current);
        }
        current.employees.push({username,salary,position});
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }
    _checkInput(inputs){
        let allgood = true;
        for(let input of inputs){
            if(input === "" || input === null || input === undefined) {allgood = false; break;}
        }
        return allgood;
    }
    bestDepartment(){
        let deps = this.departments.map(d => {
            const dep = {
                name: d.name,
                employees: d.employees.slice(),
                avarageSalary: d.employees.reduce((p,c,i,a) => p + c.salary, 0) / d.employees.length
            }
            return dep;
        })
        if(deps[0]!== undefined){
            deps.sort((a,b) => { return (a.avarageSalary == b.avarageSalary) ? 0 : (a.avarageSalary > b.avarageSalary) ? -1 : 1});
            let result = [`Best Department is: ${deps[0].name}`, `Average salary: ${deps[0].avarageSalary.toFixed(2)}`];
            for(let employee of deps[0].employees.sort((a,b) => b.salary - a.salary || a.username.localeCompare(b.username))){
                result.push(`${employee.username} ${employee.salary} ${employee.position}`);
            }
            return result.join('\n');
        }
    }
}


let c = new Company();
console.log(c.addEmployee('Stanimir', 2000, 'engineer', 'Construction'));
c.addEmployee('Pesho', 1500, 'electrical engineer', 'Construction');
c.addEmployee('Slavi', 500, 'dyer', 'Construction');
c.addEmployee('Stan', 2000, 'architect', 'Construction');
c.addEmployee('Stanimir', 1200, 'digital marketing manager', 'Marketing');
c.addEmployee('Pesho', 1000, 'graphical designer', 'Marketing');
c.addEmployee('Gosho', 1350, 'HR', 'Human resources');
console.log(c.bestDepartment());