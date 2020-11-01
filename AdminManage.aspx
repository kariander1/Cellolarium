<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminManage.aspx.cs" Inherits="AdminManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h3>משתמשים</h3>

    <br />
    <table cellpadding="0" cellpadding="1" border="0">
        <tr>
            <th colspan="2">חפש משתמשים</th>
        </tr>
        <tr>
            <td>שם</td>
            <td><input type="text" name="Fn" /></td>
        </tr>
        <tr>
            <td>שם משפחה</td>
            <td><input type="text" name="Ln" /></td>
        </tr>
    </table>
    מיין על פי:
    <select id="sort" name="sort" >
        <option  value="none" selected="selected">בחר...</option>
        <option  value="name">שם</option>
        <option  value="last">שם משפחה</option>
        <option  value="date">תאריך הצטרפות</option>

    </select>
    בסדר:
    <input type="radio" name="ord" value="up" checked="checked"/>עולה
    
    <input type="radio" name="ord" value="down"/>יורד
    
    <button name="do">בצע</button>
    <div style="overflow:auto; font-size:15px; letter-spacing:0px;" >
        <%=showUsers %>
    </div>  
</asp:Content>

