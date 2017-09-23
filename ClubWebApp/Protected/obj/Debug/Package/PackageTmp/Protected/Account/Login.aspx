<%@ Page Title="Log In" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ClubWebApp.Account.Login" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="rightWithout">
        تسجيل الدخول
    </h2>
    <br />
    <br />
    <br />
    <p class="rightWithout">
        الرجاء ادخال اسم المستخدم وكلمة المرور
    </p>
    <br />
    <br />
    <br />
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
        RenderOuterTable="true" Width="100%" 
        FailureText="لم يتم تسجيل الدخول. الرجاء المحاولة مرة أخرى">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div >
                <fieldset>
                    <legend>معلومات الحساب</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="rightWithout" Width="100px">اسم المستخدم</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="tb7"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="rightWithout" ErrorMessage="الرجاء إدخال اسم المستخدم" ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <br />
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="rightWithout" Width="100px">كلمة المرور</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="tb7" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="rightWithout" ErrorMessage="الرجاء إدخال كلمة المرور" ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <br />
                    <br />
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server" CssClass="rightWithout"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="rightWithout">تذكر المعلومات</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="تسجيل الدخول" CssClass="myButton" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
