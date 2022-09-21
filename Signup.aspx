<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Signup.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link href="Stylesheets/Signup.css" rel="stylesheet" />
    <div class="signupFrm">
        <form action="" class="form" id="form1" runat="server">
            <h1 class="title">Sign up</h1>

            <input type="text" class="input" placeholder="a" id="Phone number"><div class="inputContainer">
                <input type="text" class="input" placeholder="a" id="Email">
                <label for="" class="label">Email</label>
            </div>

            <div class="inputContainer">
                <input type="text" class="input" placeholder="a" id="Username">
                <label for="" class="label">Username</label>
            </div>

            <div class="inputContainer">
                <input type="text" class="input" placeholder="a" id="Phonenumber">
                <label for="" class="label">Phone number</label>
            </div>

            <div class="inputContainer">
                <input type="text" class="input" placeholder="a" id="Pass">
                <label for="" class="label">Password</label>
            </div>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
            &nbsp;
        </form>
    </div>
</asp:Content>
