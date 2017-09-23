<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ClubWebApp.Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%">
<tr>
<td>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
        <img id="img1" src="Styles/img/ajax-loader(4).gif" alt="" />
    </ProgressTemplate>
    </asp:UpdateProgress>
</td>
<td><h2 class="rightWithout">بحث عن ملف</h2></td>
</tr>
</table>
<hr />
<table width="100%">
<tr>
<td>
    <asp:DropDownList ID="dllSearch" runat="server" CssClass="tb7" 
        onselectedindexchanged="dllSearch_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem>اسم العضوة</asp:ListItem>
        <asp:ListItem>رقم الملف</asp:ListItem>
        <asp:ListItem>تاريخ الاشتراك</asp:ListItem>
        <asp:ListItem>رقم الهاتف</asp:ListItem>
        <asp:ListItem>رقم الهوية</asp:ListItem>
    </asp:DropDownList>
</td>
<td style="width:90px">
    <asp:Label ID="lblBy" runat="server" Text="بحث عن طريق" CssClass="rightWithout"></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:TextBox ID="tbSearch" runat="server" CssClass="tb7"></asp:TextBox>
    <ajaxToolkit:CalendarExtender 
        ID="tbSearch_CalendarExtender" runat="server" TargetControlID="tbSearch" 
        Format="dd/MM/yyyy" Enabled="False">
    </ajaxToolkit:CalendarExtender>
    <asp:RegularExpressionValidator ID="reNumber" runat="server" 
        CssClass="rightWithout" ErrorMessage="*" ForeColor="Maroon" 
        ValidationExpression="^\d+$" ControlToValidate="tbSearch" Visible="False"></asp:RegularExpressionValidator>
    <asp:Button ID="btnSearch" runat="server" CssClass="myButton" 
        onclick="btnSearch_Click" Text="بحث" />
</td>
<td style="width:90px">
    <asp:Label ID="lblWord" runat="server" Text="كلمة البحث" CssClass="rightWithout"></asp:Label>
    </td>
