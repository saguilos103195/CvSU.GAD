$(document).ready(function () {

	$(".select-control").selectmenu();
    switchTab(1);
	$(".form-footer > button").click(function () {

		if (isFormValid(".form-body")) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}

	});

	$(document).on("click", ".updateBtn", function () {

		if (isFormValid(".edit-modal")) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".modal-foot > input[type=submit]").click();
		}

	});

	$("#viewTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Type" },
			{ title: "Action" }
		],

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Type" },
			{ title: "Action" }
		],

	});

	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(collegesJSON, function (index, college) {

		if (!college.IsArchived)
		{
			var archiveBtn = document.createElement("button");
			$(archiveBtn).attr("type", "button");
			$(archiveBtn).addClass("button-control button-red");
			$(archiveBtn).html("Archive");
			$(archiveBtn).attr("onclick", "showModal($('.archive-alert')); archiveItem(" + college.CollegeID + ");");
			archiveBtn = archiveBtn.outerHTML;

			var editBtn = document.createElement("button");
			$(editBtn).attr("type", "button");
			$(editBtn).addClass("button-control button-blue");
			$(editBtn).html("Edit");
			$(editBtn).attr("onclick", "showModal($('.edit-modal')); editItem(" + college.CollegeID + ");");
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

	$('#archiveTable').dataTable().fnClearTable();

	jQuery.each(collegesJSON, function (index, college) {

		console.log(college);

		if (college.IsArchived)
		{
			var retrieveBtn = document.createElement("button");
			$(retrieveBtn).attr("type", "button");
			$(retrieveBtn).addClass("button-control button-blue");
			$(retrieveBtn).html("Retrieve");
			$(retrieveBtn).attr("onclick", "showModal($('.retrieve-alert')); retrieveItem(" + college.CollegeID + ");");
			retrieveBtn = retrieveBtn.outerHTML;

			$('#archiveTable').dataTable().fnAddData([
				college.Title,
				college.Alias,
				(college.IsMain ? "Main" : "Satellite"),
				retrieveBtn
			]);
		}

	});

});

function archiveItem(collegeID)
{
	jQuery.each(collegesJSON, function (index, college) {

		if (collegeID == college.CollegeID)
		{
			$(".selectedID").val(collegeID);
			$(".archive-alert > span").html(college.Title);
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

function retrieveItem(collegeID)
{
	jQuery.each(collegesJSON, function (index, college) {

		if (collegeID == college.CollegeID)
		{
			$(".selectedID").val(collegeID);
			$(".retrieve-alert > span").html(college.Title);
		}

	});
}

function hideModal()
{
	$(".form-modal-overlay").removeAttr("style");
	$(".form-modal-overlay > *").removeAttr("style");
}

function showModal(modal)
{
	$(".form-modal-overlay").css("display", "block");
	$(modal).css("display", "block");
}