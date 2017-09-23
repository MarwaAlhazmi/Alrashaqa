<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ClubWebApp.Edit" %>

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
    <h2 class="right">تحرير / حذف</h2>
    </td>
    </tr>
    </table>
    <table width="100%">
    <tr>
    <td>
        <asp:RadioButtonList ID="rbAdd" runat="server" CssClass="right" 
            TextAlign="Left">
            <asp:ListItem> الموظفين</asp:ListItem>
            <asp:ListItem> الخدمات</asp:ListItem>
            <asp:ListItem> العيادات</asp:ListItem>
            <asp:ListItem>أنواع سندات الصرف</asp:ListItem>
        </asp:RadioButtonList>
        </td>
    <td style="width:100px">
        &nbsp;</td>
    </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" CssClass="myButton" Text="تحرير" 
                    onclick="btnAdd_Click" />
                <asp:Label ID="lblError" runat="server" CssClass="rightWithout" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td>
        <asp:Panel ID="pnlEmp" runat="server" GroupingText="تعديل معلومات الموظفين" 
            Visible="false" CssClass="rightWithout" Width="100%">
            <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
                onrowcommand="gvEmp_RowCommand" onrowdatabound="gvEmp_RowDataBound" 
                onrowdeleting="gvEmp_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
               
                    <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                    <asp:CommandField SelectText="تحرير" ShowSelectButton="True" />
                    <asp:BoundField DataField="Dep" HeaderText="القسم" />
                    <asp:BoundField DataField="Phone" HeaderText="رقم الهاتف" />
                    <asp:BoundField DataField="Name" HeaderText="اسم الموظفة" />
                    <asp:BoundField DataField="ID" HeaderText="رقم الموظفة" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
               
            </asp:GridView>
        
        <table width="100%" runat="server" id="empTable" visible="false">
        <tr>
        <td>

            <asp:TextBox ID="tbEName" runat="server" CssClass="tb7"></asp:TextBox>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblEName" runat="server" Text="اسم الموظفة" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td class="style2">

            <asp:TextBox ID="tbPhone" runat="server" CssClass="tb7"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbPhone" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>

        </td>
        <td class="style3">
    
            <asp:Label ID="lblPhone" runat="server" Text="رقم الهاتف" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
        <tr>
        <td class="style2">

            <asp:DropDownList ID="ddlType" runat="server" CssClass="tb7" 
                AppendDataBoundItems="True" Width="160px">
                <asp:ListItem Value="0">إدارة</asp:ListItem>
            </asp:DropDownList>

        </td>
        <td class="style3">
    
            <asp:Label ID="lblType" runat="server" Text="القسم" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
            <tr>
                <td>
                <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="myButton" 
                        onclick="btnCancel_Click" CausesValidation="False" 
                        />
                    <asp:Button ID="btnEAdd" runat="server" Text="حفظ" CssClass="myButton" 
                        onclick="btnEAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="pnlDep" runat="server" GroupingText="تعديل معلومات العيادات" 
            Visible="false">
            <asp:GridView ID="gvDep" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" CssClass="rightWithout" ForeColor="#333333" GridLines="None" 
                onrowcommand="gvDep_RowCommand" onrowdatabound="gvDep_RowDataBound" 
                Width="100%" onrowdeleting="gvDep_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    
                    <asp:ButtonField CommandName="Delete" ButtonType="Link" Text="حذف" />
                    <asp:CommandField SelectText="تحرير" ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="اسم العيادة" />
                    <asp:BoundField DataField="DepID" HeaderText="رمز العيادة" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        <table width="100%" id="DepTable" runat="server" visible="false">
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
                <asp:Button ID="btnDCancel" runat="server" Text="إلغاء" CssClass="myButton" 
                        onclick="btnDCancel_Click" CausesValidation="False"
                        />
                    <asp:Button ID="btnDAdd" runat="server" Text="حفظ" CssClass="myButton" 
                        onclick="btnDAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="pnlService" runat="server" GroupingText="تعديل الخدمات" Visible="false">
            <asp:GridView ID="gvSer" runat="server" AutoGenerateColumns="False" 
                CssClass="rightWithout" Width="100%" CellPadding="4" ForeColor="#333333" 
                GridLines="None" onrowcommand="gvSer_RowCommand" 
                onrowdeleting="gvSer_RowDeleting" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                    <asp:CommandField SelectText="تحرير" ShowSelectButton="True" />
                    <asp:BoundField DataField="SubDays" HeaderText="عدد الأيام" />
                    <asp:BoundField DataField="SubType" HeaderText="نوع الخدمة" />
                    <asp:BoundField DataField="Price" HeaderText="السعر" />
                    <asp:BoundField DataField="Dep" HeaderText="القسم" />
                    <asp:BoundField DataField="Name" HeaderText="اسم الخدمة" />
                    <asp:BoundField DataField="ID" HeaderText="رمز الخدمة" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        <table width="100%" id="serTable" runat="server" visible="false">
        <tr>
        <td class="style4">
        
            <asp:RadioButtonList ID="rbSType" runat="server" 
                CssClass="rightWithout" RepeatDirection="Horizontal" TextAlign="Left" 
                onselectedindexchanged="rbSType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True">جلسة واحدة</asp:ListItem>
                <asp:ListItem>اشتراك شهري</asp:ListItem>
            </asp:RadioButtonList>
        
        </td>
        <td class="style4">
        
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
                <asp:Button ID="btnSCancel" runat="server" Text="إلغاء" CssClass="myButton" 
                        CausesValidation="False" onclick="btnSCancel_Click"
                        />
                    <asp:Button ID="btnSAdd" runat="server" CssClass="myButton" Text="حفظ" 
                        onclick="btnSAdd_Click" />
                </td>
                <td style="width:120px">
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
        

             <asp:Panel ID="pnlWith" runat="server" GroupingText="تعديل أنواع سندات القبض" 
            Visible="false">
            <asp:GridView ID="gvWith" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" CssClass="rightWithout" ForeColor="#333333" GridLines="None" 
                onrowcommand="gvWith_RowCommand" onrowdatabound="gvWith_RowDataBound" 
                Width="100%" onrowdeleting="gvWith_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    
                    <asp:ButtonField CommandName="Delete" ButtonType="Link" Text="حذف" />
                    <asp:CommandField SelectText="تحرير" ShowSelectButton="True" />
                    <asp:BoundField DataField="Department" HeaderText="تابع لقسم" />
                    <asp:BoundField DataField="Name" HeaderText="نوع سند القبض" />
                    <asp:BoundField DataField="ID" HeaderText="الرقم" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        <table width="100%" id="withTable" runat="server" visible="false">
        <tr>
        <td>

            <asp:TextBox ID="tbWName" runat="server" CssClass="tb7"></asp:TextBox>

        </td>
        <td style="width:120px">
    
            <asp:Label ID="lblWName" runat="server" Text="نوع سند القبض" CssClass="rightWithout"></asp:Label>
    
        </td>
        </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlWDep" runat="server" CssClass="tb7" Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="width:120px">
                    <asp:Label ID="lblWDep" runat="server" CssClass="rightWithout" 
                        Text="تابع لقسم"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnWCancel" runat="server" CausesValidation="False" 
                        CssClass="myButton" Text="إلغاء" onclick="btnWCancel_Click" />
                    <asp:Button ID="btnWSave" runat="server" CssClass="myButton" Text="حفظ" 
                        onclick="btnWSave_Click" />
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style2
        {
            height: 36px;
        }
        .style3
        {
            width: 120px;
            height: 36px;
        }
        .style4
        {
            height: 32px;
        }
    </style>
</asp:Content>

