let images = [
    "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1440&q=80",
    "https://images.unsplash.com/photo-1497436072909-60f360e1d4b1?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80",
    "https://images.unsplash.com/photo-1470770903676-69b98201ea1c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1350&q=80",
    "https://images.unsplash.com/photo-1431794062232-2a99a5431c6c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1350&q=80",
    "https://images.unsplash.com/photo-1523712999610-f77fbcfc3843?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"];
    
    let time = 2000; //standardtid

    changeSlide();


    function sleep(ms){
        return new Promise(resolve => setTimeout(resolve,ms));
    }
    
    async function changeSlide(){
        let startSlideCookie = document.cookie.split(";",);
        console.log(startSlideCookie);
        let cookieSlide;
        let isCookie = false;

        for(let j = 0; j < startSlideCookie.length; j++){
            if(startSlideCookie[j].includes(" startSlide")){
                cookieSlide = startSlideCookie[j].split("=");
                console.log(cookieSlide[1]);
            }
        }

        for (let i = 0; i <= images.length; i++){
            if(i >= images.length){i = 0}
            if(!isCookie) {i = cookieSlide[1]; isCookie = true}
            document.getElementsByClassName("slide")[0].style.backgroundImage = "url(" + images[i] + ")";
            document.cookie = "startSlide = " + i;
            await sleep(time);
        }
    }
    
    function setTime(){
        time = document.getElementById("speed").value;
    }