﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentMembers.aspx.cs" Inherits="ClubWebApp.CurrentMembers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table width="100%">
    <tr>
    <td>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                 <img id="img1" src="Styles/img/ajax-loader(4).gif" alt="" />
                </ProgressTemplate>
    </asp:UpdateProgress>
    </td>
    <td>
    <h2 class="right">زيارات اليوم</h2>
    </td>
    </tr>
    </table>
    <hr />
        <asp:Panel ID="pnlVisits" runat="server">
         <table width="100%">
        <tr>
        <td>
        
            <asp:GridView ID="gvMembers" runat="server" CellPadding="4" 
                CssClass="rightWithout" GridLines="None" Width="100%" 
                AutoGenerateColumns="False" onrowcommand="gvMembers_RowCommand" 
                ForeColor="#333333" PageSize="50">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField DeleteText="إستعراض الإشتراكات" ShowDeleteButton="True">
                    <ItemStyle Width="120px" />
                    </asp:CommandField>
                    <asp:CommandField SelectText="مشاهدة الملف" ShowSelectButton="True" >
                    <ItemStyle Width="100px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Time" HeaderText="وقت الدخول" />
                    <asp:BoundField DataField="Sub" HeaderText="الإشتراك" />
                    <asp:BoundField DataField="ClientName" HeaderText="اسم العضوة" />
                    <asp:BoundField DataField="ClientID" HeaderText="رقم الملف" />
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
            <br />
</td></tr></table>
        </asp:Panel>
        <br />
        <br />
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
