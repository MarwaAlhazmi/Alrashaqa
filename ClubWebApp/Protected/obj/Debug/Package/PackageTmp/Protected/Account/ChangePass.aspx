<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="ClubWebApp.Account.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2 class="right">تغيير كلمة المرور</h2><br /><br /><br /><br />
<p class="right">الرجاء اختيار اسم المستخدم للحساب المراد تغييره</p><br /><br /><br /><br />
<asp:Label ID="Label1" runat="server" AssociatedControlID="CurrentPassword" Width="150px" CssClass="rightWithout">اسم المستخدم</asp:Label>
    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="tb7" 
        AppendDataBoundItems="True" AutoPostBack="True" 
        onselectedindexchanged="ddlUsers_SelectedIndexChanged">
        <asp:ListItem>... اسم المستخدم</asp:ListItem>

    </asp:DropDownList>
        <br /><br />
        <asp:Panel ID="pnlPass" runat="server" Visible="False">
 <div>
                <fieldset>
                    <legend>معلومات الحساب</legend><br />
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword" Width="150px" CssClass="rightWithout">كلمة المرور القديمة</asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="rightWithout" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                             CssClass="rightWithout" ErrorMessage="كلمة المرور مطلوبة" ToolTip="Old Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Maroon">*</asp:RequiredFieldValidator>
                    </p><br /><br />
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword" Width="150px" CssClass="rightWithout">كلمة المرور الجديدة</asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="rightWithout" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                             CssClass="rightWithout" ErrorMessage="الرجاء ادخال كلمة المرور الجديدة" ToolTip="New Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Maroon">*</asp:RequiredFieldValidator>
                    </p>
                 
                 <br /><br />
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword" Width="150px" CssClass="rightWithout">تأكيد كلمة المرور الجديدة</asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="rightWithout" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                             CssClass="rightWithout" Display="Dynamic" ErrorMessage="الرجاء ادخال تأكيد كلمة المرور الجديدة"
                             ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Maroon">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                             CssClass="rightWithout" Display="Dynamic" ErrorMessage="التأكيد لا يتطابق مع كلمة المرور الجديدة"
                             ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Maroon">*</asp:CompareValidator>
                    </p><br /><br />
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text=" رجوع" CssClass="myButton" onclick="CancelPushButton_Click" 
                        />
                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                        CommandName="ChangePassword" Text="تغيير كلمة المرور" CssClass="myButton" 
                         ValidationGroup="ChangeUserPasswordValidationGroup" 
                        onclick="ChangePasswordPushButton_Click"/>
                    
                </p><br /><br />
            </div>
        </asp:Panel>
        <asp:Label ID="lblError" runat="server" CssClass="right" ForeColor="Maroon"></asp:Label>
</asp:Content>
