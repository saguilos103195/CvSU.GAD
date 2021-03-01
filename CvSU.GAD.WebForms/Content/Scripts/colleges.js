$(document).ready(function () {

    $("#collapseDocuments").parent(".nav-item").addClass("active");
	$("#collegesDocumentsTab").addClass("active");

	$("#createBtn").click(function () {

		if (isFormValid($(".form")))
		{
			commandClick("createBtn")
        }

	});

	$("#editBtn").click(function () {

		if (isFormValid($(".form-modal")))
		{
			commandClick("editBtn")
        }

	});

	loadCollegeTable();
	loadArchivedCollegeTable();

});

function showArchiveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to archive " + collegesJSON.find(a => a.CollegeID == id).Title + "?", "executeArchive");
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
	showConfirmationModal("Confirmation", "Are you sure want to retrieve " + collegesJSON.find(a => a.CollegeID == id).Title + "?", "executeRetrieve");
}

function executeRetrieve(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("retrieveBtn");
    }
}

function loadCollegeTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(collegesJSON, function (index, college) {

		if (!college.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("btn btn-danger m-1");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showArchiveModal(" + college.CollegeID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("btn btn-primary m-1");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showEditModal(" + college.CollegeID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				college.Title,
				college.Alias,
				(college.IsMain ? "Main" : "Satellite"),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function showEditModal(id)
{
	var selectedCollege = collegesJSON.find(c => c.CollegeID == id);

	$(".txtTitleEdit").val(selectedCollege.Title);
	$(".txtAliasEdit").val(selectedCollege.Alias);
	$(".checkBoxMainEdit").attr("checked", selectedCollege.IsMain);
	$(".selectedID").val(id);

	$("#collegeModal").modal("show");
}

function hideEditModal()
{
	$(".selectedID").val("");
	$(".txtTitleEdit").val("");
	$(".txtAliasEdit").val("");
	$(".checkBoxMainEdit").attr("checked", false);

	$("#collegeModal").modal("hide");
}

function loadArchivedCollegeTable()
{
	$('#archivedTable').dataTable().fnClearTable();

	jQuery.each(collegesJSON, function (index, college) {

		if (college.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("btn btn-primary m-1");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showRetrieveModal(" + college.CollegeID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archivedTable').dataTable().fnAddData([
				college.Title,
				college.Alias,
				(college.IsMain ? "Main" : "Satellite"),
				retrieveBtn
			]);
		}

	});
}