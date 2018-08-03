<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="myhouse.Web.Worker.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		wid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wname
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wsex
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwsex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wphoto
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwphoto" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wcard
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwcard" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wpassword
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwpassword" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wtel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwtel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wemail
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwemail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wadress
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwadress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		wtype
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwtype" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




