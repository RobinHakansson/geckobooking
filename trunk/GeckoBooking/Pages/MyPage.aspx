﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="GeckoBooking.Pages.MyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="UserName" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Table ID="MyBookingsTable" runat="server" CssClass="myBookingsTable"></asp:Table>
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Cancel" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="Cancel" runat="server" Text="Remove" OnClick="CancelSession_OnClick" />
</asp:Content>
