<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CvSU.GAD.WebForms.Accounts.Profile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<input type="hidden" runat="server" id="selectedID" class="selectedID" />
<script src="/Content/Scripts/profile.js" type="text/javascript"></script>
<div class="container-fluid">
    <div class="row">
        <div class="col-lg-4 col-xl-4">
            <div class="card shadow p-4">
                <div class="text-center">
                    <img runat="server" id="profilePicture" src="#" class="rounded-circle img-thumbnail mb-2" style="width: 10rem; height: 10rem;" alt="profile-image"/>
                    <h5 class="mb-0 text-dark" runat="server" id="displayName"></h5>
                    <p class="text-muted" runat="server" id="displayPosition"></p>
                    <div class="dropdown-divider"></div>
                    <div class="text-left mt-3">
                        <p class="text-muted mb-2 font-13"><strong>Gender :</strong><span runat="server" id="displayGender" class="ml-2"></span></p>
                        <p class="text-muted mb-2 font-13"><strong>Mobile :</strong><span runat="server" id="displayContact" class="ml-2"></span></p>
                        <p class="text-muted mb-2 font-13"><strong>Email :</strong> <span runat="server" id="displayEmail" class="ml-2 "></span></p>
                        <p class="text-muted mb-1 font-13"><strong>Address :</strong><span runat="server" id="displayAddress" class="ml-2"></span></p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-8 col-xl-8">
            <ul class="nav nav-pills mb-3 mt-3" id="pills-tab" role="tablist">
		        <li class="nav-item">
			        <a class="nav-link active" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="true">Profile</a>
		        </li>
		        <li class="nav-item">
			        <a class="nav-link" id="pills-education-tab" data-toggle="pill" href="#pills-education" role="tab" aria-controls="pills-education" aria-selected="false">Education</a>
		        </li>
		        <li class="nav-item">
			        <a class="nav-link" id="pills-seminars-tab" data-toggle="pill" href="#pills-seminars" role="tab" aria-controls="pills-seminars" aria-selected="false">Seminars</a>
		        </li>
                <li class="nav-item">
			        <a class="nav-link" id="pills-settings-tab" data-toggle="pill" href="#pills-settings" role="tab" aria-controls="pills-settings" aria-selected="false">Settings</a>
		        </li>
	        </ul>
            <div class="tab-content" id="pills-tabContent">
				<div class="tab-pane fade show active" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
					<div class="card shadow mb-4" id="basicInfoForm">
						<div class="card-body">
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>First Name</sup>
										<input runat="server" type="text" class="form-control required txtFirstName" id="txtFirstName" aria-describedby="firstNameError" placeholder="Enter First Name">
										<small id="firstNameError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Middle Name</sup>
										<input runat="server" type="text" class="form-control required txtMiddleName" id="txtMiddleName" aria-describedby="middleNameError" placeholder="Enter Middle Name">
										<small id="middleNameError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Last Name</sup>
										<input runat="server" type="text" class="form-control required txtLastName" id="txtLastName" aria-describedby="lastNameError" placeholder="Enter Last Name">
										<small id="lastNameError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-6">
									<div class="form-group">
										<sup>Birthdate</sup>
										<input runat="server" type="date" class="form-control required txtBirthdate" id="txtBirthdate" aria-describedby="birthdateError" placeholder="Enter Birthdate">
										<small id="birthdateError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
								<div class="col-6">
									<div class="form-group">
										<sup>Email Address</sup>
										<input runat="server" type="text" class="form-control required txtEmailAddress" id="txtEmailAddress" aria-describedby="emailAddressError" placeholder="Enter Email Address">
										<small id="emailAddressError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-6">
									<div class="form-group">
										<sup>Cellphone Number</sup>
										<input runat="server" type="text" class="form-control required txtCellphone" id="txtCellphone" aria-describedby="cellphoneError" placeholder="Enter Cellphone Number">
										<small id="cellphoneError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
								<div class="col-6">
									<div class="form-group">
										<sup>Telephone Number</sup>
										<input runat="server" type="text" class="form-control required txtTelephone" id="txtTelephone" aria-describedby="telephoneError" placeholder="Enter Telephone Number">
										<small id="telephoneError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-6">
									<div class="form-group">
										<sup>Religion</sup>
										<input runat="server" type="text" class="form-control required txtReligion" id="txtReligion" aria-describedby="religionError" placeholder="Enter Religion">
										<small id="religionError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
								<div class="col-6">
									<div class="form-group">
										<sup>Designation</sup>
										<input runat="server" type="text" class="form-control required txtDesignation" id="txtDesignation" aria-describedby="designationError" placeholder="Enter Designation">
										<small id="designationError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Permanent Address</sup>
										<input runat="server" type="text" class="form-control required txtPermanentAddress" id="txtPermanentAddress" aria-describedby="permanentAddressError" placeholder="Enter Permanent Address">
										<small id="permanentAddressError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Office Address</sup>
										<input runat="server" type="text" class="form-control required txtOfficeAddress" id="txtOfficeAddress" aria-describedby="officeAddressError" placeholder="Enter Office Address">
										<small id="officeAddressError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-6">
									<div class="form-group">
										<sup>Engaged in GAD From</sup>
										<input runat="server" type="date" class="form-control required txtEngagedFrom" id="txtEngagedFrom" aria-describedby="engagedFromError" placeholder="Enter Date">
										<small id="engagedFromError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
								<div class="col-6">
									<div class="form-group">
										<sup>Engaged in GAD To</sup>
										<input runat="server" type="date" class="form-control required txtEngagedTo" id="txtEngagedTo" aria-describedby="engagedToError" placeholder="Enter Date">
										<small id="engagedToError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-check mb-4">
										<input type="checkbox" runat="server" class="form-check-input checkBoxWillTravel" id="checkBoxWillTravel">
										<label class="form-check-label" for="checkBoxWillTravel">Willing to travel to CALABARZON Provinces</label>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12 mt-3 mb-3">
									<button type="button" class="btn btn-primary d-block m-auto" id="updateProfileBtn">Update Profile</button>
									<asp:Button runat="server" ID="UpdateProfileBtn" OnClick="UpdateProfileBtn_Click" CssClass="d-none updateProfileBtn" />
								</div>
							</div>
						</div>
					</div>
				</div>
                <div class="tab-pane fade show" id="pills-education" role="tabpanel" aria-labelledby="pills-education-tab">
					<div class="card shadow mb-4">
						<div class="card-body">
							<div class="list-group" id="educList">
								<button onclick="showEducModal(0)" type="button" class="list-group-item list-group-item-action text-center">+ Add Education</button>
							</div>
						</div>
					</div>
				</div>
				<div class="tab-pane fade show" id="pills-seminars" role="tabpanel" aria-labelledby="pills-seminars-tab">
					<div class="card shadow mb-4">
						<div class="card-body">
							<div class="list-group" id="seminarList">
								<button onclick="showSeminarModal(0)" type="button" class="list-group-item list-group-item-action text-center">+ Add Seminar</button>
							</div>
						</div>
					</div>
				</div>
				<div class="tab-pane fade show" id="pills-settings" role="tabpanel" aria-labelledby="pills-settings-tab">
					<div class="card shadow mb-4" id="settingsForm">
						<div class="card-body">
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<label for="fileProfilePic">Choose Profile Picture</label>
										<input type="file" class="form-control-file" runat="server" id="fileProfilePic" accept="image/x-png,image/jpeg">
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12 text-center">
									<asp:Button runat="server" ID="UploadProfilePicBtn" OnClick="UploadProfilePicBtn_Click" Text="Update Profile Picture" CssClass="btn btn-primary" />
								</div>
							</div>
							<div class="row pb-4 pt-4">
								<div class="col-12">
									<div class="dropdown-divider"></div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Password</sup>
										<input runat="server" type="password" class="form-control required txtPassword" id="txtPassword" aria-describedby="passwordError" placeholder="Enter Password">
										<small id="passwordError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12">
									<div class="form-group">
										<sup>Confirm Password</sup>
										<input runat="server" type="password" class="form-control required txtConfirmPassword" id="txtConfirmPassword" aria-describedby="confirmPasswordError" placeholder="Enter Confirm Password">
										<small id="confirmPasswordError" class="invalid-feedback">This field is required.</small>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-12 text-center mt-3 mb-3">
									<button type="button" class="btn btn-primary" id="updatePasswordBtn">Update Password</button>
									<asp:Button runat="server" ID="UpdatePasswordBtn" OnClick="UpdatePasswordBtn_Click" CssClass="d-none updatePasswordBtn" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
        </div>
    </div>
