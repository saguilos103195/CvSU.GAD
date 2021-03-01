$(document).ready(function () {

	$("#collapseDocuments").parent(".nav-item").addClass("active");
	$("#positionsDocumentsTab").addClass("active");

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

	loadPositionTable();
	loadArchivedPositionTable();

});

function showArchiveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to archive " + positionsJSON.find(p => p.PositionID == id).Title + "?", "executeArchive");
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
	showConfirmationModal("Confirmation", "Are you sure want to retrieve " + positionsJSON.find(p => p.PositionID == id).Title + "?", "executeRetrieve");
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
	var selectedPosition = positionsJSON.find(p => p.PositionID == id);

	$(".txtTitleEdit").val(selectedPosition.Title);
	$(".checkBoxFacultyEdit").attr("checked", selectedPosition.IsFaculty);
	$(".selectedID").val(id);

	$("#positionModal").modal("show");
}

function hideEditModal()
{
	$(".selectedID").val("");
	$(".txtTitleEdit").val("");
	$(".checkBoxFacultyEdit").attr("checked", false);

	$("#positionModal").modal("hide");
}

function loadPositionTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(positionsJSON, function (index, position) {

		if (!position.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("btn btn-danger m-1");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showArchiveModal(" + position.PositionID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("btn btn-primary m-1");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showEditModal(" + position.PositionID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				position.Title,
				(position.IsFaculty ? "Faculty" : "Non-faculty"),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedPositionTable()
{
	$('#archivedTable').dataTable().fnClearTable();

	jQuery.each(positionsJSON, function (index, position) {

		if (position.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("btn btn-primary m-1");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showRetrieveModal(" + position.PositionID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archivedTable').dataTable().fnAddData([
				position.Title,
				(position.IsFaculty ? "Faculty" : "Non-faculty"),
				retrieveBtn
			]);
		}

	});
}