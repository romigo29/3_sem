class Task {
    constructor(id, name, state) {
        this.id = id;
        this.name = name;
        this.state = state;
    }

    ChangeName(newName) {
        this.name = newName;
    }

    ChangeState(newState) {
        this.name = newState;
    }
}

class ToDoList {
    constructor(id, name, tasks) {
        this.id = id;
        this.name = name;
        this.tasks = tasks;
    }

    ChangeName(newName) {
        this.name = newName;
    }

    AddTask(newTask) {
        this.tasks.push(newTask);
    }

    FilterTasks(statement) {
        const filteredTasks = this.tasks.filter((task) => task.state == statement);
        return filteredTasks;
    }
}

const task1 = new Task(1, "shopping", false);
const task2 = new Task(2, "gym", true);
const task3 = new Task(3, "courseProject", true);
const task4 = new Task(4, "bike", false);
const task5 = new Task(5, "sleep", true);
const task6 = new Task(6, "reading", false);
const task7 = new Task(7, "going out", true);
const task8 = new Task(8, "watchg film", false)

const importantList = new ToDoList(1, "important", [task1, task2]);
const tomorrowList = new ToDoList(10, "unnecessary", [task7, task8]);

tomorrowList.ChangeName("todayList");

importantList.AddTask(task3);
importantList.AddTask(task4);
importantList.AddTask(task5);
importantList.AddTask(task6);

console.log(importantList);
filteredTasksByDone = importantList.FilterTasks(true);
console.log(filteredTasksByDone);