</div>
<div class="modal fade" id="educationModal" tabindex="-1" role="dialog" aria-labelledby="educationModal" aria-hidden="true">
	<div class="modal-dialog modal-xl" role="document">
		<div class="modal-content" id="educationForm">
			<div class="modal-header">
				<h5 class="modal-title" id="educationModalTitle"></h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<div class="card-body form-modal">
					<div class="form-group">
						<label for="txtSchoolName">Name of School</label>
						<input runat="server" type="text" class="form-control required txtSchoolName" id="txtSchoolName" aria-describedby="schoolNameError" placeholder="Enter School Name">
						<small id="schoolNameError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="txtSchoolCourse">Course</label>
						<input runat="server" type="text" class="form-control required txtSchoolCourse" id="txtSchoolCourse" aria-describedby="schoolCourseError" placeholder="Enter Course">
						<small id="schoolCourseError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="row">
						<div class="col-4 align-self-end">
							<div class="form-group">
								<label for="selectSchoolType">Type</label>
								<select runat="server" class="form-control required selectSchoolType" id="selectSchoolType" aria-describedby="schoolTypeError">
									<option selected disabled value="">Select Level</option>
									<option>College</option>
									<option>Post Graduate</option>
									<option>Vocational</option>
								</select>
								<small id="schoolTypeError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
						<div class="col-4 align-self-end">
							<div class="form-group">
								<label for="txtSchoolDateFrom">Inclusive Date From</label>
								<input runat="server" type="date" class="form-control required txtSchoolDateFrom" id="txtSchoolDateFrom" aria-describedby="schoolDateFromError" placeholder="Enter Date From">
								<small id="schoolDateFromError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
						<div class="col-4 align-self-end">
							<div class="form-group">
								<label for="txtSchoolDateTo">Inclusive Date To</label>
								<input runat="server" type="date" class="form-control required txtSchoolDateTo" id="txtSchoolDateTo" aria-describedby="schoolDateToError" placeholder="Enter Date To">
								<small id="schoolDateToError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-danger" onclick="hideEducModal();">Cancel</button>
				<button type="button" class="btn btn-primary d-none" id="editEducBtn">Confirm</button>
				<asp:Button runat="server" ID="EditEducBtn" OnClick="EditEducBtn_Click" CssClass="d-none editEducBtn" />
				<button type="button" class="btn btn-primary d-none" id="addEducBtn">Confirm</button>
				<asp:Button runat="server" ID="AddEducBtn" OnClick="AddEducBtn_Click" CssClass="d-none addEducBtn" />
			</div>
		</div>
	</div>
