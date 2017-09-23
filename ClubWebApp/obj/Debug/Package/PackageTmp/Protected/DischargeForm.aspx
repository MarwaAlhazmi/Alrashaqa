<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DischargeForm.aspx.cs" Inherits="ClubWebApp.DischargeForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h2 style="text-align:center">Discharge Summary</h2>
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
            Width="900px" CssClass="tb7l"></asp:TextBox>
            <h3>No. of previous referrals for the same condition:</h3>
            <asp:TextBox ID="tbPreReferrals" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px" CssClass="tb7l"></asp:TextBox>
            <br />
            <br />
            <table width="100%">
            <tr>
            <td style="width:180px">
             <h3>Date of initial session:</h3>
            </td>
            <td>
             <asp:TextBox ID="tbInitialSession" runat="server" CssClass="tb7l"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="tbInitialSession_CalendarExtender" 
                    runat="server" Format="dd/MM/yyyy" TargetControlID="tbInitialSession">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width:180px">
            <h3>Date of final session:</h3>
            </td>
            <td>
            <asp:TextBox ID="tbFinalSession" runat="server" CssClass="tb7l"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="tbFinalSession_CalendarExtender" 
                    runat="server" Format="dd/MM/yyyy" TargetControlID="tbFinalSession">
                </ajaxToolkit:CalendarExtender>
            </td>
            </tr>
            </table>
           
       
            
            
                    <h3>Total No. of session:</h3>
        <asp:TextBox ID="tbTotalSession" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px" CssClass="tb7l"></asp:TextBox>
            <h3>Treatment given:</h3>
            <asp:TextBox ID="tbTreat" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px" CssClass="tb7l"></asp:TextBox>
                    
                        <h3>Discharge criteria:</h3>
            <asp:TextBox ID="tbDischarge" runat="server" TextMode="MultiLine" Height="51px" 
            Width="900px" CssClass="tb7l"></asp:TextBox>

                        <h3>Goals:</h3>
                        <table width="100%">
                        <tr>
                        <td style="width: 780px">
                         <asp:TextBox ID="tbGoals" runat="server" TextMode="MultiLine" Height="120px" 
            Width="750px" CssClass="tb7l"></asp:TextBox>
                        </td>
           
                        <td >
                            <asp:RadioButtonList ID="rbGoals" runat="server">
                                <asp:ListItem Selected="True">Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Partial</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        </tr>
                        </table>

                        <h3>Comments and Suggestions:</h3>
            <asp:TextBox ID="tbComments" runat="server" TextMode="MultiLine" Height="90px" 
            Width="900px" CssClass="tb7l"></asp:TextBox>
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
