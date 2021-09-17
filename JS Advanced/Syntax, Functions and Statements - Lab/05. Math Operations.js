function main(num1, num2, operand) {

    let result;

    switch (operand) {
        case '+':
            result = num1 + num2;
            break;

        case '-':
            result = num1 - num2;
            break;

        case '*':
            result = num1 * num2;
            break;

        case '/':
            result = num1 / num2;
            break;

        case '**':
            result = num1 ** num2;
            break;

        case '%':
            result = num1 % num2;
            break;

        default:
            break;
    }

    console.log(result);
}

main(3, 5.5, '*');