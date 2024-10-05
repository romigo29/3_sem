//1

let arr1 = [1, [1, 2, [3, 4]], [2, 4]]

let concatenation = arr1.flat().reduce((tempArr, current) => {
    return tempArr.concat(current)
}, []);

console.log(concatenation);

//2 

let arr2 = [1, 2, [3, 4, [5, 6, [7, 8, [9, 10]]]]];

let arr2Sum = arr2.flat(Infinity).reduce((sum, current) => sum + current, 0);

console.log(arr2Sum);

//3

function makeStudent(name, age, groupId) {
    return {
        name,
        age,
        groupID: groupId
    };
}

function isAdult(students) {
    adultStudents = []

    for (i = 0; i < students.length; i++) {
        if (students[i].age > 17) {
            adultStudents.push(students[i]);
        }
    }

    return adultStudents;
}

let student1 = makeStudent("Olga", 18, 6);
let student2 = makeStudent("Serega", 18, 6);
let student3 = makeStudent("Matthew", 17, 3);

let students = [student1, student2, student3];

let filteredStudents = isAdult(students);

console.log("Совершеннолетние студенты: \n");
for (let i = 0; i < filteredStudents.length; i++) {
    console.log(filteredStudents[i].name);
}

//4

function convertToCode(symbols) {
    let total1 = "";
    let total2 = "";

    for (i = 0; i < symbols.length; i++) {
        let c = symbols.charCodeAt(i).toString();
        total1 += c;
        if (c.includes("7")) {
            c = c.replace("7", "1");
        }
        total2 += c;
    }

    console.log(
        `Значение total1: ${total1} \n
    Значение total2: ${total2} \n
    total1 - total2 = ${total1 - total2}
    `);

}

symbols = "ABC";
convertToCode(symbols);

//5

function extendObject(...args) {

    let extendedList = Object.assign({}, ...args);
    return extendedList;
}

let obj1 = { a: 1 };
let obj2 = { b: 2 };
let obj3 = { c: 3 };
let obj4 = { d: 4 };
console.log(extendObject(obj1, obj2, obj3, obj4));

//6

function printTower(n, str) {
    for (i = 1; i < n + 1; i++) {
        console.log(" ".repeat(n - i) + str.repeat(i) + " ".repeat(n - i));
    }
}

printTower(5, "*")

let user = {
    name: "John",
    age: 30
};

let clone = Object.assign({}, user);

let user1 = user;
user1.name = "Pavel";


