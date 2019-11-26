$(document).ready(function () {

	console.log(seminarsJSON);

	$("#pendingTable").DataTable({

		columns: [
			{ title: "Name" },
			{ title: "Year" },
			{ title: "Owner" },
			{ title: "Action" }
		],

	});

	$("#approvedTable").DataTable({

		columns: [
			{ title: "Name" },
			{ title: "Year" },
			{ title: "Owner" }
		],

	});

	$("#rejectedTable").DataTable({

		columns: [
			{ title: "Name" },
			{ title: "Year" },
			{ title: "Owner" }
		],
	});

	loadPendingTable();
	loadApprovedTable();
	loadRejectedTable();

});

function loadApprovedTable()
{
	$('#approvedTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Approved"), function (index, seminar) {


		$('#approvedTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName
		]);
		
	});
}

function loadRejectedTable()
{
	$('#rejectedTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Rejected"), function (index, seminar) {


		$('#rejectedTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName
		]);
		
	});
}

function loadPendingTable()
{
	$('#pendingTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Pending"), function (index, seminar) {


		var approveBtn = document.createElement("button");
		$(approveBtn).attr("type", "button");
		$(approveBtn).addClass("button-control button-green");
		$(approveBtn).html("Approve");
		$(approveBtn).attr("onclick", "showModal($('.retrieve-alert')); approveItem(" + seminar.SeminarID + ");");
		approveBtn = approveBtn.outerHTML;

		var rejectBtn = document.createElement("button");
		$(rejectBtn).attr("type", "button");
		$(rejectBtn).addClass("button-control button-red");
		$(rejectBtn).html("Reject");
		$(rejectBtn).attr("onclick", "showModal($('.archive-alert')); rejectItem(" + seminar.SeminarID + ");");
		rejectBtn = rejectBtn.outerHTML;

		$('#pendingTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName,
			approveBtn + rejectBtn
		]);

	});
}

function approveItem(seminarID)
{
	jQuery.each(seminarsJSON, function (index, seminar) {

		if (seminarID == seminar.SeminarID)
		{
			$(".selectedID").val(seminarID);
			$(".retrieve-alert > span").html(seminar.Name);
		}

	});
}

function rejectItem(seminarID)
{
	jQuery.each(seminarsJSON, function (index, seminar) {

		if (seminarID == seminar.SeminarID)
		{
			$(".selectedID").val(seminarID);
			$(".archive-alert > span").html(seminar.Name);
		}

	});
}