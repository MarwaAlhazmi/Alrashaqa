<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="ClubWebApp.Withdraw1" %>

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
    <h2 class="right">سند صرف</h2>
    </td>
    </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td>
        <asp:DropDownList ID="ddlDep" runat="server" CssClass="tb7" 
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="ddlDep_SelectedIndexChanged">
            <asp:ListItem>اختاري القسم</asp:ListItem>
        </asp:DropDownList><br /><br />
        <asp:ListBox ID="lbType" runat="server" CssClass="tb7" Visible="False" 
            Width="200px"></asp:ListBox><br /><br /><br />
            <asp:Label ID="lblError" runat="server" CssClass="rightWithout" 
            ForeColor="Maroon" Visible="False"></asp:Label>
    </td>
    <td>
       <asp:Label ID="lblDep" runat="server" CssClass="rightWithout" 
            Text="تابع لقسم"></asp:Label>
    </td>
    </tr>
 
    <tr>
    <td>
        <asp:TextBox ID="tbTo" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="tbTo" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon"></asp:RequiredFieldValidator>
        </td>
    <td>
        <asp:Label ID="lblTo" runat="server" CssClass="rightWithout" 
            Text="يصرف إلى المكرم"></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbAmount" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="reID" runat="server" 
                    ControlToValidate="tbAmount" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="#CC0000" ValidationExpression="^([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)?$"></asp:RegularExpressionValidator>
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
                <asp:Panel ID="pnlBank" Visible="false" runat="server">
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
                 <asp:Label ID="lblCheck" runat="server" CssClass="rightWithout" Text="رقم الشيك"></asp:Label>
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
            <td >
                <asp:TextBox ID="tbNotes" runat="server" CssClass="tb7" Width="600px"></asp:TextBox>
            </td>
            <td >
                <asp:Label ID="lblNotes" runat="server" CssClass="rightWithout" 
                    Text=" وذلك مقابل"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="طباعة" CssClass="myButton" 
                    onclick="btnPrint_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">

</asp:Content>

