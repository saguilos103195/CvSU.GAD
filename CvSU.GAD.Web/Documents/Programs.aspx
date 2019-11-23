<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="CvSU.GAD.Web.Documents.Programs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/programs.js"></script>
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
		<div class="form-modal">
			<div class="modal-head">
				<span>Edit</span>
				<button type="button" onclick="hideModal()">×</button>
			</div>
			<div class="modal-cont">
				<div>
					<p>Title</p>
					<input require runat="server" id="editTitleTxt" class="input-text-control editTitleTxt" />
					<span></span>
				</div>
				<div>
					<p>Alias</p>
					<input require runat="server" id="editAliasTxt" type="text" class="input-text-control editAliasTxt" />
					<span></span>
				</div>
				<div>
					<p>College</p>
                    <select class="select-control" id="editCollegeSel">
				        <option selected disabled value="">Select College</option>
			        </select>
			        <span></span>
				</div>
				<div>
					<p>Department</p>
                    <select class="select-control" id="editDepartmentSel">
				        <option selected disabled value="">Select Department First</option>
			        </select>
			        <span></span>
					<input type="hidden" runat="server" id="editSelectedDepartmentTxt" class="editSelectedDepartmentTxt" />
				</div>
			</div>
            <div class="modal-foot">
				<button class="button-control button-transparent" type="button" onclick="hideModal()">Cancel</button>
				<button class="button-control button-green updateBtn" type="button">Update</button>
				<asp:Button ID="EditBtn" runat="server" OnClick="EditBtn_Click" />
			</div>
		</div>
	</div>
	<div class="form">
		<p>Programs</p>
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
					<p>College</p>
                    <select require class="select-control" id="collegeSel">
				        <option selected disabled value="">Select College</option>
			        </select>
			        <span></span>
                </div>
            </div>
			<div class="form-col-1">
                <div>
					<p>Department</p>
                    <select require class="select-control" id="departmentSel">
				        <option selected disabled value="">Select College First</option>
			        </select>
			        <span></span>
                </div>
				<input type="hidden" runat="server" id="selectedDepartmentTxt" class="selectedDepartmentTxt" />
            </div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
				<asp:Button runat="server" ID="CreateBtn" CssClass="button-control button-green" OnClick="CreateBtn_Click" />
			</div>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="viewTable"></table>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="archiveTable"></table>
		</div>
	</div>
</asp:Content>
