//1
let a = 5;           //числовой (number)
let name = "name";
let i = 0;
let double = 0.23;   //числовой (number)
let result = 1 / 0;
let answer = true;
let no = null;
console.log(a, typeof (a));
console.log(i, typeof (i));
console.log(double, typeof (double));
console.log(result, typeof (result));
console.log(answer, typeof (answer));
console.log(no, typeof (no));


//2
console.log('Сколько квадратов В со сторонами 5 мм поместятся в четырехугольник А (45мм х 21мм). Ответ: ' + Math.floor((45 * 21) / (5 * 5)));

//3
let i3 = 2;
let a3 = ++i;
let b3 = i++;

console.log("Сравнить a и b")
if (a3 > b3) {
    console.log("больше");
}

else if (a3 < b3) {
    console.log("меньше");
}

else {
    console.log("равно");
}

//4
console.log('Котик и котик - ', 'Котик' > 'Котик' ? 'больше' : 'меньше',
    '\nКотик и китик - ', 'Котик' > 'китик' ? 'больше' : 'меньше',
    '\n73 и "53" - ', 73 > "53" ? 'больше' : 'меньше',
    '\nfalse и 0 - ', false > 0 ? 'больше' : 'меньше',
    '\n54 и true - ', 54 > true ? 'больше' : 'меньше',
    '\n123 и false - ', 123 > false ? 'больше' : 'меньше',
    '\ntrue и 3 - ', true > 3 ? 'больше' : 'меньше',
    '\n3 и "5мм" - ', 3 > "5мм" ? 'больше' : 'меньше',
    '\n8 и "-2" - ', 8 > "-2" ? 'больше' : 'меньше',
    '\n34 и "34" - ', 34 > "34" ? 'больше' : 'меньше',
    '\nnull и undefined - ', null > undefined ? 'больше' : 'меньше',
)

//5
// let TeachersName = 'marina';
// let UsersName = prompt("Введите ваше имя: ").toLowerCase();

// UsersName.includes(TeachersName) ? console.log("Данные совпадают") : console.log("Данные не совпадают");


//6

// let IsRusPassed = prompt("Сдан ли русский язык? (1 - да, 0 - нет)");
// let IsMathPassed = prompt("Сдана ли математика? (1 - да, 0 - нет)");
// let IsEngPassed = prompt("Сдан ли английский? (1 - да, 0 - нет)");

// if (+IsRusPassed && +IsMathPassed && +IsEngPassed) {
//     console.log(IsMathPassed);
//     console.log("Вы переведены на следующий курс!");
// }


// else if (!+IsRusPassed && !+IsMathPassed && !+IsEngPassed) {
//     console.log("Вы отчислены! Свбоодны!");
// }

// else {
//     console.log("Вас ожидает пересдача!");
// }

//7
console.log(`true + true = ${true + true}`,
    `\n0 + "5" = ${0 + "5"}`,
    `\n5 + "mm" = ${5 + "mm"}`,
    `\n8 / Infinity = ${8 / Infinity}`,
    `\n9 * '\n9' = ${9 * "\n9"}`,
    `\nnull - 1 = ${null - 1}`,
    `\n"5" - 2 = ${"5" - 2}`,
    `\n"5px" - 3  = ${"5px" - 3}`,
    `\ntrue - 3  = ${true - 3}`,
    `\n7 || 0  = ${7 || 0}`

)

//8
for (i = 1; i <= 10; i++) {
    if (i % 2 == 0) {
        console.log(i + 2);
    }
    else {
        console.log(i + 'mm');
    }
}

//9

// let ObjectWeek = {
//     1: "Понедельник",
//     2: "Вторник",
//     3: "Среда",
//     4: "Четверг",
//     5: "Пятница",
//     6: "Суббота",
//     7: "Воскресенье"
// }

// let ArrayWeek = ["Понедельник", "Вторник", "Среда",
//     "Четверг", "Пятница", "Суббота", "Воскресенье"];

// let day = prompt("Введите нормер дня");

// console.log(`Сегодня ${ObjectWeek[day]}`)
// console.log(`Сегодня ${ArrayWeek[day - 1]}`)

//10


function myFunction(parm1 = 'Love ', parm2, parm3,) {
    return console.log(parm1 + parm2 + parm3);
}

let parm2 = 'is ';
let parm3 = prompt("Закончите фразу 'Love is...'");

myFunction(undefined, parm2, parm3);



//11


// let a11 = prompt("Введит сторону a");
// let b11 = prompt("Введите сторону b");

// function params(a11, b11) {
//     switch (a11 == b11) {
//         case true:
//             return a11 * 4;
//             break;
//         case false:
//             return a11 * b11;
//             break;

//     }
// }

// let egetPerimeterOrSquare = params(a11, b11);
// let agetPerimeterOrSquare = (a11, b11) => {
//     switch (a11 == b11) {
//         case true:
//             return a11 * 4;
//             break;
//         case false:
//             return a11 * b11;
//             break;

//     }
// };

// console.log(params(a11, b11));
// console.log(egetPerimeterOrSquare);
// console.log(agetPerimeterOrSquare(a11, b11));

alert('10' > 9)
