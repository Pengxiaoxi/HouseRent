<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="myhouse.Web.House.Modify" Title="修改页" %>
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
		<asp:label id="lblhid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		cid
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblcid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uid
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lbluid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		sid
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblsid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hname
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthname" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hdescription
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthdescription" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hmoney
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthmoney" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		htype
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthtype" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotoone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthphotoone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphototwo
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthphototwo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotothree
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthphotothree" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hphotofour
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthphotofour" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hfloor
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthfloor" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hsize
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthsize" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		harea
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtharea" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hcommunity
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthcommunity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hadress
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthadress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		htime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txthtime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hmode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthmode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hstatus
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txthstatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

