<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ClubWebApp.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

   <asp:Label ID="lblError" runat="server" Text="" CssClass="rightWithout" ForeColor="Maroon" Visible="false"></asp:Label>
   <br />
   <br />
   <h2 class="rightWithout">
                        انشاء حساب جديد
                    </h2><br /><br /><br />
          <p>
                                <asp:Label ID="lblName" runat="server" AssociatedControlID="ddlName" CssClass="rightWithout" Width="100px">اسم الموظفه</asp:Label>
                                <asp:DropDownList ID="ddlName" runat="server" CssClass="rightWithout" 
                                    Width="150px" EnableViewState="true" ViewStateMode="Inherit" 
                                    AppendDataBoundItems="True">
                                <asp:ListItem>...اختاري الاسم</asp:ListItem>
                                </asp:DropDownList>
                               
                            </p>
                          <br /><br /><br />
                            <p>
                                <asp:Label ID="RoleLabel" runat="server" AssociatedControlID="ddlRoles" CssClass="rightWithout" Width="100px">الصلاحيات</asp:Label>
                                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="rightWithout" Width="150px">
                              
                                <asp:ListItem Value="Receptionist">استقبال</asp:ListItem>
                                <asp:ListItem Value="Manager">إدارة</asp:ListItem>
                                <asp:ListItem Value="PhysicalS">علاج طبيعي</asp:ListItem>
                                <asp:ListItem Value="Nutritionist">تغذية</asp:ListItem>
                                <asp:ListItem Value="InternalS">باطنية</asp:ListItem>
                              
                                </asp:DropDownList>
                               
                            </p>
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" 
        OnCreatedUser="RegisterUser_CreatedUser" RequireEmail="False" 
        CompleteSuccessText="تم انشاء الحساب بنجاح" 
        DuplicateUserNameErrorMessage="الرجاء ادخال اسم مستخدم مختلف" 
        UnknownErrorMessage="لم يتم انشاء الحساب. الرجاء المحاولة مره أخرى" 
        ContinueButtonText="استمرار" ContinueDestinationPageUrl="~/Default.aspx">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    
                  <br /><br /><br />
                    <p class="rightWithout">
                       يجب أن يكون عدد الأحرف في كلمة المرور على الأقل <%= Membership.MinRequiredPasswordLength %>  
                    </p>
                    <br />
                    <br /><br /><br />
                    <span>
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div>
                        <fieldset>
                            <legend>معلومات الحساب</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="rightWithout" Width="100px">اسم المستخدم</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="rightWithout"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="rightWithout" ErrorMessage="اسم المستخدم مطلوب" ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup" ForeColor="Maroon">*</asp:RequiredFieldValidator>
                            </p>
                            <br />
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="rightWithout" Width="100px">كلمة المرور</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="rightWithout" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="rightWithout" ErrorMessage="كلمة المرور مطلوبة" ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup" ForeColor="Maroon">*</asp:RequiredFieldValidator>
                            </p><br />
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" CssClass="rightWithout" Width="100px">تأكيد كلمة المرور</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="rightWithout" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="rightWithout" Display="Dynamic" 
                                     ErrorMessage="تأكيد كلمة المرور مطلوب" ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ForeColor="Maroon" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="rightWithout" Display="Dynamic" ErrorMessage="كلمة المرور لا تتطابق"
                                     ValidationGroup="RegisterUserValidationGroup" ForeColor="Maroon">*</asp:CompareValidator>
                            </p>
                              <br />
                           
                        </fieldset>
                        <p>
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="انشاء الحساب" CssClass="myButton" 
                                 ValidationGroup="RegisterUserValidationGroup"/>
                        </p>
                        <br />
                        <br />
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    

</asp:Content>
