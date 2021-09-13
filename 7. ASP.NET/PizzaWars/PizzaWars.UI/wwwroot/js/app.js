var app = new Vue(
    {
        el: '#app',
        data: {
            pizzaImg: '',
            pizzaz: [],
            response: '',
            image: ''
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

            

            //getFromApi() {
            //    //let test = [];
            //    //let a = axios.get('https://foodish-api.herokuapp.com/api/images/pizza').then(res =>
            //    //{
            //    //    test.push(res.data)
            //    //    this.image = test[0].image
                
            //    //    /*this.pizzaImg = res.data;*/
            //    //}).catch(err => console.log(err))

            //    // create a promise for the axios request
            //    const promise = axios.get('https://foodish-api.herokuapp.com/api/images/pizza')

            //    // using .then, create a new promise which extracts the data
            //    const dataPromise = promise.then((response) => response.data)


            //    return dataPromise
            //    console.log(dataPromise)


            //},

            //getImg() {
            //    this.getFromApi()
            //        .then(data => {
            //            response.json({ message: 'Request received!', data })
            //        })
            //        .catch(err => console.log(err))
            //},

            deletePizza(name) {
                this.pizzaz = this.pizzaz.filter(function (obj) {
                    return obj.name !== name;
                })
            },
        }
    }
)