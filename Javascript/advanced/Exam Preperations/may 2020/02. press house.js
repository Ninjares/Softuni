function solve(){
class Article{
    constructor(title, content){
        this.title = title;
        this.content = content;
    }

    toString() {
        return `Title: ${this.title}\nContent: ${this.content}`;
    }
}

class ShortReports extends Article{ //super replaces base
    constructor(title, content, origialResearches){
        if(content.length>150) throw new Error("Short reports content should be less then 150 symbols.");
        if(origialResearches == undefined || origialResearches.title == null || origialResearches.author == null) throw new Error("The original research should have author and title.");
        super(title, content);
        this.resercher = {title: origialResearches.title, author: origialResearches.author};
        this.comments = [];
    }
    addComment(comment){
        this.comments.push(comment);
        return 'The comment is added.';
    }
    toString(){
        if(this.comments.length ==0)
        return `${super.toString()}\n` + `Original Research: ${this.resercher.title} by ${this.resercher.author}`;
        else
        return `${super.toString()}\n` + `Original Research: ${this.resercher.title} by ${this.resercher.author}\nComments:\n` + this.comments.join('\n');
    }
}

class BookReview extends Article{
    constructor(title, content, book){
        super(title, content);
        this.book = {name: book.name, author: book.author};
        this.clients = [];
    }
    addClient(clientName, orderDescription){
        let order = {clientName, orderDescription}
        let clientlist = this.clients.map(x => x.clientName);
        if(clientlist.includes(clientName)){
            throw new Error("This client has already ordered this review.");
        }
        else {
            this.clients.push(order);
            return `${clientName} has ordered a review for ${this.book.name}`;
        }
    };
    toString(){
        if(this.clients.length == 0)
        return `${super.toString()}\n` + `Book: ${this.book.name}`;
        else {
            let clientstring = '';
            for(let client of this.clients){
                clientstring += `${client.clientName} - ${client.orderDescription}\n`;
            }
            return `${super.toString()}\n`  + `Book: ${this.book.name}\n` + "Orders:\n"+ clientstring.trim();
        }
    }
}
    return {
        Article, 
        ShortReports,
        BookReview
    }
}
let classes = new solve();
let short = new classes.ShortReports('SpaceX and Javascript', 'Yes, its damn true.SpaceX in its recent launch Dragon 2 Flight has used a technology based on Chromium and Javascript. What are your views on this ?', { title: 'Dragon 2', author: 'wikipedia.org' });
console.log(short.toString());

let bookReview = new classes.BookReview('Hrold trotter', 'He coomed in the middle of the night', {name: 'Book name', author: 'Jack off rowling'});
console.log(bookReview.addClient('Daniel', 'No cooming'));
//console.log(bookReview.addClient('Daniel', 'change it up'));
console.log(bookReview.toString());