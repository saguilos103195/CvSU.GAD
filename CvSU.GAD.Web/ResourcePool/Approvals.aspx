<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Approvals.aspx.cs" Inherits="CvSU.GAD.Web.ResourcePool.Approvals" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/approvals.js"></script>
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<div class="form-modal-overlay">
		<div class="archive-alert">
			<i class="far fa-question-circle"></i>
			<p>Are you sure want to reject</p>
			<span></span>
			<asp:Button runat="server" ID="RejectBtn" OnClick="RejectBtn_Click" CssClass="button-control button-red" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>
		<div class="retrieve-alert">
			<i class="far fa-question-circle"></i>
			<p>Are you sure want to approve</p>
			<span></span>
			<asp:Button runat="server" ID="ApproveBtn" OnClick="ApproveBtn_Click" CssClass="button-control button-green" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>
	</div>
	<div class="form">
		<p>Seminar Approvals</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">Pending</span>
			<span onclick="switchTab(1)">Approved</span>
			<span onclick="switchTab(2)">Rejected</span>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="pendingTable"></table>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="approvedTable"></table>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="rejectedTable"></table>
		</div>
	</div>
</asp:Content>