</tr>
</table>
<hr />
<table width="100%">
<tr>
<td>
    <asp:FormView ID="fvResult" runat="server" DataKeyNames="ClientID" 
        DataSourceID="EntityDataSource1" Width="100%" 
        ondatabound="fvResult_DataBound" AllowPaging="True" BackColor="White" 
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
        CellSpacing="1" onitemcommand="fvResult_ItemCommand">
        <EditItemTemplate>
            <asp:Label ID="Label13" runat="server" Text="رقم الملف" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="ClientIDLabel1" runat="server" CssClass="tb7" Text='<%# Eval("ClientID") %>' />
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="الاسم الأول" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("FirstName") %>' />
            <br />
            <br />
            <asp:Label ID="Label15" runat="server" Text="اسم الأب" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="SecondNameTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("SecondName") %>' />
            <br />
            <br />
            <asp:Label ID="Label16" runat="server" Text="اسم الجد" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("LastName") %>' />
            <br />
            <br />
            <asp:Label ID="Label17" runat="server" Text="اسم العائلة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="FamilyNameTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("FamilyName") %>' />
            <br />
            <br />
            <asp:Label ID="Label18" runat="server" Text="سنة الميلاد" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="DOBTextBox" runat="server" CssClass="tb7" Text='<%# Bind("DOB") %>' />
            <br />
            <br />
            <asp:Label ID="Label19" runat="server" Text="الجنسية" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="NationalityTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("Nationality") %>' />
            <br />
            <br />
            <asp:Label ID="Label20" runat="server" Text="رقم الهوية" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="IDNumberTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("IDNumber") %>' />
            <br />
            <br />
            <asp:Label ID="Label21" runat="server" Text="رقم الهاتف" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="tb7" Text='<%# Bind("Phone") %>' />
            <br />
            <br />
            <asp:Label ID="Label22" runat="server" Text="الحالة الاجتماعي" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:RadioButtonList ID="rbMarital" runat="server" CssClass="rightWithout" 
                TextAlign="Left" Width="96px" Text='<%# Bind("Marital") %>' >
            <asp:ListItem Value="متزوجة" Text="متزوجة"></asp:ListItem>
            <asp:ListItem Value="غير متزوجة" Text="غير متزوجة"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <br />
            <asp:Label ID="Label31" runat="server" Text="ولي الأمر" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb7"
                Text='<%# Bind("Gardian") %>' />
            <br />
            <br />
                <asp:Label ID="Label32" runat="server" Text="صلة القرابة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="tb7"
                Text='<%# Bind("Relative") %>' />
            <br />
            <br />
            <asp:Label ID="Label23" runat="server" Text="مكان الإقامة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="RefferedFromTextBox" runat="server" CssClass="tb7"
                Text='<%# Bind("Twon") %>' />
            <br />
            <br />
            <asp:Label ID="Label24" runat="server" Text="تاريخ الانتساب" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:TextBox ID="RefferedDateTextBox" runat="server" ReadOnly="true" CssClass="tb7"
                Text='<%# Bind("RefferedDate") %>' />

            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="حفظ" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="إلغاء" />
        </EditItemTemplate>
        <EditRowStyle BackColor="#9898BA" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text="رقم الملف" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="ClientIDLabel" runat="server" CssClass="rightWithout" Text='<%# Eval("ClientID") %>' />
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="الاسم الاول" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="FirstNameLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("FirstName") %>' />
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="اسم الاب" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="SecondNameLabel" runat="server" CssClass="rightWithout"
                Text='<%# Bind("SecondName") %>' />
            <br /><br />
            <asp:Label ID="Label4" runat="server" Text="اسم الجد" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="LastNameLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("LastName") %>' />
            <br /><br />
            <asp:Label ID="Label5" runat="server" Text="اسم العائلة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="FamilyNameLabel" runat="server" CssClass="rightWithout"
                Text='<%# Bind("FamilyName") %>' />
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="سنة الميلاد" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="DOBLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("DOB") %>' />
            <br /><br />
            <asp:Label ID="Label7" runat="server" Text="الجنسية" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="NationalityLabel" runat="server" CssClass="rightWithout"
                Text='<%# Bind("Nationality") %>' />
            <br /><br />
            <asp:Label ID="Label8" runat="server" Text="رقم الهوية" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="IDNumberLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("IDNumber") %>' />
            <br /><br />
            <asp:Label ID="Label9" runat="server" Text="رقم الهاتف" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="PhoneLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("Phone") %>' />
            <br /><br />
            <asp:Label ID="Label10" runat="server" Text="الحالة الاجتماعية" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="MaritalLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("Marital") %>' />
                        <br /><br />
            <asp:Label ID="Label25" runat="server" Text="ولي الأمر" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="Label26" runat="server" CssClass="rightWithout" Text='<%# Bind("Gardian") %>' />
                        <br /><br />
            <asp:Label ID="Label27" runat="server" Text="صلة القرابة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="Label28" runat="server" CssClass="rightWithout" Text='<%# Bind("Relative") %>' />
                        <br /><br />
            <asp:Label ID="Label29" runat="server" Text="مكان الإقامة" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="Label30" runat="server" CssClass="rightWithout" Text='<%# Bind("Twon") %>' />
            <br /><br />
            <asp:Label ID="Label12" runat="server" Text="تاريخ الانتساب" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="RefferedDateLabel" runat="server" CssClass="rightWithout"
                Text='<%# Bind("RefferedDate", "{0:dd/MM/yyyy}") %>' />
                <br /><br />
            <asp:Label ID="Label11" runat="server" Text="جهة التحويل" CssClass="rightWithout" Width="100px"></asp:Label>
            <asp:Label ID="RefferedFromLabel" runat="server" CssClass="rightWithout"
                Text='<%# Bind("RefferedFrom") %>' />
            

            
            <br /><br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="تعديل" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="حذف" />
                &nbsp;<asp:LinkButton ID="VisitButton" runat="server" CausesValidation="False" 
                CommandName="Visit" Text="إضافة زيارة" />
                &nbsp;<asp:LinkButton ID="ShowSubButton" runat="server" CausesValidation="False" 
                CommandName="SSub" Text="استعراض الاشتراكات" />
        </ItemTemplate>
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    </asp:FormView>
    <asp:Label ID="lblError" runat="server" Text="" CssClass="rightWithout" ForeColor="Maroon"></asp:Label>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=ClubDBEntities" DefaultContainerName="ClubDBEntities" 
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="Clients" 
        Where="it.FirstName +' '+ it.SecondName + ' ' + it.LastName +' '+it.FamilyName LIKE '%' + @name + '%' ">
        <WhereParameters>
            <asp:ControlParameter ControlID="tbSearch" Name="name" PropertyName="Text" 
                Type="String" />
        </WhereParameters>
    </asp:EntityDataSource>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
