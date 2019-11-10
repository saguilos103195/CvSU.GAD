<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.ManageAccounts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/accounts.js"></script>
	<div class="form">
		<p>Manage Accounts</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">View All</span>
			<span onclick="switchTab(1)">Archived</span>
		</div>
	</div>
</asp:Content>
