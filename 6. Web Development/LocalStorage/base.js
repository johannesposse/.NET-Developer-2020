function SetIntoLS(){
    let getInput = document.getElementById("icTxt").value;
    localStorage.setItem("saveTest",getInput); 
}

function getGetLS(){
    let readInput = localStorage.getItem("saveTest");
    document.getElementById("putThatDataDown").innerHTML += readInput;
}