<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuffetM.aspx.cs" Inherits="ClubWebApp.BuffetM" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h2 style="text-align:center">حركة الحسابات</h2>
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
                <asp:TextBox ID="tbDate" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbDate_TextChanged"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbDate" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
                </td>
            <td style="width:60px">
            <h3 class="rightWithout">التاريخ</h3>
                </td>
        </tr>
    </table><hr />
     <h2 class="right"> حركة البوفيه
    </h2>
    
    <table class="withBorder" width="100%">
    <tr>
    <td>
     <asp:TextBox ID="tbPreBalance" runat="server" CssClass="tb7" AutoPostBack="True" 
            ontextchanged="tbPreBalance_TextChanged"></asp:TextBox>
            <asp:RegularExpressionValidator ID="reID" runat="server" 
                    ControlToValidate="tbPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
    </td>
    <td style="width:150px">
   <asp:Label ID="lblPreBalance" runat="server" Text="رصيد البضاعة السابق" CssClass="rightWithout"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbIncome" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbIncome_TextChanged">0.00</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
               </td>
            <td>
                <asp:Label ID="lblIncome" runat="server" CssClass="rightWithout" 
                    Text="مشتريات اليوم"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                
                <asp:TextBox ID="tbTIncome" runat="server" CssClass="tb7" ReadOnly="True">0.00</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="tbTIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="tbTIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
                
            </td>
            <td>
                <asp:Label ID="lblTIncome" runat="server" CssClass="rightWithout" 
                    Text="اجمالي رصيد البوفية"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbSales" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbSales_TextChanged">0.00</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="tbSales" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="tbSales" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblSales" runat="server" CssClass="rightWithout" 
                    Text="ناقص مبيعات اليوم"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbMigBalance" runat="server" CssClass="tb7" ReadOnly="True">0.00</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="tbMigBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="tbMigBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblMigBalance" runat="server" CssClass="rightWithout" 
                    Text="الرصيد المرحل لليوم التالي"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
    <tr>
    <td>
    <asp:Button ID="btnReset" runat="server" Text="جديد" CssClass="myButton" 
            CausesValidation="False" onclick="btnReset_Click" 
             />
    <asp:Button ID="btnPrint" runat="server" Text="طباعة" CssClass="myButton" 
            onclick="btnPrint_Click" />
        <asp:Button ID="btnSave" runat="server" CssClass="myButton" 
            onclick="btnSave_Click" Text="حفظ" />
        
    
    </td>
    <td>
    <asp:Label ID="lblError" CssClass="rightWithout" runat="server" ForeColor="Maroon" 
            Visible="False"></asp:Label>
    </td>
    </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
