function main(arr, start, end){

        let startIndex = arr.findIndex(x => x == start);
        let endIndex = arr.findIndex(x => x == end);

        let result = arr.slice(startIndex, endIndex + 1);

       return result;

}

main(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
);