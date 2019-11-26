$(document).ready(function () {

	$(".master-sidebar-account > p").click(function () {

		if ($(".master-sidebar-account-menu").css("display") == "none")
		{
			$(".master-sidebar-account-menu").css("display", "block");
			$(".master-sidebar-account-menu").addClass("animated");
			$(".master-sidebar-account-menu").addClass("flipInY");
		}
		else
		{
			$(".master-sidebar-account-menu").css("display", "none");
		}
		
	});

	$(window).keydown(function (event) {
		if (event.keyCode == 13)
		{
			if ($(".master-alert").css("display") == "block")
			{
				location.replace($(".master-alert > div > a").attr("href"));
			}
			event.preventDefault();
			return false;
		}
	});

	$(window).keydown(function (event) {
		if (event.keyCode == 27) {

			hideModal();

		}
	});
});

function toggleMasterAlert(icon, iconColor, title, message, btnMessage, btnColor, link)
{
	$(".master-alert").css("display", "block");
	$(".master-alert > div > p").html(title);
	$(".master-alert > div > span").html(message);
	$(".master-alert > div > a").html(btnMessage);
	$(".master-alert > div > a").css("background-color", btnColor);
	$(".master-alert > div > a").attr("href", link);
	$(".master-alert > div > i").addClass(icon);
	$(".master-alert > div > i").css("color", iconColor);
}

function loadAdminTemplateInfo()
{
	if (profileJSON != null)
	{
		$("#sidebarProfileName").html(profileJSON.Firstname + " " + profileJSON.Middlename.charAt(0) + ". " + profileJSON.Lastname);
	}
}


$(document).ready(function () {

	$(".master-alert > div > a").click(function () {

		$(".master-alert").removeAttr("style");

	});

	$(".form-tabs > span").each(function () {

		$(this).removeClass("form-active-tab");

	});

	$(".tab-control").each(function () {

		$(this).css("display", "none");

	});

	$(".form-tabs > span:first-of-type").addClass("form-active-tab");
	$(".tab-control").eq(0).removeAttr("style");

	

});

function switchTab(tabindex)
{
	$(".form-tabs > span").each(function () {

		$(this).removeClass("form-active-tab");

	});

	$(".tab-control").each(function () {

		$(this).css("display", "none");

	});

	$(".form-tabs > span:nth-of-type(" + (tabindex + 1)  + ")").addClass("form-active-tab");
	$(".tab-control").eq(tabindex).removeAttr("style");
}

function hideModal()
{
	$(".form-modal-overlay").removeAttr("style");
	$(".form-modal-overlay > *").removeAttr("style");
}

function showModal(modal)
{
	$(".form-modal-overlay").css("display", "block");
	$(modal).css("display", "block");
}