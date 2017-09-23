<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Visit.aspx.cs" Inherits="ClubWebApp.Visit1" %>
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
    <h2 class="right">عرض الإشتراكات</h2>
    </td>
    </tr>
    </table>
    <hr />
    <table width="100%">
    <tr>
    <td>
        <asp:TextBox ID="tbID" runat="server" CssClass="tb7" 
            ontextchanged="tbID_TextChanged" AutoPostBack="True" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbID" CssClass="rightWithout" ErrorMessage="*" 
            ForeColor="Maroon" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
    </td>
    <td style="width:80px">
        <asp:Label ID="lblFile" runat="server" CssClass="rightWithout" Text="رقم الملف"></asp:Label>
    </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbName" runat="server" CssClass="tb7" ReadOnly="True" 
                    Width="200px"></asp:TextBox>
            </td>
            <td style="width:80px">
                <asp:Label ID="lblName" runat="server" CssClass="rightWithout" 
                    Text="اسم المشتركة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnShow" runat="server" CssClass="myButton" Text="عرض" 
                    onclick="btnShow_Click" />
                <asp:Label ID="lblError" runat="server" CssClass="rightWithout" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td style="width:80px">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="pnlSub" runat="server" GroupingText="الإشتراكات" Visible="False">
        <asp:GridView ID="gvSubs" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="rightWithout" ForeColor="#333333" GridLines="None" 
            Width="100%" 
            onrowdatabound="gvSubs_RowDataBound" 
            onselectedindexchanged="gvSubs_SelectedIndexChanged" PageSize="50" 
            onrowdeleting="gvSubs_RowDeleting">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                <asp:CommandField SelectText="عرض تفاصيل" ShowSelectButton="True">
                <ItemStyle Width="100px" />
                </asp:CommandField>
                <asp:BoundField DataField="DaysLeft" HeaderText="الزيارات المتبقية" />
                <asp:BoundField DataField="ServiceName" HeaderText="الإشتراك" />
                <asp:BoundField DataField="SubDate" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="تاريخ الإشتراك" />
                <asp:BoundField DataField="SubID" HeaderText="رقم الاشتراك" />
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
        <asp:Label ID="lblNoData" runat="server" ForeColor="Maroon" 
            CssClass="rightWithout"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlSubDetails" runat="server" Visible="false" 
            GroupingText="تفاصيل الإشتراك والزيارات">
    
        <asp:FormView ID="fvDetails" runat="server" Width="100%" BackColor="White" 
            BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
            CellSpacing="1" onitemcommand="fvDetails_ItemCommand">
            <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <ItemTemplate>
                <asp:Label ID="label1" runat="server" Text="الإشتراك" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="SubIDLabel" runat="server" CssClass="rightWithout" Text='<%# Eval("ServiceName") %>' />
                <br />
                <br />
                <asp:Label ID="label2" runat="server" Text="تاريخ الإشتراك" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="DateLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("SubDate","{0:dd/MM/yyyy}") %>' />
                <br />
                <br />
                <asp:Label ID="label3" runat="server" Text="مجموع الأيام" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="ClientIDLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("TotalDays") %>' />
                <br />
                <br />
                <asp:Label ID="label4" runat="server" Text="الحضور" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="ServiceIDLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("AttDays") %>' />
                <br />
                <br />
                <asp:Label ID="label5" runat="server" Text="الأيام المتبقية" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="SubDaysLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("LeftDays") %>' />
                <br />
                <br />
                <asp:Label ID="label8" runat="server" Text="القياسات" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="MeasurementsLabel" runat="server"  CssClass="rightWithout"
                    Text='<%# Bind("Measurements") %>' />
                <br /><br />
                <asp:Label ID="label9" runat="server" Text="التشخيص" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="DiagnosisLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("Diagnosis") %>' />
                <br /><br />    
                 <asp:Label ID="label10" runat="server" Text="التاريخ" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="HistoryLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("History") %>' />
                <br /><br />    
                <asp:Panel ID="pnlInt" runat="server" Visible="false">
                <asp:Label ID="label6" runat="server" Text="ضغط الدم" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="AttDaysLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("BPressure") %>' />
                <br /><br />
                <asp:Label ID="label7" runat="server" Text="سكر الدم" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="LeftDaysLabel" runat="server" CssClass="rightWithout" Text='<%# Bind("BSugar") %>' />
                <br /><br />
                </asp:Panel>


                <asp:Panel ID="pnlNut" runat="server" Visible="false">
                <asp:Label ID="label15" runat="server" Text="الطول" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="Label16" runat="server" CssClass="rightWithout" Text='<%# Bind("Hieght") %>' />
                <br /><br />
                <asp:Label ID="label17" runat="server" Text="الوزن" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="Label18" runat="server" CssClass="rightWithout" Text='<%# Bind("Weight") %>' />
                <br /><br />
                <asp:Label ID="label19" runat="server" Text="الدهون" CssClass="rightWithout" Width="150"/>
                <asp:Label ID="Label20" runat="server" CssClass="rightWithout" Text='<%# Bind("Fat") %>' />
                <asp:Label ID="label21" runat="server" Text="%" CssClass="rightWithout"/>
                <br /><br />
                </asp:Panel>
                 <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="تعديل" />
            </ItemTemplate>
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        </asp:FormView>
        <hr />
    <h3 class="rightWithout">جدول الزيارات</h3>
        <br />
        <br />
        <asp:GridView ID="gvVisits" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="rightWithout" DataKeyNames="VisitID" DataSourceID="EntityDataSource1" 
            ForeColor="#333333" GridLines="None" ondatabound="gvVisits_DataBound" 
            Width="100%" PageSize="50" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField DeleteText="حذف الجلسة" ShowDeleteButton="True" />
                <asp:BoundField DataField="SizeAfter" HeaderText="القياس بعد الجلسة" 
                    SortExpression="SizeAfter" />
                <asp:BoundField DataField="SizeBefore" HeaderText="القياس قبل الجلسة" 
                    SortExpression="SizeBefore" />
                <asp:BoundField DataField="SigninTime" HeaderText="الوقت" 
                    SortExpression="SigninTime" />
                <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="التاريخ" SortExpression="Date" />
                 <asp:BoundField DataField="VisitID" HeaderText="المعرف" 
                    SortExpression="VisitID" />
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
        <asp:Label ID="lblNo" runat="server" Text="" ForeColor="Maroon" CssClass="rightWithout"></asp:Label>
        <asp:Button ID="btnPrint" runat="server" CssClass="myButton" Text="طباعة" 
            onclick="btnPrint_Click" />
        <asp:Button ID="btnVisit" runat="server" Text="إضافة زيارة" CssClass="myButton" 
            onclick="btnVisit_Click" />
       
        
        <br />
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=ClubDBEntities" DefaultContainerName="ClubDBEntities" 
            EnableFlattening="False" EntitySetName="Visits" Where="" 
            EnableDelete="True">
        </asp:EntityDataSource>
    </asp:Panel>

    <asp:Panel ID="pnlVisit" runat="server" Visible="False">
    <table width="100%">
    <tr>
    <td>
        <asp:TextBox ID="tbBefore" runat="server" CssClass="tb7"></asp:TextBox>
        </td>
    <td style="width:100px">
        <asp:Label ID="lblBefore" runat="server" Text="القياس قبل الجلسة" CssClass="rightWithout"></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbAfter" runat="server" CssClass="tb7"></asp:TextBox>
            </td>
            <td style="width:100px">
                <asp:Label ID="lblAfter" runat="server" CssClass="rightWithout" 
                    Text="القياس بعد الجلسة"></asp:Label>
            </td>
           
        </tr>
         <tr>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="إلغاء" 
                        onclick="btnCancel_Click" />
                    <asp:Button ID="btnAdd" runat="server" CssClass="myButton" 
                        onclick="btnAdd_Click" Text="إضافة" />
                </td>
                <td style="width:100px">
                   </td>
            </tr>
    </table>
    
    </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
