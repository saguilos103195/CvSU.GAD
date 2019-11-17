$(document).ready(function () {

	$(".form-footer > button").click(function () {

		if (isFormValid($(".form-body"))) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}
	});

	$(document).on("selectmenuchange", "#collegeSel", function () 
	{
		loadDepartment($(this).val());
		loadProgram(0);
		$(".selectedDepartmentTxt").val("");
		$(".selectedProgramTxt").val("");
	});

	$(document).on("selectmenuchange", "#departmentSel", function () 
	{
		$(".selectedDepartmentTxt").val($(this).val());
		loadProgram($(this).val());
	});

	$(document).on("selectmenuchange", "#programSel", function () 
	{
		$(".selectedProgramTxt").val($(this).val());
	});

	$(document).on("selectmenuchange", "#schoolYearSel", function () 
	{
		$(".schoolYearTxt").val($(this).val());
	});

	$("#viewTable").DataTable({

		columns: [
			{ title: "Program" },
			{ title: "Department" },
			{ title: "Male" },
			{ title: "Female" },
			{ title: "Semester" },
			{ title: "School Year" },
			{ title: "Action" }
		]

	});

	switchTab(0);
	$(".select-control").selectmenu();
	loadCollege();
	loadSchoolYear();
	loadSDDAta();

});

function loadSDDAta()
{
	console.log(studentSDJSON);

	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(studentSDJSON, function (index, studentSD) {

		var deleteBtn = document.createElement("button");
		$(deleteBtn).attr("type", "button");
		$(deleteBtn).addClass("button-control button-red");
		$(deleteBtn).html("Delete");
		$(deleteBtn).attr("onclick", "showModal($('.archive-alert')); deleteItem(" + studentSD.DissagregationID + ");");
		deleteBtn = deleteBtn.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			(programSelectJSON.find(d => d.ID == studentSD.ProgramID).Name),
			(departmentSelectJSON.find(d => d.ID == studentSD.DepartmentID).Alias),
			studentSD.MaleQuantity,
			studentSD.FemaleQuantity,
			studentSD.Semester,
			studentSD.SchoolYear,
			deleteBtn
		]);
	});
}

function loadCollege()
{
	jQuery.each(collegeSelectJSON, function (index, item) {
		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
		$("#collegeSel").append(option);
	});

	jQuery.each(collegeSelectJSON, function (index, item) {
		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
		$("#editCollegeSel").append(option);
	});
}

function loadDepartment(collegeID)
{
	$("#departmentSel").children("option").remove();
	$("#departmentSel").append("<option selected disabled value=''>Select Department</option>");
	jQuery.each(departmentSelectJSON, function (index, item) {

		if (item.CollegeID == collegeID)
		{
			var option = document.createElement("option");
			$(option).html(item.Name);
			$(option).val(item.ID);
			$("#departmentSel").append(option);
		}

	});

	$("#departmentSel").selectmenu("refresh");
}

function loadProgram(departmentID)
{
	$("#programSel").children("option").remove();
	$("#programSel").append("<option selected disabled value=''>Select Program/Course</option>");
	jQuery.each(programSelectJSON, function (index, item) {

		if (item.DepartmentID == departmentID)
		{
			var option = document.createElement("option");
			$(option).html(item.Name);
			$(option).val(item.ID);
			$("#programSel").append(option);
		}

	});

	$("#programSel").selectmenu("refresh");
}

function loadSchoolYear()
{
	var currentYear = new Date().getFullYear();
	for (start = currentYear; start > currentYear - 20; start--)
	{
		var end = start + 1;
		var option = document.createElement("option");
		$(option).html(start + "-" + end);
		$("#schoolYearSel").append(option);
	}
	$("#schoolYearSel").selectmenu("refresh");
}