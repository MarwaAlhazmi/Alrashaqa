<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceSearch.aspx.cs" Inherits="ClubWebApp.InvoiceSearch" %>

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
                    
                <img id="img1" src="Styles/img/ajax-loader(4).gif" alt="" />
                </ProgressTemplate>
                </asp:UpdateProgress>
    </td>
    <td>
    <h2 class="right">تقارير الدخل</h2>
    </td>
    </tr>
    </table>
    
        <asp:Panel ID="pnlSearch" runat="server" GroupingText="معايير البحث">
        <asp:Panel ID="pnlSub" runat="server" GroupingText = "القسم">
        
        </asp:Panel>
        <table width="100%">
        <tr>
        <td >
        <asp:Label ID="lblDateTo" runat="server" Text="إلى تاريخ" CssClass="rightWithout" />
            <asp:TextBox ID="tbDateTo" runat="server" CssClass="tb7"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="tbDateTo_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="tbDateTo">
            </ajaxToolkit:CalendarExtender>
        </td>
        <td>
            <asp:Label ID="lblDateFrom" runat="server" Text="من تاريخ" CssClass="rightWithout" />
            <asp:TextBox ID="tbDateFrom" runat="server" CssClass="tb7"></asp:TextBox>
            
            <ajaxToolkit:CalendarExtender ID="tbDateFrom_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="tbDateFrom">
            </ajaxToolkit:CalendarExtender>
            
            </td>

        </table>
        <hr />
        <table width="100%">
              
            <tr>
                <td class="style2">
                    <asp:CheckBox ID="cbDoc" runat="server" CssClass="rightWithout" 
                        Text="المدربة / الدكتورة" TextAlign="Left" AutoPostBack="True" 
                        oncheckedchanged="cbDoc_CheckedChanged" />
                    <asp:DropDownList ID="ddlDoc" runat="server" CssClass="tb7" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox ID="cbDep" runat="server" CssClass="rightWithout" Text="القسم" 
                        TextAlign="Left" AutoPostBack="True" 
                        oncheckedchanged="cbDep_CheckedChanged" />
                    <asp:DropDownList ID="ddlDep" runat="server" CssClass="tb7" Enabled="False" 
                        AppendDataBoundItems="True" AutoPostBack="True" 
                        onselectedindexchanged="ddlDep_SelectedIndexChanged">
                        <asp:ListItem>...</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="btnSearch" runat="server" CssClass="myButton" Text="بحث" />
                </td>
                <td>
                    <asp:RadioButtonList ID="rbType" runat="server" CssClass="right" 
                        TextAlign="Left">
                        <asp:ListItem Selected="True">كل</asp:ListItem>
                        <asp:ListItem>الفواتير</asp:ListItem>
                        <asp:ListItem>سندات الصرف</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>

        </asp:Panel>



    <br />
    <br />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">

</asp:Content>

