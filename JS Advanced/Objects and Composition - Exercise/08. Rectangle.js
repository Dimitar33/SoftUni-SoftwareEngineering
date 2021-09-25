function main(width, height, color){

    color = color[0].toUpperCase() + color.slice(1);
    
    let rect = {

        width,
        height,
        color,
        calcArea: function(){

            return (rect.width * rect.height);
        }
    }

    return rect;
    
}

main(4, 5, 'Red');