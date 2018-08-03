<%@ Page Title="t_house" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="myhouse.Web.House.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="hid" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="cid" HeaderText="cid" SortExpression="cid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="sid" HeaderText="sid" SortExpression="sid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hname" HeaderText="hname" SortExpression="hname" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hdescription" HeaderText="hdescription" SortExpression="hdescription" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hmoney" HeaderText="hmoney" SortExpression="hmoney" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="htype" HeaderText="htype" SortExpression="htype" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hphotoone" HeaderText="hphotoone" SortExpression="hphotoone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hphototwo" HeaderText="hphototwo" SortExpression="hphototwo" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hphotothree" HeaderText="hphotothree" SortExpression="hphotothree" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hphotofour" HeaderText="hphotofour" SortExpression="hphotofour" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hfloor" HeaderText="hfloor" SortExpression="hfloor" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hsize" HeaderText="hsize" SortExpression="hsize" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="harea" HeaderText="harea" SortExpression="harea" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hcommunity" HeaderText="hcommunity" SortExpression="hcommunity" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hadress" HeaderText="hadress" SortExpression="hadress" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="htime" HeaderText="htime" SortExpression="htime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hmode" HeaderText="hmode" SortExpression="hmode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hstatus" HeaderText="hstatus" SortExpression="hstatus" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="hid" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="hid" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
