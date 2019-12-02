$(document).ready(function () {

	$(".select-control").selectmenu();

	$(".form-footer > button").click(function () {

		if (isFormValid($(".form-body")) & isMatched($(".passwordTxt"), $(".confirmPasswordTxt"), "Password did not match"))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}

	});

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

	$("#collegeSel").parent().parent().css("display", "none");
	$("#collegeSel").removeAttr("require");

	$(document).on("selectmenuchange", ".accountTypeSel", function () 
	{
		if ($(this).val() == "Coordinator")
		{
			$("#collegeSel").parent().parent().removeAttr("style");
			$("#collegeSel").attr("require", "");
		}
		else
		{
			$("#collegeSel").parent().parent().css("display", "none");
			$("#collegeSel").removeAttr("require");
			loadCollege();
			$(".selectedCollegeTxt").val("");
		}
	});

	$(document).on("selectmenuchange", "#collegeSel", function () 
	{
		$(".selectedCollegeTxt").val($(this).val());
	});

	$("#collegeSel").selectmenu();
	loadCollege();

});

function loadCollege()
{
	$("#collegeSel").children("option").remove();
	$("#collegeSel").append("<option selected disabled value=''>Select College</option>");

	jQuery.each(collegeSelectJSON, function (index, item) {
		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
		$("#collegeSel").append(option);
	});

	$("#collegeSel").selectmenu("refresh");
}