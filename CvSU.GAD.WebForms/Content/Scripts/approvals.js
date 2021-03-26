$(document).ready(function () {

	$("#collapseResource").parent(".nav-item").addClass("active");
	$("#approvalsResourcePoolTab").addClass("active");

	console.log(accomplishmentJSON);
	console.log(extensionJSON);

	loadPendingSeminarTable();
	loadApprovedSeminarTable();
	loadRejectedSeminarTable();

	loadPendingExtensionsTable();
	loadApprovedExtensionsTable();
	loadRejectedExtensionsTable();

	loadPendingAccomplishmentsTable();
	loadApprovedAccomplishmentsTable();
	loadRejectedAccomplishmentsTable();
});

function showApproveSeminarModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to approve " + seminarsJSON.find(s => s.SeminarID == id).Name + "?", "executeApproveSeminar");
}

function executeApproveSeminar(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("approveSeminarBtn");
    }
}

function showRejectSeminarModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to reject " + seminarsJSON.find(s => s.SeminarID == id).Name + "?", "executeRejectSeminar");
}

function executeRejectSeminar(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("rejectSeminarBtn");
    }
}

function showApproveExtensionModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to approve " + extensionJSON.find(s => s.DocumentID == id).DocumentName + "?", "executeApproveExtension");
}

function executeApproveExtension(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("approveExtensionBtn");
    }
}

function showRejectExtensionModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to reject " + extensionJSON.find(s => s.DocumentID == id).DocumentName + "?", "executeRejectExtension");
}

function executeRejectExtension(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("rejectExtensionBtn");
    }
}

function showApproveAccomplishmentModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to approve " + accomplishmentJSON.find(s => s.DocumentID == id).DocumentName + "?", "executeApproveAccomplishment");
}

function executeApproveAccomplishment(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("approveAccomplishmentBtn");
    }
}

function showRejectAccomplishmentModal(id)
{
	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to reject " + accomplishmentJSON.find(s => s.DocumentID == id).DocumentName + "?", "executeRejectAccomplishment");
}

function executeRejectAccomplishment(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("rejectAccomplishmentBtn");
    }
}

function loadApprovedSeminarTable()
{
	$('#approvedSeminarTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Approved"), function (index, seminar) {

		$('#approvedSeminarTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName
		]);
		
	});
}

function loadRejectedSeminarTable()
{
	$('#rejectedSeminarTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Rejected"), function (index, seminar) {


		$('#rejectedSeminarTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName
		]);
		
	});
}

function loadPendingSeminarTable()
{
	$('#pendingSeminarTable').dataTable().fnClearTable();

	jQuery.each(seminarsJSON.filter(s => s.Status == "Pending"), function (index, seminar) {


		var approveBtn = document.createElement("button");
		$(approveBtn).attr("type", "button");
		$(approveBtn).addClass("btn btn-primary m-1");
		$(approveBtn).html("Approve");
		$(approveBtn).attr("onclick", "showApproveSeminarModal(" + seminar.SeminarID + ");");
		approveBtn = approveBtn.outerHTML;

		var rejectBtn = document.createElement("button");
		$(rejectBtn).attr("type", "button");
		$(rejectBtn).addClass("btn btn-danger m-1");
		$(rejectBtn).html("Reject");
		$(rejectBtn).attr("onclick", "showRejectSeminarModal(" + seminar.SeminarID + ");");
		rejectBtn = rejectBtn.outerHTML;

		$('#pendingSeminarTable').dataTable().fnAddData([
			seminar.Name,
			seminar.Year,
			seminar.ProfileName,
			approveBtn + rejectBtn
		]);

	});
}


function loadPendingExtensionsTable() {
	$('#pendingExtensionsTable').dataTable().fnClearTable();

	jQuery.each(extensionJSON.filter(s => s.Status == "Pending"), function (index, doc) {

		console.log(doc);

		var approveBtn = document.createElement("button");
		$(approveBtn).attr("type", "button");
		$(approveBtn).addClass("btn btn-primary m-1");
		$(approveBtn).html("Approve");
		$(approveBtn).attr("onclick", "showApproveExtensionModal(" + doc.DocumentID + ");");
		approveBtn = approveBtn.outerHTML;

		var rejectBtn = document.createElement("button");
		$(rejectBtn).attr("type", "button");
		$(rejectBtn).addClass("btn btn-danger m-1");
		$(rejectBtn).html("Reject");
		$(rejectBtn).attr("onclick", "showRejectExtensionModal(" + doc.DocumentID + ");");
		rejectBtn = rejectBtn.outerHTML;

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#pendingExtensionsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename,
			approveBtn + rejectBtn
		]);

	});
}

function loadApprovedExtensionsTable() {
	$('#approvedExtensionsTable').dataTable().fnClearTable();

	jQuery.each(extensionJSON.filter(s => s.Status == "Approved"), function (index, doc) {

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#approvedExtensionsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename
		]);

	});
}

function loadRejectedExtensionsTable() {
	$('#rejectedExtensionsTable').dataTable().fnClearTable();

	jQuery.each(extensionJSON.filter(s => s.Status == "Rejected"), function (index, doc) {

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#rejectedExtensionsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename
		]);

	});
}

function loadPendingAccomplishmentsTable() {
	$('#pendingAccomplishmentsTable').dataTable().fnClearTable();

	jQuery.each(accomplishmentJSON.filter(s => s.Status == "Pending"), function (index, doc) {

		console.log(doc);

		var approveBtn = document.createElement("button");
		$(approveBtn).attr("type", "button");
		$(approveBtn).addClass("btn btn-primary m-1");
		$(approveBtn).html("Approve");
		$(approveBtn).attr("onclick", "showApproveAccomplishmentModal(" + doc.DocumentID + ");");
		approveBtn = approveBtn.outerHTML;

		var rejectBtn = document.createElement("button");
		$(rejectBtn).attr("type", "button");
		$(rejectBtn).addClass("btn btn-danger m-1");
		$(rejectBtn).html("Reject");
		$(rejectBtn).attr("onclick", "showRejectAccomplishmentModal(" + doc.DocumentID + ");");
		rejectBtn = rejectBtn.outerHTML;

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#pendingAccomplishmentsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename,
			approveBtn + rejectBtn
		]);

	});
}

function loadApprovedAccomplishmentsTable() {
	$('#approvedAccomplishmentsTable').dataTable().fnClearTable();

	jQuery.each(accomplishmentJSON.filter(s => s.Status == "Approved"), function (index, doc) {

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#approvedAccomplishmentsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename
		]);

	});
}

function loadRejectedAccomplishmentsTable() {
	$('#rejectedAccomplishmentsTable').dataTable().fnClearTable();

	jQuery.each(accomplishmentJSON.filter(s => s.Status == "Rejected"), function (index, doc) {

		var middleInitial = doc.Account.Profiles[0].Middlename > 0 ? doc.Account.Profiles[0].Middlename.Substring(0, 1) + "." : "";

		$('#rejectedAccomplishmentsTable').dataTable().fnAddData([
			doc.Title,
			doc.DocumentName,
			doc.Account.Profiles[0].Firstname + " " + middleInitial + " " + doc.Account.Profiles[0].Middlename
		]);

	});
}