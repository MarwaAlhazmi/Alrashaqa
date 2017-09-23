<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ClubWebApp.Invoice" %>
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
           <table style="width:100%">
               <tr>
                   <td>
                   <asp:ListBox ID="lbSelected" runat="server" CssClass="tb7" Height="100px" 
                           Width="210px"></asp:ListBox>
                   </td>
                   <td style="width:50px">
                   <asp:Button ID="btnAdd" runat="server" CssClass="rightWithout" 
                   Text="&lt;&lt;" onclick="btnAdd_Click" CausesValidation="False" />
                   <asp:Button ID="btnDelete" runat="server" CssClass="rightWithout" 
                   Text="X" onclick="btnDelete_Click" CausesValidation="False" Width="30px" />
                   </td>
                   <td style="width:200px">
                    <asp:ListBox ID="lbServices" runat="server" CssClass="tb7" Height="100px" 
                           Width="210px"></asp:ListBox>
                   </td>
               </tr>
           </table>
               
               
               
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
                            <asp:Label ID="lbltbDis0" runat="server" AssociatedControlID="tbDis" 
                                CssClass="rightWithout" Text="%"></asp:Label>
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
          
       </table>
       </asp:Panel>
       <asp:Panel ID="pnlType" runat="server" GroupingText="نوع الفاتورة" 
            Visible="False">
       <table width="100%">
       <tr>
       <td>
           <asp:RadioButtonList ID="rbType" runat="server" CssClass="rightWithout" 
               RepeatColumns="3" TextAlign="Left" AutoPostBack="True" 
               onselectedindexchanged="rbType_SelectedIndexChanged">
               <asp:ListItem Value="Check">شيك</asp:ListItem>
               <asp:ListItem Value="Credit">آجل</asp:ListItem>
               <asp:ListItem Selected="True" Value="Cash">نقدي</asp:ListItem>
           </asp:RadioButtonList>
       </td>
       <td style="width:120px">
           <asp:Label ID="lblType" runat="server" CssClass="rightWithout" 
               Text="طريقة الدفع"></asp:Label>
       </td>
       </tr>
       </table>
       
       <asp:Panel ID="pnlCredit" runat="server" Visible="false">
       <table width="100%">
        <tr>
               <td>
                   <asp:TextBox ID="tbPaid" runat="server" CssClass="tb7" 
                       ontextchanged="tbPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
               </td>
               <td style="width:120px">
                   <asp:Label ID="lblPaid" runat="server" AssociatedControlID="tbPaid" 
                       CssClass="rightWithout" Text="المبلغ المدفوع"></asp:Label>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:TextBox ID="tbRemain" runat="server" CssClass="tb7" ReadOnly="true"></asp:TextBox>
               </td>
               <td style="width:120px">
                   <asp:Label ID="lblRemain" runat="server" AssociatedControlID="tbRemain" 
                       CssClass="rightWithout" Text="المبلغ المتبقي"></asp:Label>
               </td>
           </tr>
       </table>
       </asp:Panel>

       <asp:Panel ID="pnlCheck" runat="server" Visible="false">
       <table width="100%">
       <tr>
                <td>
                <asp:TextBox ID="tbCheck" runat="server" CssClass="tb7"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbCheck" CssClass="rightWithout" ErrorMessage="*" 
                    ForeColor="#CC0000" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbCheck" CssClass="rightWithout" ErrorMessage="*" 
                        ForeColor="Maroon"></asp:RequiredFieldValidator>
                </td>
                <td width="120px">
                 <asp:Label ID="lblCheck" runat="server" CssClass="rightWithout" Text="رقم الشيك"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:TextBox ID="tbBank" runat="server" CssClass="tb7"></asp:TextBox>
                </td>
                <td>
                 <asp:Label ID="lblBank" runat="server" CssClass="rightWithout" Text="على بنك"></asp:Label>
                </td>
                </tr>
       </table>
       </asp:Panel>
       <asp:Button ID="btnAddV" runat="server" CssClass="myButton" 
                       Text="إنشاء سند" Enabled="False" onclick="btnAddV_Click" 
               Visible="False" />
       <asp:Button ID="btnPrintV" runat="server" CssClass="myButton" 
                       Text="طباعة السند" Enabled="False" onclick="btnPrintV_Click" />
       <asp:Button ID="btnPrint" runat="server" CssClass="myButton" 
                       onclick="btnPrint_Click" Text=" طباعة الفاتورة" Enabled="False" />
                       <asp:Button ID="btnSave" runat="server" CssClass="myButton" 
                        Text="حفظ" onclick="btnSave_Click" />
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

