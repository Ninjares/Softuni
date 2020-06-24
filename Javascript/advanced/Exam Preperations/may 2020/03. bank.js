class Bank{
    constructor(bankName){
        this.bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer){
        if(this.allCustomers.find(x => x.personalId == customer.personalId) != undefined) throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        else this.allCustomers.push(customer);
        return customer;
    }
    depositMoney(personalId, ammount){
        if(this.allCustomers.map(x => x.personalId).includes(personalId)){
            const customer = this.allCustomers.find(x => x.personalId == personalId);
            if(customer.totalMoney === undefined) customer.totalMoney = 0;
            customer.totalMoney += ammount;
            if(customer.transactions === undefined) customer.transactions = [];
            customer.transactions.push(ammount);
            return `${customer.totalMoney}$`;
        }
        else throw new Error('We have no customer with this ID!');
    }
    withdrawMoney(personalId, ammount){
        if(this.allCustomers.map(x => x.personalId).includes(personalId)){
            const customer = this.allCustomers.find(x => x.personalId == personalId);
            if(customer.totalMoney === undefined) customer.totalMoney = 0;
            if(customer.totalMoney < ammount) throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
            customer.totalMoney -= ammount;
            if(customer.transactions === undefined) customer.transactions = [];
            customer.transactions.push(-ammount);
            return `${customer.totalMoney}$`;
        }
        else throw new Error('We have no customer with this ID!');
    }
    customerInfo(personalId){
        if(this.allCustomers.map(x => x.personalId).includes(personalId)){
            const customer = this.allCustomers.find(x => x.personalId == personalId);
            let transactionHistory = [];
            if(customer.transactions != undefined)
            while(customer.transactions.length>0){
                let last = customer.transactions.pop();
                last >=0 ? transactionHistory.push(`${customer.transactions.length+1}. ${customer.firstName} ${customer.lastName} made deposit of ${last}$!`)
                : transactionHistory.push(`${customer.transactions.length+1}. ${customer.firstName} ${customer.lastName} withdrew ${-last}$!`)
            }
            if(customer.transactions != undefined)
            return [
                `Bank name: ${this.bankName}`,
                `Customer name: ${customer.firstName} ${customer.lastName}`,
                `Customer ID: ${customer.personalId}`,
                `Total Money: ${customer.totalMoney}$`,
                `Transactions:`,
                transactionHistory.join('\n')
            ].join('\n');
            else return [
                `Bank name: ${this.bankName}`,
                `Customer name: ${customer.firstName} ${customer.lastName}`,
                `Customer ID: ${customer.personalId}`,
                `Total Money: 0$`,
            ].join('\n');
            
        }
        else throw new Error('We have no customer with this ID!');
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));
console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 1}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
