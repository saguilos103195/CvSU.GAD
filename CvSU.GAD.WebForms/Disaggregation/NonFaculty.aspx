<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="NonFaculty.aspx.cs" Inherits="CvSU.GAD.WebForms.Disaggregation.NonFaculty" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/employee.js" type="text/javascript"></script>
<input type="hidden" runat="server" id="selectedID" class="selectedID" />
<asp:Button runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" CssClass="d-none deleteBtn" />
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">Non-Faculty Sex Disaggregation</h1>
    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
		<li class="nav-item">
			<a class="nav-link" id="pills-add-tab" data-toggle="pill" href="#pills-add" role="tab" aria-controls="pills-add" aria-selected="true">Add</a>
		</li>
		<li class="nav-item">
			<a class="nav-link active" id="pills-viewall-tab" data-toggle="pill" href="#pills-viewall" role="tab" aria-controls="pills-viewall" aria-selected="false">View All</a>
		</li>
	</ul>
	<div class="tab-content" id="pills-tabContent">
		<div class="tab-pane fade show" id="pills-add" role="tabpanel" aria-labelledby="pills-add-tab">
			<div class="card shadow mb-4">
				<div class="card-body form">
					<div class="form-group">
						<label for="selectCollege">College</label>
						<select runat="server" class="form-control required selectCollege" id="selectCollege" aria-describedby="collegeError">
							<option selected disabled value="">Select College</option>
						</select>
						<small id="collegeError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="selectDepartment">Department</label>
						<select runat="server" class="form-control required selectDepartment" id="selectDepartment" aria-describedby="departmentError">
							<option selected disabled value="">Select Department</option>
						</select>
						<small id="departmentError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="selectPosition">Position</label>
						<select runat="server" class="form-control required selectPosition" id="selectPosition" aria-describedby="positionError">
							<option selected disabled value="">Select Position</option>
						</select>
						<small id="positionError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="row">
						<div class="col-6">
							<div class="form-group">
								<label for="numMaleQuantity">Male Quantity</label>
								<input runat="server" type="number" class="form-control required numMaleQuantity" id="numMaleQuantity" min="0" aria-describedby="maleQuantityError" placeholder="Enter number">
								<small id="maleQuantityError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
						<div class="col-6">
							<div class="form-group">
								<label for="numFemaleQuantity">Female Quantity</label>
								<input runat="server" type="number" class="form-control required numFemaleQuantity" id="numFemaleQuantity" min="0" aria-describedby="femaleQuantityError" placeholder="Enter number">
								<small id="femaleQuantityError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
					</div>
					<div class="row">
						<div class="col-6">
							<div class="form-group">
								<label for="selectSemester">Semester</label>
								<select runat="server" class="form-control required selectSemester" id="selectSemester" aria-describedby="semesterError">
									<option selected disabled value="">Select Semester</option>
									<option>First</option>
									<option>Second</option>
								</select>
								<small id="semesterError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
						<div class="col-6">
							<div class="form-group">
								<label for="selectSchoolYear">School Year</label>
								<select runat="server" class="form-control required selectSchoolYear" id="selectSchoolYear" aria-describedby="schoolYearError">
									<option selected disabled value="">Select School Year</option>
								</select>
								<small id="schoolYearError" class="invalid-feedback">This field is required.</small>
							</div>
						</div>
					</div>
					<button id="createBtn" type="button" class="commandBtn btn btn-primary">Create</button>
					<asp:Button runat="server" ID="CreateBtn" OnClick="CreateBtn_Click" CssClass="createBtn d-none" />
				</div>
			</div>
		</div>
		<div class="tab-pane fade show active" id="pills-viewall" role="tabpanel" aria-labelledby="pills-viewall-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="viewTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Position</th>
									<th>Department</th>
									<th>Male</th>
									<th>Female</th>
									<th>Semester</th>
									<th>School Year</th>
									<th>Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Position</th>
									<th>Department</th>
									<th></th>
									<th></th>
									<th>Semester</th>
									<th>School Year</th>
									<th></th>
								</tr>
							</tfoot>
							<tbody>
								
							</tbody>
						</table>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
