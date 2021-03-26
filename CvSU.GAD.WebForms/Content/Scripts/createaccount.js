$(document).ready(function () {

    $("#collapseAccount").parent(".nav-item").addClass("active");
    $("#createAccountTab").addClass("active");

    $("#createBtn").click(function () {

        if (isFormValid($(".form")) & isPasswordValid())
        {
            commandClick("createBtn");
        }

    });

    $(document).on("change", ".selectType", function () {

        if ($(this).val() == "Coordinator")
        {
            $(".selectCollege").parent(".form-group").removeClass("d-none");
            $(".selectCollege").addClass("required");
        }
        else
        {
            $(".selectCollege").val("");
            $(".selectCollege").parent(".form-group").addClass("d-none");
            $(".selectCollege").removeClass("required");
        }

    });

    //loadCollege();

});

function isPasswordValid()
{
    var isValid = true;

    if ($(".txtPassword").val().length > 0)
    {
        if ($(".txtPassword").val().length < 8)
        {
            $("#passwordError").html("Passwords must be atleast 8 characters.");
            $(".txtPassword").addClass("is-invalid");
            isValid = false;
        }
        else
        {
            $("#passwordError").html("This field is required.");
            $(".txtPassword").removeClass("is-invalid");

            if ($(".txtPassword").val() != $(".txtConfirmPassword").val())
            {
                console.log("Passwords not match.");
                $("#confirmPasswordError").html("Passwords did not match.");
                $(".txtConfirmPassword").addClass("is-invalid");
                var isValid = false;
            }
            else
            {
                $("#confirmPasswordError").html("This field is required.");
                $(".txtConfirmPassword").removeClass("is-invalid");
            }
        }
    }

    return isValid;
}

function loadCollege()
{
	$(".selectCollege").children("option").remove();
    $(".selectCollege").append("<option selected disabled value=''>Select College</option>");

	jQuery.each(collegeSelectJSON, function (index, item) {
		var option = document.createElement("option");
		$(option).html(item.Name);
		$(option).val(item.ID);
        $(".selectCollege").append(option);
	});

}