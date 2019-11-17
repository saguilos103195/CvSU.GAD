<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.Setup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Content/Stylesheets/setup.css" />
    <script type="text/javascript" src="../Content/Scripts/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/setup.js" ></script>
	<div class="template education-item" model="EducationalAttainments" attr="EducationalAttainments" attrtype="listitem" item="0">
		<button type="button" onclick="removeEducationalAttainment(this);">×</button>
		<div class="form-col-1">
			<div>
				<p>Name of School</p>
				<input type="text" class="input-text-control" require model="EducationalAttainments" attr="SchoolName" attrtype="single" />
				<span></span>
			</div>
		</div>
		<div class="form-col-1">
			<div>
				<p>Degree/Course</p>
				<input type="text" class="input-text-control" require model="EducationalAttainments" attr="Course" attrtype="single" />
				<span></span>
			</div>
		</div>
		<div class="form-col-3">
			<div>
				<p>Type</p>
				<select class="select-control" require model="EducationalAttainments" attr="EducationalLevel" attrtype="single">
					<option selected disabled value="">Select Level</option>
					<option>College</option>
					<option>Post Graduate</option>
					<option>Vocational</option>
				</select>
				<span></span>
			</div>
			<div>
				<p>Inclusive Date From</p>
				<input type="text" class="input-text-control inclusiveDateFromTxt" require model="EducationalAttainments" attr="DateFrom" attrtype="single" />
				<span></span>
			</div>
			<div>
				<p>Inclusive Date To</p>
				<input type="text" class="input-text-control inclusiveDateToTxt" require model="EducationalAttainments" attr="DateTo" attrtype="single" />
				<span></span>
			</div>
		</div>
	</div>
    <div class="setup">
        <p>Account Setup</p>
		<input type="hidden" runat="server" id="educListTxt" /> 
		<asp:Button runat="server" ID="CreateProfileBtn" OnClick="CreateProfileBtn_Click" />
        <div class="setup-body">
            <span>Please fill up all required fields to proceed.</span>
            <div class="setup-content">
                <h3>Personal Information</h3>
                <section>
                    <div class="form-col-3">
				        <div>
					        <p>First Name</p>
					        <input require runat="server" id="fnameTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
                        <div>
					        <p>Middle Name</p>
					        <input require runat="server" id="mnameTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
                        <div>
					        <p>Last Name</p>
					        <input require runat="server" id="lnameTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
			        </div>
			        <div class="form-col-3">
				        <div>
					        <p>Birthdate</p>
					        <input require runat="server" id="birthDateTxt" type="text" class="input-text-control birthDateTxt" />
					        <span></span>
				        </div>
                        <div>
					        <p>Gender</p>
					        <select require class="select-control" id="genderSel" runat="server">
						        <option selected disabled value="">Select Gender</option>
						        <option>Male</option>
						        <option>Female</option>
					        </select>
					        <span></span>
				        </div>
			        </div>
                </section>
                <h3>Contact Information</h3>
                <section>
                    <div class="form-col-1">
				        <div>
					        <p>Permanent Address</p>
					        <input require runat="server" id="addressTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
			        </div>
                    <div class="form-col-3">
				        <div>
					        <p>Email Address</p>
					        <input require runat="server" id="emailTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
                        <div>
					        <p>Cellphone Number</p>
					        <input require runat="server" id="cellphoneTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
                        <div>
					        <p>Telephone Number</p>
					        <input require runat="server" id="telephoneTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
			        </div>
                </section>
                <h3>Additional Information</h3>
                <section>
                    <div class="form-col-2">
				        <div>
					        <p>Religion</p>
					        <input require runat="server" id="religionTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
                        <div>
					        <p>Designation</p>
					        <input require runat="server" id="designationTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
			        </div>
                    <div class="form-col-1">
				        <div>
					        <p>Office Address</p>
					        <input require runat="server" id="officeAddressTxt" type="text" class="input-text-control" />
					        <span></span>
				        </div>
			        </div>
                    <div class="form-col-2">
				        <div>
					        <p>Engagement on GAD From</p>
					        <input require runat="server" id="engageFromTxt" type="text" class="input-text-control engageFromTxt" />
					        <span></span>
				        </div>
                        <div>
					        <p>Engagement on GAD To</p>
					        <input require runat="server" id="engageToTxt" type="text" class="input-text-control engageToTxt" />
					        <span></span>
				        </div>
			        </div>
                    <div class="form-col-1">
				        <div>
					        <label class="check-control">
						        <p>Willing to travel to CALABARZON Provinces</p>
						        <input runat="server" id="willingChkBox" value="true" type="checkbox">
						        <span class="checkmark"></span>
					        </label>
				        </div>
			        </div>
                </section>
                <h3>Educational Attainment</h3>
                <section>
                    <div model="EducationList" attr="EducationList" attrtype="listitem" item="0">
						<div model="EducationList" attr="EducationalAttainments" attrtype="list" id="educationList" >
							<div class="education-item" model="EducationalAttainments" attr="EducationalAttainments" attrtype="listitem" item="0">
								<div class="form-col-1">
									<div>
										<p>Name of School</p>
										<input type="text" class="input-text-control" require model="EducationalAttainments" attr="SchoolName" attrtype="single" />
										<span></span>
									</div>
								</div>
								<div class="form-col-1">
									<div>
										<p>Degree/Course</p>
										<input type="text" class="input-text-control" require model="EducationalAttainments" attr="Course" attrtype="single" />
										<span></span>
									</div>
								</div>
								<div class="form-col-3">
									<div>
										<p>Type</p>
										<select class="select-control" require model="EducationalAttainments" attr="EducationalLevel" attrtype="single">
											<option selected disabled value="">Select Level</option>
											<option>College</option>
											<option>Post Graduate</option>
											<option>Vocational</option>
										</select>
										<span></span>
									</div>
									<div>
										<p>Inclusive Date From</p>
										<input type="text" class="input-text-control inclusiveDateFromTxt" require model="EducationalAttainments" attr="DateFrom" attrtype="single" />
										<span></span>
									</div>
									<div>
										<p>Inclusive Date To</p>
										<input type="text" class="input-text-control inclusiveDateToTxt" require model="EducationalAttainments" attr="DateTo" attrtype="single" />
										<span></span>
									</div>
								</div>
							</div>
						</div>
                    </div>
					<div class="educational-form-control">
						<button type="button" class="button-control button-white" onclick="addEducationalAttainment();" >Add Educational Attainment</button>
					</div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
