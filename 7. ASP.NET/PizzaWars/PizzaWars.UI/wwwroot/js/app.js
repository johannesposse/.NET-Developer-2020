var app = new Vue(
    {
        el: '#app',
        data: {
            //image: '',
            //pizzaImg: ''
            pizzaz: []
        },
        mounted() {
            this.getPizzaz()
        },
        methods: {

            getPizzaz() {
                axios.get('/Home/Pizzas').then(res => {
                    this.pizzaz = res.data
                    console.log(res.data)
                })
                    .catch(err => console.log(err))
            },

            //sendPizzaImage: function() {
            //    axios({
            //        method: 'post',
            //        url: '/home/pizza',
            //        data: {
            //            "image": this.pizzaImg
            //        }
            //    })
            //        .then(function (response) {

            //            console.log(response)
            //        })
            //        .catch(function (error) {
            //            console.log(error)
            //        })
            //},

            //getPizzaImage() {
            //    axios.get('https://foodish-api.herokuapp.com/api/images/pizza').then(res =>
            //    {
            //        this.pizzaImg = res.data;
            //        this.sendPizzaImage();
            //        console.log(res.data);
            //    })
            //        .catch(err => console.log(err))                
            //}
        }
    }
)