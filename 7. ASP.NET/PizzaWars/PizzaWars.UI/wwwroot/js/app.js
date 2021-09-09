var app = new Vue(
    {
        el: '#app',
        data: {
            pizzaImg: '',
            pizzaz: [],
            response: ''
        },
        mounted() {
            this.getPizzaz()
        },
        methods: {

            getPizzaz() {
                axios.get('/Home/Pizzas').then(res => {
                    this.pizzaz = res.data;
                })
                    .catch(err => console.log(err))
            },

            getFromApi() {
                axios.get('https://foodish-api.herokuapp.com/api/images/pizza').then(res =>
                {
                    this.pizzaImg = res.data;
                    console.log(this.pizzaImg.image)
                    //let img = res.data.image
                    //console.log(img)
                    //return this.img
                })
                    .catch(err => console.log(err))
                return this.pizzaImg.image
            },

            deletePizza(name) {
                this.pizzaz = this.pizzaz.filter(function (obj) {
                    return obj.name !== name;
                })
            },

            async  axiosTest() {
                response = await axios.get('https://foodish-api.herokuapp.com/api/images/pizza')
                console.log(response.data.image)
                return response.data.image
            }

        }
    }
)