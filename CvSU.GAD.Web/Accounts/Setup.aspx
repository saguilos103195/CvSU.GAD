<%@ Page Title="" Language="C#" MasterPageFile="~/GAD.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="CvSU.GAD.Web.Accounts.Setup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Content/Stylesheets/setup.css" />
    <script type="text/javascript" src="../Content/Scripts/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/setup.js" ></script>
    <div class="setup">
        <p>Account Setup</p>
        <div class="setup-body">
            <h3>Personal Information</h3>
            <section>
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
            </section>
            <h3>Contact Information</h3>
            <section>
                
            </section>
            <h3>Additional Information</h3>
            <section>
                
            </section>
            <h3>Educational Attainment</h3>
            <section>
                
            </section>
        </div>
    </div>
</asp:Content>
