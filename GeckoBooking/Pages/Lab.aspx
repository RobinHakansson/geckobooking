<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="GeckoBooking.Lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Theme/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="../Theme/StyleSheet.css" type="text/css" />
    <script type="text/javascript" src="../JavaScript/Datepicker-v1.js"></script>
    <script type="text/javascript">
        function setDate() {
            $("#datepicker").datepicker("setDate", new Date($(".date").val()));

            //$("form").submit();
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
    <%--<div id="pass-test-box">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Encode" OnClick="Button1_Click" />

        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="WRONG!" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>

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
    </div>--%>

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div id="booking-test-box">
                    <p>Enter a date or select one from below</p>
                    <br />
                    <div id="left-box">
                        <span class="vertline-center">Date:</span>
                        <asp:TextBox ID="TextBox2" runat="server" onchange="javascript: setDate();" CssClass="date"></asp:TextBox>
                        <img id="calendar-icon" alt="Show calendar" src="../Theme/Images/calendar-22x21.png" class="vertline-center" />
                        <asp:Button ID="Button1" runat="server" Text="Show available sessions" CssClass="bookingButton" OnClick="Button1_OnClick" />
                        <br />
                        <div id="datepicker" style="display: none"></div>
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <%--<div id="right-box">
                <div id="image-box">
                    <h1 class="center">Images..</h1>
                </div>
            </div>--%>
                <div class="thumbnail">
                    <img src="../Theme/Images/hk-badm.jpg" alt="HK badminton" />
                    <p>  B = badminton</p>
                </div>
            </div>

            <div class="col-md-3">
                <div class="thumbnail">
                    <img alt="HK tennis" src="../Theme/Images/hk-tennis.jpg" />
                    <p>T = tennis</p>
                </div>
            </div>
        </div>
    </div>

    <h2>Courts for booking</h2>
    <div id="booking-box">

        <asp:Button ID="Button2" runat="server" Text="Test: Check if checked ^.^" OnClick="Button2_OnClick" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label5" runat="server" CssClass="selectedDateText"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SessionTime" HeaderText="Time" />
                </Columns>
            </asp:GridView>--%>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="CurrentDateLabel" runat="server" CssClass="selectedDateText"></asp:Label>
                <asp:Table ID="Table1" runat="server" CssClass="bookingTable"></asp:Table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>

        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <img src="../Theme/Images/ajax-loader.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>

</asp:Content>
