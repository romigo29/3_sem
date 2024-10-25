//1
let numbers = [13, 4, 7, 9];
let [y] = numbers;
console.log(`Первый элемент массива: ${y}`);

//2

let user = {
    name: "Serega",
    age: "18"
}

let admin = {

    ...user,
    access: true,
    level: "high"
}

console.log("Информация об администраторе: ");
for (key in admin) {
    console.log(`${key} : ${admin[key]}`);
}

//3
let store = {
    state: {    //1 уровень
        profilePage: {  //2 уровень
            posts: [   //3 уровень 
                { id: 1, message: 'Hi', likesCount: 12 },
                { id: 2, message: 'By', likesCount: 1 },
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                { id: 1, name: 'Valera' },
                { id: 2, name: 'Andrey' },
                { id: 3, name: 'Sasha' },
                { id: 4, name: 'Viktor' }
            ],
            messages: [
                { id: 1, message: 'hi' },
                { id: 2, message: 'hi hi,' },
                { id: 3, message: 'hi hi hi' }
            ],
        },

        sidebar: [],
    },
}

let {
    state: {    //1 уровень
        profilePage: {  //2 уровень
            posts,
            newPostText
        },

        dialogsPage: {
            dialogs,
            messages,
        },

        sidebar,
    }
} = store;

console.log("Количество лайков: ");
for (let element of posts) {
    console.log(element.likesCount);
}

console.log("Пользователи с четными id: ");
for (let element of dialogs) {
    if (element.id % 2 == 0) {
        console.log(element.name);
    }
}

messages.map((num) => num.message = "Hello, user");
for (let element of messages) {
    console.log(element);
}

//4
let tasks = [
    { id: 1, title: "HTML&CSS", isDone: true },
    { id: 2, title: "JS", isDone: true },
    { id: 3, title: "ReactJS", isDone: false },
    { id: 4, title: "Rest API", isDone: false },
    { id: 5, title: "GraphQL", isDone: false },

];

let task6 = { id: 6, title: "Photoshop", isDone: false };

let updatedTasks = [...tasks, task6];

updatedTasks.forEach(element => {
    console.log(element);
});

//5

let myArr = [1, 2, 3]

function sumValue(x, y, z) {
    return x + y + z;
}

console.log(sumValue(...myArr));