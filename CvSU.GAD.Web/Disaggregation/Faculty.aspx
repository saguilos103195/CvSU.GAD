<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs" Inherits="CvSU.GAD.Web.Disaggregation.Faculty" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/faculty.js"></script>
	<input type="hidden" runat="server" id="selectedID" class="selectedID" />
	<div class="form-modal-overlay">
		<div class="archive-alert">
			<i class="far fa-question-circle"></i>
			<p>Are you sure want to delete</p>
			<span></span>
			<asp:Button runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" CssClass="button-control button-red" Text="Ok" />
			<button type="button" class="button-control button-blue" onclick="hideModal()">Cancel</button>
		</div>
	</div>
	<div class="form">
		<p>Faculty Sex Disaggregation</p>
		<div class="form-tabs">
			<span onclick="switchTab(0)">Add</span>
			<span onclick="switchTab(1)">View All</span>
		</div>
		<div class="form-body tab-control">
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
			<div class="form-col-1">
				<div>
					<p>Position</p>
                    <select require class="select-control" id="positionSel">
				        <option selected disabled value="">Select Position</option>
			        </select>
			        <span></span>
                </div>
				<input type="hidden" runat="server" id="selectedPositionTxt" class="selectedPositionTxt" />
			</div>
			<div class="form-col-4">
				<div>
					<p>Male Quantity</p>
					<input require runat="server" id="maleQTxt" type="text" class="input-text-control" />
					<span></span>
				</div>
				<div>
					<p>Female Quantity</p>
					<input require runat="server" id="femaleQTxt" type="text" class="input-text-control" />
					<span></span>
				</div>
				<div>
					<p>Semester</p>
					<select require class="select-control" id="semesterSel" runat="server">
						<option selected disabled value="">Select Type</option>
						<option>First</option>
						<option>Second</option>
					</select>
					<span></span>
				</div>
				<div>
					<p>School Year</p>
					<select require class="select-control" id="schoolYearSel">
						<option selected disabled value="">Select Type</option>
					</select>
					<span></span>
				</div>
				<input type="hidden" runat="server" id="schoolYearTxt" class="schoolYearTxt" />
			</div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
				<asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" />
			</div>
		</div>
		<div class="table-view-control tab-control">
			<table class="table-control" id="viewTable"></table>
		</div>
	</div>
</asp:Content>
