<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Approvals.aspx.cs" Inherits="CvSU.GAD.WebForms.ResourcePool.Approvals" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/approvals.js" type="text/javascript"></script>
<div class="container-fluid">
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<asp:Button runat="server" ID="ApproveBtn" OnClick="ApproveBtn_Click" CssClass="d-none approveBtn" Text="Ok" />
	<asp:Button runat="server" ID="RejectBtn" OnClick="RejectBtn_Click" CssClass="d-none rejectBtn" Text="Ok" />
    <h1 class="h3 mb-2 text-gray-800">Seminar Approvals</h1>
    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
		<li class="nav-item">
			<a class="nav-link active" id="pills-pending-tab" data-toggle="pill" href="#pills-pending" role="tab" aria-controls="pills-pending" aria-selected="true">Pending</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-approved-tab" data-toggle="pill" href="#pills-approved" role="tab" aria-controls="pills-approved" aria-selected="false">Approved</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-rejected-tab" data-toggle="pill" href="#pills-rejected" role="tab" aria-controls="pills-rejected" aria-selected="false">Rejected</a>
		</li>
	</ul>
	<div class="tab-content" id="pills-tabContent">
		<div class="tab-pane fade show active" id="pills-pending" role="tabpanel" aria-labelledby="pills-pending-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="pendingTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
									<th>Action</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
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
		<div class="tab-pane fade" id="pills-approved" role="tabpanel" aria-labelledby="pills-approved-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="approvedTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
								</tr>
							</tfoot>
							<tbody>
								
							</tbody>
						</table>
					</div>
				</div>
			</div>
		</div>
		<div class="tab-pane fade" id="pills-rejected" role="tabpanel" aria-labelledby="pills-rejected-tab">
			<div class="card shadow mb-4">
				<div class="card-body">
					<div class="table-responsive">
						<table class="table table-bordered" id="rejectedTable" width="100%" cellspacing="0">
							<thead>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<th>Name</th>
									<th>Year</th>
									<th>Owner</th>
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
