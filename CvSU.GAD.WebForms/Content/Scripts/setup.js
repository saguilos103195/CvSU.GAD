var currentStep = 0;
var educCount = 1;

$(document).ready(function () {

    $(document).on("click", "#personalInfoBtn", function () {

        if (isFormValid($("#pills-personal")))
        {
            currentStep++
            setWizardPage();
        }

    });

    $(document).on("click", "#contactInfoBtn", function () {

        if (isFormValid($("#pills-contact"))) {
            currentStep++
            setWizardPage();
        }

    });

    $(document).on("click", "#additionalInfoBtn", function () {

        if (isFormValid($("#pills-additional"))) {
            currentStep++
            setWizardPage();
        }

    });

    $(document).on("click", ".deleteEducBtn", function () {

        $(this).closest(".educItem").remove();
        
    });

    $(document).on("click", "#addEducBtn", function () {

        educCount++;
        var educItem = $("#educItemTemplate").clone();
        educItem.removeClass("d-none");
        educItem.removeAttr("id");


        var schoolName = educItem.find(".schoolName")[0];
        $(schoolName).attr("aria-describedby", "schoolNameError" + educCount);
        var schoolNameError = educItem.find("#schoolNameError")[0];
        $(schoolNameError).attr("id", "schoolNameError" + educCount);

        var schoolCourse = educItem.find(".schoolCourse")[0];
        $(schoolCourse).attr("aria-describedby", "courseError" + educCount);
        var schoolCourseError = educItem.find("#courseError")[0];
        $(schoolCourseError).attr("id", "courseError" + educCount);

        var schoolLevel = educItem.find(".schoolLevel")[0];
        $(schoolLevel).attr("aria-describedby", "levelError" + educCount);
        var schoolLevelError = educItem.find("#levelError")[0];
        $(schoolLevelError).attr("id", "levelError" + educCount);

        var schoolDateFrom = educItem.find(".schoolDateFrom")[0];
        $(schoolDateFrom).attr("aria-describedby", "dateFromError" + educCount);
        var schoolDateFromError = educItem.find("#dateFromError")[0];
        $(schoolDateFromError).attr("id", "dateFromError" + educCount);

        var schoolDateTo = educItem.find(".schoolDateTo")[0];
        $(schoolDateTo).attr("aria-describedby", "dateToError" + educCount);
        var schoolDateToError = educItem.find("#dateToError")[0];
        $(schoolDateToError).attr("id", "dateToError" + educCount);

        $("#educationContainer").append(educItem[0].outerHTML);

    });

    $(document).on("click", "#submitBtn", function () {


        if (isFormValid($("#pills-educational"))) {

            serializeEducationList();
            commandClick("submitBtn");
        }

    });

    $(document).on("click", ".prevBtn", function () {

        currentStep--
        setWizardPage();

    });

});

function serializeEducationList()
{
    var educArray = [];

    $("#educationContainer").children(".educItem").each(function () {

        var educItem = {};
        educItem.SchoolName = $(this).find(".schoolName").val();
        educItem.Course = $(this).find(".schoolCourse").val();
        educItem.EducationalLevel = $(this).find(".schoolLevel").val();
        educItem.DateFrom = $(this).find(".schoolDateFrom").val();
        educItem.DateTo = $(this).find(".schoolDateTo").val();

        educArray.push(educItem);
    });

    $(".educListJson").val(JSON.stringify(educArray));
}

function setWizardPage()
{
    $("#navPills").find(".nav-link").each(function () {

        $(this).removeClass("active");
        $(this).removeClass("disabled btn-secondary text-white");
        $(this).addClass("disabled btn-secondary text-white");

    });

    var currentTab = $("#navPills").find(".nav-link")[currentStep];
    $(currentTab).removeClass("disabled btn-secondary text-white");
    $(currentTab).addClass("active");

    $("#pills-tabContent").children(".tab-pane").each(function () {

        $(this).removeClass("active");

    });

    var currentPage = $("#pills-tabContent").children(".tab-pane")[currentStep];
    $(currentPage).addClass("active");
}

