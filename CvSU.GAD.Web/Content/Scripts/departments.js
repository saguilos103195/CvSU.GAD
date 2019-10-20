$(document).ready(function () {

	$(".form-footer > button").click(function () {

		if (isFormValid()) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}
	});

	loadCollege();
	$("#selectCollege").selectmenu();
});

function loadCollege()
{
	console.log(jsonColleges);

	jQuery.each(jsonColleges, function (index, item) {
		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
		$("#selectCollege").append(option);
	});
}

function getSelectedCollege()
{
	$(".selectedCollege").val($("#selectCollege").val());
	console.log("Selected college id: " + $(".selectedCollege").val());
}

function setCollegeSelectionOnChange()
{
	$(document).on("selectmenuchange", "#selectCollege", function () {
		$(".selectedCollege").val($(this).val());
	});
}