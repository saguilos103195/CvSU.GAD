<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CvSU.GAD.WebForms.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Gender and Development - Login</title>

    <link href="Content/Stylesheets/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
	<link href="Content/Stylesheets/sb-admin-2.css" rel="stylesheet" type="text/css" />

	<!-- Bootstrap core JavaScript-->
	<script src="Content/Scripts/jquery/jquery.min.js"></script>
	<script src="Content/Scripts/bootstrap/js/bootstrap.bundle.min.js"></script>
	<!-- Core plugin JavaScript-->
	<script src="Content/Scripts/jquery-easing/jquery.easing.min.js"></script>

</head>
<body class="bg-primary">
	<form runat="server" id="form1"> 
		<div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header justify-content-center"><h3 class="font-weight-light my-4">Login</h3></div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label class="small mb-1" for="inputUsername">Username</label>
                                            <input runat="server" class="form-control" id="inputUsername" placeholder="Enter Username" />
                                        </div>
                                        <div class="form-group">
                                            <label class="small mb-1" for="inputPassword">Password</label>
                                            <input runat="server" type="password" class="form-control" id="inputPassword" placeholder="Enter Password" />
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox">
                                                <input class="custom-control-input" id="rememberPasswordCheck" type="checkbox"/>
                                                <label class="custom-control-label" for="rememberPasswordCheck">Remember password</label>
                                            </div>
                                        </div>
										<div class="form-group">
											<p class="text-danger small text-center" runat="server" id="errorMessage" visible="false">Error</p>
										</div>
                                        <div class="form-group d-flex align-items-center justify-content-between mt-4 mb-0">
											<div></div>
											<asp:Button runat="server" Text="Login" class="btn btn-primary" OnClick="LoginBtn_Click" />
                                        </div>
                                    </div>
                                    <div class="card-footer text-center">
                                        <div class="small">Cavite State University - Gender and Development</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        </div>
	</form>
</body>
<script src="Content/Scripts/sb-admin-2.js"></script>
</html>
