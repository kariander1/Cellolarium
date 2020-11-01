<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registraion.aspx.cs" Inherits="Registraion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="5" cellspacing="5">
         <tr>
            <td>תעודת זהות:</td>
            <td><input type="text" name="id"/></td>
           
        </tr>
        <tr>
            <td>שם:</td>
            <td><input type="text" name="first" /></td>
           
        </tr>
        <tr>
            <td>שם משפחה:</td>
            <td><input type="text" name="last" /></td>
            
        </tr>
        <tr>
            <td>סיסמא:</td>
            <td><input type="password" name="pass"  /></td>
        </tr>
        <tr>
            <td>אימות סיסמא:</td>
            <td><input type="password" name="checkpass"  /></td>
        </tr>
        <tr>
            <td>אימייל:</td>
            <td><input type="text" name="mail" /></td>
        </tr>
        <tr>
            <td>מין:</td>
            <td><input type="radio" name="gender" value="זכר"  checked="checked"/>זכר<input type="radio" name="gender" value="נקבה"/>נקבה</td>
            <td>בקשות מיוחדות:</td>
        </tr>
        <tr>
            <td>תוכניות אהובות:</td>
            <td><input type="checkbox" name="sel" value="פוקימון"/>פוקימון</td>
            <td rowspan="4">
                <textarea name="req" cols="25" rows="7">
                </textarea>
                </td>
        </tr>
        <tr>
            <td></td>
            <td><input type="checkbox" name="sel"value="דרגון בול זי" />דרגון בול זי</td>
        </tr>
        <tr>
            <td></td>
            <td><input type="checkbox" name="sel" value="איך פגשתי את אימא"/>איך פגשתי את אימא</td>
        </tr>
        <tr>
            <td></td>
            <td><input type="checkbox" name="sel" value="שנות ה-70"/>שנות ה-70</td>
        </tr>
        <tr align="center">
            <td colspan="3"><input type="submit" name="sub" value="שלח" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<input type="reset" value="נקה" /></td>
        </tr>
    </table>
    <div class="ok">
        <%=msg %>
    </div>
</asp:Content>

