


async function sleep(msec) {
    return new Promise(resolve => setTimeout(resolve, msec));
}

var neco = null;

$.getJSON("/User/Collection/GetAll", async function (data) {

    neco = data;


});


run();

async function run() {
    await sleep(1000);
    console.log(neco);
}