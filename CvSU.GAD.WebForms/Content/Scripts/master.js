$(document).ready(function () {

	loadAdminTemplateInfo();

	initializeSidebar();

	$(window).keydown(function (event) {
		if (event.keyCode == 13) {
			event.preventDefault();
			return false;
		}
	});

	$("table").each(function () {

		var table = $(this);
		var tableHeaderCount = (table.find("tr:nth-child(1) th").length) / 2;

		if (table.hasClass("disaggregation-table")) {
			var tableOptions = {
				dom: 'Bfrtip',
				buttons: [
					{
						extend: 'copy',
						text: 'Copy to Clipboard',
						className: 'bg-secondary text-white border-0',
						exportOptions: {
							columns: ':not(.actionCol)'
						}
					},
					{
						extend: 'excel',
						text: 'Export as Excel',
						className: 'bg-primary text-white border-0',
						exportOptions: {
							columns: ':not(.actionCol)'
						},
					},
					{
						extend: 'csv',
						text: 'Export as CSV',
						className: 'bg-info text-white border-0',
						exportOptions: {
							columns: ':not(.actionCol)'
						}
					},
					{
						extend: 'print',
						text: 'Print',
						className: 'bg-dark text-white border-0',
						exportOptions: {
							columns: ':not(.actionCol)'
						}
					},
				],
				'columnDefs': [
					{
						'searchable': false,
						'targets': [tableHeaderCount - 1]
					},
				],
			}
		}
        else {
			var tableOptions = {
				'columnDefs': [
					{
						'searchable': false,
						'targets': [tableHeaderCount - 1]
					},
				],
			}
        }

		

		table.DataTable().destroy()
		table.DataTable(tableOptions);

	});

	$(document).on("change", "input[type='number']", function () {

		if ($(this).val() != null || $(this).val() != "")
		{
			$(this).val(parseInt($(this).val()));
			var value = parseInt($(this).val());
			var min = parseInt($(this).attr("min"));
			
			if (value < min)
			{
				$(this).val(min);
            }
        }
	});

	//$('.inputMin').on('change', function () {
	//	var max = parseFloat($('.inputMax').val());
	//	var min = parseFloat($('.inputMin').val());
	//	if (min > max) {
	//		$('.inputMin').val(max);
	//	}
	//});
	
});

function initializeSidebar()
{
	if (profileJSON.Account.Type == "Coordinator")
	{
		$("#accountNav").css("display", "none");
		$("#resourcepoolNav").css("display", "none");

		$("#collegesDocumentsTab").css("display", "none");
		$("#departmentsDocumentsTab").css("display", "none");
		$("#programsDocumentsTab").css("display", "none");
		$("#positionsDocumentsTab").css("display", "none");
	}
}


function commandClick(id)
{
	$("." + id).click();
}

function showErrorModal(title, message, buttonText, link)
{
	$("#alertModalTitle").html(title);
	$("#alertModalIcon").removeAttr("class");
	$("#alertModalIcon").addClass("far fa-times-circle text-danger");
	$("#alertModalBody").html(message);
	$("#alertModalButton").html(buttonText);
	$("#alertModalButton").removeAttr("class");
	$("#alertModalButton").addClass("btn btn-danger");
	$("#alertModalButton").attr("href", link);
	$("#alertModal").modal("show");
}

function showSuccessModal(title, message, buttonText, link)
{
	$("#alertModalTitle").html(title);
	$("#alertModalIcon").removeAttr("class");
	$("#alertModalIcon").addClass("far fa-check-circle text-success");
	$("#alertModalBody").html(message);
	$("#alertModalButton").html(buttonText);
	$("#alertModalButton").removeAttr("class");
	$("#alertModalButton").addClass("btn btn-success");
	$("#alertModalButton").attr("href", link);
	$("#alertModal").modal("show");
}

function showConfirmationModal(title, message, command)
{
	$("#confirmationModalTitle").html(title);
	$("#confirmationModalBody").html(message);
	$("#confirmationModalAcceptButton").attr("onclick", command + "(true);");
	$("#confirmationModalCancelButton").attr("onclick", command + "(false);");
	$("#confirmationModal").modal("show");
}

function isFormValid(form)
{
	console.log("Checking Form empty fields...");
	var isValid = true;

	form.find(".required").each(function () {

		if ($(this).val() == null || $(this).val() == "")
		{
			$(this).addClass("is-invalid");
			isValid = false;
		}
		else
		{
			$(this).removeClass("is-invalid");
        }

	});

	return isValid;
}

function loadAdminTemplateInfo()
{
	if (profileJSON != null)
	{
		var middleName = "";
		
		if (profileJSON.Middlename != null && profileJSON.Middlename != "")
		{
			middleName = profileJSON.Middlename.charAt(0) + ". ";
        }

		$("#profileName").html(profileJSON.Firstname + " " + middleName + profileJSON.Lastname);
		$("#profilePicture").attr("src", (profileJSON.Image != null ? "data:image/png;base64," + profileJSON.Image : profileJSON.Gender == "Male" ? "../Content/Images/male.png" : "../Content/Images/female.png"));

	}
}

function filterDepartments(collegValue, selectDepartment)
{
	if (collegValue != "" && collegValue != null)
	{
		selectDepartment.children("option").each(function () {

			var optionValue = $(this).val();

			if (optionValue != null && optionValue != "")
			{
				var collegeID = departments.find(d => d.DepartmentID == parseInt($(this).val())).CollegeID;

				if (collegeID == parseInt(collegValue))
				{
					$(this).removeClass("d-none");
				}
				else
				{
					$(this).addClass("d-none");
                }
            }
		});
	}
	else
	{
		selectDepartment.children("option").addClass("d-none");
		selectDepartment.children("option").first().removeClass("d-none");
    }
}

function filterPrograms(departmentValue, selectProgram) {

	if (departmentValue != "" && departmentValue != null) {
		selectProgram.children("option").each(function () {

			var optionValue = $(this).val();

			if (optionValue != null && optionValue != "") {
				var departmentID = programs.find(p => p.ProgramID == parseInt($(this).val())).DepartmentID;

				if (departmentID == parseInt(departmentValue)) {
					$(this).removeClass("d-none");
				}
				else {
					$(this).addClass("d-none");
				}
			}
		});
	}
	else {
		selectProgram.children("option").addClass("d-none");
		selectProgram.children("option").first().removeClass("d-none");
	}
}