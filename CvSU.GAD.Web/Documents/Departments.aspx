<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="CvSU.GAD.Web.Documents.Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<div class="form-modal-overlay">
		<div class="archive-modal">
			<p>Are you sure want to archive</p>
			<span></span>
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
			<asp:Button runat="server" ID="ArchiveBtn" CssClass="button-control button-red" Text="Ok" OnClick="ArchiveBtn_Click" />
		</div>
	</div>
	<div class="form">
		<p>Departments</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">Add</span>
			<span onclick="switchTab(1)">View All</span>
			<span onclick="switchTab(2)">Archived</span>
		</div>
		<div class="form-body tab-control">
			<div class="form-col-1">
				<div>
					<p>Title</p>
					<input require runat="server" id="titleTxt" type="text" class="input-text-control" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Alias</p>
					<input require runat="server" id="aliasTxt" type="text" class="input-text-control" />
					<span></span>
				</div>
			</div>
            <div class="form-col-1">
                <div>
                    <select class="select-control" id="selectCollege" onchange="getSelectedCollege()">
				        <option selected disabled value="">Select College</option>
			        </select>
			        <span></span>
                </div>
            </div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
				<asp:Button runat="server" ID="CreateBtn" CssClass="button-control button-green" OnClick="CreateBtn_Click" />
			</div>
		</div>
	</div>
	<script type="text/javascript" src="../Content/Scripts/departments.js"></script>
</asp:Content>
