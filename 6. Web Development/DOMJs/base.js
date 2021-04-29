// console.log(window);
// console.log(window.innerWidth);
// console.log(document);

let havABody = document.body;
// console.log(havABody);
// havABody.innerHTML ="<h1>Hej</h1>";

// document.getElementById("uniqueID").innerHTML ="From the JS";

let allH1 = document.getElementsByTagName("h1");

for(let i = 0; i < allH1.length; i++){
    allH1[i].innerHTML ="mf";
}

let aClass = document.getElementsByClassName("aClass");

aClass[0].innerHTML ="fuck";

document.querySelector("li:last-child").innerHTML ="mf";

allH1[0].style.fontSize ="3rem"; //inte bra att göra
