$(document).ready(function () {

	$("#collapseDocuments").parent(".nav-item").addClass("active");
	$("#departmentsDocumentsTab").addClass("active");

	loadDepartmentTable();
	loadArchivedDepartmentTable();

	$("#createBtn").click(function () {

		if (isFormValid($(".form")))
		{
			console.log($(".selectCollege").val());
			commandClick("createBtn")
        }

	});

	$("#editBtn").click(function () {

		if (isFormValid($(".form-modal")))
		{
			commandClick("editBtn")
        }

	});

});

function showArchiveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to archive " + departmentsJSON.find(d => d.DepartmentID == id).Title + "?", "executeArchive");
}

function executeArchive(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("archiveBtn");
    }
}

function showRetrieveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to retrieve " + departmentsJSON.find(d => d.DepartmentID == id).Title + "?", "executeRetrieve");
}

function executeRetrieve(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("retrieveBtn");
    }
}

function showEditModal(id)
{
	var selectedDepartment = departmentsJSON.find(d => d.DepartmentID == id);

	$(".txtTitleEdit").val(selectedDepartment.Title);
	$(".txtAliasEdit").val(selectedDepartment.Alias);
	$(".selectCollegeEdit").val(selectedDepartment.CollegeID);
	$(".selectedID").val(id);

	$("#departmentModal").modal("show");
}

function hideEditModal()
{
	$(".selectedID").val("");
	$(".txtTitleEdit").val("");
	$(".txtAliasEdit").val("");
	$(".selectCollegeEdit").val("");

	$("#departmentModal").modal("hide");
}

function loadDepartmentTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(departmentsJSON, function (index, department) {

		if (!department.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("btn btn-danger m-1");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showArchiveModal(" + department.DepartmentID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("btn btn-primary m-1");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showEditModal(" + department.DepartmentID + ");");
			editBtn = editBtn.outerHTML;

			$('#viewTable').dataTable().fnAddData([
				department.Title,
				department.Alias,
				(collegesJSON.find(c => c.CollegeID == department.CollegeID).Alias),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedDepartmentTable()
{
	$('#archivedTable').dataTable().fnClearTable();

	jQuery.each(departmentsJSON, function (index, department) {

		if (department.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("btn btn-primary m-1");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showRetrieveModal(" + department.DepartmentID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archivedTable').dataTable().fnAddData([
				department.Title,
				department.Alias,
				(collegesJSON.find(c => c.CollegeID == department.CollegeID).Alias),
				retrieveBtn
			]);
		}

	});
}