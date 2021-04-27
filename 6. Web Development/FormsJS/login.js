function checkPass(){
    
    let fName = document.forms["formName"]["fName"].value;
    let lName = document.forms["formName"]["lName"].value;
    let email = document.forms["formName"]["email"].value; 
    let gdpr = document.getElementById("gdpr")
    let terms = document.getElementById("terms")
    let birthdate = document.forms["formName"]["birthdate"].value;

    validateEmail(email);

    if(fName == ""){
        alert("Du behöver ett förnamn");
        return false;
    }else if(lName == ""){
        alert("Du behöver ett efternamn");
        return false;
    }else if(! validateEmail(email)){
        alert("Skriv in en korrekt epost");
        return false;
    }else if(gdpr.checked != true){
        alert("Du behöver godkänna GDPR");
        return false;
    }else if(terms.checked != true){
        alert("Du behöver godkänna vilkoren");
        return false;
    }else if(birthdate == ""){
        alert("Du behöver ett födelsedatum");
        return false;
    }

   

    function validateEmail(email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log(re.test(String(email).toLowerCase()));
        return re.test(String(email).toLowerCase());
    }
}