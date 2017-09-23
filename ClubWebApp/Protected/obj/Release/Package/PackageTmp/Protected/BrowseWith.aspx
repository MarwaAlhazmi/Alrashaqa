<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseWith.aspx.cs" Inherits="ClubWebApp.BrowseWith" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
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
    <td><h2 class="right">استعراض سندات الصرف</h2></td>
    </tr>
    </table>

    <asp:Panel ID="Panel1" runat="server">
    <table width="100%">
    <tr>
    <td></td>
    <td>
    
        <asp:RadioButtonList ID="rbSelect" runat="server" AutoPostBack="True" 
            CssClass="rightWithout" onselectedindexchanged="rbSelect_SelectedIndexChanged" 
            TextAlign="Left">
            <asp:ListItem Selected="True">تاريخ السند</asp:ListItem>
            <asp:ListItem>رقم السند</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
    </td>
    <td style="width:150px">
        <asp:Label ID="lblSelect" runat="server" CssClass="rightWithout" 
            Text="عرض السند باستخدام"></asp:Label>
        <br />
        
        </td>
    </tr>
    <tr>
    <td></td>
    <td></td>
    <td></td>
    </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch0" runat="server" CssClass="myButton" Text="بحث" 
                    onclick="btnSearch0_Click" />
                <asp:TextBox ID="tbDate" runat="server" CssClass="tb7"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="tbDate0_CalendarExtender" runat="server" 
                    Format="dd/MM/yyyy" TargetControlID="tbDate">
                </ajaxToolkit:CalendarExtender>
                <asp:RegularExpressionValidator ID="reID" runat="server" 
                    ControlToValidate="tbDate" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="#CC0000" ValidationExpression="^\d+$" Enabled="False"></asp:RegularExpressionValidator>
            </td>
            <td style="width:150px">
                <asp:Label ID="lblDate" runat="server" CssClass="rightWithout" 
                    Text="تاريخ السند"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width:150px">
                &nbsp;</td>
        </tr>
    </table>
    </asp:Panel>
    <hr />

        <asp:Panel ID="pnlResult" runat="server">
        <table width="100%">
        <tr>
        <td>
     
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" DataSourceID="edsInvoices" Width="100%" 
                AllowPaging="True" AllowSorting="True" CellPadding="4" 
                CssClass="rightWithout" GridLines="None" ondatabound="GridView1_DataBound" 
                onrowcommand="GridView1_RowCommand" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="عرض" ShowSelectButton="True" />
                    <asp:BoundField DataField="Notes" HeaderText="مقابل" 
                        SortExpression="Notes" />
                    <asp:BoundField DataField="Bank" HeaderText="البنك" 
                        SortExpression="Bank" />
                    <asp:BoundField DataField="CheckNum" HeaderText="رقم الشيك" 
                        SortExpression="CheckNum" />
                    <asp:BoundField DataField="Amount" HeaderText="المبلغ" 
                        SortExpression="Amount" />
                    <asp:BoundField DataField="ToPerson" HeaderText="صرف إلى" 
                        SortExpression="ToPerson" />
                    <asp:BoundField DataField="Date" HeaderText="التاريخ" 
                        SortExpression="Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="EmpID" HeaderText="رقم الموظف" 
                        SortExpression="EmpID" />
                    <asp:BoundField DataField="ID" HeaderText="رقم السند" 
                        SortExpression="ID" ReadOnly="True" />
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
            <asp:Label ID="lblError" runat="server" CssClass="right" ForeColor="Maroon" 
                Visible="False"></asp:Label>
                   
        </td>
        </tr>
        </table>
            </asp:Panel>
            <br />
            <asp:EntityDataSource ID="edsInvoices" runat="server" 
                ConnectionString="name=ClubDBEntities" DefaultContainerName="ClubDBEntities" 
                EnableFlattening="False" EntitySetName="Withdraws" 
                Where="it.Date between @Invoice and @Invoice">
                <WhereParameters>
                    <asp:ControlParameter ControlID="tbDate" Name="Invoice" PropertyName="Text" 
                        Type="DateTime" />
                </WhereParameters>
            </asp:EntityDataSource>
            <br />
            

            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
