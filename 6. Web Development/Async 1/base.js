// setTimeout(placeInto,3000);
// setTimeout(placeInto,4000);
// setTimeout(placeInto,5000);

// document.write("ma'fk");

// function placeInto(){
//     document.getElementById("placeHolder").innerHTML += "wait?";
// }

// let img = document.getElementById("imgID");

// img.addEventListener("load", function(){
//     console.log("nice cock lad");
// });


// img.addEventListener("error", function(){
//     console.log("fuck my life");
//     img.src="img/error.jpg";
// });

// let promise = new Promise(function(resolve,reject){
//     let x = 1;
//     let y = 2;

//     if(x === y){
//         resolve("bra jobbat...");
//     }else{
//         reject("fan vad kass du är...");
//     }
// });


// promise.then(function(resolve){
//     console.log(resolve);
// }, function(reject){
//     console.log(reject);
// });

let imgPromise = new Promise(function(resolve,reject){
    let img = document.getElementById("imgID");
    img.onload = function(){
        resolve("FAN VAD BRA");
    }
    img.onerror = function(){
        reject(img)
    }
});

imgPromise.then(function(resolve)
{
    console.log(resolve);
}, function(reject)
{
    console.log(reject.src);
    reject.src ="img/error.jpg"
});