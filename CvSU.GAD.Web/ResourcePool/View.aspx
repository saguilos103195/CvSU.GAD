<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CvSU.GAD.Web.ResourcePool.View" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="resourse-pool container">
		<link rel="stylesheet" href="../Content/Stylesheets/resourcepool.css" />
		<p>GAD Resource Pool</p>
		<div class="resourse-pool-header">
			<select class="select-control">
				<option>All</option>
				<option>CAS</option>
				<option>CEIT</option>
				<option>CON</option>
				<option>CEMDS</option>
			</select>
			<select class="select-control">
				<option>Both</option>
				<option>Male</option>
				<option>Female</option>
			</select>
		</div>
	</div>
</asp:Content>
