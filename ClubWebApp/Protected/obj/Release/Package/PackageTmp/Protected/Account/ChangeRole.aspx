<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeRole.aspx.cs" Inherits="ClubWebApp.Account.ChangeRole" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="right">تغيير الصلاحيات</h2><br /><br /><br /><br />
<p class="right">الرجاء اختيار اسم المستخدم للحساب المراد تغييره</p><br /><br /><br /><br />
<asp:Label ID="Label1" runat="server"  Width="150px" CssClass="rightWithout">اسم المستخدم</asp:Label>
    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="tb7" 
        AppendDataBoundItems="True" AutoPostBack="True" 
        onselectedindexchanged="ddlUsers_SelectedIndexChanged">
        <asp:ListItem>... اسم المستخدم</asp:ListItem>

    </asp:DropDownList>
        <br /><br />
        <asp:Panel ID="pnlPass" runat="server" Visible="False">
 <div>
                <fieldset>
                    <legend>معلومات الحساب</legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" Width="150px" CssClass="rightWithout">نوع الحساب</asp:Label>
                                <br /><br />
                        <asp:RadioButtonList ID="rbRoles" runat="server" CssClass="right" 
                            TextAlign="Left">
                                <asp:ListItem Value="Receptionist">استقبال</asp:ListItem>
                                <asp:ListItem Value="Manager">إدارة</asp:ListItem>
                                <asp:ListItem Value="PhysicalS">علاج طبيعي</asp:ListItem>
                                <asp:ListItem Value="Nutritionist">تغذية</asp:ListItem>
                                <asp:ListItem Value="InternalS">باطنية</asp:ListItem>
                        </asp:RadioButtonList>
                    </p>
                    <br />
                </fieldset>
                <p>
                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text=" رجوع" CssClass="myButton" onclick="CancelPushButton_Click" 
                        />
                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                        CommandName="ChangePassword" Text="حفظ" CssClass="myButton"  
                        onclick="ChangePasswordPushButton_Click" Width="95px"/>
                    
                </p><br /><br />
            </div>
        </asp:Panel>
        <asp:Label ID="lblError" runat="server"  CssClass="rightWithout" ForeColor="Maroon"></asp:Label>
</asp:Content>
