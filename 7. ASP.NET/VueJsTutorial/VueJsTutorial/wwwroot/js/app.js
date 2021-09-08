var app = new Vue(
    {
        el: '#app',
        data: {
            message: 'Kom igen då Britt-Marie. Kör för Fa-an!',
            showMessage: false,
            counter: 0,
            pizzaz: []
        },
        mounted() {
            this.getData()
        },
        methods: {
            getData() {
                axios.get('/Admin/Pizzas').then(res => { this.pizzaz = res.data })
                    .catch(err => console.log(err))
            },
            deletePizza(name) {
                this.pizzaz = this.pizzaz.filter(function (obj) {
                    return obj.name !== name;
                })
            },
            changeMessage() {
                this.message = 'Hepp'
            },
            toggleMessage() {
                this.showMessage = !this.showMessage;
            },
            count() {
                this.counter++;
            }
        }
    }
)