$(document).ready(function () {

	switchTab(1);

	$(".form-footer > button").click(function () {

		if (isFormValid($(".form-body"))) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}
	});

	$(document).on("click", ".updateBtn", function () {

		if (isFormValid($(".edit-modal"))) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".modal-foot > input[type=submit]").click();
		}

	});

	$(document).on("selectmenuchange", "#collegeSel", function () 
	{
		$(".selectedCollegeTxt").val($(this).val());
	});

	$(document).on("selectmenuchange", "#editCollegeSel", function () 
	{
		$(".editSelectedCollegeTxt").val($(this).val());
	});

	$("#viewTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "College" },
			{ title: "Action" }
		],

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "College" },
			{ title: "Action" }
		],

	});

	loadDepartmentTable();
	loadArchivedDepartmentTable();
	loadCollege();
	$("#collegeSel").selectmenu();
	$("#editCollegeSel").selectmenu();
	
});

function loadDepartmentTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(departmentsJSON, function (index, department) {

		if (!department.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + department.DepartmentID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.edit-modal')); editItem(" + department.DepartmentID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				department.Title,
				department.Alias,
				(collegeSelectJSON.find(c => c.ID == department.CollegeID).Alias),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedDepartmentTable()
{
	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(departmentsJSON, function (index, department) {

		if (department.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("button-control button-blue");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showModal($('.retrieve-alert')); retrieveItem(" + department.DepartmentID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archiveTable').dataTable().fnAddData([
				department.Title,
				department.Alias,
				(collegeSelectJSON.find(c => c.ID == department.CollegeID).Alias),
				retrieveBtn
			]);
		}

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

function archiveItem(departmentID)
{
	jQuery.each(departmentsJSON, function (index, department) {

		if (departmentID == department.DepartmentID)
		{
			$(".selectedID").val(departmentID);
			$(".archive-alert > span").html(department.Title);
		}

	});
}

function editItem(departmentID)
{
	jQuery.each(departmentsJSON, function (index, department) {

		if (departmentID == department.DepartmentID)
		{
			$(".selectedID").val(departmentID);
			$(".editTitleTxt").val(department.Title);
			$(".editAliasTxt").val(department.Alias);
			$("#editCollegeSel").val(department.CollegeID);
			$("#editCollegeSel").selectmenu("refresh");
			$(".editSelectedCollegeTxt").val(department.CollegeID);
		}

	});
}

function retrieveItem(departmentID)
{
	jQuery.each(departmentsJSON, function (index, department) {

		if (departmentID == department.DepartmentID)
		{
			$(".selectedID").val(departmentID);
			$(".retrieve-alert > span").html(department.Title);
		}

	});
}
