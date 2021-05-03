let btnCount = 0;

function buttonCount(){
    let allEleWithHide = document.getElementsByClassName("hide");
    
    for(let i = 0; i < allEleWithHide.length; i++){
        allEleWithHide[i].style.display = "none";
    }

    document.getElementsByClassName("hide")[btnCount].style.display="block";
    btnCount++;

    if(btnCount >= allEleWithHide.length){
        btnCount = 0;
    }
}

function showToggle(){
    let divEle = document.getElementById("toggleDIV");

    if(divEle.style.display === "none"){
        console.log("fucjk");
        divEle.style.display ="block";
    } else{
        console.log("asdkld");
        divEle.style.display ="none";
    }
}

function makeIMG(){
    let aIMG = document.createElement("img");
    aIMG.setAttribute("src","https://source.unsplash.com/random");
    aIMG.setAttribute("width","304");
    aIMG.setAttribute("height","228");
    aIMG.setAttribute("alt","ingen jehvla aning");
    document.getElementById("imgHold").appendChild(aIMG);
}
