<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="CvSU.GAD.WebForms.Accounts.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Content/Scripts/createaccount.js"></script>
<div class="container-fluid">
    <h1 class="h3 mb-2 text-gray-800">Accounts</h1>
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Create Account</h6>
        </div>
        <div class="card-body form">
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <input runat="server" type="text" class="form-control required txtUsername" id="txtUsername" aria-describedby="usernameError" placeholder="Enter username">
                <small id="usernameError" class="invalid-feedback">This field is required.</small>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <input runat="server" type="password" class="form-control required txtPassword" id="txtPassword" aria-describedby="passwordError" placeholder="Enter password">
                <small id="passwordError" class="invalid-feedback">This field is required.</small>
            </div>
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password</label>
                <input runat="server" type="password" class="form-control required txtConfirmPassword" id="txtConfirmPassword" aria-describedby="confirmPasswordError" placeholder="Enter password confirmation">
                <small id="confirmPasswordError" class="invalid-feedback">This field is required.</small>
            </div>
            <div class="form-group">
                <label for="selectType">Type</label>
                <select runat="server" class="form-control required selectType" id="selectType" aria-describedby="typeError">
                    <option selected disabled value="">Select Type</option>
					<option>Administrator</option>
					<option>Coordinator</option>
                </select>
                <small id="typeError" class="invalid-feedback">This field is required.</small>
            </div>
            <div class="form-group d-none">
                <label for="selectCollege">College</label>
                <select runat="server" class="form-control selectCollege" id="selectCollege" aria-describedby="collegeError">
                    <option selected disabled value="">Select College</option>
                </select>
                <small id="collegeError" class="invalid-feedback">This field is required.</small>
            </div>
            <button id="createBtn" type="button" class="commandBtn btn btn-primary">Create</button>
            <asp:Button runat="server" ID="CreateBtn" OnClick="CreateBtn_Click" CssClass="createBtn d-none" />
        </div>
    </div>
</div>
</asp:Content>
