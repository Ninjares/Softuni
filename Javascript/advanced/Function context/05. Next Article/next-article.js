function getArticleGenerator(articles) {
    articles.reverse();
    function returnArticle(){
        if(articles.length!=0)
        {
            let toadd = document.createElement('article');
            toadd.innerText = articles.pop();
            document.getElementById('content').appendChild(toadd);
        }
    }
    return returnArticle;
}