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
                let test = [];
                axios.get('https://foodish-api.herokuapp.com/api/images/pizza').then(res =>
                {
                    test.push(res.data)
                    console.log(test[0].image)
                    /*console.log(test)*/
                    /*this.pizzaImg = res.data;*/
                }).catch(err => console.log(err))

                    return test.image
                //let test2 = test.image
                //console.log(test2)
                console.log(test)
               /* return test[test.length -1]*/

            },

            deletePizza(name) {
                this.pizzaz = this.pizzaz.filter(function (obj) {
                    return obj.name !== name;
                })
            },
        }
    }
)