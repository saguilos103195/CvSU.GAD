<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CvSU.GAD.Web.ResourcePool.View" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="resourse-pool container">
		<link rel="stylesheet" href="../Content/Stylesheets/resourcepool.css" />
		<p>GAD Resource Pool</p>
		<div class="resourse-pool-header">
			<div>
				<select class="select-control">
					<option>All</option>
					<option>CAS</option>
					<option>CEIT</option>
					<option>CON</option>
					<option>CEMDS</option>
				</select>
			</div>
			<div>
				<select class="select-control">
					<option>All</option>
					<option>Male</option>
					<option>Female</option>
				</select>
			</div>
		</div>
		<div class="resourse-pool-body">
			<div class="resourse-pool-profile text-center mt-4">
				<p style="background: red;"></p>
			</div>
		</div>
	</div>
</asp:Content>
