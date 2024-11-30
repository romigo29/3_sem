//1
//квадраты
let yellowSquare = {
    color: "yellow",
    getColor() {
        return this.color;
    }
}

function Square(size) {
    this.size = size
}

Square.prototype = Object.create(yellowSquare);

let largerSquare = new Square(500);
let smallerSquare = new Square(100);
smallerSquare.name = "маленький квадрат";
console.log(Object.getPrototypeOf(smallerSquare));
console.log(smallerSquare.name);

//круги
let middleCircle = {
    size: 300
}

function Circle(color) {
    this.color = color;
    this.GetColor = () => this.color;
}

Circle.prototype = Object.create(middleCircle);

let whiteCircle = new Circle("white");
let greenCircle = new Circle("green");
console.log(whiteCircle.size);
//треугольники
let middleTriangle = {
    size: 300,

}

function Triangle(n) {
    this.nlines = n;

    this.GetNLines = () => this.nlines;
}

Triangle.prototype = Object.create(middleTriangle);

let triangle1 = new Triangle(1);
let triangle3 = new Triangle(3);
console.log(triangle3.size);

console.log("Уникальные свойства: ");
console.log(greenCircle.GetColor());
console.log(triangle3.GetNLines());
console.log(smallerSquare.hasOwnProperty("name"));

//2
class Human {
    constructor(name, lastName, year, age, adress) {
        this.name = name;
        this.lastName = lastName;
        this.birthYear = year;
        this.age = age;
        this.adress = adress;
    }

    changeAdress(newAdress) {
        this.adress = newAdress;
    }

    get currentAge() {
        const currentYear = new Date().getFullYear();
        return currentYear - this.birthYear;
    }

    set changeAge(newAge) {
        if (this.age < 0) {
            console.log("Возраст должен быть неотицательным!");
        }
        else {
            this.age = newAge;
            const currentYear = new Date().getFullYear();
            this.birthYear = currentYear - this.age;
        }
    }
}

class Student extends Human {
    constructor(name, lastName, year, age, adress, faculty, course, group, gradeBook) {
        super(name, lastName, year, age, adress);
        this.faculty = faculty;
        this.course = course;
        this.group = group;
        this.gradeBook = gradeBook;
    }

    changeCourse(newCourse) {
        this.course = newCourse;
    }

    changeGroup(newGroup) {
        this.group = newGroup;
    }

    getFullname() {
        return this.name + this.lastName;
    }

    decodeGradeBook() {
        const strGradeBook = this.gradeBook.toString();
        return {
            nFaculty: strGradeBook[0],
            nSpeciality: strGradeBook[1],
            admissionYear: 2000 + parseInt(strGradeBook.slice(2, 4)),
            studyPrice: strGradeBook[4],
            uniqueNumber: strGradeBook.slice(5),
        }
    }
}

class Faculty {
    constructor(faculty, nGroups, students) {
        this.faculty = faculty;
        this.nGroups = nGroups;
        this.Students = students;
    }

    changeNGroups(n) {
        this.nGroups = n;
    }

    changeNStudents(n) {
        this.Students = n;
    }

    getDev() {
        const filteredDevStudents = this.Students.filter((student) => student.decodeGradeBook().nSpeciality == 3)
        console.log(`Количество студентов ДЭиВИ: ${filteredDevStudents.length}`);
    }

    getGroup(group) {
        const filteredStudents = this.Students.filter((student) => student.group === group);
        console.log(`Студенты группы ${group}: `);
        console.log(filteredStudents.forEach(student => { console.log(student.getFullname) }));
    }
}

let student1 = new Student("Connor", "Android", "25", 2038, "Detroit", "IT", 1, 10, 71201800);
let student2 = new Student("Hank", "Galagher", "23", 2035, "Detroit", "IT", 1, 9, 73202137);
let student3 = new Student("Marry", "Cross", "21", 2036, "Detroit", "IT", 1, 8, 71202456);
let student4 = new Student("Dasha", "Instasamka", "25", 2038, "Detroit", "IT", 1, 6, 73201789);
let student5 = new Student("Serega", "Pirat", "25", 2038, "Detroit", "IT", 1, 9, 73201119);


const ITFaculty = new Faculty("IT", 10, [student1, student2, student3, student4, student5]);
ITFaculty.getDev()
