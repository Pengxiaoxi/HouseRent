<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="myhouse.Web.House.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		hid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		cid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		sid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hname
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hdescription
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhdescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hmoney
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhmoney" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		htype
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhtype" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotoone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhphotoone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphototwo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhphototwo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotothree
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhphotothree" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotofour
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhphotofour" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hfloor
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhfloor" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hsize
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhsize" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		harea
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblharea" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hcommunity
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhcommunity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hadress
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhadress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		htime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hmode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhmode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hstatus
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhstatus" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




