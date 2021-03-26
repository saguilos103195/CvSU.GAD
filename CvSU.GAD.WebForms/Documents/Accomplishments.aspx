<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Accomplishments.aspx.cs" Inherits="CvSU.GAD.WebForms.Documents.Accomplishments" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/accomplishments.js" type="text/javascript"></script>
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">Accomplishment Reports</h1>
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
						<label for="txtTitle">Title</label>
						<input runat="server" type="text" class="form-control required txtTitle" id="txtTitle" aria-describedby="titleError" placeholder="Enter Title">
						<small id="titleError" class="invalid-feedback">This field is required.</small>
					</div>
					<div class="form-group mb-4">
						<label for="fileDocument">Choose Report Document</label>
						<input type="file" class="form-control-file required fileDocument" runat="server" id="fileDocument" accept=".xlsx,.xls, .doc, .docx,.ppt, .pptx,.txt,.pdf" aria-describedby="documentError">
						<small id="documentError" class="invalid-feedback">This field is required.</small>
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
									<th>Created By</th>
									<th>Status</th>
									<th class="actionCol">Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Title</th>
									<th>Created By</th>
									<th>Status</th>
									<th class="actionCol">Action</th>
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
