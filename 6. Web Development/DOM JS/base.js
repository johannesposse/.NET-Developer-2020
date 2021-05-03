// let elamA = document.createElement("a");
// console.log(elamA);

// elamA.href ="https://www.google.se";
// elamA.innerText ="Länk till google";
// elamA.setAttribute("target","_blank"); //för att öppna på ny sida
// document.body.appendChild(elamA);


let divMain = document.getElementsByTagName("div");
// console.log(divMain);
// divMain[0].appendChild(elamA);

function makeLink(target, content){
    let elamA = document.createElement("a");
    elamA.href = target;
    elamA.innerText = content;
    elamA.setAttribute("target","_blank"); //för att öppna på ny sida
    
    let divMain = document.getElementsByTagName("div");
    divMain[0].appendChild(elamA);
}

makeLink("https://www.google.se","link");



function makeLinkReturn(target, content){
    let elamA = document.createElement("a");
    elamA.href = target;
    elamA.innerText = content;
    elamA.setAttribute("target","_blank"); //för att öppna på ny sida

    return elamA;
}

let returnElem = makeLinkReturn("https://sweclockers.com","Swec");
let pInDiv = divMain[0].getElementsByTagName("p");
pInDiv[0].appendChild(returnElem);

