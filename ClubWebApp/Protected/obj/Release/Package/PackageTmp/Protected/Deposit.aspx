<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="ClubWebApp.Deposit1" %>

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
                <img id="img1" alt="" src="Styles/img/ajax-loader(4).gif" />
                </ProgressTemplate>
    </asp:UpdateProgress>
    </td>
    <td>
    <h2 class="right">سند قبض</h2>
    </td>
    </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td>
        <asp:TextBox ID="tbInv" runat="server" CssClass="tb7" AutoPostBack="True" 
            ontextchanged="tbInv_TextChanged"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="tbInv" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="#CC0000" ValidationExpression="^\d+$" Enabled="False"></asp:RegularExpressionValidator>
    </td>
    <td style="width:150px">
        <asp:Label ID="lblInv" runat="server" Text="سند قبض لفاتورة رقم" CssClass="rightWithout"></asp:Label>
    </td>
    </tr>
    </table><hr />
        <asp:Panel ID="pnlDeposit"  Visible="false" runat="server">
        
    <table width="100%">

            <tr>
                <td>
                    <asp:TextBox ID="tbTo" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tbTo" CssClass="rightWithout" ErrorMessage="*" 
                        ForeColor="Maroon"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblTo" runat="server" CssClass="rightWithout" Text="استلمت أنا"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbFrom" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="tbFrom" CssClass="rightWithout" ErrorMessage="*" 
                        ForeColor="Maroon"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblFrom" runat="server" CssClass="rightWithout" Text="من المكرم"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbAmount" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reID" runat="server" 
                        ControlToValidate="tbAmount" CssClass="rightWithout" ErrorMessage="*" 
                        ForeColor="#CC0000" ValidationExpression="^([0-9]*\,?[0-9]+|[0-9]+\,?[0-9]*)?$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbAmount" CssClass="rightWithout" ErrorMessage="*" 
                        ForeColor="Maroon"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" CssClass="rightWithout" Text="المبلغ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbAmountW" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAmountW" runat="server" CssClass="rightWithout" 
                        Text="وقدره كتابة"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlBank" runat="server" Visible="false">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbBank" runat="server" CssClass="tb7"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblBank" runat="server" CssClass="rightWithout" Text="على بنك"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbCheck" runat="server" CssClass="tb7"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="tbCheck" CssClass="rightWithout" ErrorMessage="*" 
                                        ForeColor="#CC0000" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="tbCheck" CssClass="rightWithout" ErrorMessage="*" 
                                        ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblCheck" runat="server" CssClass="rightWithout" 
                                        Text="رقم الشيك"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbType" runat="server" AutoPostBack="True" 
                        CssClass="rightWithout" onselectedindexchanged="rbType_SelectedIndexChanged" 
                        TextAlign="Left">
                        <asp:ListItem Selected="True">نقدا</asp:ListItem>
                        <asp:ListItem>شيك</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbNotes" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblNotes" runat="server" CssClass="rightWithout" 
                        Text=" وذلك مقابل"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                
                    <asp:Button ID="btnPrint" runat="server" CssClass="myButton" 
                        onclick="btnPrint_Click" Text="طباعة" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
    </table>

    </asp:Panel>
    <asp:Label ID="lblError" runat="server" CssClass="right" ForeColor="Maroon" 
                Visible="False"></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">

</asp:Content>

