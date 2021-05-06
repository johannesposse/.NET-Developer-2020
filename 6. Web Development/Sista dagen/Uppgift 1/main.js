const btn = document.querySelector(".btn")
btn.addEventListener("click",async function(){
    const respons = await fetch("https://swapi.dev/api/people/1/")
    const data = await respons.json()

    const arcivle = document.querySelector("article")

    let str = `
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    <p>${data.name}</p>
    `

    const eyeColorP = document.querySelector(".eye-color")
    const nameP = document.querySelector(".name")
    const heightP = document.querySelector(".height")
    const massP = document.querySelector(".mass")
    const filmList = document.querySelector(".films")

    nameP.innerText = data.name
    eyeColorP.innerText =data.eye_color
    heightP.innerText = data.height
    massP.innerText = data.mass

    for(let film of data.films){
        const li  = document.createElement("li")
        li.innerText = film
        filmList.append(li)
    }
})