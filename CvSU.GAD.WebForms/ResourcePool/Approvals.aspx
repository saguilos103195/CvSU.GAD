<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Approvals.aspx.cs" Inherits="CvSU.GAD.WebForms.ResourcePool.Approvals" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/approvals.js" type="text/javascript"></script>
<div class="container-fluid">
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<asp:Button runat="server" ID="ApproveBtn" OnClick="ApproveBtn_Click" CssClass="d-none approveSeminarBtn" Text="Ok" />
	<asp:Button runat="server" ID="RejectBtn" OnClick="RejectBtn_Click" CssClass="d-none rejectSeminarBtn" Text="Ok" />

	<asp:Button runat="server" ID="ApproveExtensionBtn" OnClick="ApproveExtensionBtn_Click" CssClass="d-none approveExtensionBtn" Text="Ok" />
	<asp:Button runat="server" ID="RejectExtensionBtn" OnClick="RejectExtensionBtn_Click" CssClass="d-none rejectExtensionBtn" Text="Ok" />

	<asp:Button runat="server" ID="ApproveAccomplishmentBtn" OnClick="ApproveAccomplishmentBtn_Click" CssClass="d-none approveAccomplishmentBtn" Text="Ok" />
	<asp:Button runat="server" ID="RejectAccomplishmentBtn" OnClick="RejectAccomplishmentBtn_Click" CssClass="d-none rejectAccomplishmentBtn" Text="Ok" />

    <h1 class="h3 mb-2 text-gray-800">Approvals</h1>


	<ul class="nav nav-pills mb-3" id="approval-pills-tab" role="tablist">
		<li class="nav-item">
			<a class="nav-link active" id="pills-seminar-tab" data-toggle="pill" href="#pills-seminar" role="tab" aria-controls="pills-seminar" aria-selected="true">Seminar</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-extensions-tab" data-toggle="pill" href="#pills-extensions" role="tab" aria-controls="pills-extensions" aria-selected="false">Extensions</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" id="pills-accomplishments-tab" data-toggle="pill" href="#pills-accomplishments" role="tab" aria-controls="pills-accomplishments" aria-selected="false">Accomplishments</a>
		</li>
	</ul>

	<div class="tab-content" id="pills-approvalTabContent">
		<div class="tab-pane fade show active" id="pills-seminar" role="tabpanel" aria-labelledby="pills-seminar-tab">
			<div class="card">
				<div class="card-header">
					<ul class="nav nav-tabs card-header-tabs">
						<li class="nav-item">
							<a class="nav-link active" id="tabs-pending-seminar-tab" data-toggle="tab" href="#tabs-pending-seminar" role="tab" aria-controls="tabs-pending-seminar" aria-selected="true">Pending</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-approved-seminar-tab" data-toggle="tab" href="#tabs-approved-seminar" role="tab" aria-controls="tabs-approved-seminar" aria-selected="false">Approved</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-rejected-seminar-tab" data-toggle="tab" href="#tabs-rejected-seminar" role="tab" aria-controls="tabs-rejected-seminar" aria-selected="false">Rejected</a>
						</li>
					</ul>
				</div>
				<div class="card-body">
					<div class="tab-content" id="pills-seminarTabContent">
						<div class="tab-pane fade show active" id="tabs-pending-seminar" role="tabpanel" aria-labelledby="tabs-pending-seminar-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="pendingSeminarTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Name</th>
											<th>Year</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Name</th>
											<th>Year</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</tfoot>
									<tbody>
								
									</tbody>
								</table>
							</div>
						</div>
						<div class="tab-pane fade show" id="tabs-approved-seminar" role="tabpanel" aria-labelledby="tabs-approved-seminar-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="approvedSeminarTable" width="100%" cellspacing="0">
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
						<div class="tab-pane fade show" id="tabs-rejected-seminar" role="tabpanel" aria-labelledby="tabs-rejected-seminar-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="rejectedSeminarTable" width="100%" cellspacing="0">
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
		<div class="tab-pane fade" id="pills-extensions" role="tabpanel" aria-labelledby="pills-extensions-tab">
			<div class="card">
				<div class="card-header">
					<ul class="nav nav-tabs card-header-tabs">
						<li class="nav-item">
							<a class="nav-link active" id="tabs-pending-extensions-tab" data-toggle="tab" href="#tabs-pending-extensions" role="tab" aria-controls="tabs-pending-extensions" aria-selected="true">Pending</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-approved-extensions-tab" data-toggle="tab" href="#tabs-approved-extensions" role="tab" aria-controls="tabs-approved-extensions" aria-selected="false">Approved</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-rejected-extensions-tab" data-toggle="tab" href="#tabs-rejected-extensions" role="tab" aria-controls="tabs-rejected-extensions" aria-selected="false">Rejected</a>
						</li>
					</ul>
				</div>
				<div class="card-body">
					<div class="tab-content" id="pills-extensionsTabContent">
						<div class="tab-pane fade show active" id="tabs-pending-extensions" role="tabpanel" aria-labelledby="tabs-pending-extensions-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="pendingExtensionsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</tfoot>
									<tbody>
								
									</tbody>
								</table>
							</div>
						</div>
						<div class="tab-pane fade show" id="tabs-approved-extensions" role="tabpanel" aria-labelledby="tabs-approved-extensions-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="approvedExtensionsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</tfoot>
									<tbody>
								
									</tbody>
								</table>
							</div>
						</div>
						<div class="tab-pane fade show" id="tabs-rejected-extensions" role="tabpanel" aria-labelledby="tabs-rejected-extensions-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="rejectedExtensionsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
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
		<div class="tab-pane fade" id="pills-accomplishments" role="tabpanel" aria-labelledby="pills-accomplishments-tab">
			<div class="card">
				<div class="card-header">
					<ul class="nav nav-tabs card-header-tabs">
						<li class="nav-item">
							<a class="nav-link active" id="tabs-pending-accomplishments-tab" data-toggle="tab" href="#tabs-pending-accomplishments" role="tab" aria-controls="tabs-pending-accomplishments" aria-selected="true">Pending</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-approved-accomplishments-tab" data-toggle="tab" href="#tabs-approved-accomplishments" role="tab" aria-controls="tabs-approved-accomplishments" aria-selected="false">Approved</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" id="tabs-rejected-accomplishments-tab" data-toggle="tab" href="#tabs-rejected-accomplishments" role="tab" aria-controls="tabs-rejected-accomplishments" aria-selected="false">Rejected</a>
						</li>
					</ul>
				</div>
				<div class="card-body">
					<div class="tab-content" id="pills-accomplishmentsTabContent">
						<div class="tab-pane fade show active" id="tabs-pending-accomplishments" role="tabpanel" aria-labelledby="tabs-pending-accomplishments-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="pendingAccomplishmentsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
											<th class="actionCol">Action</th>
										</tr>
									</tfoot>
									<tbody>
								
									</tbody>
								</table>
							</div>
						</div>
						<div class="tab-pane fade show" id="tabs-approved-accomplishments" role="tabpanel" aria-labelledby="tabs-approved-accomplishments-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="approvedAccomplishmentsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</tfoot>
									<tbody>
								
									</tbody>
								</table>
							</div>
						</div>
						<div class="tab-pane fade show" id="tabs-rejected-accomplishments" role="tabpanel" aria-labelledby="tabs-rejected-accomplishments-tab">
							<div class="table-responsive">
								<table class="table table-bordered" id="rejectedAccomplishmentsTable" width="100%" cellspacing="0">
									<thead>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
											<th>Owner</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>Title</th>
											<th>Document Name</th>
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
	</div>
</div>
</asp:Content>
