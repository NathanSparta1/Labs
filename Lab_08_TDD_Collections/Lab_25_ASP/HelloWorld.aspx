<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="Lab_25_ASP.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hello World</h1>
    <ul>
        <li>one</li>
        <li>two</li>
    </ul>

    <asp:Label ID="Label1" runat="server" Text="Label">
    This is a label
    </asp:Label>

    <asp:TextBox ID="TextBox1" runat="server">this is a textbox</asp:TextBox>
  
    
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    
    <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>

      <asp:Button ID="Button1" runat="server" Text= "ASP Submit button" OnClick="Button1_Click" />

    <form method="get" action="processdata.cs">
        first Name <input type="text" placeholder="type here" name="firstname" />

        <button type="submit"  onclick="eventPreventDefault()";">Submit</button>
    </form>


</asp:Content>
