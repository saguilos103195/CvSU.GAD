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
	console.log(accountsJSON);
	loadAccounts();

});

function loadAccounts()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(accountsJSON, function (index, account) {

		if (!account.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + account.PositionID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.form-modal')); editItem(" + account.PositionID + ");");
			editBtn = editBtn.outerHTML;


			$('#viewTable').dataTable().fnAddData([
				account.Username,
				account.Type,
				account.CreatedBy.Username,
				account.
				archiveBtn +
				editBtn
			]);
		}

	});
}