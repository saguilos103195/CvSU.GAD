$(document).ready(function () {

    $("#collapseProjects").parent(".nav-item").addClass("active");
    $("#applyProjectsTab").addClass("active");

    $("#createBtn").click(function () {

        if (isFormValid($(".form")))
        {
            commandClick("createBtn");
        }

    });


});