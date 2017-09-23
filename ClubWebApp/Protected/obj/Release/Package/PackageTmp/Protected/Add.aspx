<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ClubWebApp.Add" %>

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
    <h2 class="right">إضافة للنظام</h2>
    </td>
    </tr>
    </table>
    <table width="100%">
    <tr>
    <td>
        <asp:RadioButtonList ID="rbAdd" runat="server" CssClass="right" 
            TextAlign="Left">
            <asp:ListItem>إضافة موظفة</asp:ListItem>
            <asp:ListItem>إضافة خدمة</asp:ListItem>
            <asp:ListItem>إضافة عيادة</asp:ListItem>
        </asp:RadioButtonList>
        </td>
    <td style="width:100px">
        <asp:Label ID="lblAdd" runat="server" CssClass="right" Text="نوع الإضافة"></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" CssClass="myButton" Text="إضافة" 
                    onclick="btnAdd_Click" />
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
    </table>
    <hr />

    <table width="100%">
    <tr>
    <td>
        <asp:Panel ID="pnlEmp" runat="server" GroupingText="إضافة موظفة للنظام" Visible="false">
        <table width="100%">
        <tr>
        <td>

            <asp:TextBox ID="tbEName" runat="server" CssClass="tb7"></asp:TextBox>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblEName" runat="server" Text="اسم الموظفة" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td>

            <asp:TextBox ID="tbPhone" runat="server" CssClass="tb7"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbPhone" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblPhone" runat="server" Text="رقم الهاتف" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td>

            <asp:DropDownList ID="ddlType" runat="server" CssClass="tb7" 
                AppendDataBoundItems="True" Width="160px">
                <asp:ListItem Value="0">إدارة</asp:ListItem>
            </asp:DropDownList>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblType" runat="server" Text="القسم" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEAdd" runat="server" Text="حفظ" CssClass="myButton" 
                        onclick="btnEAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="pnlDep" runat="server" GroupingText="إضافة عيادة للنظام" Visible="false">
        <table width="100%">
        <tr>
        <td>

            <asp:TextBox ID="tbDName" runat="server" CssClass="tb7"></asp:TextBox>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblDName" runat="server" Text="اسم العيادة" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDAdd" runat="server" Text="حفظ" CssClass="myButton" 
                        onclick="btnDAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="pnlService" runat="server" GroupingText="إضافة خدمة للنظام" Visible="false">
        <table width="100%">
        <tr>
        <td>
        
            <asp:RadioButtonList ID="rbSType" runat="server" 
                CssClass="rightWithout" RepeatDirection="Horizontal" TextAlign="Left" 
                onselectedindexchanged="rbSType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True">جلسة واحدة</asp:ListItem>
                <asp:ListItem>اشتراك شهري</asp:ListItem>
            </asp:RadioButtonList>
        
        </td>
        <td>
        
            <asp:Label ID="lblSType" runat="server" CssClass="rightWithout" 
                Text="نوع الخدمة"></asp:Label>
        
        </td>
        </tr>
        <tr>
        <td>

            <asp:TextBox ID="tbSName" runat="server" CssClass="tb7"></asp:TextBox>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblSName" runat="server" Text="الخدمة" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td>

       
            <asp:DropDownList ID="ddlSDep" runat="server" CssClass="tb7" Width="160px">
            </asp:DropDownList>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblSDep" runat="server" Text="تابع لقسم" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td>
             <asp:TextBox ID="tbPrice" runat="server" CssClass="tb7"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="tbPrice" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^([0-9]*\,?[0-9]+|[0-9]+\,?[0-9]*)?$"></asp:RegularExpressionValidator>

            &nbsp;</td>
        <td style="width:120px">
    
            <asp:Label ID="lblPrice" runat="server" Text="سعر الخدمة" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbDays" runat="server" CssClass="tb7" Enabled="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="tbDays" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
                </td>
                <td style="width:120px">
                    <asp:Label ID="lblDays" runat="server" CssClass="rightWithout" 
                        Text="عدد أيام الاشتراك"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSAdd" runat="server" CssClass="myButton" Text="حفظ" 
                        onclick="btnSAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
        
    </td>
    </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
