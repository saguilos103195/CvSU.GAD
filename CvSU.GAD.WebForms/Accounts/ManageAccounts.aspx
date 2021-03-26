<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="CvSU.GAD.WebForms.Accounts.ManageAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/manageaccounts.js" type="text/javascript"></script>
<div class="container-fluid">
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<asp:Button runat="server" ID="ArchiveBtn" OnClick="ArchiveBtn_Click" CssClass="d-none archiveBtn" Text="Ok" />
	<asp:Button runat="server" ID="RetrieveBtn" OnClick="RetrieveBtn_Click" CssClass="d-none retrieveBtn" Text="Ok" />
    <h1 class="h3 mb-2 text-gray-800">Manage Accounts</h1>
    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
		<li class="nav-item">
			<a class="nav-link active" id="pills-viewall-tab" data-toggle="pill" href="#pills-viewall" role="tab" aria-controls="pills-viewall" aria-selected="true">View All</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-archived-tab" data-toggle="pill" href="#pills-archived" role="tab" aria-controls="pills-archived" aria-selected="false">Archived</a>
		</li>
	</ul>
	<div class="tab-content" id="pills-tabContent">
		<div class="tab-pane fade show active" id="pills-viewall" role="tabpanel" aria-labelledby="pills-viewall-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="viewTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Username</th>
									<th>Type</th>
									<th>Created By</th>
									<th>College</th>
									<th class="actionCol">Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Username</th>
									<th>Type</th>
									<th>Created By</th>
									<th>College</th>
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
		<div class="tab-pane fade" id="pills-archived" role="tabpanel" aria-labelledby="pills-archived-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="archiveTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Username</th>
									<th>Type</th>
									<th>Created By</th>
									<th>College</th>
									<th class="actionCol">Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Username</th>
									<th>Type</th>
									<th>Created By</th>
									<th>College</th>
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
