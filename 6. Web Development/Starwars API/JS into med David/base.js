const btn = document.querySelector(".btn");


btn.addEventListener("click", async function(){
    const getApi = await fetch("http://swapi.dev/api/people/");
    const jsonData = await getApi.json();
    console.log(jsonData);

    const personList = document.querySelector(".content")


    for (let persons of jsonData.results){
        console.log(persons.name);
        let li =  document.createElement("li");
        li.className = persons.name.trim(" ");
            li.innerText = persons.name;
            personList.append(li);
       
        
    }
    const liEvent = document.querySelectorAll("li").forEach(el => {
        el.addEventListener("click", function(){
            console.log(el.innerText);
            for (let persons of jsonData.results){
                if(persons.name == el.innerText){
                    document.querySelector(".homeworld").innerText = persons.homeworld;
                }
            }
        })
    });

    /*liEvent.addEventListener("click", async function(){
        const name = document.querySelectorAll("li");
        console.log(name);
    })*/

})