</div>
<div class="modal fade" id="seminarModal" tabindex="-1" role="dialog" aria-labelledby="seminarModal" aria-hidden="true">
	<div class="modal-dialog modal-xl" role="document">
		<div class="modal-content" id="seminarForm">
			<div class="modal-header">
				<h5 class="modal-title" id="seminarModalTitle"></h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<div class="card-body form-modal">
					<div class="form-group">
						<label for="txtSeminarName">Name</label>
						<input runat="server" type="text" class="form-control required txtSeminarName" id="txtSeminarName" aria-describedby="seminarNameError" placeholder="Enter Name">
						<small id="seminarNameError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="txtSeminarYear">Year</label>
						<input runat="server" type="text" class="form-control required txtSeminarYear" id="txtSeminarYear" aria-describedby="seminarYearError" placeholder="Enter Year">
						<small id="seminarYearError" class="invalid-feedback">This field is required.</small>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-danger" onclick="hideSeminarModal();">Cancel</button>
				<button type="button" class="btn btn-primary d-none" id="editSeminarBtn">Confirm</button>
				<asp:Button runat="server" ID="EditSeminarBtn" OnClick="EditSeminarBtn_Click" CssClass="d-none editSeminarBtn" />
				<button type="button" class="btn btn-primary d-none" id="addSeminarBtn">Confirm</button>
				<asp:Button runat="server" ID="AddSeminarBtn" OnClick="AddSeminarBtn_Click" CssClass="d-none addSeminarBtn" />
			</div>
		</div>
	</div>
</div>
</asp:Content>
