function SetIntoLS(){
    let getInput = document.getElementById("icTxt").value;
    sessionStorage.setItem("saveTest",getInput); 
}

function getGetLS(){
    let readInput = sessionStorage.getItem("saveTest");
    document.getElementById("putThatDataDown").innerHTML += readInput;
}