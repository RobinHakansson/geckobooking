﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="GeckoBooking.Lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="../Theme/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="../Theme/StyleSheet.css" type="text/css" />--%>
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
    
    <ul>
        <li class="sub-menu-item"><a href="Lab.aspx"><h4>Booking</h4></a></li>
        <li class="sub-menu-item"><a href="MyPage.aspx"><h4>MyPage</h4></a></li>
    </ul>
    <br/>

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

                        <br />
                        <div id="datepicker" style="display: none"></div>
                        <asp:Button ID="Button1" runat="server" Text="Show available sessions" CssClass="bookingButton" OnClick="Button1_OnClick" />
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
                    <p>B = badminton</p>
                </div>
            </div>

            <div class="col-md-3">
                <div class="thumbnail">
                    <img alt="HK tennis" src="../Theme/Images/tennisprince.jpg" />
                    <p>T = tennis</p>
                </div>
            </div>
        </div>
    </div>

    <h2>Courts for booking</h2>
    <div id="booking-box">
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="CurrentDateLabel" runat="server" CssClass="selectedDateText"></asp:Label>
                    <br/>
                    <asp:Table ID="Table1" runat="server" CssClass="bookingTable"></asp:Table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ConfirmBooking" EventName="Click" />
                </Triggers>

            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Theme/Images/ajax-loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>

        <div class="col-md-6">
            <%--<div id="confirm-box">--%>
            
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="ConfirmBox" runat="server" CssClass="confirm-box" Visible="False">
                        <asp:Label ID="Label6" runat="server" Text="Your Selections" CssClass="selectedSessionText"></asp:Label>
                        <br />
                        <asp:Button ID="ConfirmBooking" runat="server" Text="Confirm booking" OnClick="ConfirmBooking_OnClick" Enabled="False" Visible="False" CssClass="btnDisable" />
                    </asp:Panel>
                            </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            

            <%--</div>--%>
        </div>
    </div>
</asp:Content>
