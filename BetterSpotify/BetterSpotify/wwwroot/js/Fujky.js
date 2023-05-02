


//async function sleep(msec) {
//    return new Promise(resolve => setTimeout(resolve, msec));
//}

//var neco = null;

//$.getJSON("/User/Collection/GetAll", async function (data) {

//    neco = data;


//});

//function funguj (data) {
//    console.log('click');
//    console.log(data);
//    console.log(neco);
//}

//document.getElementById('but').addEventListener('click',funguj);;


////Funkcni

//var info = null;

//fetch("/User/Collection/GetAll").then(response => response.json())
//    .then(data => info = data).then(infoZob);

//function infoZob() {
//    console.log('InfoZob');
//    console.log(info);
//}

//run();

//async function run() {
//    await sleep(1000);
//    console.log(neco);
//}

let url = '/User/Collection/Getall';

console.log('pokus')

fetch(url)
    .then(res => res.json())
    .then(out =>
        AppViewModel.firstName() = out)
    .catch(err => { throw err });



function AppViewModel() {
    var self = this;
    this.firstName = ko.observableArray();
    
}


ko.applyBindings(AppViewModel);
