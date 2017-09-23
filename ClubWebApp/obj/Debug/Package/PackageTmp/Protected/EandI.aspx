<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EandI.aspx.cs" Inherits="ClubWebApp.EandI" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table width="100%">

<tr>
<td>

</td>
<td>
<h2 class="right">بيان بإيرادات ومصروفات العيادات</h2>
</td>
</tr>
</table>
<table width="100%">
    
<tr>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td class="style3">
    <asp:DropDownList ID="dllMonth" runat="server" CssClass="tb7" Width="50px">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlYear" runat="server" CssClass="tb7" Width="80px">
    </asp:DropDownList>
    </td>
<td style="width:150px">
    <asp:Label ID="lblDate" runat="server" CssClass="rightWithout" 
        Text="حددي الشهر والسنة"></asp:Label>
</td>
</tr>

<tr>
<td>
    <asp:Button ID="btnShow" runat="server" CssClass="myButton" 
        onclick="btnShow_Click" Text="عرض" />
    </td>
<td>
    &nbsp;</td>
<td>

    <asp:DropDownList ID="ddlDep" runat="server" CssClass="tb7" Width="200px">
    </asp:DropDownList>

</td>
<td>
    <asp:Label ID="lblDep" runat="server" CssClass="rightWithout" Text="العيادة"></asp:Label>
    </td>
</tr>
</table>
<hr />
<br />

  <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" />
<asp:Panel ID="pnlData" runat="server" Visible="false">
    <table width="100%">
    <tr>
    <td>
        
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblError" runat="server" Text="لايوجد بيانات لعرضها" 
            CssClass="rightWithout" ForeColor="Maroon" Visible="False"></asp:Label>
    </td></tr>
    <tr>
    <td>
    <asp:Button ID="btnPrint" runat="server" Text="طباعة" CssClass="myButton" 
            onclick="btnPrint_Click" />
    </td>
    </tr>
    </table>
    </asp:Panel>




        
</asp:Content>


