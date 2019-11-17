var educCount = 1;

$(document).ready(function () {

    $(".setup-content").steps({
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
        },
        onStepChanging: function () {

			return isFormValid($(".wizard .content .current"));
        },
        onFinishing: function () {

			return isFormValid($(".wizard .content .current"));
        },
		onFinished: function (event, currentIndex) {
			$(".setup > input[type=hidden]").val(JSON.stringify(ProcessModel("EducationList", 0).EducationalAttainments));
			$(".setup > input[type=submit]").click();

        }
    });

	$(".select-control").selectmenu();
	$(".birthDateTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});
	$('.birthDateTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$(".engageFromTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true,
		onSelect: function (date) { $(".engageToTxt").datepicker("option", "minDate", date); }
	});
	$('.engageFromTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$(".engageToTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});
	$('.engageToTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});

	$("#educationList .inclusiveDateFromTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true,
		onSelect: function (date) { $("#educationList .inclusiveDateToTxt").datepicker("option", "minDate", date); }
	});
	$("#educationList .inclusiveDateToTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});


});

function addEducationalAttainment()
{
	var educTemplate = $(".template.education-item").clone();
	educTemplate.attr("item", educCount);
	educTemplate.removeClass("template");
	educTemplate.find(".select-control").next().remove();
	educTemplate.find(".select-control").selectmenu();
	$("#educationList").append(educTemplate);
	educTemplate.find(".inclusiveDateFromTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		onSelect: function (date) { educTemplate.find(".inclusiveDateToTxt").datepicker("option", "minDate", date); }
	});
	educTemplate.find(".inclusiveDateToTxt").datepicker({
		dateFormat: 'dd/mm/yy',
	});
	educCount++;
}

function removeEducationalAttainment(element)
{
	var container = $(element).parent().parent();
	$(element).parent().remove();
	var counter = 0;
	container.children(".education-item").each(function () {

		$(this).attr("item", counter);

		counter++;
	});

	educCount = counter;
}