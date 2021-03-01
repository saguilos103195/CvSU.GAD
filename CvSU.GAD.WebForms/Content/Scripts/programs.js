$(document).ready(function () {

	$("#collapseDocuments").parent(".nav-item").addClass("active");
	$("#programsDocumentsTab").addClass("active");

	loadProgramTable();
	loadArchivedProgramTable();
	filterDepartments($(".selectCollege").val(), $(".selectDepartment"));
	filterDepartments($(".selectCollegeEdit").val(), $(".selectDepartmentEdit"));

	$(document).on("change", ".selectCollege", function () {

		filterDepartments($(this).val(), $(".selectDepartment"));
		$(".selectDepartment").val("");

	});

	$(document).on("change", ".selectCollegeEdit", function () {

		filterDepartments($(this).val(), $(".selectDepartmentEdit"));
		$(".selectDepartmentEdit").val("");

	});

	$("#createBtn").click(function () {

		if (isFormValid($(".form")))
		{
			commandClick("createBtn");
        }

	});

	$("#editBtn").click(function () {

		if (isFormValid($(".form-modal")))
		{
			commandClick("editBtn")
        }

	});

});

function loadProgramTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(programsJSON, function (index, program) {

		if (!program.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("btn btn-danger m-1");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showArchiveModal(" + program.ProgramID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("btn btn-primary m-1");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showEditModal(" + program.ProgramID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				program.Title,
				program.Alias,
				(departments.find(d => d.DepartmentID == program.DepartmentID).Alias),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedProgramTable()
{
	$('#archivedTable').dataTable().fnClearTable();

	jQuery.each(programsJSON, function (index, program) {

		if (program.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("btn btn-primary m-1");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showRetrieveModal(" + program.ProgramID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archivedTable').dataTable().fnAddData([
				program.Title,
				program.Alias,
				(departments.find(d => d.DepartmentID == program.DepartmentID).Alias),
				retrieveBtn
			]);
		}

	});
}

function showArchiveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to archive " + programsJSON.find(d => d.ProgramID == id).Title + "?", "executeArchive");
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
	showConfirmationModal("Confirmation", "Are you sure want to retrieve " + programsJSON.find(d => d.ProgramID == id).Title + "?", "executeRetrieve");
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
	var selectedProgram = programsJSON.find(p => p.ProgramID == id);
	var selectedDepartment = departments.find(d => d.DepartmentID == selectedProgram.DepartmentID);
	var selectedCollege = colleges.find(c => c.CollegeID == selectedDepartment.CollegeID);
	$(".txtTitleEdit").val(selectedProgram.Title);
	$(".txtAliasEdit").val(selectedProgram.Alias);
	$(".selectCollegeEdit").val(selectedCollege.CollegeID);
	filterDepartments($(".selectCollegeEdit").val(), $(".selectDepartmentEdit"));
	$(".selectDepartmentEdit").val(selectedDepartment.DepartmentID);
	$(".selectedID").val(id);

	$("#programModal").modal("show");
}

function hideEditModal()
{
	$(".selectedID").val("");
	$(".txtTitleEdit").val("");
	$(".txtAliasEdit").val("");
	$(".selectCollegeEdit").val("");
	$(".selectDepartmentEdit").val("");

	$("#programModal").modal("hide");
}