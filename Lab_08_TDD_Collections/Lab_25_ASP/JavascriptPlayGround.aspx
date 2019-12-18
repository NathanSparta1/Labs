<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JavascriptPlayGround.aspx.cs" Inherits="Lab_25_ASP.JavascriptPlayGround" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



<script>
var x = 0
    alert('the value of x is' + x);  

function runSomeTestData()
    {
        x++;
        alert('the value of x is' + x); 
        var madman = confirm('are you a madman');

        var name = prompt('Ok then fine! whats your name????');

        if (madman) {
            alert('thanks, ' + name + '!!!')
        }
        else { alert('safe my g');}

        console.log(madman);
        console.log(name);
    }
</script>

    <button onclick="runSomeTestData()">Run Some Test Data</button>
    <div id="test-data"></div>

</asp:Content>
