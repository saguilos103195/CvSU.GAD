function ProcessModel(Model, Counter) {
	var JSONModel = new Object();

	$('div[attr="' + Model + '"][item="' + Counter + '"] *[model="' + Model + '"]').each(function () {
		var Attribute = $(this).attr("attr");
		var AttributeType = $(this).attr("attrtype");

		if (AttributeType === "single") {
			if ($(this).attr("type") === "checkbox")
			{
				JSONModel[Attribute] = this.checked;
			}
			else
			{
				JSONModel[Attribute] = $(this).val() === "" ? null : $(this).val();
			}
		}
		else if (AttributeType === "list") {
			var ObjectList = [];
			var counter = 0;

			$(this).find('div[model="' + Attribute + '"][attr="' + Attribute + '"][attrtype="listitem"]').each(function () {

				ObjectList.push(ProcessModel(Attribute, counter));

				counter++;
			});

			JSONModel[Attribute] = ObjectList;
		}
	});

	return JSONModel;
}

$(document).ready(function () {

	$(document).on("focusin", "*[require]", function () {

		$(this).removeAttr("style");
		$(this).next().removeAttr("style");

	});

	$(document).on("focusin", ".ui-selectmenu-button", function () {

		$(this).removeAttr("style");
		$(this).next().removeAttr("style");

	});

});

function isFormValid(form)
{
	var isValid = true;
	var gotFocus = false;

	form.find("*[require]").each(function ()
	{
		if ($(this).is("select"))
		{
			if ($(this).val() === "" || $(this).val() === null)
			{
				$(this).next().css("border-color", "#f62d51");
				$(this).next().next().css("display", "block");
				$(this).next().next().html("This field is required");
				$(this).next().next().css("color", "#f62d51");

				if (gotFocus === false) {
					$("html, body").scrollTop($(this).next().offset().top - 50);
					gotFocus = true;
				}

				isValid = false;
			}
			else
			{
				$(this).next().removeAttr("style");
				$(this).next().next().removeAttr("style");
			}
		}
		else
		{
			if ($(this).val() === "")
			{
				$(this).css("border-color", "#f62d51");
				$(this).next().css("display", "block");
				$(this).next().html("This field is required");
				$(this).next().css("color", "#f62d51");

				if (gotFocus === false) {
					$("html, body").scrollTop($(this).offset().top - 50);
					gotFocus = true;
				}

				isValid = false;
			}
			else
			{
				$(this).removeAttr("style");
				$(this).next().removeAttr("style");
			}
		}
	});

	return isValid;
}