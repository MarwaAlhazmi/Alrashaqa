<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trans.aspx.cs" Inherits="ClubWebApp.Trans" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%">

<tr>
<td>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
     <img id="img1" src="Styles/img/ajax-loader(4).gif" alt="" />
        <br />
    </ProgressTemplate>
    </asp:UpdateProgress>
</td>
<td>
<h2 class="right">تفصيل بمصروفات المركز</h2>
</td>
</tr>
</table>
<table width="100%">
    
<tr>
<td></td>
<td style="width:200px">
    <asp:DropDownList ID="ddlYear" runat="server" CssClass="tb7" Width="80px">
    </asp:DropDownList>
</td>
<td style="width:80px">
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
</td>
<td style="width:120px">
    <asp:Label ID="lblDate" runat="server" CssClass="rightWithout" 
        Text="حددي الشهر والسنة"></asp:Label>
</td>
</tr>
    <tr>
       <td></td>
        <td style="width:200px">
            <asp:Button ID="btnShow" runat="server" CssClass="myButton" Text="عرض" 
                onclick="btnShow_Click" />
        </td>
        <td style="width:80px">
            &nbsp;</td>
        <td style="width:120px">
            &nbsp;</td>
    </tr>
</table>
<hr />
<br />
    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>

