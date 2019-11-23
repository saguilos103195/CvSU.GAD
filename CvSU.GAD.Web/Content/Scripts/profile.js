﻿$(document).ready(function() {

	$(".profile-tab > button").click(function () {

		if (isFormValid($(".profile-tab")))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".profile-tab > input[type=submit]").click();
		}

	});

	$(".educModalBtn").click(function () {

		console.log("input[type=submit]:contains('" + $(this).html() + "')");

		if (isFormValid($(".educ-modal")))
		{
			//$(this).css("pointer-events", "none");
			//$(this).css("opacity", ".9");
			
			$("input[type=submit]:contains('" + $(this).html() + "')").click();
		}


	});

	$(".bdateTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});
	$('.bdateTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.bdateTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".engagedFromTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true,
		onSelect: function (date) { $(".engagedToTxt").datepicker("option", "minDate", date); }
	});
	$('.engagedFromTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.engagedFromTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".engagedToTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});
	$('.engagedToTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.engagedToTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".educDateFromTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true,
		onSelect: function (date) { $(".educDateToTxt").datepicker("option", "minDate", date); }
	});
	$('.educDateFromTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.educDateFromTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".educDateToTxt").datepicker({
		dateFormat: 'dd/mm/yy',
		changeMonth: true,
		changeYear: true
	});
	$('.educDateToTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.educDateToTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	loadAdminTemplateInfo();
	loadProfile();
	switchTab(0);
	$(".select-control").selectmenu();

});

function loadProfile()
{
	console.log(profileJSON);
	$(".profileID").val(profileJSON.ProfileID);
	$(".fnameTxt").val(profileJSON.Firstname);
	$(".mnameTxt").val(profileJSON.Middlename);
	$(".lnameTxt").val(profileJSON.Lastname);
	$(".bdateTxt").val(moment(profileJSON.Birthdate).format("DD/MM/YYYY"));
	$(".religionTxt").val(profileJSON.Religion);
	$(".cellphoneTxt").val(profileJSON.CellphoneNumber);
	$(".telephoneTxt").val(profileJSON.TelephoneNumber);
	$(".emailTxt").val(profileJSON.EmailAddress);
	$(".lnameTxt").val(profileJSON.Lastname);
	$(".addressTxt").val(profileJSON.Address);
	$(".designationTxt").val(profileJSON.Designation);
	$(".officeAddressTxt").val(profileJSON.OfficeAddress);
	$(".engagedFromTxt").val( moment(profileJSON.EngagedFrom).format("DD/MM/YYYY"));
	$(".engagedToTxt").val(moment(profileJSON.EngagedTo).format("DD/MM/YYYY"));
	$(".willingChkBox").attr("checked", profileJSON.WillTravel);

	if (profileJSON.Educations.length > 0 && profileJSON.Educations != null)
	{
		loadEducation();
	}
}

function loadEducation()
{
	jQuery.each(profileJSON.Educations, function (index, education) {

		$(".educ-list").append("<div onclick='showModal(\".educ-modal\"); updateEducation(" + education.EducationID + ");'>" +
									"<label>" + moment(education.DateFrom).format("DD/MM/YYYY") + " - " +  moment(education.DateTo).format("DD/MM/YYYY") + "</label>" +
									"<h5>" + education.Course + "</h5>" +
									"<p>" + education.SchoolName + "</p>" +
									"<span>" + education.EducationalLevel + "</span>" +
								"</div>");

	});
}

function addEducation()
{
	$(".modal-head > span").html("Add Education");
	$(".educModalBtn").html("Add");
}

function updateEducation(educationID)
{
	$(".modal-head > span").html("Update Education");
	$(".educModalBtn").html("Update");

	var education = profileJSON.Educations.find(e => e.EducationID == educationID);

	$(".selectedID").val(education.EducationID);
	$(".educSchoolNameTxt").val(education.SchoolName);
	$(".educCourseTxt").val(education.Course);
	$(".educTypeSel").val(education.EducationalLevel);
	$(".educTypeSel").selectmenu("refresh");
	$(".educDateFromTxt").val(moment(education.DateFrom).format("DD/MM/YYYY"));
	$(".educDateToTxt").val(moment(education.DateTo).format("DD/MM/YYYY"));
	
}