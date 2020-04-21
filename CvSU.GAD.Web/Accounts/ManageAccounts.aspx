<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.ManageAccounts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/manageaccounts.js"></script>
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<div class="form-modal-overlay">
		<div class="archive-alert">
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
		</div>
	</div>
	<div class="form">
		<p>Manage Accounts</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">View All</span>
			<span onclick="switchTab(1)">Archived</span>
		</div>
	</div>
	<div class="table-view-control tab-control">
		<table class="table-control" id="viewTable"></table>
	</div>
    <div class="table-view-control tab-control">
		<table class="table-control" id="archiveTable"></table>
	</div>
</asp:Content>
