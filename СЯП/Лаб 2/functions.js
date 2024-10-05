//1
function basicOperation(operation, value1, value2) {

    switch (operation) {
        case "+":
            return value1 + value2;

        case "-":
            return value1 - value2;

        case "*":
            return value1 * value2;

        case "/":
            return value1 / value2;

        default:
            console.log("Введен неверный символ");

    }
    return result;
}

let result = basicOperation('+', 5, 10);
let result2 = basicOperation('-', 5, 10);
let result3 = basicOperation('*', 5, 10);
let result4 = basicOperation('/', 5, 10);

console.log(result);
console.log(result2);
console.log(result3);
console.log(result4);

// //2
// function returnCube(n) {
//     let sum = 0;
//     for (i = 1; i <= n; i++) {
//         sum += i * i * i;
//     }

//     return sum;
// }

// n = prompt("Введите натуральное число n");
// console.log(`Сумма кубов до числа n (${n}) включительно: ${returnCube(n)}`);

//3
function getArraySum(numbers) {
    let size = numbers.length;
    let average = 0
    for (i = 0; i < size; i++) {
        average += numbers[i];
    }
    return average / size;
}

let numbers = [3, 12, 54, 87, 12];
console.log(`Среднеарифметическое чисел массива numbers (${numbers}): ${getArraySum(numbers)}`);

//4
function reverseString(str) {
    let newStr = "";
    for (i = str.length - 1; i >= 0; i--) {
        let code = str.charCodeAt(i);
        if ((65 <= code && code <= 90) || (97 <= code && code <= 122)) {
            newStr += str[i];
        }
    }

    return newStr;
}

let str1 = "JavaScript";
let str2 = "JavaScr53э";

console.log(`Реверсирование латинских символов строки ${str1}: ${reverseString(str1)}`);
console.log(`Реверсирование латинских символов строки ${str2}: ${reverseString(str2)}`);

//5
function duplicateString(n, s) {
    return s.repeat(n);
}

let n = 13;
let s = 'Кофе помогает от Альцгеймера. ';
console.log(duplicateString(n, s));

//6

function isArr1InArr2(arr1, arr2) {
    let arr3 = [];
    arr1.forEach(element1 => {
        if ((arr2.includes(element1))) {
            arr3.push(element1);
        }
    });

    return arr3;

}

let arr1 = ["cherry", "kiwi", "qwerty"];
let arr2 = ["banana", "kiwi", "apple"];
console.log(isArr1InArr2(arr1, arr2));

let myFunctions = (array) => {
    let mult = 1;
    array.forEach(element => {
        mult *= element;
    });

    return mult;
};

console.log(myFunctions([1, 2, 3]));