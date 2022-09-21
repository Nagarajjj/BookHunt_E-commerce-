<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Signup.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <form id="form1" runat="server" style="padding-left:50px; padding-top:25px">
    <div>
        <asp:HiddenField ID="hfContactID" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"  Text="Name"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
         
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="EmailID"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
         
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Register" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td colspan="2">
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
              
            </tr>
        </table>
        <br />
        
    </div>
    </form>
</asp:Content>
