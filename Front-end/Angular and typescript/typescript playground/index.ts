class Person{
    private name: string;
    
    constructor(name: string){
        this.name = name;
    }
    sayHello(){
        return `${this.name} says hello`;
    }
}
const user = new Person("Ma nibba");
console.log(user.sayHello());

//1. npm init
//2. npm install typescript
//3. create tsconfig.json
//4. npm run build
//5. node ./dist/index.js