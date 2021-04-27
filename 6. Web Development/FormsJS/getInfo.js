let currentURL = new URL(window.location.href);
let search = new URLSearchParams(currentURL.search);

let fName = search.get("fName");
let lName = search.get("lName");
let email = search.get("email");
let gdpr = search.get("gdpr");
let terms = search.get("terms");
let birthdate = search.get("birthdate");

document.getElementById("1").innerHTML = "Förnamn: " + fName;
document.getElementById("2").innerHTML = "Efternamn: " +lName;
document.getElementById("3").innerHTML = "Email: " +email;
document.getElementById("4").innerHTML = "GDRP: " +gdpr;
document.getElementById("5").innerHTML = "Vilkor: " +terms;
document.getElementById("6").innerHTML = "Födelsedatum: " +birthdate;