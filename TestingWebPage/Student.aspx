<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  
CodeBehind="Student.aspx.cs" Inherits="MYSQLCRUDApplication.Student" %>  
  
<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">  
    Simple Insert Select Update and Delete in ASP.NET using MySQL Database   
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">  
</asp:Content>  
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">  
    <table>  
        <tr>  
            <td class="td">Name:</td>  
            <td>  
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>  
            <td>  
                <asp:Label ID="lblSID" runat="server" Visible="false"></asp:Label> </td>  
        </tr>  
        <tr>  
            <td class="td">Address:</td>  
            <td>  
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>  
            <td> </td>  
        </tr>  
        <tr>  
            <td class="td">Mobile:</td>  
            <td>  
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>  
            <td> </td>  
        </tr>  
        <tr>  
            <td class="td">Email ID:</td>  
            <td>  
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>  
            <td> </td>  
        </tr>  
        <tr>  
            <td></td>  
            <td>  
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />  
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false"  
OnClick="btnUpdate_Click" />  
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>  
            <td></td>  
        </tr>  
    </table>  
  
    <div style="padding: 10px; margin: 0px; width: 100%;">  
        <p>  
            Total Student:<asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label>  
        </p>  
        <asp:GridView ID="GridViewStudent" runat="server" DataKeyNames="SID"   
            OnSelectedIndexChanged="GridViewStudent_SelectedIndexChanged"  
OnRowDeleting="GridViewStudent_RowDeleting">  
            <Columns>  
                <asp:CommandField HeaderText="Update" ShowSelectButton="True" />  
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />  
            </Columns>  
        </asp:GridView>  
    </div>  
</asp:Content>
