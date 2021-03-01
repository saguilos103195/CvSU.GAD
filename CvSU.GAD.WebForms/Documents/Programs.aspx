<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="CvSU.GAD.WebForms.Documents.Programs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/programs.js" type="text/javascript"></script>
<input type="hidden" runat="server" id="selectedID" class="selectedID" />
<asp:Button runat="server" ID="ArchiveBtn" OnClick="ArchiveBtn_Click" CssClass="d-none archiveBtn" />
<asp:Button runat="server" ID="RetrieveBtn" OnClick="RetrieveBtn_Click" CssClass="d-none retrieveBtn" />
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">Programs</h1>
    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
		<li class="nav-item">
			<a class="nav-link" id="pills-add-tab" data-toggle="pill" href="#pills-add" role="tab" aria-controls="pills-add" aria-selected="true">Add</a>
		</li>
		<li class="nav-item">
			<a class="nav-link active" id="pills-viewall-tab" data-toggle="pill" href="#pills-viewall" role="tab" aria-controls="pills-viewall" aria-selected="false">View All</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-archived-tab" data-toggle="pill" href="#pills-archived" role="tab" aria-controls="pills-archived" aria-selected="false">Archived</a>
		</li>
	</ul>
	<div class="tab-content" id="pills-tabContent">
		<div class="tab-pane fade show" id="pills-add" role="tabpanel" aria-labelledby="pills-add-tab">
			<div class="card shadow mb-4">
				<div class="card-body form">
					<div class="form-group">
						<label for="txtTitle">Title</label>
						<input runat="server" type="text" class="form-control required txtTitle" id="txtTitle" aria-describedby="titleError" placeholder="Enter title">
						<small id="titleError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="txtAlias">Alias</label>
						<input runat="server" type="text" class="form-control required txtAlias" id="txtAlias" aria-describedby="aliasError" placeholder="Enter alias">
						<small id="aliasError" class="invalid-feedback">This field is required.</small>
					</div>
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
									<th>Title</th>
									<th>Alias</th>
									<th>Department</th>
									<th>Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Title</th>
									<th>Alias</th>
									<th>Department</th>
									<th>Action</th>
								</tr>
							</tfoot>
							<tbody>
								
							</tbody>
						</table>
					</div>
				</div>
			</div>
		</div>
		<div class="tab-pane fade show" id="pills-archived" role="tabpanel" aria-labelledby="pills-archived-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="archivedTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Title</th>
									<th>Alias</th>
									<th>Department</th>
									<th>Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Title</th>
									<th>Alias</th>
									<th>Department</th>
									<th>Action</th>
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
<div class="modal fade" id="programModal" tabindex="-1" role="dialog" aria-labelledby="programModalTitle" aria-hidden="true">
	<div class="modal-dialog modal-xl" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title">Edit Program</h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<div class="card-body form-modal">
					<div class="form-group">
						<label for="txtTitleEdit">Title</label>
						<input runat="server" type="text" class="form-control required txtTitleEdit" id="txtTitleEdit" aria-describedby="titleErrorEdit" placeholder="Enter title">
						<small id="titleErrorEdit" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="txtAliasEdit">Alias</label>
						<input runat="server" type="text" class="form-control required txtAliasEdit" id="txtAliasEdit" aria-describedby="aliasErrorEdit" placeholder="Enter alias">
						<small id="aliasErrorEdit" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="selectCollegeEdit">College</label>
						<select runat="server" class="form-control required selectCollegeEdit" id="selectCollegeEdit" aria-describedby="collegeErrorEdit">
							<option selected disabled value="">Select College</option>
						</select>
						<small id="collegeErrorEdit" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group">
						<label for="selectDepartmentEdit">Department</label>
						<select runat="server" class="form-control required selectDepartmentEdit" id="selectDepartmentEdit" aria-describedby="departmentErrorEdit">
							<option selected disabled value="">Select Department</option>
						</select>
						<small id="departmentErrorEdit" class="invalid-feedback">This field is required.</small>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-danger" onclick="hideEditModal();">Cancel</button>
				<button type="button" class="btn btn-primary" id="editBtn">Confirm</button>
				<asp:Button runat="server" ID="EditBtn" OnClick="EditBtn_Click" CssClass="d-none editBtn" />
			</div>
		</div>
	</div>
</div>
</asp:Content>
