let search ="";
const protcol = "https://"
const urlName = 'www.flickr.com/'
const path = "services/"
const query = "rest/?method=flickr.photos.search&"
const apiKey = "api_key=8ed52e76b5c4ab1bec78c9e13fbd3f60"
const query2 = "&sort=relevance&per_page=9&format=json&nojsoncallback=1"


//


const btn = document.querySelector(".btn")

btn.addEventListener("click", async function(){
    let search = document.querySelector("#search").value
    
    if(search == "")
    {
        alert("FÅR INTE VARA TOM")
    }
    else
    {
        let searchPath ="&text=" + search
        let url = `${protcol}${urlName}${path}${query}${apiKey}${searchPath}${query2}`
        const response = await fetch(url)
        const data = await response.json()
        generateIMG(data.photos.photo);
        
    }
});

function generateIMG(data){
    
    removePhotos("newImg")

    for(let i = 0; i < data.length; i++){
        const farmID = data[i].farm;
        const serverID = data[i].server;
        const id = data[i].id;
        const secret = data[i].secret;
        const imgUrl = `https://live.staticflickr.com/${serverID}/${id}_${secret}_z.jpg`
        const addImg = document.querySelector(".images");

        if(i == 0){
            const topImg = document.createElement("section");
            topImg.className = "topImg"
            topImg.style.backgroundImage = "url(" + imgUrl + ")"
            addImg.append(topImg);
        }else{
            const newImg = document.createElement("section");
            newImg.className = "newImg"
            newImg.style.backgroundImage = "url(" + imgUrl + ")"
            addImg.append(newImg);
        }
    }
}

function removePhotos(className){
    const elements = document.getElementsByClassName(className);
    console.log(elements)
    while(elements.length > 0){
        elements[0].parentNode.removeChild(elements[0]);
    }
}