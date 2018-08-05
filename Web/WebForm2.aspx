<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="myhouse.Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript" src="/MyAdmin/js/jquery-1.11.1.js"></script>

    <script type="text/javascript">
        function change(sex)
        {
            //alert(sex);
            $("#sex").val(sex);
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select style="width:auto;" name="sex" id="sex">
              <option value="男">男</option>
              <option value="女">女</option>
        </select>
        <input type="button" name="b1" onclick="change('女')" />
    </div>
    </form>
</body>
</html>
