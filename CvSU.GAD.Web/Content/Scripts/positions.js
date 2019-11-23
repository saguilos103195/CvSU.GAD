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

	$("#viewTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Type" },
			{ title: "Action" }
		]

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Type" },
			{ title: "Action" }
		]

	});

	loadPositionTable();
	loadArchivedPositionTable();

});

function loadPositionTable()
{
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(positionsJSON, function (index, position) {

		if (!position.IsArchived) {
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + position.PositionID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.edit-modal')); editItem(" + position.PositionID + ");");
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
	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(positionsJSON, function (index, position) {

		if (position.IsArchived) {
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("button-control button-blue");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showModal($('.retrieve-alert')); retrieveItem(" + position.PositionID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archiveTable').dataTable().fnAddData([
				position.Title,
				(position.IsFaculty ? "Faculty" : "Non-faculty"),
				retrieveBtn
			]);
		}

	});
}

function archiveItem(positionID)
{
	jQuery.each(positionsJSON, function (index, position) {

		if (positionID == position.PositionID)
		{
			$(".selectedID").val(positionID);
			$(".archive-alert > span").html(position.Title);
		}

	});
}

function editItem(positionID)
{
	jQuery.each(positionsJSON, function (index, position) {

		if (positionID == position.PositionID)
		{
			$(".selectedID").val(positionID);
			$(".editTitleTxt").val(position.Title);
			$(".editTypeChkBx").attr("checked", position.IsFaculty);
		}

	});
}

function retrieveItem(positionID)
{
	jQuery.each(positionsJSON, function (index, position) {

		if (positionID == position.PositionID)
		{
			$(".selectedID").val(positionID);
			$(".retrieve-alert > span").html(position.Title);
		}

	});
}