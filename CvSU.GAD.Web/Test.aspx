<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="CvSU.GAD.Web.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">

		$(document).ready(function () {

			$("#test").selectmenu();

		});

	</script>
	<div style="padding: 20px;">
		<input class="input-text" type="text" placeholder="First Name" />
		<select id="test">
			<option>1</option>
			<option>1</option>
			<option>1</option>
		</select>
		<button class="button-control button-green" type="button">Confirm</button>
		<button class="button-control button-red" type="button">confirm</button>
		<button class="button-control button-yellow" type="button">Confirm</button>
		<button class="button-control button-blue" type="button">confirm</button>
	</div>
</asp:Content>
