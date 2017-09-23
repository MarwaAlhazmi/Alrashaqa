﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeptInvoices.aspx.cs" Inherits="ClubWebApp.DeptInvoices" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table width="100%">
    <tr>
    <td>
   <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <img id="img1" alt="" src="Styles/img/ajax-loader(4).gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>
    </td>
    <td>
    <h2 class="right">الفواتير الغير مدفوعة</h2>
    </td>
    </tr>
    </table>
    <hr />
    <asp:Panel ID="pnlInvoices" runat="server">
     <table width="100%">
        <tr>
        <td>
        
        <asp:GridView ID="gvInvoices" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="InvID" CellPadding="4" 
            CssClass="rightWithout" GridLines="None" Width="100%" 
            onrowcommand="gvInvoices_RowCommand" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField SelectText="اصدار سند قبض" ShowSelectButton="True" />
                <asp:BoundField DataField="EmpName" HeaderText="المسئولة" 
                    SortExpression="RecepName" />
                <asp:BoundField DataField="Remain" HeaderText="المبلغ المتبقي" />
                <asp:BoundField DataField="Amount" DataFormatString="{0:0.00}" 
                    HeaderText="مبلغ الفاتورة" SortExpression="TotalAmount" />
                <asp:BoundField DataField="ClientName" HeaderText="اسم المشتركة" />
                <asp:BoundField DataField="FileID" HeaderText="رقم الملف" 
                    SortExpression="ClientID" />
                <asp:BoundField DataField="Date" HeaderText="التاريخ" SortExpression="Date" 
                    DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="InvID" HeaderText="رقم الفاتورة" ReadOnly="True" 
                    SortExpression="InvID" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        </td></tr></table>
        <br /><br />
        </asp:Panel>
        <br />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
