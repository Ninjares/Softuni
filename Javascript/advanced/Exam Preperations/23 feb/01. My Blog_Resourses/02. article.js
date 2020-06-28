class Article {
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }
    get likes(){
        if(this._likes.length === 0) return `${this.title} has 0 likes`;
        else if(this._likes.length === 1) return `${this._likes[0]} likes this article!`;
        else return `${this._likes[0]} and ${this._likes.length-1} others like this article!`
    }
    like(username){
        if(this._likes.includes(username)) throw new Error(`You can't like the same article twice!`);
        else if(this.creator === username) throw new Error(`You can't like your own articles!`);
        else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }
    dislike(username){
        if(!this._likes.includes(username)) throw new Error(`You can't dislike this article!`);
        else {
            //Implement removal;
            this._likes = this._likes.filter(x => x !== username);
            return `${username} disliked ${this.title}`;
        }
    }
    comment(username, content, id){
        let comment = {
            username,
            content
        }
        if(id==undefined||this._comments.find(x => x.id == id)===undefined){
            comment.id = this._comments.length+1;
            comment.replies = [];
            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        }
        else if(this._comments.find(x => x.id == id)!==undefined){
            comment.id = `${this._comments.find(x => x.id == id).id}.${this._comments.find(x => x.id == id).replies.length+1}`;
            this._comments.find(x => x.id == id).replies.push(comment);
            return `You replied successfully`;
        }
    }
    toString(sortingtype){
        let returnstring = [
            `Title: ${this.title}`,
            `Creator: ${this.creator}`,
            `Likes: ${this._likes.length}`,
            `Comments:`
        ]
        let comments = [];
        switch(sortingtype){
            case 'asc':{
                for(let comment of this._comments.sort((a,b) => a.id-b.id)){
                    comments.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
                    if(comment.replies.length>0){
                        for(let reply of comment.replies.sort((a,b) => a.id-b.id)){
                            comments.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                        }
                    }
                }
                break;
            }
            case 'desc':{
                for(let comment of this._comments.sort((a,b) => b.id-a.id)){
                    comments.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
                    if(comment.replies.length>0){
                        for(let reply of comment.replies.sort((a,b) => b.id-a.id)){
                            comments.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                        }
                    }
                }
                break;
            }
            case 'username':{
                for(let comment of this._comments.sort((a,b) => a.username.localeCompare(b.username))){
                    comments.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
                    if(comment.replies.length>0){
                        for(let reply of comment.replies.sort((a,b) => a.username.localeCompare(b.username))){
                            comments.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                        }
                    }
                }
                break;
            }
        }
        returnstring.push(comments.join('\n'));
        return returnstring.join('\n')
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
