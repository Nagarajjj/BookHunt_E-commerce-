<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Signup.Test1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <form id="form1" runat="server" style="padding-left: 50px; padding-top: 25px">
        <div>
            <asp:HiddenField ID="hfContactID" runat="server" />
            <br />
            <table>
                <tr>
                    <td>EmailID</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMobile" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="SignIn" OnClick="btnSave_Click" />


                </td>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server"></asp:Label>

                </td>

            </table>
            <div style="inline;">
                <p style="text-align: center; font-weight: bold">Not a member?<a href="Register.aspx">Register Now</a></p>
                <p style="text-align: center; font-weight: bold">&nbsp;</p>
            </div>

        </div>
    </form>
    </table>
</asp:Content>
