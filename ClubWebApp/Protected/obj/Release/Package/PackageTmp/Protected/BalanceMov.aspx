<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BalanceMov.aspx.cs" Inherits="ClubWebApp.BalanceMov" %>

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
                    ontextchanged="tbIncome_TextChanged"></asp:TextBox>
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
                
                <asp:TextBox ID="tbTIncome" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
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
                    ontextchanged="tbSales_TextChanged"></asp:TextBox>
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
                <asp:TextBox ID="tbMigBalance" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
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
   <br />
    <hr />
    <h2 class="right">حركة عهدة المصروفات</h2>
        
        
        <table class="withBorder" width="100%">
    <tr>
    <td>
     <asp:TextBox ID="tbOPreBalance" runat="server" CssClass="tb7" AutoPostBack="True" 
            ontextchanged="tbOPreBalance_TextChanged"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="tbOPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="tbOPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
    </td>
    <td style="width:150px">
   <asp:Label ID="lblOPreBalance" runat="server" Text="رصيد العهدة المرحل" CssClass="rightWithout"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbOBalance" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbOBalance_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                    ControlToValidate="tbOBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="tbOBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
               </td>
            <td>
                <asp:Label ID="lblOBalance" runat="server" CssClass="rightWithout" 
                    Text="اضافة عهدة"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                
                <asp:TextBox ID="tbOTBalance" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="tbOTBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="tbOTBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
                
            </td>
            <td>
                <asp:Label ID="lblOTBalance" runat="server" CssClass="rightWithout" 
                    Text="مجموع العهدة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbOExpenses" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbOExpenses_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="tbOExpenses" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="tbOExpenses" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblOExpenses" runat="server" CssClass="rightWithout" 
                    Text="ناقص مصروفات اليوم"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbOMigBlanace" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="tbOMigBlanace" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="tbOMigBlanace" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblOMigBalance" runat="server" CssClass="rightWithout" 
                    Text="الرصيد المرحل لليوم التالي"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <hr />
    <h2 class="right">حركة الصندوق</h2>
        
        
        <table class="withBorder" width="100%">
    <tr>
    <td>
     <asp:TextBox ID="tbCPreBalance" runat="server" CssClass="tb7" AutoPostBack="True" 
            ontextchanged="tbCPreBalance_TextChanged"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="tbCPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="tbCPreBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
    </td>
    <td style="width:150px">
   <asp:Label ID="lblCPreBalance" runat="server" Text="الرصيد السابق" CssClass="rightWithout"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbCIncome" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbCIncome_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate="tbCIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="tbCIncome" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
               </td>
            <td>
                <asp:Label ID="lblCIncome" runat="server" CssClass="rightWithout" 
                    Text="ايراد اليوم"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                
                <asp:TextBox ID="tbCBuffet" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbCBuffet_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" 
                    ControlToValidate="tbCBuffet" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="tbCBuffet" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
                
            </td>
            <td>
                <asp:Label ID="lblCBuffet" runat="server" CssClass="rightWithout" 
                    Text="ايراد البوفيه"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbCTotal" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" 
                    ControlToValidate="tbCTotal" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="tbCTotal" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblCTotal" runat="server" CssClass="rightWithout" 
                    Text="الإجمالي"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbCExpenses" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbCExpenses_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" 
                    ControlToValidate="tbCExpenses" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                    ControlToValidate="tbCExpenses" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblCExpenses" runat="server" CssClass="rightWithout" 
                    Text="محول لعهدة المصروفات"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:TextBox ID="tbCBank" runat="server" CssClass="tb7" AutoPostBack="True" 
                    ontextchanged="tbCBank_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" 
                    ControlToValidate="tbCBank" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                    ControlToValidate="tbCBank" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblCBank" runat="server" CssClass="rightWithout" 
                    Text="ايداع نقدي بالبنك"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:TextBox ID="tbCMigBalance" runat="server" CssClass="tb7" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" 
                    ControlToValidate="tbCMigBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon" 
                    ValidationExpression="^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                    ControlToValidate="tbCMigBalance" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblCMigBalance" runat="server" CssClass="rightWithout" 
                    Text="الرصيد المرحل"></asp:Label>
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
