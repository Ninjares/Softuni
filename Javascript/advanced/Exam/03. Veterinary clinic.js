class VeterinaryClinic{
    constructor(clinicName, capacity){
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }
    newCustomer(ownerName, petName, kind, procedures){
        if(this.currentWorkload == this.capacity) throw new Error('Sorry, we are not able to accept more patients!');
        let kindlow = kind.toLocaleLowerCase();
        if(this.clients.find(x => x.ownerName === ownerName) === undefined){
            let client =  {
                ownerName,
                pets: [{petName, kind: kindlow, procedures}]
            }
            this.clients.push(client);
            this.currentWorkload++;
            return `Welcome ${petName}!`
        }
        else if(this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName) === undefined){
            this.clients.find(x => x.ownerName === ownerName).pets.push({petName, kind: kindlow, procedures});
            this.currentWorkload++;
            return `Welcome ${petName}!`
        }
        else{
            if(this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures.length != 0) 
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures.join(', ')}.`); //TODO
            this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures = procedures;
            this.currentWorkload++;
            return `Welcome ${petName}!`;
        }
    }
    onLeaving (ownerName, petName){
        if(this.clients.find(x => x.ownerName === ownerName) === undefined) throw new Error("Sorry, there is no such client!");
        if(this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName) === undefined
            ||this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures.length === 0) throw new Error(`Sorry, there are no procedures for ${petName}!`);
        else{
            this.totalProfit += 500 * this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures.length;
            this.clients.find(x => x.ownerName === ownerName).pets.find(p => p.petName === petName).procedures = [];
            this.currentWorkload--;
            return `Goodbye ${petName}. Stay safe!`;
        }
        
    }
    toString (){
        let customers = [];
        for(let customer of this.clients.sort((a,b) => a.ownerName.localeCompare(b.ownerName))){
            customers.push(`${customer.ownerName} with:`);
            for(let pet of customer.pets.sort((a,b) => a.petName.localeCompare(b.petName))){
                customers.push(`---${pet.petName} - a ${pet.kind} that needs: ${pet.procedures.join(', ')}`);
            }
        }
        return [
            `${this.clinicName} is ${Math.round((this.currentWorkload/this.capacity)*100)}% busy today!`,
            `Total profit: ${this.totalProfit.toFixed(2)}$`,
            customers.join('\n')
        ].join('\n');
    }
}

let clinic = new VeterinaryClinic('SoftCare', 3);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']); 
console.log(clinic.toString());
