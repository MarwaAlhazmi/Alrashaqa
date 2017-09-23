<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Control.aspx.cs" Inherits="ClubWebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 493px;
        }
        .style3
        {
            width: 295px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table width="100%" >
<tr>
<td style="width:30%" class="withBorder">
<table width="100%">
<tr>
<td class="style2">
 <img id="img2" src="../Styles/img/padlock_locked.png" alt="" class="right" /></td>
<td class="style3">
<a href="" class="bottom_link" 
                            
        style="line-height:300%;margin-left:10px;color:#e9727a; font-size:35px;"> حسابات المستخدمين</a>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="style2">&nbsp;</td>
<td class="style3">
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li></li>
					<li><img src="../Styles/img/arrow.png" class="arrow" alt="" /><a href="Register.aspx" class="bottom_link" style="font-size:larger" >تسجيل مستخدم جديد</a></li>
					<li><img src="../Styles/img/arrow.png" class="arrow" alt="" /><a href="ChangePass.aspx" class="bottom_link" style="font-size:larger">تغيير كلمة المرور لمستخدم</a></li>

					<li><img src="../Styles/img/arrow.png" class="arrow" alt="" /><a href="ChangeRole.aspx" class="bottom_link" style="font-size:larger">تغيير وظيفة مستخدم</a></li>
				</ul>
		</div>
    </td>
<td>
    &nbsp;</td>
</tr>
</table>
 &nbsp;</td>
</tr>
</table>
   
</asp:Content>
