function getArticleGenerator(articles) {
    
    let content = document.getElementById(`content`);
    let count = 0;

    return () => {

        if (count < articles.length) {
            
            content.appendChild(create(articles[count++]))
        }
    }

    function create(text){

        let article = document.createElement(`article`);
        article.textContent = text;

        return article;
    }
}
