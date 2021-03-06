﻿$(document).ready(function () {

	$("#collapseProjects").parent(".nav-item").addClass("active");
    $("#accomplishmentsDocumentsTab").addClass("active");

    $("#createBtn").click(function () {

        if (isFormValid($(".form"))) {
            commandClick("createBtn");
        }

    });

	loadAccomplishments();
});


function loadAccomplishments() {
	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(reportsJSON, function (index, report) {

		var downloadBtn = document.createElement("button");
		$(downloadBtn).attr("type", "button");
		$(downloadBtn).addClass("btn btn-primary m-1");
		$(downloadBtn).html("Download");
		$(downloadBtn).attr("onclick", "downloadDocument(" + report.DocumentID + ");");
		downloadBtn = downloadBtn.outerHTML;

		var profile = report.Account.Profiles[0];
		var middleInitial = profile.Middlename.length > 0 ? profile.Middlename.charAt(0) + "." : "";

		var statusTxt = document.createElement("span");
		$(statusTxt).html(report.Status);
		
		switch (report.Status) {
			case "Pending":
				$(statusTxt).addClass("text-warning");
				break;
			case "Approved":
				$(statusTxt).addClass("text-primary");
				break;
			case "Rejected":
				$(statusTxt).addClass("text-danger");
				break;
			default:
				break;
		}

		statusTxt = statusTxt.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			report.Title,
			profile.Firstname + " " + middleInitial + " " + profile.Lastname,
			statusTxt,
			downloadBtn
		]);

	});
}

function downloadDocument(id) {
	var report = reportsJSON.find(p => p.DocumentID == id);

	if (report.DocumentFile != null || report.DocumentFile != "") {
		var postData = JSON.stringify({ projectID: report.DocumentID });

		$.ajax({
			type: "POST",
			url: "/projects/view.aspx/GetBase64DocumentFile",
			data: postData,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {

				console.log(response);

				if (response.d != "" && response.d != null) {
					var linkSource = "data:" + report.DocumentMimeType + ";base64," + response.d;
					var downloadLink = document.createElement("a");

					downloadLink.href = linkSource;
					downloadLink.download = report.DocumentName;
					downloadLink.click();
				}
				else {
					showErrorModal("Error", "File not found", "OK", "#");
				}
			},
			error: function (e) {
				console.log(e);
			}
		});

	}
}