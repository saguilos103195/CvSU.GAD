<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CvSU.GAD.WebForms.Projects.View" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/viewprojects.js" type="text/javascript"></script>
<div class="container-fluid">
	<h1 class="h3 mb-2 text-gray-800">View GAD Extension Projects</h1>
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
</asp:Content>
