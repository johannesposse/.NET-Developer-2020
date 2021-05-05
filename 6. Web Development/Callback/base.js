function placeInto(holder){
    document.getElementById("placeholder").innerHTML = holder;
}

let someString = "Simple function";

placeInto(someString);


function secondFunc(secondParam){
    placeInto(secondParam + "added from you mama");
}

someString ="you mamma "

secondFunc(someString);

function thirdFunc(normalParam,paramFunction){
    paramFunction(normalParam + " added from you daddy");
}

thirdFunc("you daddy", placeInto);

function secondInto(holder){
    document.getElementById("secondholder").innerHTML = holder;
}

thirdFunc("you daddy", secondInto);

document.write(('b' + 'a' + + 'a' + 'a').toLocaleLowerCase());