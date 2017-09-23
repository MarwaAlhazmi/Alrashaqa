<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DietSystem.aspx.cs" Inherits="ClubWebApp.DietSystem" %>

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
<h2 class="right">أنظمة الحمية الغذائية</h2>
</td>
</tr>
</table>
<table width="100%">
    
<tr>
<td ></td>
<td>
    <asp:DropDownList ID="ddlDep" runat="server" 
        CssClass="tb7" Width="160px">
    </asp:DropDownList>

</td>

<td style="width:80px">
    <asp:Label ID="lblDiet" runat="server" CssClass="rightWithout" 
        Text="النظام الغذائي"></asp:Label>
</td>
</tr>

    <tr>
       <td></td>
        <td style="width:200px">
            <asp:Button ID="btnShow" runat="server" CssClass="myButton" Text="فتح" 
                onclick="btnShow_Click" />
        </td>
        
        <td style="width:120px">
            &nbsp;</td>
    </tr>
</table>
<hr />
<asp:Label ID="lblError" runat="server" Text="لا يمكن فتح لملف" 
            CssClass="rightWithout" ForeColor="Maroon" Visible="False"></asp:Label>

    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
 
    </asp:Content>

