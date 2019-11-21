$(document).ready(function() {

	loadAdminTemplateInfo();
	loadProfile();
	switchTab(0);

	$(".profile-tab > button").click(function () {

		if (isFormValid($(".profile-tab")))
		{
			$(this).css("pointer-events", "none");
			$(this).css("opacity", ".9");
			$(".profile-tab > input[type=submit]").click();
		}

	});

	$(".bdateTxt").datepicker({ dateFormat: 'dd/mm/yy' });
	$('.bdateTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.bdateTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".engagedFromTxt").datepicker({ dateFormat: 'dd/mm/yy' });
	$('.engagedFromTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.engagedFromTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});

	$(".engagedToTxt").datepicker({ dateFormat: 'dd/mm/yy' });
	$('.engagedToTxt').on("cut copy paste", function (e) {
		e.preventDefault();
	});
	$('.engagedToTxt').on("keydown", function (e) {
		if (e.keyCode !== 8) {
			e.preventDefault();
		}
	});
});

function loadProfile()
{
	$(".fnameTxt").val(profileJSON.Firstname);
	$(".mnameTxt").val(profileJSON.Middlename);
	$(".lnameTxt").val(profileJSON.Lastname);
	$(".bdateTxt").val(moment(profileJSON.Birthdate).format("DD/MM/YYYY"));
	$(".religionTxt").val(profileJSON.Religion);
	$(".cellphoneTxt").val(profileJSON.CellphoneNumber);
	$(".telephoneTxt").val(profileJSON.TelephoneNumber);
	$(".emailTxt").val(profileJSON.EmailAddress);
	$(".lnameTxt").val(profileJSON.Lastname);
	$(".addressTxt").val(profileJSON.Address);
	$(".designationTxt").val(profileJSON.Designation);
	$(".officeAddressTxt").val(profileJSON.OfficeAddress);
	$(".engagedFromTxt").val( moment(profileJSON.EngagedFrom).format("DD/MM/YYYY"));
	$(".engagedToTxt").val(moment(profileJSON.EngagedTo).format("DD/MM/YYYY"));
	$(".willingChkBox").attr("checked", profileJSON.WillTravel);
}