<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EvaluationBrowse.aspx.cs" Inherits="ClubWebApp.EvaluationBrowse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h2 style="text-align:center">Evaluation Froms - Search</h2>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                <img id="img1" alt="" src="Styles/img/ajax-loader(4).gif" />
                </ProgressTemplate>
    </asp:UpdateProgress>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Maroon" Visible="false"></asp:Label>
        <br />
        <br />
 
    <table width="100%">
        <tr>
            <td>
            <h3>
                Date</h3>
                </td>
                <td>
            
                    <asp:TextBox ID="tbDate" runat="server" AutoPostBack="True" CssClass="tb7l"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        Format="dd/MM/yyyy" TargetControlID="tbDate">
                    </ajaxToolkit:CalendarExtender>
            
                </td>
        </tr>
        <tr>
            <td>
                <h3>
                File ID</h3></td>
            <td>
                <asp:TextBox ID="tbID" runat="server" AutoPostBack="True" CssClass="tb7l"></asp:TextBox>
     
                <asp:Button ID="btnGo" runat="server" onclick="btnGo_Click" Text="Go" />
            </td>
        </tr>
    </table><hr />
    <asp:Panel ID="pnlG" runat="server" Visible="false">
        <asp:GridView ID="gvRequests" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvRequests_RowCommand" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="FileID" HeaderText="File ID" />
                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" />
                <asp:BoundField DataField="EmpName" HeaderText="Physician Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
  </asp:Panel>

    </td>
    </tr>
    </table>
    

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
