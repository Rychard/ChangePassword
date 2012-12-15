<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChangePassword.Default" %>


<%@ Register TagPrefix="SHEARER" TagName="ChangePassword" Src="ChangePassword.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="panelSuccess" Visible="False">
            <p style="color:green">Your password has been changed!</p>    
        </asp:Panel>
        <asp:Panel runat="server" ID="panelChangePassword">
            <SHEARER:ChangePassword runat="server" ID="ChangePasswordControl" />    
        </asp:Panel>
    </div>
    </form>
</body>
</html>
