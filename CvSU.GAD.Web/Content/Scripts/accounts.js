$(document).ready(function () {

	$(".select-control").selectmenu();

	$(".form-footer > button").click(function () {

		if (isFormValid(".form-body")) {
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".form-footer > input[type=submit]").click();
		}

	});

});