<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="CvSU.GAD.WebForms.Projects.Apply" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/applyprojects.js" type="text/javascript"></script>
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">Apply GAD Extension Project</h1>
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Create Project</h6>
        </div>
        <div class="card-body form">
            <div class="form-group">
                <label for="txtTitle">Title</label>
                <input runat="server" type="text" class="form-control required txtTitle" id="txtTitle" aria-describedby="titleError" placeholder="Enter Title">
                <small id="titleError" class="invalid-feedback">This field is required.</small>
            </div>
            <div class="form-group mb-4">
				<label for="fileDocument">Choose Project Document</label>
				<input type="file" class="form-control-file required fileDocument" runat="server" id="fileDocument" accept=".xlsx,.xls, .doc, .docx,.ppt, .pptx,.txt,.pdf" aria-describedby="documentError">
			    <small id="documentError" class="invalid-feedback">This field is required.</small>
            </div>
            <button id="createBtn" type="button" class="commandBtn btn btn-primary">Create</button>
            <asp:Button runat="server" ID="CreateBtn" OnClick="CreateBtn_Click" CssClass="createBtn d-none" />
        </div>
    </div>
</div>
</asp:Content>
