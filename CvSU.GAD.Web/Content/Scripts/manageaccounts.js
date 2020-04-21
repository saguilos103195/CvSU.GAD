$(document).ready(function () {

	$("#viewTable").DataTable({

		columns: [
			{ title: "Username" },
			{ title: "Type" },
			{ title: "Created By" },
			{ title: "College" },
			{ title: "Action" }
		],

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Username" },
			{ title: "Type" },
			{ title: "Created By" },
			{ title: "College" },
			{ title: "Action" }
		],

	});

	switchTab(0);
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
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + account.AccountID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.form-modal')); editItem(" + account.AccountID + ");");
			editBtn = editBtn.outerHTML;

			$('#viewTable').dataTable().fnAddData([
				account.Username,
				account.Type,
				allAccountsJSON.find(a => a.AccountID == account.CreatedByID).Username,
				(account.CollegeID == null ? "N/A" : collegesJSON.find(c => c.CollegeID == account.CollegeID).Title),
				archiveBtn +
				editBtn
			]);
		}

	});
}

function loadArchivedAccounts()
{
	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(accessedAccountsJSON, function (index, account) {

		if (account.IsArchived) {
			
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("button-control button-blue");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showModal($('.retrieve-alert')); retrieveItem(" + account.AccountID + ");");
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

function archiveItem(accountID)
{
	jQuery.each(allAccountsJSON, function (index, account) {

		if (accountID == account.AccountID)
		{
			$(".selectedID").val(accountID);
			$(".archive-alert > span").html(account.Username);
		}

	});
}

function editItem(collegeID)
{
	jQuery.each(collegesJSON, function (index, college) {

		if (collegeID == college.CollegeID)
		{
			$(".selectedID").val(collegeID);
			$(".editTitleTxt").val(college.Title);
			$(".editAliasTxt").val(college.Alias);
			$(".editTypeChkBx").attr("checked", college.IsMain);
		}

	});
}

function retrieveItem(accountID)
{
	jQuery.each(allAccountsJSON, function (index, account) {

		if (accountID == account.AccountID)
		{
			$(".selectedID").val(accountID);
			$(".retrieve-alert > span").html(account.Username);
		}

	});
}