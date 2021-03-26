var exportDocumentName = "Student_Disaggregation" + moment(new Date()).format('YYYYMMDD');

$(document).ready(function () {

	$("#collapseDisaggregation").parent(".nav-item").addClass("active");
	$("#studentDisaggregationTab").addClass("active");

	$("#createBtn").click(function () {

		if (isFormValid($(".form")))
		{
			commandClick("createBtn");
		}

	});

	filterDepartments($(".selectCollege").val(), $(".selectDepartment"));
	filterPrograms($(".selectDepartment").val(), $(".selectProgram"));

	$(document).on("change", ".selectCollege", function () {

		filterDepartments($(this).val(), $(".selectDepartment"));
		$(".selectDepartment").val("").change();

	});

	$(document).on("change", ".selectDepartment", function () {

		filterPrograms($(this).val(), $(".selectProgram"));
		$(".selectProgram").val("")

	});

	initializeUser();
	loadDisaggragationData();

});

function showDeleteModal(id)
{
	var data = studentSDJSON.find(s => s.DisaggregationID == id);

	$(".selectedID").val(id);
	showConfirmationModal("Confirmation", "Are you sure want to delete " + data.ProgramTitle + " " + data.Semester + " Semester SY " + data.SchoolYear + "?", "executeDelete");
}

function executeDelete(isConfirmed)
{
	if (isConfirmed)
	{
		commandClick("deleteBtn");
    }
}

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

function exportDisaggregation() {

	var disaggregationData = [];

	$.each($('#viewTable').DataTable().data().toArray(), function (index, item) {

		var disaggregation = {
			Program: $(this)[0],
			Department: $(this)[1],
			Male: $(this)[2],
			Female: $(this)[3],
			Semester: $(this)[4],
			SchoolYear: $(this)[5]
		}

		disaggregationData.push(disaggregation);

	});

	console.log(disaggregationData);
}

function loadDisaggragationData()
{

	var table = $('#viewTable').DataTable();

	$('#viewTable').dataTable().fnClearTable();

	jQuery.each(studentSDJSON, function (index, studentSD) {

		var deleteBtn = document.createElement("button");
		$(deleteBtn).attr("type", "button");
		$(deleteBtn).addClass("btn btn-danger");
		$(deleteBtn).html("Delete");
		$(deleteBtn).attr("onclick", "showDeleteModal(" + studentSD.DisaggregationID + ");");
		deleteBtn = deleteBtn.outerHTML;

		$('#viewTable').dataTable().fnAddData([
			studentSD.ProgramTitle,
			studentSD.Department,
			studentSD.MaleQuantity,
			studentSD.FemaleQuantity,
			studentSD.Semester,
			studentSD.SchoolYear,
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
				table.column(i)
					.search(val ? '^' + $(this).val() + '$' : val, true, false)
					.draw();
			});

			filterIcon.appendTo(filterBody);

			filterBody.appendTo($(this).empty());

			switch (columnName) {

				case "Program":
				case "Department":

					filterSelect.append('<option value="">All ' + columnName + 's</option>');
					
					table.column(i).data().unique().sort().each(function (d, j) {
						filterSelect.append('<option value="' + d + '">' + d + '</option>');
					});

					break;
				case "School Year":

					filterSelect.append('<option value="">All</option>');

					var schoolYearData = table.column(i).data().unique().sort().toArray();
					var currentYear = parseInt(new Date().getFullYear());
					var startYear = currentYear - 19;

					var schoolYearRange = [];

					for (startYear; startYear <= currentYear; startYear++) {

						var schoolYear = startYear + "-" + (startYear + 1);
						schoolYearRange.push(schoolYear);
					}

					schoolYearRange = schoolYearRange.concat(schoolYearData.filter(sy => !schoolYearRange.includes(sy))).sort();
					
					for (var sy = 0; sy < schoolYearRange.length; sy++)
					{
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
