$(document).ready(function () {

	$("#collapseDisaggregation").parent(".nav-item").addClass("active");
	

	var path = window.location.pathname;
	var page = path.split("/").pop().replace(".aspx", "");

	if (page == "faculty")
	{
		$("#facultyDisaggregationTab").addClass("active");
	}
	else if (page == "nonfaculty")
	{
		$("#nonFacultyDisaggregationTab").addClass("active");
    }

	console.log(page);

	$("#createBtn").click(function () {

		if (isFormValid($(".form")))
		{
			commandClick("createBtn");
		}

	});

	filterDepartments($(".selectCollege").val(), $(".selectDepartment"));

	$(document).on("change", ".selectCollege", function () {

		filterDepartments($(this).val(), $(".selectDepartment"));
		$(".selectDepartment").val("");

	});

	initializeUser();
	loadDisaggragationData();

});

function initializeUser()
{
	if (profileJSON.Account.Type == "Coordinator")
	{
		$(".selectCollege").attr("disabled", "disabled");

		$(".selectCollege").children("option").each(function () {

			if (profileJSON.Account.CollegeID == parseInt($(this).val()))
			{
				$(this).removeClass("d-none");
			}
			else
			{
				$(this).addClass("d-none");
			}
		});


		$(".selectCollege").val(profileJSON.Account.CollegeID);
		filterDepartments($(".selectCollege").val(), $(".selectDepartment"));
    }
}

function showDeleteModal(id)
{
	var data = employeeSDJSON.find(f => f.DisaggregationID == id);

	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to delete " + data.PositionTitle + " " + data.Semester + " Semester SY " + data.SchoolYear + "?", "executeDelete");
}

function executeDelete(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("deleteBtn");
    }
}

function loadDisaggragationData()
{
	var table = $('#viewTable').DataTable();

	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(employeeSDJSON, function (index, employeeSD) {

		var deleteBtn = document.createElement("button");
		$(deleteBtn).attr("type", "button");
		$(deleteBtn).addClass("btn btn-danger");
		$(deleteBtn).html("Delete");
		$(deleteBtn).attr("onclick", "showDeleteModal(" + employeeSD.DisaggregationID + ");");
		deleteBtn = deleteBtn.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			employeeSD.PositionTitle,
			employeeSD.Department,
			employeeSD.MaleQuantity,
			employeeSD.FemaleQuantity,
			employeeSD.Semester,
			employeeSD.SchoolYear,
			deleteBtn
		]);
	});

	$("#viewTable tfoot th").each(function (i) {

		if ($(this).text() !== '') {

			var columnName = $(this).text();

			var filterBody = document.createElement("div");
			filterBody = $(filterBody);
			filterBody.css({
				'position': 'relative',
				'display': 'flex'
			});

			var filterSelect = document.createElement("select");
			filterSelect = $(filterSelect);
			filterSelect.css({
				'outline': 'none',
				'border': 'none',
				'appearance': 'none',
				'padding-right': '20px',
				'flex': '1',
				'cursor': 'pointer'
			});

			var filterIcon = document.createElement("i");
			filterIcon = $(filterIcon);
			filterIcon.addClass("fas fa-filter");
			filterIcon.css({
				'position': 'absolute',
				'font-size': '13px',
				'right': '0px',
				'margin-top': '5px',
				'pointer-events': 'none'
			});

			filterSelect.appendTo(filterBody).on('change', function () {
				var val = $(this).val();

				console.log(val);

				table.column(i)
					.search(val ? '^' + $(this).val() + '$' : val, true, false)
					.draw();
			});

			filterIcon.appendTo(filterBody);

			filterBody.appendTo($(this).empty());

			switch (columnName) {

				case "Position":
				case "Department":

					filterSelect.append('<option value="">All ' + columnName + 's</option>');

					table.column(i).data().unique().sort().each(function (d, j) {
						filterSelect.append('<option value="' + d + '">' + d + '</option>');
					});

					break;
				case "School Year":

					filterSelect.append('<option value="">All</option>');

					var schoolYearData = [];

					table.column(i).data().unique().sort().each(function (d, j) {
						schoolYearData.push(d);
					});
					var currentYear = parseInt(new Date().getFullYear());
					var startYear = currentYear - 19;

					var schoolYearRange = [];

					for (startYear; startYear <= currentYear; startYear++) {

						var schoolYear = startYear + "-" + (startYear + 1);
						schoolYearRange.push(schoolYear);
					}

					schoolYearRange = schoolYearRange.concat(schoolYearData.filter(sy => !schoolYearRange.includes(sy))).sort();

					for (var sy = 0; sy < schoolYearRange.length; sy++) {
						filterSelect.append('<option value=' + schoolYearRange[sy] + '>' + schoolYearRange[sy] + '</option>');
					}

					break;
				case "Semester":

					filterSelect.append('<option value="">Both</option>');
					filterSelect.append('<option value="First">First</option>');
					filterSelect.append('<option value="Second">Second</option>');

					break;
				default:
					break;

			}
		}
	});
}
