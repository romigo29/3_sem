//1

function addItem(set, item) {

    console.log(`Добавлен элемент ${item}`);
    set.add(item);
}

function removeItem(set, item) {
    if (set.has(item)) {
        console.log(`Удален элемент ${item}`);
        set.delete(item)
        return set;
    }

    console.log(`Элемент ${item} не найден`);
}

function isIncluded(set, item) {

    if (set.has(item)) {
        console.log(`Элемент ${item} включен в список`);
    }
    else {
        console.log(`Элемент ${item} не включен в список`);
    }

}
let products = new Set(["pita", "chicken", "tomato", "lettuce", "ketchup", "yogurt"]);

console.log(products);
isIncluded(products, "ham");
addItem(products, "cucumber");
removeItem(products, "tomato");
console.log(products);

//2

function createStudent(ID, group, name) {
    return {
        ID,
        group,
        name,
    };
}

function addStudent(set, student) {
    set.add(student);
    return set;
}

function removeStudent(set, id) {
    for (let student of set) {
        if (student.ID == id) {
            set.delete(student);
            console.log(`Студент №${id} найден. Удаляем его из базы.`)
            return set;
        }
    }

    console.log(`Студент №${id} не был найден.`);
}

function filterByGroup(set, group) {
    let filteredStudents = new Set();
    for (let student of set) {
        if (student.group == group) {
            filteredStudents.add(student);
        }
    }

    return filteredStudents;
}

function sortByID(set) {
    let sortedStudents = [...set];
    return sortedStudents.sort((s1, s2) => s1.ID - s2.ID);
}

let studentsInfo = new Set();
let student1 = createStudent(701231245, 6, "Serega");
let student2 = createStudent(709879876, 3, "Matthew");
let student3 = createStudent(701137564, 6, "Olga");
let student4 = createStudent(704235252, 10, "Jan");

addStudent(studentsInfo, student1);
addStudent(studentsInfo, student2);
addStudent(studentsInfo, student3);
addStudent(studentsInfo, student4);
console.log(studentsInfo);

removeStudent(studentsInfo, 704235252);
console.log(studentsInfo);

let filteredStudentsInfo = filterByGroup(studentsInfo, 6);
console.log(filteredStudentsInfo);

let sortedStudentsInfo = sortByID(studentsInfo);
console.log(sortedStudentsInfo);

//3

function addGoods(goods, id, name, amount, price) {
    return goods.set(id, { name, amount, price });
}

function getGoodsAmount(goods) {
    return goods.size;
}

function getGoodsPrices(goods) {
    let overallPrice = 0;
    for (obj of goods.values()) {
        overallPrice += obj.price;
    }

    return overallPrice;
}

function deleteGoodsByID(goods, id) {
    if (goods.has(id)) {
        console.log(`Товар №${id} найден. Удаляю товар из базы`);
        return goods.delete(id);
    }

    else {
        console.log(`Товар №${id} не найден`);
    }
}

function deleteGoodsByName(goods, name) {
    for (let obj of goods) {
        if (obj[1].name == name) {
            console.log(`Товар "${obj[1].name}" найден. Удаляю товар из базы`);
            goods.delete(obj[0]);
        }
    }

    return goods;
}

function changeGoodsAmount(goods, ...amount) {
    let i = 0;
    for (let obj of goods.values()) {
        obj.amount = amount[i++];
    }
}

function changeGoodsPrice(goods, id, price) {
    for (obj of goods.keys()) {
        if (obj == id) {
            console.log(`Товар №${id} найден. Изменяю цену товара`);
            goods.get(obj).price = price;
        }
    }
}

let goods = new Map();

addGoods(goods, 12, "Iron", 1, 46);
addGoods(goods, 29, "Fridge", 3, 800)
addGoods(goods, 31, "Microwave", 12, 120)
addGoods(goods, 32, "Microwave", 10, 124)
addGoods(goods, 3, "WashingMachine", 5, 300)
console.log(goods)
console.log(`Текущее количество товаров: ${getGoodsAmount(goods)}. Их общая цена: ${getGoodsPrices(goods)}$`);


deleteGoodsByID(goods, 29);
console.log(goods)

deleteGoodsByName(goods, "Microwave");
console.log(goods)

changeGoodsAmount(goods, 1, 2);
console.log(goods)

changeGoodsPrice(goods, 3, 333);
console.log(goods)

//4

let cache = new WeakMap();

function cashData(obj) {
    if (!cache.has(obj)) {

        console.log("Добавляю в кэш данные")
        let result = multipleValue(obj);
        cache.set(obj, result);

        return result;
    }

    console.log("Беру данные из кэша");
    return cache.get(obj);
}

function multipleValue(obj) {
    return obj.value * 2;
}

let objValue = { value: 29 };

let result1 = cashData(objValue);
console.log(result1);
let result2 = cashData(objValue);
console.log(result2);

objValue = null;
//после удаления объект память кэша очистится