<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ClubWebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table id="AdminTable" width="100%" runat="server" visible="false">
<tr>
<td style="width:30%; height:354px;" class="withBorder">
 <div>
 <img id="img3" src="Styles/img/create_new_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الفواتير</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Invoice.aspx" class="bottom_link" style="font-size:larger" >انشاء فاتورة</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="BrowseInvoice.aspx" class="bottom_link" style="font-size:larger">استعراض فاتورة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DeptInvoices.aspx" class="bottom_link" style="font-size:larger" >فواتير غير مدفوعة</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="IncompleteInvoice.aspx" class="bottom_link" style="font-size:larger">طلبات الفواتير</a></li>
				</ul>
		</div>
 </div>
 <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img2" src="Styles/img/computer_monitor.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الاشتراكات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="AddSub.aspx" class="bottom_link" style="font-size:larger" >إضافة اشتراك</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">تعديل اشتراك</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">إضافة زيارة</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img1" src="Styles/img/create_new_folder.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الملفات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="NewMember.aspx" class="bottom_link" style="font-size:larger">إضافة ملف</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Search.aspx" class="bottom_link" style="font-size:larger">البحث عن ملف</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="CurrentMembers.aspx" class="bottom_link" style="font-size:larger">الزوار الحاليين</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
</tr>

<tr>
<td style="width:30%; height:354px;" class="withBorder">
 <div>
 <img id="img4" src="Styles/img/application.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">سندات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Withdraw.aspx" class="bottom_link" style="font-size:larger" >سند صرف</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Deposit.aspx" class="bottom_link" style="font-size:larger" >سند قبض</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="BrowseWith.aspx" class="bottom_link" style="font-size:larger">استعراض سندات الصرف</a></li>
				</ul>
		</div>
 </div>
 <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img5" src="Styles/img/chart.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">تقارير</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Movement.aspx" class="bottom_link" style="font-size:larger" >حركة الحسابات اليومية</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="BalanceMov.aspx" class="bottom_link" style="font-size:larger" >حركة حسابات البوفيه</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="BalanceMov.aspx?show=1" class="bottom_link" style="font-size:larger" >عرض حركة حسابات البوفيه</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Expenses.aspx" class="bottom_link" style="font-size:larger">مصروفات المركز</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Income.aspx" class="bottom_link" style="font-size:larger">إيرادات المركز</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img6" src="Styles/img/view_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">العيادات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DietSystem.aspx" class="bottom_link" style="font-size:larger">انظمة غذائية</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DischargeForm.aspx" class="bottom_link" style="font-size:larger">ملخص خروج من قسم علاج طبيعي</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="EvaluationSheet.aspx" class="bottom_link" style="font-size:larger">نموذج تقييم حالة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequest.aspx" class="bottom_link" style="font-size:larger">طلب علاج طبيعي</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
</tr>

<tr>
<td style="width:30%; height:354px;" class="withBorder">
 <div>
 <img id="img7" src="Styles/img/view_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">العيادات - استعراض</a></li>
					<li style="height: 24px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DischargeForm.aspx?show=1" class="bottom_link" style="font-size:larger">عرض ملخص خروج - علاج طبيعي</a></li>
					<li style="height: 23px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="EvaluationSheet.aspx?show=1" class="bottom_link" style="font-size:larger">عرض نموذج تقييم حالة</a></li>
                    <li style="height: 24px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequest.aspx?show=1" class="bottom_link" style="font-size:larger">عرض طلب علاج طبيعي</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequestBrowse.aspx" class="bottom_link" style="font-size:larger">استعراض لطلبات العلاج الطبيعي</a></li>
				</ul>
		</div>
 </div>
 <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img8" src="Styles/img/padlock_locked.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">لوحة التحكم</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Account/Control.aspx" class="bottom_link" style="font-size:larger" >إدارة حسابات المستخدمين</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Add.aspx" class="bottom_link" style="font-size:larger" > إضافة معلومات للنظام</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Edit.aspx" class="bottom_link" style="font-size:larger">تحرير معلومات النظام </a></li>

				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 
  <br /><br /><br />
