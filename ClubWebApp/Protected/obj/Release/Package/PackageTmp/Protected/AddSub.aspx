<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSub.aspx.cs" Inherits="ClubWebApp.AddSub" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
    <h2 class="rightWithout"> اشتراك جديد </h2>
    </td>
    </tr>
    </table> 
   <asp:Panel ID="pnlMember" runat="server" GroupingText="معلومات المشتركة">

    <table width="100%">
    <tr>
        <td>
            <asp:TextBox ID="tbFile" runat="server"  CssClass="tb7" 
                ontextchanged="tbFile_TextChanged" AutoPostBack="True"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ControlToValidate="tbFile" CssClass="rightWithout" ErrorMessage="*" 
                ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
        </td>
    <td style="width:90px">
        <asp:Label ID="lblFile" runat="server" Text="رقم الملف" CssClass="rightWithout" AssociatedControlID="tbFile"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                 <asp:Label ID="lblNameValue" runat="server"
                    CssClass="rightWithout" Height="19px"></asp:Label>
            </td>
            <td style="width:90px">
                <asp:Label ID="lblName" runat="server"  
                    CssClass="rightWithout" Text=" اسم العضوة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" CssClass="rightWithout" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td style="width: 90px">
                &nbsp;</td>
        </tr>
    </table>
       </asp:Panel>
       <asp:Panel ID="pnlService" runat="server" GroupingText="معلومات الاشتراك" 
            Visible="False">
       <table width="100%">
       <tr>
       <td>
           <asp:DropDownList ID="ddlDep" runat="server" AppendDataBoundItems="True" 
               AutoPostBack="True" CssClass="tb7" 
               onselectedindexchanged="ddlDep_SelectedIndexChanged" Width="150px">
               <asp:ListItem>...اختاري القسم</asp:ListItem>
           </asp:DropDownList>
       </td>
       <td style="width:80px">
           <asp:Label ID="lblDep" runat="server" CssClass="rightWithout" Text="القسم"></asp:Label>
       </td>
       </tr>
           <tr>
               <td>
                   <asp:DropDownList ID="ddlDoc" runat="server" AutoPostBack="True" CssClass="tb7" 
                       Width="150px">
                   </asp:DropDownList>
               </td>
               <td style="width:80px">
                   <asp:Label ID="lblDoc" runat="server" CssClass="rightWithout" Text="المسؤولة"></asp:Label>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:DropDownList ID="ddlServices" runat="server" AutoPostBack="True" 
                       CssClass="tb7" Width="150px">
                   </asp:DropDownList>
               </td>
               <td style="width:80px">
                   <asp:Label ID="lblServices" runat="server" CssClass="rightWithout" 
                       Text="الإشتراك"></asp:Label>
               </td>
           </tr>
       </table>
       </asp:Panel>
       <asp:Panel ID="pnlDetails" runat="server" GroupingText="معلومات إضافية" 
            Visible="False">
       <table width="100%">
       <tr>
       <td >
           <asp:TextBox ID="tbMeasurements" runat="server" CssClass="tb7" Height="25px" 
               Width="600px"></asp:TextBox>
           </td>
       <td style="width:100px">
           <asp:Label ID="lblMeasurements" runat="server" CssClass="rightWithout" 
               Text="القياس الطبي"></asp:Label>
           </td>
       </tr>
       <tr>
       <td >
           <asp:TextBox ID="tbDiagnosis" runat="server" CssClass="tb7" Height="25px" 
               Width="600px"></asp:TextBox>
           </td>
       <td style="width:100px">
           <asp:Label ID="lblDiagnosis" runat="server" CssClass="rightWithout" 
               Text="التشخيص"></asp:Label>
           </td>
       </tr>
       </table>
       <hr />
       <asp:Panel ID="pnlInt" runat="server" Visible="False">
       <table width="100%">

       <tr>
       <td>
           <asp:TextBox ID="tbBPressure" runat="server" CssClass="rightWithout"></asp:TextBox>
       </td>
       <td style="width:100px">
           <asp:Label ID="lblBPressure" runat="server" CssClass="rightWithout" Text="ضغط الدم"></asp:Label>
       </td>
       </tr>

              <tr>
       <td>
           <asp:TextBox ID="tbBSugar" runat="server" CssClass="rightWithout"></asp:TextBox>
       </td>
       <td style="width:100px">
           <asp:Label ID="lblBSugar" runat="server" CssClass="rightWithout" Text="سكر الدم"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
      
       <asp:Panel ID="pnlNut" runat="server" Visible="False">
       <table width="100%">
       <tr>
       <td class="style2">
           <asp:TextBox ID="tbHieght" runat="server" CssClass="rightWithout"></asp:TextBox>
       </td>
       <td class="style3">
           <asp:Label ID="lblHieght" runat="server" CssClass="rightWithout" Text="الطول"></asp:Label>
       </td>
       </tr>
              <tr>
       <td>
           <asp:TextBox ID="tbWeight" runat="server" CssClass="rightWithout"></asp:TextBox>
       </td>
       <td style="width:100px">
           <asp:Label ID="lblWeight" runat="server" CssClass="rightWithout" Text="الوزن"></asp:Label>
       </td>
       </tr>
              <tr>
       <td>
           <asp:TextBox ID="tbFat" runat="server" CssClass="rightWithout"></asp:TextBox>
       </td>
       <td style="width:100px">
           <asp:Label ID="lblFat" runat="server" CssClass="rightWithout" Text="الدهون"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>

       </asp:Panel>
        <asp:Button ID="btnSave" runat="server" CssClass="myButton" Text="حفظ" 
            onclick="btnSave_Click" />

       </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .style2
    {
        height: 26px;
    }
    .style3
    {
        width: 100px;
        height: 26px;
    }
</style>
</asp:Content>

