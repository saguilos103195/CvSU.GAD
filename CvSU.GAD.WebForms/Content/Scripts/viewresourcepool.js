$(document).ready(function () {

    $("#collapseResource").parent(".nav-item").addClass("active");
    $("#viewResourcePoolTab").addClass("active");

    loadProfiles();

    $(document).on("change", ".selectReassignType", function () {

        if ($(this).val() == "Coordinator") {
            $(".selectReassignCollege").parent(".form-group").removeClass("d-none");
            $(".selectReassignCollege").addClass("required");
        }
        else {
            $(".selectReassignCollege").val("");
            $(".selectReassignCollege").parent(".form-group").addClass("d-none");
            $(".selectReassignCollege").removeClass("required");
        }

    });

    $("#reassignBtn").click(function () {

        if (isFormValid($("#reassignForm")))
		{
            commandClick("reassignBtn")
        }

	});

});

function showProfileModal(id)
{
    var resourcePool = resourcePoolJSON.find(r => r.Profile.ProfileID == id);
    var profile = resourcePool.Profile;
    var college = resourcePool.College;

    $("#profileModalPicture").attr("src", (profile.Image != null ? "data:image/png;base64," + profile.Image : profile.Gender == "Male" ? "/Content/Images/male.png" : "/Content/Images/female.png"));

    var middleInitial = "";

    if (profile.Middlename != "" || profile.Middlename != null) {
        middleInitial = profile.Middlename.charAt(0) + ".";
    }

    $("#profileModalCompleteName").html(profile.Firstname + " " + middleInitial + " " + profile.Lastname);
    
    if (profile.Account.Type == "Coordinator")
    {
        $("#profileModalPosition").html(college.Alias + " " + profile.Account.Type);
    }
    else
    {
        $("#profileModalPosition").html(profile.Account.Type);
    }

    $("#profileModalFirstname").html(profile.Firstname);
    $("#profileModalMiddlename").html(profile.Middlename);
    $("#profileModalLastname").html(profile.Lastname);
    $("#profileModalGender").html(profile.Gender);
    $("#profileModalBirthdate").html(moment(profile.Birthdate).format("MMMM DD, YYYY"));
    $("#profileModalEmail").html(profile.EmailAddress);
    $("#profileModalCellphone").html(profile.CellphoneNumber);
    $("#profileModalTelephone").html(profile.TelephoneNumber);
    $("#profileModalReligion").html(profile.Religion);
    $("#profileModalDesignation").html(profile.Designation);
    $("#profileModalPermanentAddress").html(profile.PermanentAddress);
    $("#profileModalOfficeAddress").html(profile.OfficeAddress);
    $("#profileModalEngagementGAD").html(moment(profile.EngagedFrom).format("MMMM DD, YYYY") + " - " + moment(profile.EngagedTo).format("MMMM DD, YYYY"));
    $("#profileModalWillTravel").html(profile.WillTravel ? "Yes" : "No");

    $("#profileModalEducList").html("");

    jQuery.each(profile.Educations, function (index, education) {

        var educItem = document.createElement("div");
        $(educItem).addClass("list-group-item list-group-item-action");

        var educDate = document.createElement("div");
        $(educDate).addClass("text-right small text-muted");
        $(educDate).html(moment(education.DateFrom).format("MM/DD/YYYY") + " - " + moment(education.DateTo).format("MM/DD/YYYY"));

        var educCourse = document.createElement("div");
        $(educCourse).addClass("text-dark");
        $(educCourse).html(education.Course);

        var educSchool = document.createElement("div");
        $(educSchool).addClass("small");
        $(educSchool).html(education.SchoolName);

        var educLevel = document.createElement("div");
        $(educLevel).addClass("small text-muted");
        $(educLevel).html(education.EducationalLevel);

        $(educItem).append(educDate);
        $(educItem).append(educCourse);
        $(educItem).append(educSchool);
        $(educItem).append(educLevel);

        $("#profileModalEducList").append(educItem);

    });

    $("#profileModalSeminarList").html("");

    jQuery.each(profile.Seminars, function (index, seminar) {

        var seminarItem = document.createElement("div");
        $(seminarItem).addClass("list-group-item list-group-item-action");

        var seminarDate = document.createElement("div");
        $(seminarDate).addClass("text-right small text-muted");
        $(seminarDate).html(seminar.Year);

        var seminarTitle = document.createElement("div");
        $(seminarTitle).html(seminar.Name);
        $(seminarTitle).addClass("text-dark");

        $(seminarItem).append(seminarDate);
        $(seminarItem).append(seminarTitle);

        $("#profileModalSeminarList").append(seminarItem);

    });


    $("#profileModal").modal("show");
}

