﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.Profile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" href="../Content/Stylesheets/profile.css" />
	<script type="text/javascript" src="../Content/Scripts/profile.js"></script>
	<div class="form-modal-overlay">
		<%--<div class="archive-alert">
			<i class="far fa-question-circle"></i>
			<p>Are you sure want to archive</p>
			<span></span>
			<asp:Button runat="server" ID="ArchiveBtn" OnClick="ArchiveBtn_Click" CssClass="button-control button-red" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>
		<div class="retrieve-alert">
			<i class="far fa-question-circle"></i>
			<p>Are you sure want to retrieve</p>
			<span></span>
			<asp:Button runat="server" ID="RetrieveBtn" OnClick="RetrieveBtn_Click" CssClass="button-control button-red" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>--%>
		<div class="form-modal">
			<div class="modal-head">
				<span>Edit</span>
				<button type="button" onclick="hideModal()">×</button>
			</div>
			<div class="modal-cont">
				<div>
					<p>Title</p>
					<input require runat="server" id="editTitleTxt" class="input-text-control editTitleTxt" />
					<span></span>
				</div>
				<div>
					<p>Alias</p>
					<input require runat="server" id="editAliasTxt" type="text" class="input-text-control editAliasTxt" />
					<span></span>
				</div>
				<div>
					<p>College</p>
                    <select class="select-control" id="editCollegeSel">
				        <option selected disabled value="">Select College</option>
			        </select>
			        <span></span>
				</div>
				<div>
					<p>Department</p>
                    <select class="select-control" id="editDepartmentSel">
				        <option selected disabled value="">Select Department First</option>
			        </select>
			        <span></span>
					<input type="hidden" runat="server" id="editSelectedDepartmentTxt" class="editSelectedDepartmentTxt" />
				</div>
			</div>
            <div class="modal-foot">
				<button class="button-control button-transparent" type="button" onclick="hideModal()">Cancel</button>
				<button class="button-control button-green updateBtn" type="button">Update</button>
				<%--<asp:Button ID="EditBtn" runat="server" OnClick="EditBtn_Click" />--%>
			</div>
		</div>
	</div>
	<div class="profile container">
		<p>Profile</p>
		<div class="profile-body row">
			<div class="col-lg-4 col-xlg-3 col-md-5">
				<div class="card">
					<div class="card-body">
						<div class="text-center mt-4">
							<img class="profile-pic" src="../Content/Images/NC.jpg" />
							<h4 class="profile-name mt-2">Samuel Marvin Aguilos</h4>
							<h6 class="profile-position">Administrator</h6>
						</div>
					</div>
					<div>
						<hr />
					</div>
					<div class="card-body">
						<small class="text-muted">Gender</small>
						<h6 class="profile-label">Male</h6>
						<small class="text-muted">Email address</small>
						<h6 class="profile-label">samuel103195@gmail.com</h6>
						<small class="text-muted">Phone</small>
						<h6 class="profile-label">09123456789</h6>
						<small class="text-muted">Address</small>
						<h6 class="profile-label">Blk 8 Lot 35 Beverly Hills st. San Marino City, Salawag, Dasmarinas City, Cavite</h6>
					</div>
				</div>
			</div>
			<div class="col-lg-8 col-xlg-9 col-md-7">
				<div class="form-tabs">
					<span onclick="switchTab(0)">Profile</span>
					<span onclick="switchTab(1)">Education</span>
					<span onclick="switchTab(2)">Seminars</span>
					<span onclick="switchTab(3)">Settings</span>
				</div>
				<div class="form-body profile-tab tab-control">
					<div class="form-col-1">
						<div>
							<p>First Name</p>
							<input require runat="server" id="fnameTxt" type="text" class="input-text-control fnameTxt" />
							<span></span>
						</div>					</div>
					<div class="form-col-1">
						<div>
							<p>Middle Name</p>
							<input require runat="server" id="mnameTxt" type="text" class="input-text-control mnameTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Last Name</p>
							<input require runat="server" id="lnameTxt" type="text" class="input-text-control lnameTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Birthdate</p>
							<input require runat="server" id="bdateTxt" type="text" class="input-text-control bdateTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Religion</p>
							<input require runat="server" id="religionTxt" type="text" class="input-text-control religionTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-2">
						<div>
							<p>Cellphone Number</p>
							<input require runat="server" id="cellphoneTxt" type="text" class="input-text-control cellphoneTxt" />
							<span></span>
						</div>
						<div>
							<p>Telephone Number</p>
							<input require runat="server" id="telephoneTxt" type="text" class="input-text-control telephoneTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Email Address</p>
							<input require runat="server" id="emailTxt" type="text" class="input-text-control emailTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Permanent Address</p>
							<input require runat="server" id="addressTxt" type="text" class="input-text-control addressTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Designation</p>
							<input require runat="server" id="designationTxt" type="text" class="input-text-control designationTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<p>Office Address</p>
							<input require runat="server" id="officeAddressTxt" type="text" class="input-text-control officeAddressTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-2">
						<div>
							<p>Engaged in GAD From</p>
							<input require runat="server" id="engagedFromTxt" type="text" class="input-text-control engagedFromTxt" />
							<span></span>
						</div>
						<div>
							<p>Engaged in GAD To</p>
							<input require runat="server" id="engagedToTxt" type="text" class="input-text-control engagedToTxt" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<label class="check-control">
								<p>Willing to travel to CALABARZON Provinces</p>
								<input runat="server" id="willingChkBox" value="true" type="checkbox" class="willingChkBox">
								<span class="checkmark"></span>
							</label>
						</div>
					</div>
					<button class="button-control button-green" type="button" >Update Profile</button>
					<asp:Button runat="server" ID="UpdateProfileBtn" OnClick="UpdateProfileBtn_Click" />
				</div>
				<div class="form-body educ-tab tab-control">
					<div class="educ-list">
						<div onclick="addEducation()">
							<h1>+ Add Edudcation</h1>
						</div>
					</div>
				</div>
				<div class="form-body tab-control">
					<div class="form-col-1">
						<div>
							<p>Alias</p>
							<input require runat="server" id="Text4" type="text" class="input-text-control" />
							<span></span>
						</div>
					</div>
					<div class="form-col-1">
						<div>
							<label class="check-control">
								<p>Main Campus</p>
								<input runat="server" id="Checkbox2" value="true" type="checkbox">
								<span class="checkmark"></span>
							</label>
						</div>
					</div>
				</div>
				<%--<div class="card">

				</div>--%>
			</div>
		</div>
	</div>
</asp:Content>
