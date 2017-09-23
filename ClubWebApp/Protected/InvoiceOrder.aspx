<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceOrder.aspx.cs" Inherits="ClubWebApp.InvoiceOrder" %>
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
    <h2 class="rightWithout"> إصدار فاتورة </h2>
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
    <td style="width:80px">
        <asp:Label ID="lblFile" runat="server" Text="رقم الملف" CssClass="rightWithout" AssociatedControlID="tbFile"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                 <asp:Label ID="lblNameValue" runat="server"
                    CssClass="rightWithout" Height="19px"></asp:Label>
            </td>
            <td style="width:80px">
                <asp:Label ID="lblName" runat="server"  
                    CssClass="rightWithout" Text=" اسم العضوة"></asp:Label>
            </td>
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
                   <asp:CheckBoxList ID="cbServices" runat="server" CssClass="rightWithout" 
                       RepeatColumns="2" RepeatDirection="Horizontal" TextAlign="Left" 
                       onselectedindexchanged="cbServices_SelectedIndexChanged" 
                       AutoPostBack="True">
                   </asp:CheckBoxList>
               </td>
               <td style="width:80px">
                   <asp:Label ID="lblServices" runat="server" CssClass="rightWithout" 
                       Text="الإشتراكات"></asp:Label>
               </td>
           </tr>
       </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlTotal" runat="server" GroupingText="المبلغ" Visible="False">
       <table width="100%">
       <tr>
       <td>
           <asp:TextBox ID="tbTotal" runat="server" CssClass="tb7" ReadOnly="true"></asp:TextBox></td>
       <td style="width:120px" >
           <asp:Label ID="lblTotal" runat="server" Text="المبلغ الإجمالي" CssClass="rightWithout"></asp:Label></td>
       </tr>
           <tr>
                        <td>
                   <asp:TextBox ID="tbDis" runat="server" CssClass="tb7" ontextchanged="tbDis_TextChanged" 
                                AutoPostBack="True"></asp:TextBox>
               </td>
               <td style="width:120px">
                   <asp:Label ID="lbltbDis" runat="server" CssClass="rightWithout" AssociatedControlID="tbDis"
                       Text="الخصم"></asp:Label>
               </td>
               
           </tr>
           <tr>
  <td>
                   <asp:TextBox ID="tbFinal" runat="server" CssClass="tb7" ReadOnly="true"></asp:TextBox>
               </td>
               <td style="width:120px">
                   <asp:Label ID="lblFinal" runat="server" CssClass="rightWithout" AssociatedControlID="tbFinal"
                       Text="المبلغ النهائي"></asp:Label>
               </td>
           </tr>

            <tr>
               <td>
                   <asp:TextBox ID="tbNotes" runat="server" CssClass="tb7" 
                       Width="500px"></asp:TextBox>
                </td>
               <td style="width:120px">
                   <asp:Label ID="lblNotes" runat="server" AssociatedControlID="tbNotes" 
                       CssClass="rightWithout" Text="ملاحظات"></asp:Label>
                </td>
           </tr>
          
           <tr>
               <td>
               <asp:Button ID="btnNew" runat="server" CssClass="myButton" 
                       Text="جديد" onclick="btnNew_Click" />
                   <asp:Button ID="btnSave0" runat="server" CssClass="myButton" 
                       onclick="btnSave_Click" Text="حفظ" />
                       
               </td>
               <td style="width:120px">
                   &nbsp;</td>
           </tr>
          
       </table>
       </asp:Panel>
       
       <table width="100%">
       <tr>
       <td>
           <asp:Label ID="lblError" CssClass="rightWithout" runat="server" Text="" ForeColor="Maroon"></asp:Label>
       </td>
       
       </tr>
       </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">

</asp:Content>

