$(document).ready(function () {

	$(".login-body input[type=text], .login-body input[type=password]").keydown(function (event) {
		if (event.keyCode == 13)
		{
			$(".login-body input[type=submit]").click();
			event.preventDefault();
			return false;
		}
	});

});