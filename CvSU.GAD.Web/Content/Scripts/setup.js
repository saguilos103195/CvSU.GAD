$(document).ready(function () {

    $(".setup-body").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: 1,
        transitionEffectSpeed: 200,

        titleTemplate: '<span class="number">#index#</span>#title#',
        labels: {
            cancel: "Cancel",
            current: "",
            pagination: "Pagination",
            finish: "Finish",
            next: "Next",
            previous: "Previous",
            loading: "Loading ..."
        }
        //onStepChanging: function (event, currentIndex, newIndex) {
        //    form.validate().settings.ignore = ":disabled,:hidden";
        //    return form.valid();
        //},
        //onFinishing: function (event, currentIndex) {
        //    form.validate().settings.ignore = ":disabled";
        //    return form.valid();
        //},
        //onFinished: function (event, currentIndex) {
        //    alert("Submitted!");
        //}
    });

});