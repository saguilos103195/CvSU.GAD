<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">

		$(document).ready(function () {

			$(".select-control").selectmenu();

		});

	</script>
	<div class="form">
		<p>Accounts</p>
		<div class="form-body">
			<p>Create Account</p>
			<div class="form-col-1">
				<div>
					<p>Username</p>
					<input type="text" class="input-text-control" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Password</p>
					<input type="password" class="input-text-control" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Confirm Password</p>
					<input type="password" class="input-text-control" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<p>Type</p>
					<select class="select-control">
						<option selected disabled value="">Select Type</option>
						<option>Administrator</option>
						<option>Coordinator</option>
					</select>
					<span></span>
				</div>
			</div>
			<div class="form-footer">
				<button class="button-control button-green" type="button">Create</button>
			</div>
		</div>
	</div>
</asp:Content>