function showReassignModal(id)
{
    var resourcePool = resourcePoolJSON.find(r => r.Profile.ProfileID == id);
    var profile = resourcePool.Profile;
    var college = resourcePool.College;

    var middleInitial = "";

    if (profile.Middlename != "" || profile.Middlename != null) {
        middleInitial = profile.Middlename.charAt(0) + ".";
    }

    $(".selectedID").val(id);
    $("#txtCompleteName").val(profile.Firstname + " " + middleInitial + " " + profile.Lastname);
    $(".selectReassignType").val(profile.Account.Type).change();
    if (profile.Account.Type == "Coordinator")
    {
        $(".selectReassignCollege").val(college.CollegeID);
    }
    else
    {
        $(".selectReassignCollege").val("");
    }

    $("#reassignModal").modal("show");
}

function hideReassignModal()
{
    $(".selectedID").val("");
    $(".txtCompleteName").val("");
    $(".selectReassignType").val("").change();
    $(".selectReassignCollege").val("");

    $("#reassignModal").modal("hide");
}

function loadProfiles()
{

    if (resourcePoolJSON != null || resourcePoolJSON != "")
    {
        if (resourcePoolJSON.length > 0)
        {
            $.each(resourcePoolJSON, function (index, resourcePool) {

                var profileItem = document.createElement("div");
                $(profileItem).addClass("col-lg-4 col-xl-4");

                var profileContainer = document.createElement("div");
                $(profileContainer).addClass("card shadow mb-4 text-center p-4");

                var profileImage = document.createElement("img")
                $(profileImage).attr("src", (resourcePool.Profile.Image != null ? "data:image/png;base64," + resourcePool.Profile.Image : resourcePool.Profile.Gender == "Male" ? "/Content/Images/male.png" : "/Content/Images/female.png"));
                $(profileImage).css("width", "8rem");
                $(profileImage).css("height", "8rem");
                $(profileImage).addClass("rounded-circle img-thumbnail m-auto");

                var middleInitial = "";

                if (resourcePool.Profile.Middlename != "" || resourcePool.Profile.Middlename != null) {
                    middleInitial = resourcePool.Profile.Middlename.charAt(0) + ".";
                }

                var profileName = document.createElement("h5");
                $(profileName).addClass("mb-0 mt-4 text-dark");
                $(profileName).html(resourcePool.Profile.Firstname + " " + middleInitial + " " + resourcePool.Profile.Lastname)

                var profilePosition = document.createElement("p");
                $(profilePosition).addClass("text-muted mb-0");
                if (resourcePool.Profile.Account.Type == "Coordinator")
                {
                    $(profilePosition).html(resourcePool.College.Alias + " " + resourcePool.Profile.Account.Type);
                }
                else
                {
                    $(profilePosition).html(resourcePool.Profile.Account.Type);
                }

                var profileStatus = document.createElement("p");

                if (resourcePool.Profile.Account.IsArchived)
                {
                    $(profileStatus).addClass("text-warning mb-2");
                    $(profileStatus).html("Archived");
                }
                else
                {
                    $(profileStatus).addClass("text-primary mb-2");
                    $(profileStatus).html("Active");
                }

                var viewBtn = document.createElement("button");
                $(viewBtn).html("View Profile");
                $(viewBtn).attr("type", "button");
                $(viewBtn).attr("onclick", "showProfileModal(" + resourcePool.Profile.ProfileID + ")");
                $(viewBtn).addClass("btn btn-primary m-1");

                var reassignBtn = document.createElement("button");
                $(reassignBtn).html("Re-assign");
                $(reassignBtn).attr("type", "button");
                $(reassignBtn).attr("onclick", "showReassignModal(" + resourcePool.Profile.ProfileID + ")");
                $(reassignBtn).addClass("btn btn-info m-1");


                $(profileContainer).append(profileImage);
                $(profileContainer).append(profileName);
                $(profileContainer).append(profilePosition);
                $(profileContainer).append(profileStatus);
                $(profileContainer).append(viewBtn);
                $(profileContainer).append(reassignBtn);

                $(profileItem).append(profileContainer);

                $("#profilesList").append(profileItem);

            });
        }
    }
}