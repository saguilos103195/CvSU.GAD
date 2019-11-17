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
		$(".selectedDepartmentTxt").val("");
	});

	$(document).on("selectmenuchange", "#departmentSel", function () 
	{
		$(".selectedDepartmentTxt").val($(this).val());
	});

	$(document).on("selectmenuchange", "#positionSel", function () 
	{
		$(".selectedPositionTxt").val($(this).val());
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
	loadPosition();
	loadSchoolYear();
	loadSDDAta();

});

function loadSDDAta()
{
	$('#viewTable').dataTable().fnClearTable();

	console.log(facultySDJSON);

	jQuery.each(facultySDJSON, function (index, facultySD) {

		var deleteBtn = document.createElement("button");
		$(deleteBtn).attr("type", "button");
		$(deleteBtn).addClass("button-control button-red");
		$(deleteBtn).html("Delete");
		$(deleteBtn).attr("onclick", "showModal($('.archive-alert')); deleteItem(" + facultySD.DisaggregationID + ");");
		deleteBtn = deleteBtn.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			(positionSelectJSON.find(d => d.ID == facultySD.PositionID).Name),
			(departmentSelectJSON.find(d => d.ID == facultySD.DepartmentID).Alias),
			facultySD.MaleQuantity,
			facultySD.FemaleQuantity,
			facultySD.Semester,
			facultySD.SchoolYear,
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

function loadPosition()
{
	jQuery.each(positionSelectJSON, function (index, item) {

		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
		$("#positionSel").append(option);

	});

	$("#positionSel").selectmenu("refresh");
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

function deleteItem(disaggregationID)
{
	jQuery.each(studentSDJSON, function (index, studentSD) {

		if (disaggregationID == studentSD.DisaggregationID)
		{
			$(".selectedID").val(disaggregationID);
			$(".archive-alert > span").html((programSelectJSON.find(p => p.ID == studentSD.ProgramID)).Alias + " " +
				studentSD.Semester + " Semester SY " + studentSD.SchoolYear);
		}

	});
}