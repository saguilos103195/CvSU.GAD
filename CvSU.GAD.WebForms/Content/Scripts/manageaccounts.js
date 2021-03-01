$(document).ready(function () {

    $("#collapseAccount").parent(".nav-item").addClass("active");
    $("#manageAccountsTab").addClass("active");

	$("#viewTable").DataTable();
	$("#archiveTable").DataTable();

	loadAccounts();
	loadArchivedAccounts();
});

function loadAccounts()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(accessedAccountsJSON, function (index, account) {

		if (!account.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("btn btn-danger m-1");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showArchiveModal(" + account.AccountID + ");");
			archiveBtn = archiveBtn.outerHTML;

			$('#viewTable').dataTable().fnAddData([
				account.Username,
				account.Type,
				allAccountsJSON.find(a => a.AccountID == account.CreatedByID).Username,
				(account.CollegeID == null ? "N/A" : collegesJSON.find(c => c.CollegeID == account.CollegeID).Title),
				archiveBtn
			]);
		}

	});
}

function showArchiveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to archive " + accessedAccountsJSON.find(a => a.AccountID == id).Username + "?", "executeArchive");
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
	showConfirmationModal("Confirmation", "Are you sure want to retrieve " + accessedAccountsJSON.find(a => a.AccountID == id).Username + "?", "executeRetrieve");
}

function executeRetrieve(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("retrieveBtn");
    }
}

function loadArchivedAccounts()
{
	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(accessedAccountsJSON, function (index, account) {

		if (account.IsArchived) {
			
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("btn btn-primary m-1");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showRetrieveModal(" + account.AccountID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archiveTable').dataTable().fnAddData([
				account.Username,
				account.Type,
				allAccountsJSON.find(a => a.AccountID == account.CreatedByID).Username,
				(account.CollegeID == null ? "N/A" : collegesJSON.find(c => c.CollegeID == account.CollegeID).Title),
				retrieveBtn
			]);
		}

	});
}