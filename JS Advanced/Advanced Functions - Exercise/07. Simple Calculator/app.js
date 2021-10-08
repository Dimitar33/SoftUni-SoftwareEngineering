function calculator() {

    let first;
    let second;
    let res;

    return {

        init: (selector1, selector2, selector3) => {

             first = document.querySelector(selector1);
             second = document.querySelector(selector2);
             res = document.querySelector(selector3);
        },

        add: () => res.value = Number(first.value) + Number(second.value),
        subtract: () => res.value = Number(first.value) - Number(second.value)

    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');



