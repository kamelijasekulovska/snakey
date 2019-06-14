import Vue from "vue";
import FirstComponent from "../FirstComponent.vue";
import SecondComponent from "../SecondComponent.vue"

var vm = new Vue({
    el: "#snakey",
    components: {
        FirstComponent,
        SecondComponent
    }
});

