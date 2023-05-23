const fs = require('fs');

// Read JSON files
const json1 = fs.readFileSync('C:\\Users\\umutu\\Downloads\\response_1684765827104.json');
const json2 = fs.readFileSync('C:\\Users\\umutu\\Downloads\\response_1684765708395.json');

// Parse JSON data
const data1 = JSON.parse(json1);
const data2 = JSON.parse(json2);

// Initialize arrays to store different elements
const differentElements1 = [];
const differentElements2 = [];

// Compare "adi" and "firmaadi" properties and list different elements
data1.forEach((element1) => {
    const adi1 = element1.adi;
    const matchingElement = data2.find((element2) => element2.firmaadi === adi1);

    if (!matchingElement) {
        differentElements1.push(element1);
    }
});

data2.forEach((element2)=> {
    const firmaadi2 = element2.firmaadi;
    const matchingElement = data1.find((element1) => element1.adi === firmaadi2);

    if (!matchingElement) {
        differentElements2.push(element2);
    }
});

// Output the different elements
console.log("Elements from json1 that are not present in json2:");
console.log(differentElements1);

console.log("Elements from json2 that are not present in json1:");
console.log(differentElements2);