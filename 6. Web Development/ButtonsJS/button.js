function buttonFunc(){
    console.log("mafk");
    document.getElementById("buttonDemo").innerHTML +="MAFK";
}

let num = 10;
document.getElementById("mafkOnClick").addEventListener("mousemove", function(){
    document.getElementById("mafkOnClick").style.paddingTop ="";
    document.getElementById("mafkOnClick").style.paddingTop +=num +"px";
    document.getElementById("mafkOnClick").style.paddingLeft ="";
    document.getElementById("mafkOnClick").style.paddingLeft +=num +"px";
    num = num + 10;
    // alert(num);
});
