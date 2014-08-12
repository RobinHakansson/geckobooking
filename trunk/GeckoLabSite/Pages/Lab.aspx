<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Lab.aspx.cs" Inherits="Pages_Lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JavaScript/Datepicker-v1.js"></script>
    <script type="text/javascript">
        function setDate() {
            $("#datepicker").datepicker("setDate", new Date($("#date").val()));
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="pass-test-box">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Encode" OnClick="Button1_Click" />

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
            <input type="text" id="date" class="vertline-center" size="30" onchange="setDate()" />
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


        </div>

    </div>
</asp:Content>

