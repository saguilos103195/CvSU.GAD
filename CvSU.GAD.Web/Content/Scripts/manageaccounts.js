$(document).ready(function () {

	$("#viewTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Department" },
			{ title: "Action" }
		],

	});

	$("#archiveTable").DataTable({

		columns: [
			{ title: "Title" },
			{ title: "Alias" },
			{ title: "Department" },
			{ title: "Action" }
		],

	});

	console.log(accountsJSON);

});