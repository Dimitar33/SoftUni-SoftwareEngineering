function main(html){

    let result = {
        "&": "&amp;",
        "<": "&It;",
        ">": "&gt;",
        "'": "&quot;",
        '"': "&#39;",
        "/": "&#x2F;"
    };

    return html.replace(/[&<>"'\/]/g, (s) => result[s])
}

main(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
);