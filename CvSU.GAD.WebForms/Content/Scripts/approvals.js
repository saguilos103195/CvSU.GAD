$(document).ready(function () {

	$("#collapseResource").parent(".nav-item").addClass("active");
	$("#approvalsResourcePoolTab").addClass("active");

	loadPendingTable();
	loadApprovedTable();
	loadRejectedTable();

});

function showApproveModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to approve " + seminarsJSON.find(s => s.SeminarID == id).Name + "?", "executeApprove");
}

function executeApprove(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("approveBtn");
    }
}

function showRejectModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to reject " + seminarsJSON.find(s => s.SeminarID == id).Name + "?", "executeReject");
}

function executeReject(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("rejectBtn");
    }
}

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
		$(approveBtn).addClass("btn btn-primary m-1");
		$(approveBtn).html("Approve");
		$(approveBtn).attr("onclick", "showApproveModal(" + seminar.SeminarID + ");");
		approveBtn = approveBtn.outerHTML;

		var rejectBtn = document.createElement("button");
		$(rejectBtn).attr("type", "button");
		$(rejectBtn).addClass("btn btn-danger m-1");
		$(rejectBtn).html("Reject");
		$(rejectBtn).attr("onclick", "showRejectModal(" + seminar.SeminarID + ");");
		rejectBtn = rejectBtn.outerHTML;

		$('#pendingTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName,
			approveBtn + rejectBtn
		]);

	});
}