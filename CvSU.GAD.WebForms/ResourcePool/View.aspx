<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CvSU.GAD.WebForms.ResourcePool.View" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/viewresourcepool.js" type="text/javascript"></script>
<input type="hidden" runat="server" id="selectedID" class="selectedID" />
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">GAD Resource Pool</h1>
    <div class="card shadow mb-4">
        <div class="card-body">
            <div class="row">
                <div class="col-lg-4 col-xl-4">
                    <div class="form-group">
						<label for="txtName">Name</label>
						<input type="text" class="form-control required txtName" id="txtName" placeholder="Enter Name">
					</div>
                </div>
                <div class="col-lg-4 col-xl-4">
                    <div class="form-group">
						<label for="selectCampus">Campus</label>
						<select class="form-control required selectCampus" id="selectCampus">
							<option>Any</option>
                            <option>Main</option>
                            <option>Satellite</option>
						</select>
					</div>
                </div>
                <div class="col-lg-4 col-xl-4">
                    <div class="form-group">
						<label for="selectType">Type</label>
						<select class="form-control required selectType" id="selectType">
							<option>Any</option>
                            <option>Administrator</option>
                            <option>Coordinator</option>
						</select>
					</div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="profilesList">
        
    </div>
</div>
<div class="modal fade" id="profileModal" tabindex="-1" role="dialog" aria-labelledby="profileModalTitle" aria-hidden="true">
	<div class="modal-dialog modal-lg" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title">View Profile</h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<div class="text-center">
					<img id="profileModalPicture" src="#" class="rounded-circle img-thumbnail mb-2" style="width: 10rem; height: 10rem;" alt="profile-image"/>
					<h5 class="mb-0 text-dark" id="profileModalCompleteName"></h5>
					<p class="text-muted" id="profileModalPosition"></p>
				</div>
				<div class="card mb-4">
					<div class="card-header">
						<div class="text-primary">
							Personal Information
						</div>
					</div>
					<div class="card-body">
						<div class="mb-2">
							<span class="text-dark">First Name:</span>
							<span class="text-muted" id="profileModalFirstname"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Middle Name:</span>
							<span class="text-muted" id="profileModalMiddlename"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Last Name:</span>
							<span class="text-muted" id="profileModalLastname"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Gender:</span>
							<span class="text-muted" id="profileModalGender"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Birthdate:</span>
							<span class="text-muted" id="profileModalBirthdate"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Email Address:</span>
							<span class="text-muted" id="profileModalEmail"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Cellphone Number:</span>
							<span class="text-muted" id="profileModalCellphone"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Telephone Number:</span>
							<span class="text-muted" id="profileModalTelephone"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Religion:</span>
							<span class="text-muted" id="profileModalReligion"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Designation:</span>
							<span class="text-muted" id="profileModalDesignation"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Permanent Address:</span>
							<span class="text-muted" id="profileModalPermanentAddress"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Office Address:</span>
							<span class="text-muted" id="profileModalOfficeAddress"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Engagement in GAD:</span>
							<span class="text-muted" id="profileModalEngagementGAD"></span>
						</div>
						<div class="mb-2">
							<span class="text-dark">Willing to travel to CALABARZON Provinces:</span>
							<span class="text-muted" id="profileModalWillTravel"></span>
						</div>
					</div>
				</div>
				<div class="card mb-4">
					<div class="card-header">
						<div class="text-info">
							Educational Attainment
						</div>
					</div>
					<div class="card-body">
						<div class="list-group" id="profileModalEducList">
							
						</div>
					</div>
				</div>
				<div class="card mb-4">
					<div class="card-header">
						<div class="text-warning">
							Seminars Attended
						</div>
					</div>
					<div class="card-body">
						<div class="list-group" id="profileModalSeminarList">
							<div class="list-group-item list-group-item-action">
								<div class="text-right small text-muted">1246</div>
								<div class="text-dark">Test Seminar Approved</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="modal fade" id="reassignModal" tabindex="-1" role="dialog" aria-labelledby="profileModalTitle" aria-hidden="true">
	<div class="modal-dialog modal-lg" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title">Reassign GAD Personnel</h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<p class="small">Reassigning will automatically change <span class="text-warning">Archive</span> to <span class="text-primary">Active</span> Status</p>
				<div class="form" id="reassignForm">
					<div class="form-group">
						<label for="Name">Complete Name</label>
						<input class="form-control txtUsername" disabled id="txtCompleteName" aria-describedby="completeNameError" placeholder="Enter Complete Name">
						<small id="completeNameError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="selectReassignType">Type</label>
						<select runat="server" class="form-control required selectReassignType" id="selectReassignType" aria-describedby="reassignTypeError">
							<option selected disabled value="">Select Type</option>
							<option>Administrator</option>
							<option>Coordinator</option>
						</select>
						<small id="reassignTypeError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group d-none">
						<label for="selectReassignCollege">College</label>
						<select runat="server" class="form-control selectReassignCollege" id="selectReassignCollege" aria-describedby="reassignCollegeError">
							<option selected disabled value="">Select College</option>
						</select>
						<small id="reassignCollegeError" class="invalid-feedback">This field is required.</small>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-danger" onclick="hideReassignModal();">Cancel</button>
				<button type="button" class="btn btn-primary" id="reassignBtn">Confirm</button>
				<asp:Button runat="server" ID="ReassignBtn" OnClick="ReassignBtn_Click" CssClass="d-none reassignBtn" />
			</div>
		</div>
	</div>
</div>
</asp:Content>
