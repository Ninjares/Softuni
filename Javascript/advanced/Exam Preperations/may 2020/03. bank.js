class Bank{
    constructor(bankName){
        this.bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer){
        if(this.allCustomers.find(x => x.personalId == customer.personalId) !== undefined
            || this.allCustomers.find(x => x.firstName == customer.firstName && x.lastName==customer.lastName) !== undefined)
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        else {
            customer.totalMoney = 0;
            customer.transactions = [];
            this.allCustomers.push(customer);
        }
        return customer;
    }
    depositMoney(personalId, ammount){
        if(this.allCustomers.find(x => x.personalId === personalId)!== undefined){
            const customer = this.allCustomers.find(x => x.personalId === personalId);
            customer.totalMoney += ammount;
            customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${ammount}$!`);
            return `${customer.totalMoney}$`;
        }
        else throw new Error('We have no customer with this ID!');
    }
    withdrawMoney(personalId, ammount){
        if(this.allCustomers.find(x => x.personalId === personalId)!== undefined){
            const customer = this.allCustomers.find(x => x.personalId === personalId);
            if(customer.totalMoney < ammount) throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
            customer.totalMoney -= ammount;
            customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${ammount}$!`);
            return `${customer.totalMoney}$`;
        }
        else throw new Error('We have no customer with this ID!');
    }
    customerInfo(personalId){
        if(this.allCustomers.find(x => x.personalId === personalId)!== undefined){
            const customer = this.allCustomers.find(x => x.personalId === personalId);
            let trans = customer.transactions.slice();
            let transactionHistory = [];
            while(trans.length>0){
                transactionHistory.push(`${trans.length}. ${trans.pop()}`);
            }
            //if(customer.transactions.length !=0)
            return [
                `Bank name: ${this._bankName}`,
                `Customer name: ${customer.firstName} ${customer.lastName}`,
                `Customer ID: ${customer.personalId}`,
                `Total Money: ${customer.totalMoney}$`,
                `Transactions:`,
                
            ].concat(transactionHistory.join('\n')).join('\n');
            // else return [
            //     `Bank name: ${this.bankName}`,
            //     `Customer name: ${customer.firstName} ${customer.lastName}`,
            //     `Customer ID: ${customer.personalId}`,
            //     `Total Money: 0$`,
            // ].join('\n');
            
        }
        else throw new Error('We have no customer with this ID!');
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

console.log(bank.depositMoney(6233267, 250));
console.log(bank.depositMoney(6233267, 125));
console.log(bank.depositMoney(4151596, 555));

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
console.log(bank.customerInfo(6233267));
