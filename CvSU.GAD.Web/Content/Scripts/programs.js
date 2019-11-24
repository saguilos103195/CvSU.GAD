$(document).ready(function () {

	$(".form-footer > button").click(function () {

		if (isFormValid($(".form-body"))) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}
	});

	$(document).on("click", ".updateBtn", function () {

		if (isFormValid($(".form-modal"))) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".modal-foot > input[type=submit]").click();
		}

	});

	$(document).on("selectmenuchange", "#collegeSel", function () 
	{
		$(".selectedDepartmentTxt").val("");
		loadDepartment($(this).val());
	});

	$(document).on("selectmenuchange", "#departmentSel", function () 
	{
		$(".selectedDepartmentTxt").val($(this).val());
	});

	$(document).on("selectmenuchange", "#editCollegeSel", function () 
	{
		$(".editSelectedDepartmentTxt").val("");
		loadEditDepartment($(this).val());
	});

	$(document).on("selectmenuchange", "#editDepartmentSel", function () 
	{
		$(".editSelectedDepartmentTxt").val($(this).val());
	});


	$("#viewTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Department" },
			{ title: "Action" }
		],

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Department" },
			{ title: "Action" }
		],

	});

	switchTab(1);
	loadCollege();
	loadProgramTable();
	loadArchivedProgramTable();
	$("#collegeSel").selectmenu();
	$("#departmentSel").selectmenu();
	$("#editCollegeSel").selectmenu();
	$("#editDepartmentSel").selectmenu();
});

function loadProgramTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(programsJSON, function (index, program) {

		if (!program.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + program.ProgramID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.form-modal')); editItem(" + program.ProgramID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				program.Title,
				program.Alias,
				(departmentSelectJSON.find(d => d.ID == program.DepartmentID).Alias),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedProgramTable()
{
	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(programsJSON, function (index, program) {

		if (program.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("button-control button-blue");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showModal($('.retrieve-alert')); retrieveItem(" + program.ProgramID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archiveTable').dataTable().fnAddData([
				program.Title,
				program.Alias,
				(departmentSelectJSON.find(d => d.ID == program.DepartmentID).Alias),
				retrieveBtn
			]);
		}

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

function loadEditDepartment(collegeID)
{
	$("#editDepartmentSel").children("option").remove();
	$("#editDepartmentSel").append("<option selected disabled value=''>Select Department</option>");
	jQuery.each(departmentSelectJSON, function (index, item) {

		if (item.CollegeID == collegeID)
		{
			var option = document.createElement("option");
			$(option).html(item.Name);
			$(option).val(item.ID);
			$("#editDepartmentSel").append(option);
		}

	});

	$("#editDepartmentSel").selectmenu("refresh");
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

function archiveItem(programID)
{
	jQuery.each(programsJSON, function (index, program) {

		if (programID == program.ProgramID)
		{
			$(".selectedID").val(programID);
			$(".archive-alert > span").html(program.Title);
		}

	});
}

function editItem(programID)
{
	jQuery.each(programsJSON, function (index, program) {

		if (programID == program.ProgramID)
		{
			$(".selectedID").val(programID);
			$(".editTitleTxt").val(program.Title);
			$(".editAliasTxt").val(program.Alias);

			var department = departmentSelectJSON.find(d => d.ID == program.DepartmentID);
			var college = collegeSelectJSON.find(c => c.ID == department.CollegeID);

			$("#editCollegeSel").val(college.ID);
			$("#editCollegeSel").selectmenu("refresh");

			loadEditDepartment(college.ID);

			$("#editDepartmentSel").val(department.ID);
			$("#editDepartmentSel").selectmenu("refresh");

			$(".editSelectedDepartmentTxt").val(department.ID);
		}
	});
}

function retrieveItem(programID)
{
	jQuery.each(programsJSON, function (index, program) {

		if (programID == program.ProgramID)
		{
			$(".selectedID").val(programID);
			$(".retrieve-alert > span").html(program.Title);
		}

	});
}