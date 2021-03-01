$(document).ready(function () {

    $("#collapseProjects").parent(".nav-item").addClass("active");
	$("#viewProjectsTab").addClass("active");

	loadProjects();

});

function loadProjects()
{
	$('#viewTable').dataTable().fnClearTable();

	console.log(projectsJSON);

	jQuery.each(projectsJSON, function (index, project) {

		var downloadBtn = document.createElement("button");
		$(downloadBtn).attr("type", "button");
		$(downloadBtn).addClass("btn btn-primary m-1");
		$(downloadBtn).html("Download");
		$(downloadBtn).attr("onclick", "downloadDocument(" + project.DocumentID + ");");
		downloadBtn = downloadBtn.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			project.Title,
			project.Account.Username,
			downloadBtn
		]);

	});
}

function downloadDocument(id)
{
	var project = projectsJSON.find(p => p.DocumentID == id);

	if (project.DocumentFile != null || project.DocumentFile != "")
	{
		var postData = JSON.stringify({ projectID: project.DocumentID });

		$.ajax({
			type: "POST",
			url: "/projects/view.aspx/GetBase64DocumentFile",
			data: postData,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {

				console.log(response);

				if (response.d != "" && response.d != null)
				{
					var linkSource = "data:" + project.DocumentMimeType + ";base64," + response.d;
					var downloadLink = document.createElement("a");

					downloadLink.href = linkSource;
					downloadLink.download = project.DocumentName;
					downloadLink.click();
				}
				else
				{
					showErrorModal("Error", "File not found", "OK", "#");
                }
			},
			error: function (e) {
				console.log(e);
            }
		});
		
    }
}