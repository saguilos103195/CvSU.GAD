<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="CvSU.GAD.Web.Documents.Programs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<%--<script type="text/javascript" src="../Content/Scripts/colleges.js"></script>--%>
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<div class="form-modal-overlay">
		<div class="archive-modal">
			<p>Are you sure want to archive</p>
			<span></span>
			<asp:Button runat="server" ID="ArchiveBtn" OnClick="ArchiveBtn_Click" CssClass="button-control button-red" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>
	</div>
	<div class="form">
		<p>Programs</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">Add</span>
			<span onclick="switchTab(1)">View All</span>
			<span onclick="switchTab(4)">Archived</span>
		</div>
		<%--<div class="form-body tab-control">
			<div class="form-col-1">
				<div>
					<p>Title</p>
					<input required runat="server" id="titleTxt" type="text" class="input-text-control" />
					<span>Test Error</span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Alias</p>
					<input required runat="server" id="aliasTxt" type="text" class="input-text-control" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<label class="check-control">
						<p>Main Campus</p>
						<input runat="server" id="typeChkBx" value="true" type="checkbox">
						<span class="checkmark"></span>
					</label>
				</div>
			</div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
				<asp:Button ID="createBtn" runat="server" OnClick="createBtn_Click" />
			</div>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="viewTable"></table>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="archiveTable"></table>
		</div>--%>
	</div>
</asp:Content>
