var app = new Vue(
    {
        el: '#app',
        data: {
            pizzaImg: '',
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

            getPizzaImage() {
                axios.get('https://foodish-api.herokuapp.com/api/images/pizza').then(res =>
                {
                    this.pizzaImg = res.data;
                    //console.log(res.data)
                    //console.log(this.pizzaImg.image)   
                   
                })
                    .catch(err => console.log(err))
                return this.pizzaImg.image
            },

            deletePizza(name) {
                this.pizzaz = this.pizzaz.filter(function (obj) {
                    return obj.name !== name;
                })
            },
        }
    }
)