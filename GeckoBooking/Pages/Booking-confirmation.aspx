<%@ Page Title="Booking Confirmation" MasterPageFile="~/SiteMasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="Booking-confirmation.aspx.cs" Inherits="GeckoBooking.Booking_confirmation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 id="headerText">New booking was added!</h1>
    <br/>
    <asp:Label ID="LabelBooked" runat="server" Text=""></asp:Label>
    <asp:Label ID="LabelSessions" runat="server"></asp:Label>
            
       
</asp:Content>

