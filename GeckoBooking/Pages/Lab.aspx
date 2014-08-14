<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="GeckoBooking.Lab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" src="../JavaScript/Datepicker-v1.js"></script>
    <script type="text/javascript">
        function setDate() {
            $("#datepicker").datepicker("setDate", new Date($(".date").val()));
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#calendar-icon").click(function () {
                $("#datepicker").toggle({
                    duration: 600
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pass-test-box">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <%--<asp:Button ID="Button1" runat="server" Text="Encode" OnClick="Button1_Click" />--%>

        <br />
        <%--<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="WRONG!" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>--%>
        
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>

    <div id="booking-test-box">
        <div id="left-box">
            <span class="vertline-center">Date:</span> 
            <asp:TextBox ID="TextBox2" runat="server" Text="2014-08-05" onchange="javascript: setDate();" CssClass="date"></asp:TextBox>
            <img id="calendar-icon" alt="Show calendar" src="../Theme/Images/calendar-22x21.png" class="vertline-center" />
            <br />
            <div id="datepicker"></div>
            <p>Test</p>
            
        </div>

        <div id="right-box">
            <div id="image-box">
                <h1 class="center">Images..</h1>
            </div>
        </div>

        <div id="booking-box">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>

    </div>
</asp:Content>
