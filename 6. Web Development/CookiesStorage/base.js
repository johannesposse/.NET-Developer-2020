function SetIntoLS(){
    let getInput = document.getElementById("icTxt").value;
     
    let intoCookie = "cookieName =" + getInput;
    let date = new Date(Date.now()+ 86400e3);
    date = date.toUTCString();
    // document.cookie = intoCookie + "; expires=" + date + "; max-age=3600";
    document.cookie = intoCookie+ "; max-age=3600";


}

function getGetLS(){
    let getCookie = document.cookie;
    //document.getElementById("putThatDataDown").innerHTML += readInput;

    console.log(getCookie.split("="));
}