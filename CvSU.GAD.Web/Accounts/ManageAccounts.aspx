<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.ManageAccounts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/accounts.js"></script>
    <script type="text/javascript">
        switchTab(0);
    </script>
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
