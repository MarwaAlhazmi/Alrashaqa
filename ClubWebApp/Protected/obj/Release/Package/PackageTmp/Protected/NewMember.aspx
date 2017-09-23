<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMember.aspx.cs" Inherits="ClubWebApp.NewMember" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table width="100%">
    <tr>
    <td>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <img id="img1" alt="" src="Styles/img/ajax-loader(4).gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>
    </td>
    <td>
    <h2 class="rightWithout">إضافة ملف جديد</h2>
    </td>
    </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td><asp:TextBox ID="tbLastName" runat="server" CssClass="tb7"></asp:TextBox></td>
    <td style="width:57px">
        <asp:Label ID="lblLastName" runat="server" CssClass="rightWithout" Width="57px"
            Text="اسم الجد" AssociatedControlID="tbLastName"></asp:Label>
        </td>
    <td><asp:TextBox ID="tbSecondName" runat="server" CssClass="tb7"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="tbSecondName" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon"></asp:RequiredFieldValidator>
        </td>
    <td style="width:57px">
        <asp:Label ID="lblSecondName" runat="server" CssClass="rightWithout" Width="57px"
            Text="اسم الأب" AssociatedControlID="tbSecondName"></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbFirstName" runat="server" CssClass="tb7"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbFirstName" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon"></asp:RequiredFieldValidator>
        </td>
    <td style="width:57px">
        <asp:Label ID="lblFirstName" runat="server" Text="الاسم الأول" 
            CssClass="rightWithout" Width="57px" AssociatedControlID="tbFirstName"></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="tbFamilyName" runat="server" CssClass="tb7"></asp:TextBox>
            </td>
            <td style="width:57px">
                <asp:Label ID="lblFamilyName" runat="server" CssClass="rightWithout" Width="53px"
                    Text="اسم العائلة" AssociatedControlID="tbFamilyName"></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td>
        <asp:TextBox ID="tbID" runat="server" CssClass="tb7"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="tbID" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,12}$"></asp:RegularExpressionValidator>
    </td>
    <td style="width:57px">
        <asp:Label ID="lblID" runat="server" CssClass="rightWithout" Width="57px"
            Text="رقم الهوية" AssociatedControlID="tbID"></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbNation" runat="server" CssClass="tb7"></asp:TextBox>
        </td>
    <td style="width:57px">
        <asp:Label ID="lblNation" runat="server" CssClass="rightWithout" Width="57px"
            Text="الجنسية" AssociatedControlID="tbNation"></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbPhone" runat="server" CssClass="tb7"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="tbPhone" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbPhone" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
        </td>
    <td style="width:57px">
    <asp:Label ID="lblPhone" runat="server" CssClass="rightWithout" Width="57px"
                    Text="رقم الهاتف" AssociatedControlID="tbPhone"></asp:Label>
    </td>
    </tr>
    </table>
    <hr />
        <table width="100%">
    <tr>
    <td>
        <asp:TextBox ID="tbRefferedFrom" runat="server" CssClass="tb7"></asp:TextBox>
    </td>
    <td style="width:57px">
        <asp:Label ID="lblRefferedFrom" runat="server" CssClass="rightWithout" Width="57px"
            Text="جهة التحويل" AssociatedControlID="tbRefferedFrom"></asp:Label>
        </td>
    <td>
        <asp:RadioButtonList ID="rbMarital" runat="server" CssClass="rightWithout" 
            TextAlign="Left" Width="150px">
            <asp:ListItem Selected="True">متزوجة</asp:ListItem>
            <asp:ListItem>غير متزوجة</asp:ListItem>
        </asp:RadioButtonList>
        </td>
    <td class="style2">
        <asp:Label ID="lblMarital" runat="server" CssClass="rightWithout" Width="57px"
            Text="الحالة الاجتماعية" AssociatedControlID="rbMarital"></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="tbDOB" runat="server" CssClass="tb7"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="tbDOB" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
        </td>
    <td style="width:57px">
    <asp:Label ID="lblDOB" runat="server" CssClass="rightWithout" Width="57px"
                    Text="سنة الميلاد" AssociatedControlID="tbDOB"></asp:Label>
    </td>
    </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td><asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="myButton" 
            onclick="btnSave_Click" /></td>
    <td></td>
    </tr>
    </table>
        
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 64px;
        }
    </style>
</asp:Content>

