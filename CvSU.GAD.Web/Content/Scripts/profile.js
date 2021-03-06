﻿$(document).ready(function() {

	$(".profile-tab > button").click(function () {

		if (isFormValid($(".profile-tab")))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".profile-tab > input[type=submit]").click();
		}

	});

	$(".settings-tab > button").click(function () {

		if (isFormValid($(".settings-tab")) & isMatched($(".passwordTxt"), $(".confirmPasswordTxt"), "Password did not match."))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".settings-tab > input[type=submit]").click();
		}

	});

	$(".educModalBtn").click(function () {

		if (isFormValid($(".educ-modal")))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".educ-modal .modal-foot > input[value='" + $(this).html() + "']").click();
		}
	});

	$(".seminarModalBtn").click(function () {

		if (isFormValid($(".seminar-modal")))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".seminar-modal .modal-foot > input[value='" + $(this).html() + "']").click();
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

	loadProfile();
	switchTab(0);
	$(".select-control").selectmenu();

});

function uploadProfilePicture()
{
	$(".profile-pic > input[type=submit]").click();
}

function loadProfile()
{
	console.log(profileJSON);
	$("#profilePicture").css("background", "url(" + (profileJSON.Image != null ? "data:image/png;base64," + profileJSON.Image : profileJSON.Gender == "Male" ? "../Content/Images/male.png" : "../Content/Images/female.png" ) + ")");

	var middleInitial = "";

	if (profileJSON.Middlename != "" || profileJSON.Middlename != null)
	{
		middleInitial = profileJSON.Middlename.charAt(0) + ".";
    }

	$("#fullNameProfileTxt").html(profileJSON.Firstname + " " + middleInitial + " " + profileJSON.Lastname);
	$("#positionProfileTxt").html(profileJSON.Account.Type);
	$("#genderProfileTxt").html(profileJSON.Gender);
	$("#emailProfileTxt").html(profileJSON.EmailAddress);
	$("#cpNoProfileTxt").html(profileJSON.CellphoneNumber);
	$("#addressProfileTxt").html(profileJSON.Address);

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

	if (profileJSON.Seminars.length > 0 && profileJSON.Seminars != null)
	{
		loadSeminar();
	}
}

function loadSeminar()
{
	jQuery.each(profileJSON.Seminars.sort(compareValues('Status')), function (index, seminar) {

		$(".seminarList").append("<div onclick='showModal(\".seminar-modal\"); updateSeminar(" + seminar.SeminarID + ");'>" +
			"<label>" + seminar.Year + "</label>" +
			"<h5>" + seminar.Name + "</h5>" +
			"<p class='seminar-" + seminar.Status.toLowerCase() + "'>" + seminar.Status + "</p>" +
			"</div>");

	});
}

function loadEducation()
{
	jQuery.each(profileJSON.Educations, function (index, education) {

		$(".educList").append("<div onclick='showModal(\".educ-modal\"); updateEducation(" + education.EducationID + ");'>" +
									"<label>" + moment(education.DateFrom).format("DD/MM/YYYY") + " - " +  moment(education.DateTo).format("DD/MM/YYYY") + "</label>" +
									"<h5>" + education.Course + "</h5>" +
									"<p>" + education.SchoolName + "</p>" +
									"<span>" + education.EducationalLevel + "</span>" +
								"</div>");

	});
}

function addEducation()
{
	$(".educ-modal .modal-head > span").html("Add Education");
	$(".educModalBtn").html("Add");
}

function updateEducation(educationID)
{
	$(".educ-modal .modal-head > span").html("Update Education");
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

function addSeminar()
{
	$(".seminar-modal .modal-head > span").html("Add Seminar");
	$(".seminarModalBtn").html("Add");
}

function updateSeminar(seminarID)
{
	$(".seminar-modal .modal-head > span").html("Update Education");
	$(".seminarModalBtn").html("Update");

	var seminar = profileJSON.Seminars.find(s => s.SeminarID == seminarID);
	$(".selectedID").val(seminar.SeminarID);
	$(".seminarNameTxt").val(seminar.Name);
	$(".seminarYearTxt").val(seminar.Year);
	
}
