<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="CvSU.GAD.WebForms.Accounts.Setup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Account Setup</title>

    <link href="/Content/Stylesheets/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
	<link href="/Content/Stylesheets/sb-admin-2.css" rel="stylesheet" type="text/css" />

	<!-- Bootstrap core JavaScript-->
	<script src="/Content/Scripts/jquery/jquery.min.js"></script>
	<script src="/Content/Scripts/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="/Content/Scripts/moment.min.js"></script>
	<!-- Core plugin JavaScript-->
	<script src="/Content/Scripts/jquery-easing/jquery.easing.min.js"></script>
    <script src="/Content/Scripts/master.js"></script>
    <script src="/Content/Scripts/setup.js"></script>
</head>
<body class="bg-gradient-primary">
    <form id="form1" runat="server">
        <div class="container">
            <div class="card shadow mb-4 mt-5">
                <div class="card-header">
                    <h2 class="text-primary">Account Setup</h2>
                </div>
                <ul class="nav nav-pills nav-fill" id="navPills">
                    <li class="nav-item">
			            <a class="nav-link rounded-0 active" id="pills-personal-tab" data-toggle="pill" href="#pills-personal" role="tab" aria-controls="pills-personal" aria-selected="true">Personal Information</a>
		            </li>
		            <li class="nav-item">
			            <a class="nav-link rounded-0 disabled btn-secondary text-white" id="pills-contact-tab" data-toggle="pill" href="#pills-contact" role="tab" aria-controls="pills-contact" aria-selected="false">Contact Information</a>
		            </li>
		            <li class="nav-item">
			            <a class="nav-link rounded-0 disabled btn-secondary text-white" id="pills-additional-tab" data-toggle="pill" href="#pills-additional" role="tab" aria-controls="pills-additional" aria-selected="false">Additional Information</a>
		            </li>
                    <li class="nav-item">
			            <a class="nav-link rounded-0 disabled btn-secondary text-white" id="pills-educational-tab" data-toggle="pill" href="#pills-educational" role="tab" aria-controls="pills-educational" aria-selected="false">Educational Attainment</a>
		            </li>
                </ul>
                <div class="card-body">
                    <div class="tab-content" id="pills-tabContent">
                        <div class="tab-pane fade show form active" id="pills-personal" role="tabpanel" aria-labelledby="pills-personal-tab">
                            <div class="form-group">
						        <label for="txtFirstName">First Name</label>
						        <input runat="server" type="text" class="form-control required txtFirstName" id="txtFirstName" aria-describedby="firstNameError" placeholder="Enter First Name"/>
						        <small id="firstNameError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="form-group">
						        <label for="txtMiddleName">Middle Name</label>
						        <input runat="server" type="text" class="form-control required txtMiddleName" id="txtMiddleName" aria-describedby="middleNameError" placeholder="Enter Middle Name"/>
						        <small id="middleNameError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="form-group">
						        <label for="txtLastName">Last Name</label>
						        <input runat="server" type="text" class="form-control required txtLastName" id="txtLastName" aria-describedby="lastNameError" placeholder="Enter Last Name"/>
						        <small id="lastNameError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtBirthdate">Birthdate</label>
						                <input runat="server" type="date" class="form-control required txtBirthdate" id="txtBirthdate" aria-describedby="birthdateError" placeholder="Enter Birthdate"/>
						                <small id="birthdateError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="selectGender">College</label>
						                <select runat="server" class="form-control required selectGender" id="selectGender" aria-describedby="genderError">
							                <option selected disabled value="">Select Gender</option>
                                            <option>Male</option>
                                            <option>Female</option>
						                </select>
						                <small id="genderError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                            </div>
                            <button type="button" class="btn btn-primary float-right" id="personalInfoBtn">Next</button>
                        </div>
                        <div class="tab-pane fade show form" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
                            <div class="form-group">
						        <label for="txtPermanentAddress">Permanent Address</label>
						        <input runat="server" type="text" class="form-control required txtPermanentAddress" id="txtPermanentAddress" aria-describedby="permanentAddressError" placeholder="Enter Permanent Address"/>
						        <small id="permanentAddressError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="form-group">
						        <label for="txtEmailAddress">Email Address</label>
						        <input runat="server" type="text" class="form-control required txtEmailAddress" id="txtEmailAddress" aria-describedby="emailAddressError" placeholder="Enter Email Address"/>
						        <small id="emailAddressError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtCellphoneNumber">Cellphone Number</label>
						                <input runat="server" type="text" class="form-control required txtCellphoneNumber" id="txtCellphoneNumber" aria-describedby="cellphoneNumberError" placeholder="Enter Cellphone Number"/>
						                <small id="cellphoneNumberError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtTelephoneNumber">Telephone Number</label>
						                <input runat="server" type="text" class="form-control required txtTelephoneNumber" id="txtTelephoneNumber" aria-describedby="telephoneNumberError" placeholder="Enter Telephone Number"/>
						                <small id="telephoneNumberError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                            </div>
                            <button type="button" class="btn btn-primary float-right ml-1" id="contactInfoBtn">Next</button>
                            <button type="button" class="btn btn-secondary float-right mr-1 prevBtn">Prev</button>
                        </div>
                        <div class="tab-pane fade show form" id="pills-additional" role="tabpanel" aria-labelledby="pills-additional-tab">
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtReligion">Religion</label>
						                <input runat="server" type="text" class="form-control required txtReligion" id="txtReligion" aria-describedby="religionError" placeholder="Enter Religion"/>
						                <small id="religionError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtDesignation">Designation</label>
						                <input runat="server" type="text" class="form-control required txtDesignation" id="txtDesignation" aria-describedby="designationError" placeholder="Enter Designation"/>
						                <small id="designationError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                            </div>
                            <div class="form-group">
						        <label for="txtOfficeAddress">Office Address</label>
						        <input runat="server" type="text" class="form-control required txtOfficeAddress" id="txtOfficeAddress" aria-describedby="officeAddressError" placeholder="Enter Office Address"/>
						        <small id="officeAddressError" class="invalid-feedback">This field is required.</small>
					        </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtEngagementFrom">Engagement on GAD From</label>
						                <input runat="server" type="date" class="form-control required txtEngagementFrom" id="txtEngagementFrom" aria-describedby="engagementFromError" placeholder="Enter Engagement From"/>
						                <small id="engagementFromError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
						                <label for="txtEngagementTo">Engagement on GAD To</label>
						                <input runat="server" type="date" class="form-control required txtEngagementTo" id="txtEngagementTo" aria-describedby="engagementToError" placeholder="Enter Engagement To"/>
						                <small id="engagementToError" class="invalid-feedback">This field is required.</small>
					                </div>
                                </div>
                            </div>
                            <div class="row">
								<div class="col-12">
									<div class="form-check mb-4">
										<input type="checkbox" runat="server" class="form-check-input checkBoxWillTravel" id="checkBoxWillTravel" />
										<label class="form-check-label" for="checkBoxWillTravel">Willing to travel to CALABARZON Provinces</label>
									</div>
								</div>
							</div>
                            <button type="button" class="btn btn-primary float-right ml-1" id="additionalInfoBtn">Next</button>
                            <button type="button" class="btn btn-secondary float-right mr-1 prevBtn">Prev</button>
                        </div>
                        <div class="tab-pane fade show" id="pills-educational" role="tabpanel" aria-labelledby="pills-educational-tab">
                            <input type="hidden" runat="server" id="educListJson" class="educListJson" />
                            <div id="educationContainer">
                                <div class="educItem">
                                    <div class="form-group">
						                <label>Name of School</label>
						                <input type="text" class="form-control required schoolName" aria-describedby="schoolNameError1" placeholder="Enter Name of School"/>
						                <small id="schoolNameError1" class="invalid-feedback">This field is required.</small>
					                </div>
                                    <div class="form-group">
						                <label>Degree/Course</label>
						                <input type="text" class="form-control required schoolCourse" aria-describedby="courseError1" placeholder="Enter Degree/Course"/>
						                <small id="courseError1" class="invalid-feedback">This field is required.</small>
					                </div>
                                    <div class="row">
                                        <div class="col-4">
                                            <div class="form-group">
						                        <label>Level</label>
						                        <select class="form-control required schoolLevel" aria-describedby="levelError1">
							                        <option selected disabled value="">Select Level</option>
                                                    <option>College</option>
                                                    <option>Post Graduate</option>
                                                    <option>Vocational</option>
						                        </select>
						                        <small id="levelError1" class="invalid-feedback">This field is required.</small>
					                        </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
						                        <label>Inclusive Date From</label>
						                        <input type="date" class="form-control required schoolDateFrom" aria-describedby="dateFromError1"/>
						                        <small id="dateFromError1" class="invalid-feedback">This field is required.</small>
					                        </div>
                                        </div>
                                         <div class="col-4">
                                            <div class="form-group">
						                        <label>Inclusive Date To</label>
						                        <input type="date" class="form-control required schoolDateTo" aria-describedby="dateToError1"/>
						                        <small id="dateToError1" class="invalid-feedback">This field is required.</small>
					                        </div>
                                        </div>
                                    </div>
                                    <div class="dropdown-divider">

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <button type="button" class="btn btn-light border-primary text-primary float-right mt-3 mb-3" id="addEducBtn">Add Educational Attainment</button>
                                </div>
                            </div>
                            <asp:Button ID="SubmitBtn" runat="server" CssClass="d-none submitBtn" OnClick="SubmitBtn_Click" />
                            <button type="button" class="btn btn-primary float-right ml-1" id="submitBtn">Submit</button>
                            <button type="button" class="btn btn-secondary float-right mr-1 prevBtn">Prev</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="educItem d-none" id="educItemTemplate">
            <div class="row">
                <div class="col-12">
                    <button type="button" class="close deleteEducBtn" >
			            <span aria-hidden="true">&times;</span>
			        </button>
                </div>
            </div>
            <div class="form-group">
				<label>Name of School</label>
				<input type="text" class="form-control required schoolName" aria-describedby="schoolNameError" placeholder="Enter Name of School"/>
				<small id="schoolNameError" class="invalid-feedback">This field is required.</small>
			</div>
            <div class="form-group">
				<label>Degree/Course</label>
				<input type="text" class="form-control required schoolCourse" aria-describedby="courseError" placeholder="Enter Degree/Course"/>
				<small id="courseError" class="invalid-feedback">This field is required.</small>
			</div>
            <div class="row">
                <div class="col-4">
                    <div class="form-group">
						<label>Level</label>
						<select class="form-control required schoolLevel" aria-describedby="levelError">
							<option selected disabled value="">Select Level</option>
                            <option>College</option>
                            <option>Post Graduate</option>
                            <option>Vocational</option>
						</select>
						<small id="levelError" class="invalid-feedback">This field is required.</small>
					</div>
                </div>
                <div class="col-4">
                    <div class="form-group">
						<label>Inclusive Date From</label>
						<input type="date" class="form-control required schoolDateFrom" aria-describedby="dateFromError"/>
						<small id="dateFromError" class="invalid-feedback">This field is required.</small>
					</div>
                </div>
                    <div class="col-4">
                    <div class="form-group">
						<label>Inclusive Date To</label>
						<input type="date" class="form-control required schoolDateTo" aria-describedby="dateToError"/>
						<small id="dateToError" class="invalid-feedback">This field is required.</small>
					</div>
                </div>
            </div>
            <div class="dropdown-divider">

            </div>
        </div>
        <div class="modal fade" id="alertModal" tabindex="-1" role="dialog" aria-labelledby="alertModalTitle" aria-hidden="true">
			<div class="modal-dialog" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="alertModalTitle"></h5>
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="text-center mt-4 mb-2 display-1">
						<i id="alertModalIcon"></i>
					</div>
					<div id="alertModalBody" class="modal-body text-center pb-4">
						
					</div>
					<div class="modal-footer">
						<a href="#" id="alertModalButton" onclick="$('#alertModal').modal('hide')" class="btn btn-primary"></a>
					</div>
				</div>
			</div>
		</div>
    </form>
    <script src="/Content/Scripts/sb-admin-2.js"></script>
</body>
</html>
