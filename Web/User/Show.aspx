<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="myhouse.Web.User.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		uid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		unickname
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblunickname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uname
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		usex
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblusex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uphoto
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluphoto" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ucard
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblucard" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ucardphoto
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblucardphoto" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		upassword
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblupassword" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		utel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblutel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uqq
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluqq" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uemail
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluemail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uregtime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluregtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ucredit
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblucredit" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		utype
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblutype" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




