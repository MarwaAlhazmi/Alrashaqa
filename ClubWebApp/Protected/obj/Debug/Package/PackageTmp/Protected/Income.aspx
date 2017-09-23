<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="ClubWebApp.Income" %>

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
<h2 class="right">بيان بإيرادات المركز اليومية</h2>
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
<asp:Panel ID="pnlData" runat="server" Visible="false">
    <table width="100%">
    <tr>
    <td>
        <asp:GridView ID="gvIncome" runat="server" CssClass="rightWithout" Width="100%" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ondatabound="gvIncome_DataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Income" HeaderText="الإيراد" />
                <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="التاريخ" />
                <asp:BoundField DataField="Day" HeaderText="اليوم" />
                <asp:BoundField DataField="Ser" HeaderText="مسلسل" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
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
    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>

