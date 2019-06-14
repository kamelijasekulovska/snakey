import Vue from "vue";
import FirstComponent from "../FirstComponent.vue";
import SecondComponent from "../SecondComponent.vue"

var vm = new Vue({
    el: "#nt-page-home",
    components: {
        FirstComponent,
        SecondComponent
    }
});

