


async function sleep(msec) {
    return new Promise(resolve => setTimeout(resolve, msec));
}

var neco = null;

$.getJSON("/User/Collection/GetAll", async function (data) {

    neco = data;


});

function funguj (data) {
    console.log('click');
    console.log(data);
    console.log(neco);
}

document.getElementById('but').addEventListener('click',funguj);;


//Funkcni

var info = null;

fetch("/User/Collection/GetAll").then(response => response.json())
    .then(data => info = data).then(infoZob);

function infoZob() {
    console.log('InfoZob');
    console.log(info);
}

//run();

//async function run() {
//    await sleep(1000);
//    console.log(neco);
//}