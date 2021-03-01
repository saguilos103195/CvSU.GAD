$(document).ready(function () {

	loadEducation();
	loadSeminar();

	$("#updateProfileBtn").click(function () {

		if (isFormValid($("#basicInfoForm")))
		{
			commandClick("updateProfileBtn")
        }

	});

	$("#addEducBtn").click(function () {

		if (isFormValid($("#educationForm")))
		{
			commandClick("addEducBtn")
        }

	});

	$("#editEducBtn").click(function () {

		if (isFormValid($("#educationForm")))
		{
			commandClick("editEducBtn")
        }

	});

	$("#addSeminarBtn").click(function () {

		if (isFormValid($("#seminarForm")))
		{
			commandClick("addSeminarBtn")
        }

	});

	$("#editSeminarBtn").click(function () {

		if (isFormValid($("#seminarForm")))
		{
			commandClick("editSeminarBtn")
        }

	});

	$("#updatePasswordBtn").click(function () {

		if (isFormValid($("#settingsForm")) & isPasswordValid())
		{
			commandClick("updatePasswordBtn")
		}

	});

});

function loadEducation()
{
	if (profileJSON.Educations.length > 0 && profileJSON.Educations != null)
	{
		jQuery.each(profileJSON.Educations, function (index, education) {

			var educItem = document.createElement("button");
			$(educItem).addClass("list-group-item list-group-item-action");
			$(educItem).attr("type", "button")
			$(educItem).attr("onclick", "showEducModal(" + education.EducationID + ")");

			var educDate = document.createElement("div");
			$(educDate).addClass("text-right small text-muted");
			$(educDate).html(moment(education.DateFrom).format("MM/DD/YYYY") + " - " + moment(education.DateTo).format("MM/DD/YYYY"));

			var educCourse = document.createElement("div");
			$(educCourse).addClass("text-primary");
			$(educCourse).html(education.Course);

			var educSchool = document.createElement("div");
			$(educSchool).addClass("small");
			$(educSchool).html(education.SchoolName);

			var educLevel = document.createElement("div");
			$(educLevel).addClass("small text-muted");
			$(educLevel).html(education.EducationalLevel);

			$(educItem).append(educDate);
			$(educItem).append(educCourse);
			$(educItem).append(educSchool);
			$(educItem).append(educLevel);

			$("#educList").append(educItem);

		});
	}
}

function loadSeminar()
{
	if (profileJSON.Seminars.length > 0 && profileJSON.Seminars != null)
	{
		jQuery.each(profileJSON.Seminars, function (index, seminar) {

			var seminarItem = document.createElement("button");
			$(seminarItem).addClass("list-group-item list-group-item-action");
			$(seminarItem).attr("type", "button")
			$(seminarItem).attr("onclick", "showSeminarModal(" + seminar.SeminarID + ")")

			var seminarDate = document.createElement("div");
			$(seminarDate).addClass("text-right small text-muted");
			$(seminarDate).html(seminar.Year);

			var seminarTitle = document.createElement("div");
			$(seminarTitle).html(seminar.Name);

			var seminarStatus = document.createElement("div");
			$(seminarStatus).addClass("small pb-3");
			$(seminarStatus).html(seminar.Status);

			switch (seminar.Status)
			{
				case "Approved":
					$(seminarStatus).addClass("text-primary");
					break;
				case "Pending":
					$(seminarStatus).addClass("text-warning");
					break;
				case "Rejected":
					$(seminarStatus).addClass("text-danger");
					break;
                default:
            }

			$(seminarItem).append(seminarDate);
			$(seminarItem).append(seminarTitle);
			$(seminarItem).append(seminarStatus);

			$("#seminarList").append(seminarItem);

		});
	}
}

function showSeminarModal(id)
{
	$("#editSeminarBtn").removeClass("d-none");
	$("#addSeminarBtn").removeClass("d-none");

	$("#seminarModal .is-invalid").each(function (item, index) {

		$(this).removeClass("is-invalid");

	});

	if (id == 0 || id == null)
	{
		$("#seminarModalTitle").html("Add Seminar");
		$(".selectedID").val("");
		$(".txtSeminarName").val("");
		$(".txtSeminarYear").val("");

		$("#editSeminarBtn").addClass("d-none");
	}
	else
	{
		$("#seminarModalTitle").html("Edit Seminar");
		var seminar = profileJSON.Seminars.find(s => s.SeminarID == id);
		$(".selectedID").val(seminar.SeminarID);
		$(".txtSeminarName").val(seminar.Name);
		$(".txtSeminarYear").val(seminar.Year);

		$("#addSeminarBtn").addClass("d-none");
	}

	$("#seminarModal").modal("show");
}

function hideSeminarModal()
{
	$("#seminarModalTitle").html("");
	$(".selectedID").val("");
	$(".txtSeminarName").val("");
	$(".txtSeminarYear").val("");

	$("#seminarModal").modal("hide");
}

function showEducModal(id)
{
	$("#editEducBtn").removeClass("d-none");
	$("#addEducBtn").removeClass("d-none");

	$("#educationModal .is-invalid").each(function (item, index) {

		$(this).removeClass("is-invalid");

	});

	if (id == 0 || id == null)
	{
		$("#educationModalTitle").html("Add Education");
		$(".selectedID").val("");
		$(".txtSchoolName").val("");
		$(".txtSchoolCourse").val("");
		$(".selectSchoolType").val("");
		$(".txtSchoolDateFrom").val("");
		$(".txtSchoolDateTo").val("");

		$("#editEducBtn").addClass("d-none");
	}
    else {

		var education = profileJSON.Educations.find(e => e.EducationID == id);

		$("#educationModalTitle").html("Edit Education");
		$(".selectedID").val(education.EducationID);
		$(".txtSchoolName").val(education.SchoolName);
		$(".txtSchoolCourse").val(education.Course);
		$(".selectSchoolType").val(education.EducationalLevel);
		$(".txtSchoolDateFrom").val(moment(education.DateFrom).format("YYYY-MM-DD"));
		$(".txtSchoolDateTo").val(moment(education.DateTo).format("YYYY-MM-DD"));

		$("#addEducBtn").addClass("d-none");
    }

	$("#educationModal").modal("show");
}

function hideEducModal()
{
	$("#educationModalTitle").html("");
	$(".selectedID").val("");
	$(".txtSchoolName").val("");
	$(".txtSchoolCourse").val("");
	$(".selectSchoolType").val("");
	$(".txtSchoolDateFrom").val("");
	$(".txtSchoolDateTo").val("");

	$("#educationModal").modal("hide");
}

function isPasswordValid()
{
    var isValid = true;

    if ($(".txtPassword").val().length > 0)
    {
        if ($(".txtPassword").val().length < 8)
        {
            console.log("Password weak.");
            $("#passwordError").html("Passwords too weak.");
            $(".txtPassword").addClass("is-invalid");
            isValid = false;
        }
        else
        {
            $("#passwordError").html("This field is required.");
            $(".txtPassword").removeClass("is-invalid");

            if ($(".txtPassword").val() != $(".txtConfirmPassword").val())
            {
                console.log("Passwords not match.");
                $("#confirmPasswordError").html("Passwords did not match.");
                $(".txtConfirmPassword").addClass("is-invalid");
                var isValid = false;
            }
            else
            {
                $("#confirmPasswordError").html("This field is required.");
                $(".txtConfirmPassword").removeClass("is-invalid");
            }
        }
    }

    return isValid;
}