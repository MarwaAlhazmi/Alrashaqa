<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="ClubWebApp.Bank" %>

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
<h2 class="right">كشف حساب البنك</h2>
</td>
</tr>
</table>
<table width="100%">
    
<tr>
<td></td>
<td style="width:350px">
    <asp:Label ID="lblDate0" runat="server" CssClass="rightWithout" Text="الى تاريخ" 
        Width="80px"></asp:Label>
    <asp:TextBox ID="tbTo" runat="server" CssClass="tb7"></asp:TextBox>
      <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
        Format="yyyy/MM/dd" TargetControlID="tbTo">
    </ajaxToolkit:CalendarExtender>
</td>
<td style="width:250px">
    <asp:Label ID="lblDate" runat="server" CssClass="rightWithout" 
        Text="من تاريخ" Width="80px"></asp:Label>
    <asp:TextBox ID="tbFrom" runat="server" CssClass="tb7"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
        Format="yyyy/MM/dd" TargetControlID="tbFrom">
    </ajaxToolkit:CalendarExtender>
</td>
</tr>
    <tr>
       <td></td>
        <td style="width:250px">
            <asp:Button ID="btnShow" runat="server" CssClass="myButton" Text="عرض" 
                onclick="btnShow_Click" />
        </td>
        <td>
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
            GridLines="None" ondatabound="gvIncome_DataBound" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="الرصيد" />
                <asp:BoundField DataField="Debit" HeaderText="مدين" />
                <asp:BoundField DataField="Credit" 
                    HeaderText="دائن" />
                <asp:BoundField DataField="Note" HeaderText="التفاصيل" />
                <asp:BoundField DataField="Date" HeaderText="التاريخ" />
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

