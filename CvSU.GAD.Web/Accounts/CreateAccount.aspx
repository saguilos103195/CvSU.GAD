<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Content/Scripts/createaccount.js"></script>
	<div class="form">
		<p>Accounts</p>
		<div class="form-body">
			<p>Create Account</p>
			<div class="form-col-1">
				<div>
					<p>Username</p>
					<input require type="text" class="input-text-control" id="usernameTxt" runat="server" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Password</p>
					<input require type="password" class="input-text-control passwordTxt" id="passwordTxt" runat="server" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Confirm Password</p>
					<input require type="password" class="input-text-control confirmPasswordTxt" id="confirmPasswordTxt" runat="server" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Type</p>
					<select require class="select-control accountTypeSel" id="accountTypeSel" runat="server">
						<option selected disabled value="">Select Type</option>
						<option>Administrator</option>
						<option>Coordinator</option>
					</select>
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
				<input type="hidden" class="selectedCollegeTxt" runat="server" id="selectedCollegeTxt" />
			</div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
				<asp:Button runat="server" ID="CreateBtn" OnClick="CreateBtn_Click" />
			</div>
		</div>
	</div>
</asp:Content>
