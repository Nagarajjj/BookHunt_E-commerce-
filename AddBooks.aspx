<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddBooks.aspx.cs" Inherits="Signup.AddBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    &nbsp;<form id="form1" runat="server">

        <asp:Button ID="Sign_out" runat="server" OnClick="Sign_out_Click"
            Text="Signout" />
        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="sqladdbooks" Style="text-align: center">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="BookId" DataSourceID="sqladdbooks" AllowPaging="True" CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" GridLines="Horizontal" OnPageIndexChanging="FormView1_PageIndexChanging">
                <EditItemTemplate>
                    BookId:
                <asp:Label ID="BookIdLabel1" runat="server" Text='<%# Eval("BookId") %>' />
                    <br />
                    BookTitle:
                <asp:TextBox ID="BookTitleTextBox" runat="server" Text='<%# Bind("BookTitle") %>' />
                    <br />
                    BookAuthor:
                <asp:TextBox ID="BookAuthorTextBox" runat="server" Text='<%# Bind("BookAuthor") %>' />
                    <br />
                    BookPrice:
                <asp:TextBox ID="BookPriceTextBox" runat="server" Text='<%# Bind("BookPrice") %>' />
                    <br />
                    BookPublicationYear:
                <asp:TextBox ID="BookPublicationYearTextBox" runat="server" Text='<%# Bind("BookPublicationYear") %>' />
                    <br />
                    BookStock:
                <asp:TextBox ID="BookStockTextBox" runat="server" Text='<%# Bind("BookStock") %>' />
                    <br />
                    BookImage:
                <asp:TextBox ID="BookImageTextBox" runat="server" Text='<%# Bind("BookImage") %>' />
                    <br />
                    VendorId:
                <asp:TextBox ID="VendorIdTextBox" runat="server" Text='<%# Bind("VendorId") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <InsertItemTemplate>
                    BookTitle:
                <asp:TextBox ID="BookTitleTextBox" runat="server" Text='<%# Bind("BookTitle") %>' />
                    <br />
                    BookAuthor:
                <asp:TextBox ID="BookAuthorTextBox" runat="server" Text='<%# Bind("BookAuthor") %>' />
                    <br />
                    BookPrice:
                <asp:TextBox ID="BookPriceTextBox" runat="server" Text='<%# Bind("BookPrice") %>' />
                    <br />
                    BookPublicationYear:
                <asp:TextBox ID="BookPublicationYearTextBox" runat="server" Text='<%# Bind("BookPublicationYear") %>' />
                    <br />
                    BookStock:
                <asp:TextBox ID="BookStockTextBox" runat="server" Text='<%# Bind("BookStock") %>' />
                    <br />
                    BookImage:
                <asp:TextBox ID="BookImageImgsrc" runat="server" Text='<%# Bind("BookImage") %>' />
                    <br />
                    VendorId:
                <asp:TextBox ID="VendorIdTextBox" runat="server" Text='<%# Bind("VendorId") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                    <br />

                    <br />
                </ItemTemplate>
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
            </asp:FormView>
            <asp:SqlDataSource ID="sqladdbooks" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:BookHuntConnectionString %>" DeleteCommand="DELETE FROM [BookTable] WHERE [BookId] = @original_BookId AND [BookTitle] = @original_BookTitle AND [BookAuthor] = @original_BookAuthor AND [BookPrice] = @original_BookPrice AND [BookPublicationYear] = @original_BookPublicationYear AND [BookStock] = @original_BookStock AND [BookImage] = @original_BookImage AND [VendorId] = @original_VendorId" InsertCommand="INSERT INTO [BookTable] ([BookTitle], [BookAuthor], [BookPrice], [BookPublicationYear], [BookStock], [BookImage], [VendorId]) VALUES (@BookTitle, @BookAuthor, @BookPrice, @BookPublicationYear, @BookStock, @BookImage, @VendorId)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [BookId], [BookTitle], [BookAuthor], [BookPrice], [BookPublicationYear], [BookStock], [BookImage], [VendorId] FROM [BookTable]" UpdateCommand="UPDATE [BookTable] SET [BookTitle] = @BookTitle, [BookAuthor] = @BookAuthor, [BookPrice] = @BookPrice, [BookPublicationYear] = @BookPublicationYear, [BookStock] = @BookStock, [BookImage] = @BookImage, [VendorId] = @VendorId WHERE [BookId] = @original_BookId AND [BookTitle] = @original_BookTitle AND [BookAuthor] = @original_BookAuthor AND [BookPrice] = @original_BookPrice AND [BookPublicationYear] = @original_BookPublicationYear AND [BookStock] = @original_BookStock AND [BookImage] = @original_BookImage AND [VendorId] = @original_VendorId">
                <DeleteParameters>
                    <asp:Parameter Name="original_BookId" Type="Int16" />
                    <asp:Parameter Name="original_BookTitle" Type="String" />
                    <asp:Parameter Name="original_BookAuthor" Type="String" />
                    <asp:Parameter Name="original_BookPrice" Type="Decimal" />
                    <asp:Parameter Name="original_BookPublicationYear" Type="Int16" />
                    <asp:Parameter Name="original_BookStock" Type="Int16" />
                    <asp:Parameter Name="original_BookImage" Type="String" />
                    <asp:Parameter Name="original_VendorId" Type="Int16" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="BookTitle" Type="String" />
                    <asp:Parameter Name="BookAuthor" Type="String" />
                    <asp:Parameter Name="BookPrice" Type="Decimal" />
                    <asp:Parameter Name="BookPublicationYear" Type="Int16" />
                    <asp:Parameter Name="BookStock" Type="Int16" />
                    <asp:Parameter Name="BookImage" Type="String" />
                    <asp:Parameter Name="VendorId" Type="Int16" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="BookTitle" Type="String" />
                    <asp:Parameter Name="BookAuthor" Type="String" />
                    <asp:Parameter Name="BookPrice" Type="Decimal" />
                    <asp:Parameter Name="BookPublicationYear" Type="Int16" />
                    <asp:Parameter Name="BookStock" Type="Int16" />
                    <asp:Parameter Name="BookImage" Type="String" />
                    <asp:Parameter Name="VendorId" Type="Int16" />
                    <asp:Parameter Name="original_BookId" Type="Int16" />
                    <asp:Parameter Name="original_BookTitle" Type="String" />
                    <asp:Parameter Name="original_BookAuthor" Type="String" />
                    <asp:Parameter Name="original_BookPrice" Type="Decimal" />
                    <asp:Parameter Name="original_BookPublicationYear" Type="Int16" />
                    <asp:Parameter Name="original_BookStock" Type="Int16" />
                    <asp:Parameter Name="original_BookImage" Type="String" />
                    <asp:Parameter Name="original_VendorId" Type="Int16" />
                </UpdateParameters>

            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</asp:Content>
