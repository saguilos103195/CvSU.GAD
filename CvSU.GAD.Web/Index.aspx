<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CvSU.GAD.Web.Index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" href="Content/Stylesheets/index.css" />
	<script type="text/javascript" src="Content/Scripts/index.js"></script>
	<div class="login d-flex flex-column justify-content-center">
		<p>Cavite State University - Gender and Development</p>
		<div class="login-body align-self-center">
			<p>Sign In</p>
			<div class="form-col-1">
				<div>
					<%--<p>Title</p>--%>
					<input runat="server" id="usernameTxt" type="text" class="input-text-control" placeholder="Username" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<%--<p>Title</p>--%>
					<input runat="server" id="passwordTxt" type="password" class="input-text-control" placeholder="Password" />
					<span></span>
				</div>
			</div>
			<div class="form-col-1">
				<div>
					<asp:Button runat="server" ID="LoginBtn" OnClick="LoginBtn_Click" Text="Login" CssClass="button-control button-green" />
				</div>
			</div>
			
		</div>
	</div>
</asp:Content>
