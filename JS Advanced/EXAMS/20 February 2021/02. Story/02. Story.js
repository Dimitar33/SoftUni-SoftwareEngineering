class Story {

    constructor(title, creator) {

        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {

        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;

        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;

        } else {
            return `${this._likes[0]} and ${this._likes.length-1} others like this story!`
        }
    }

    like(username) {

        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!");

        } else if (username === this.creator) {
            throw new Error("You can't like your own story!");

        } else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`
        }
    }


    dislike(username) {

        if (this._likes.includes(username)) {

            const indx = this._likes.indexOf(username);
            this._likes.splice(indx, 1);

            return `${username} disliked ${this.title}`;

        } else {
            throw new Error("You can't dislike this story!");
        }
    }

    comment(username, content, id) {

        if (id === undefined ||
            !this._comments.some(x => x.id === id)) {

            this._comments.push({

                id: this._comments.length + 1,
                username,
                content,
                replies: [],
            });

            return `${username} commented on ${this.title}`;

        } else {

            let indxOfComment = this._comments.indexOf(this._comments.find(x => x.id === id));

            if (this._comments[indxOfComment].replies === undefined) {
                this._comments[indxOfComment].replies = [];
            }

            this._comments[indxOfComment].replies.push({
                id: `${id}.${this._comments[indxOfComment].replies.length+1}`,
                username,
                content,
            });

            return "You replied successfully";
        }
    }

    toString(sortingType) {

        let result = `Title: ${this.title}\n`;
        result += `Creator: ${this.creator}\n`;
        result += `Likes: ${this._likes.length}\n`;
        result += `Comments:\n`;

        if (sortingType === 'asc') {
            for (const item of this._comments) {
                result += `-- ${item.id}. ${item.username}: ${item.content}\n`;

                if (item.replies.length > 0) {
                    for (const reply of item.replies) {
                        result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }
        } else if (sortingType === 'desc') {

            let reversedComments = this._comments.reverse();

            for (const item of reversedComments) {
                result += `-- ${item.id}. ${item.username}: ${item.content}\n`;

                if (item.replies.length > 0) {

                    let reversedReplies = item.replies.reverse();

                    for (const reply of reversedReplies) {
                        result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }

        } else if (sortingType === 'username') {
            let sortedUsers = this._comments.sort((a, b) => a.username.localeCompare(b.username));

            for (const item of sortedUsers) {
                result += `-- ${item.id}. ${item.username}: ${item.content}\n`;

                if (item.replies.length > 0) {

                    let sortedReplies = item.replies.sort((a, b) => a.username.localeCompare(b.username));

                    for (const reply of sortedReplies) {
                        result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }

        }

        result = result.trimEnd();

        return result;
    }
};

// class Story{

//     constructor(title, creator){

//         this.title = title;
//         this.creator = creator;
//         this.comments = {}; //private
//         this._likes = []; //private
//     }

//     get likes(){

//         if (this._likes.length == 0) {
            
//             return `${this.title} has 0 likes`;
//         }
//         else if (this._likes.length == 1) {
            
//             return `${this._likes[0]} likes this story!`;
//         }

//         return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
//     }

//     like (username){

//         if (this._likes.includes(username)) {
            
//             throw new Error(`You can't like the same story twice!`);
//         }
//         else if (username == this.creator) {
            
//             throw new Error(`You can't like your own story!`);
//         }

//         this._likes.push(username);
//         return `${username} liked ${this.title}!`
//     }
        
//     dislike (username){

//         if (!this._likes.includes(username)) {
            
//             throw new Error(`You can't dislike this story!`);
//         }

//         this._likes = this._likes.filter(x => x != username);
//         return `${username} disliked ${this.title}`;
//     }

    
//     repCount = 0.1;

//     comment(username, content, id){


//         if (!id) {
            
//             let count = Object.keys(this.comments).length + 1;
//             this.comments[count] = {username, content, replies: {}};
            
//             return `${username} commented on ${this.title}`;
//         }

//         else {
            
//             let repCount = Object.keys(this.comments[id]['replies']).length + 1;
//             this.comments[id].replies[`${id}.${repCount}`] = {username, content};
            
//             return `You replied successfully`;
//         }
//     }

//     toString(sortingType){

//         if (sortingType == `asc`) {
            
//         }
//         else if (sortingType == `desc`) {
            
//            Object.entries(this.comments).sort((a,b) => b[1].id - a[1].id);
//         }
//         else{

//         }
//         let asd = Array.from(Object.entries(this.comments));

//         let commentsString = asd;

//         for (const key in this.comments) {

//             commentsString += `-- ${key}. ${this.comments[key].username}: ${this.comments[key].content}\n`;
                
//         }

//         return  `Title: {title}\nCreator: {creator}\nLikes: {likes}\nComments:\n${commentsString}`
//     }
// }

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 2);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