</td>
</tr>
</table>
<br />  
<table id="RecepTable" width="100%" runat="server" visible="false">
<tr>
<td style="width:30%; height:354px;" class="withBorder">
 <div>
 <img id="img9" src="Styles/img/create_new_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الفواتير</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Invoice.aspx" class="bottom_link" style="font-size:larger" >انشاء فاتورة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Deposit.aspx" class="bottom_link" style="font-size:larger" >سند قبض</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="BrowseInvoice.aspx" class="bottom_link" style="font-size:larger">استعراض فاتورة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DeptInvoices.aspx" class="bottom_link" style="font-size:larger" >فواتير غير مدفوعة</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="IncompleteInvoice.aspx" class="bottom_link" style="font-size:larger">طلبات الفواتير</a></li>
				</ul>
		</div>
 </div>
 <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img10" src="Styles/img/computer_monitor.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الاشتراكات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="AddSub.aspx" class="bottom_link" style="font-size:larger" >إضافة اشتراك</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">تعديل اشتراك</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">إضافة زيارة</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img11" src="Styles/img/create_new_folder.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الملفات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="NewMember.aspx" class="bottom_link" style="font-size:larger">إضافة ملف</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Search.aspx" class="bottom_link" style="font-size:larger">البحث عن ملف</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="CurrentMembers.aspx" class="bottom_link" style="font-size:larger">الزوار الحاليين</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
</tr>

</table>
<br />
<table id="PhysicalTable" width="100%" runat="server" visible="false">
<tr>
<td style="width:30%; height:354px;" class="withBorder">
 <div>
 <img id="img17" src="Styles/img/view_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">علاج طبيعي</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="EvaluationSheet.aspx" class="bottom_link" style="font-size:larger">نموذج تقييم حالة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DischargeForm.aspx" class="bottom_link" style="font-size:larger">ملخص خروج من قسم علاج طبيعي</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequestBrowse.aspx" class="bottom_link" style="font-size:larger">استعراض لطلبات العلاج الطبيعي</a></li>
                    <li style="height: 24px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DischargeForm.aspx?show=1" class="bottom_link" style="font-size:larger">عرض ملخص خروج - علاج طبيعي</a></li>
					<li style="height: 23px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="EvaluationSheet.aspx?show=1" class="bottom_link" style="font-size:larger">عرض نموذج تقييم حالة</a></li>                    
                    
                    
				</ul>
		</div>
 </div>

 <br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img13" src="Styles/img/computer_monitor.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الاشتراكات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="AddSub.aspx" class="bottom_link" style="font-size:larger" >إضافة اشتراك</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">تعديل اشتراك</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">إضافة زيارة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="InvoiceOrder.aspx" class="bottom_link" style="font-size:larger">طلب فاتورة</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img14" src="Styles/img/create_new_folder.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الملفات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="NewMember.aspx" class="bottom_link" style="font-size:larger">إضافة ملف</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Search.aspx" class="bottom_link" style="font-size:larger">البحث عن ملف</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="CurrentMembers.aspx" class="bottom_link" style="font-size:larger">الزوار الحاليين</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
</tr>

</table>
<br /> 
<table id="NutTabel" width="100%" runat="server" visible="false">
<tr>
<td style="width:30%; height:354px;" class="withBorder">
  <div>
 <img id="img20" src="Styles/img/view_page.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">تغذية</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="DietSystem.aspx" class="bottom_link" style="font-size:larger">انظمة غذائية</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequest.aspx" class="bottom_link" style="font-size:larger">طلب علاج طبيعي</a></li>
                    <li style="height: 24px"><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequest.aspx?show=1" class="bottom_link" style="font-size:larger">عرض طلب علاج طبيعي</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="PhysicalRequestBrowse.aspx" class="bottom_link" style="font-size:larger">استعراض لطلبات العلاج الطبيعي</a></li>
				</ul>
		</div>
 </div>
 <br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img15" src="Styles/img/computer_monitor.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الاشتراكات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="AddSub.aspx" class="bottom_link" style="font-size:larger" >إضافة اشتراك</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">تعديل اشتراك</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Visit.aspx" class="bottom_link" style="font-size:larger">إضافة زيارة</a></li>
                    <li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="InvoiceOrder.aspx" class="bottom_link" style="font-size:larger">طلب فاتورة</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
<td style="width:30%" class="withBorder">
 <div>
 <img id="img16" src="Styles/img/create_new_folder.png" alt="" />
   <div class="menu_bottom_list">
				<ul class="bottom_item">
					<li><a href="" class="bottom_link" style="line-height:300%;margin-left:10px;color:#e9727a; font-size:larger;">الملفات</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="NewMember.aspx" class="bottom_link" style="font-size:larger">إضافة ملف</a></li>
					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="Search.aspx" class="bottom_link" style="font-size:larger">البحث عن ملف</a></li>

					<li><img src="Styles/img/arrow.png" class="arrow" alt="" /><a href="CurrentMembers.aspx" class="bottom_link" style="font-size:larger">الزوار الحاليين</a></li>
				</ul>
		</div>
 </div>
  <br /><br /><br />
</td>
</tr>

</table>
<br />  
</asp:Content>
