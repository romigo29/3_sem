// //1-1
// function makeCounter() {
//     let currentCount = 1;

//     return function () {
//         return currentCount++;
//     };
// }

// let counter = makeCounter();

// alert(counter());
// alert(counter());
// alert(counter());

// let counter2 = makeCounter();
// alert(counter2());

// //1-2

// let currentCount = 1;
// function makeCounter() {
//     return function () { 
//         return currentCount++;
//     };
// }

// let counter = makeCounter();
// let counter2 = makeCounter();

// alert(counter());
// alert(counter());
// alert(counter());

// alert(counter2());
// alert(counter2());

// //2 
// function getVolume(a) {
//     return (b) => {
//         return (c) => {
//             return a * b * c;
//         }
//     }
// }

// const fixedLength = 3;
// const width = 4;
// const height = 5;

// console.log(getVolume(fixedLength)(width)(height));

// const inter1 = getVolume(fixedLength);
// const result = inter1(width)(height);
// console.log(result);

//3
function* moveObject() {
    let x = 0; // Начальные координаты объекта
    let y = 0;
    const step = 10;
    console.log(`Начальные координаты объекта: x=${x}, y=${y}`)

    while (true) {
        let direction = yield { x, y };

        switch (direction) {
            case "left":
                x -= step;
                break;
            case "right":
                x += step;
                break;
            case "up":
                y += step;
                break;
            case "down":
                y -= step;
                break;
            default:
                console.log("Неизвестная команда: " + direction);
        }
        console.log(`Новые координаты: x=${x}, y=${y}`);
    }
}

const objectMovement = moveObject();
objectMovement.next();
let answer;

while (true) {

    answer = prompt("Введите направление двжиения (end для выхода)").toLowerCase();
    if (answer == "end") {
        console.log("Завершение программы");
        break;
    }
    objectMovement.next(answer);
}

//4
console.log(Object.keys(window));

let myVar1 = 13;
var myVar2 = 13;

alert(window.myVar1);
alert(window.myVar2);











