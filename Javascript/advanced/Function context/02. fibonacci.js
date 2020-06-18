function getFibonator(){
    this.first = 0;
    this.second = 0;
    function fibonator(){
        let helper = this.second;
        if(this.second==0)
        {
            this.second = 1;
        }else{ 
            this.second = this.second + this.first;
        }
        this.first = helper;
        return this.second;
    }
    return fibonator;
}

let fib = getFibonator()
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());