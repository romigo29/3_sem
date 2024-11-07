// "use strict";
//1

let person = {

    name: "Serega",
    age: 13,

    greet() {
        return `Привет, ${this.name}!`;
    },

    ageAfterYears(years) {
        return "Текущий возраст: " + (this.age + years);
    }
}

console.log(person.greet());
console.log(person.ageAfterYears(13));

//2
let car = {

    model: "BMW",
    year: 2020,

    getInfo() {

        return `Модель: ${this.model}, Год: ${this.year}`;
    }
}

console.log(car.getInfo());

//3

function Book(t, a) {
    this.title = t;
    this.author = a;

    this.getTitle = () => console.log(`Название книги: ${this.title}`);
    this.getAuthor = () => console.log(`Имя автора: ${this.author}`);
}

let book1 = new Book("Десять негритят", "Агата Кристи");
book1.getAuthor();
book1.getTitle();

//4
let team = {
    players: [
        { player: "Serega", role: "Content-maker" },
        { player: "Chicko", role: "Leader" },
        { player: "Zlatochka", role: "Co-leader" }
    ],

    getPlayers() {
        console.log("Наша команда:");
        this.players.forEach(element => {
            console.log(`Участник ${element.player}, позиция: ${element.role}`)
        }
        );
    }
}

team.getPlayers();

//5
const counter = function () {
    let counter = 0;
    return {
        increment: function () {
            counter++;
            return counter;
        },
        decrement: function () {
            counter--;
            return counter;
        },
        getCount: function () {
            return counter;

        }
    }
}
    ();

console.log(counter.increment());
console.log(counter.increment());
console.log(counter.decrement());
console.log(counter.getCount());

//6

let item = {
    price: 42
};

console.log(`Цена до: ${item.price}`);

Object.defineProperty(item, "price", {
    writable: true,
    configurable: true
});

item.price = 100;
console.log(`Цена после: ${item.price}`);

Object.freeze(item)

console.log(`Цена до: ${item.price}`);
item.price = 200;
console.log(`Цена после: ${item.price}`);

//7
let circle = {
    _radius: 1,

    get getSquare() {
        return Math.PI * this._radius * this._radius;
    },

    get Radius() {
        return `Текущий радиус: ${this._radius}`;
    },

    set Radius(value) {
        if (value > 0) {
            this._radius = value;
            console.log("Значение радиуса изменено");
        }
        else {
            console.log("Радиус должен быть положительным");
        }
    }
}

console.log(circle.Radius);
circle.Radius = 3;
console.log(circle.Radius);
console.log(circle.getSquare);

//8
function printCarInfo(car) {
    console.log(`Страна изготовления машины: ${car8.make}`);
    console.log(`Модель машины: ${car8.model}`);
    console.log(`Год изготовления машины: ${car8.year}`);
}

let car8 = {
    make: "Germany",
    model: "BMW",
    year: 2020
}

Object.defineProperties(car8, {
    make: {
        writable: true,
        configurable: true,
    },
    model: {
        writable: true,
        configurable: true,
    },
    year: {
        writable: true,
        configurable: true,
    }
})

car8.make = "Japan";
car8.model = "Toyta";
car8.year = 2024;
printCarInfo(car);

Object.freeze(car8);

car8.make = "Germany";
car8.model = "BMW";
car8.year = 2020;
printCarInfo(car);

//9
let numbers = [3, 4, 5];

Object.defineProperty(numbers, "sum", {
    get: function () {
        let sum = 0;

        this.forEach((num) => sum += num)
        return sum;
    },

    configurable: false,
})

console.log(numbers.sum);
numbers.sum = 13;
console.log(numbers.sum);

//10
let rectangle = {
    _width: 1,
    _height: 1,

    get getSquare() {
        return `Площадь прямоугольника: ${this._width * this._height}`;
    },

    get Width() {
        return `Ширина прямоугольника: ${this._width}`
    },

    set Width(w) {
        if (w > 0) {
            this.width = w;
        }
    },

    get Height() {
        return `Ширина прямоугольника: ${this.Height}`
    },

    set Height(h) {
        if (h > 0) {
            this._height = h;
        }
    }
}

rectangle.Width = 100;
rectangle.Height = 150;
console.log(rectangle.getSquare);

//11
let user = {
    firstName: "Agatha",
    lastName: "Christie",

    get FullName() {
        return `Полное имя пользователя: ${this.firstName} ${this.lastName}`;
    },

    set FullName(value) {
        [this.firstName, this.lastName] = value.split(" ");
        console.log(`Полное имя пользователя изменено`);
    },
}

console.log(user.FullName);
user.FullName = "Hercule Poirot";
console.log(user.FullName);