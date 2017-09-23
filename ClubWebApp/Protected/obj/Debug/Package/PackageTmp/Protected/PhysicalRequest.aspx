<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhysicalRequest.aspx.cs" Inherits="ClubWebApp.PhysicalRequest" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h2 style="text-align:center">Physical Therapy - Request Form</h2>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                <img id="img1" alt="" src="Styles/img/ajax-loader(4).gif" />
                </ProgressTemplate>
    </asp:UpdateProgress>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Maroon" Visible="false"></asp:Label>
        <br />
        <br />
        <h5 id="lblInfo" runat="server" visible="false">
        First enter the File ID then the Date when the sheet was created.
        </h5>
    <table width="100%">
        <tr>
        <td>
            <h3>
                File ID</h3>
        </td>
            <td>
                <asp:TextBox ID="tbID" runat="server" CssClass="tb7l" AutoPostBack="True" 
                    ontextchanged="tbID_TextChanged"></asp:TextBox>
        <asp:RegularExpressionValidator ID="reID" runat="server" 
                    ControlToValidate="tbID" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\d+$" Enabled="False"></asp:RegularExpressionValidator>
                </td>
            <td>
            <h3>
                Date</h3>
                </td>
                <td>
            
                    <asp:TextBox ID="tbDate" runat="server" AutoPostBack="True" CssClass="tb7l" 
                        ontextchanged="tbDate_TextChanged"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        Format="dd/MM/yyyy" TargetControlID="tbDate">
                    </ajaxToolkit:CalendarExtender>
            
                </td>
        </tr>
    </table><hr />
    <table width="100%">
    <tr>
    <td>
    
    
        <asp:Panel ID="pnlClient" runat="server" Visible="false">
        <table width="100%">
        <tr>
        <td style="width:100px">
        
            <asp:Label ID="lblName" runat="server" Text="Patient Name"></asp:Label>
        
        </td>
        <td>
            <asp:TextBox ID="tbName" runat="server" CssClass="tb7l" ReadOnly="True"></asp:TextBox>
            </td>
        <td style="width:70px">
            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbPhone" runat="server" CssClass="tb7l" ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
                   <tr>
        <td>
        
            <asp:Label ID="lblDOB" runat="server" Text="Year of birth"></asp:Label>
        
        </td>
        <td>
            <asp:TextBox ID="tbDOB" runat="server" CssClass="tb7l" ReadOnly="True"></asp:TextBox>
            </td>
        <td>
            <asp:Label ID="lblNation" runat="server" Text="Nationality"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbNation" runat="server" CssClass="tb7l" ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
        </table>
        <hr />
        </asp:Panel>
        <asp:Panel ID="pnlInfo" runat="server" Visible="false">
        <h3>Diagnosis:</h3>
        <asp:TextBox ID="tbDia" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px"></asp:TextBox>
                    <h3>Goals and Objectives of treatment:</h3>
        <asp:TextBox ID="tbGoals" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px"></asp:TextBox>
            <h3>Precations (if Any):</h3>
            <asp:TextBox ID="tbPrecaution" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px"></asp:TextBox>
                    
            <br />
            <br />
            <table width="100%">
            <tr>
            <td></td>
            <td style="width:100px">
            <asp:Button ID="btnSave" runat="server" CssClass="myButton" 
                    Text="Save" onclick="btnSave_Click" />
            </td>
            <td  style="width:100px">
            <asp:Button ID="btnPrint" runat="server" CssClass="myButton" Text="Print" 
                    onclick="btnPrint_Click" />
            </td>
            </tr>
            </table>
            
            
            
                    
            </asp:Panel>

    </td>
    </tr>
    </table>
    

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
