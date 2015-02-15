<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaDelivery01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<ul>
        <asp:ListView runat="server" ID="productList" ItemType="PizzaDelivery01.Entity.Product" SelectMethod="GetProducts">
            <ItemTemplate>
                <li><%#: Item.id %> - <%#: Item.name %></li>
            </ItemTemplate>
        </asp:ListView>
    </ul>--%>
    <!-- view placeholder -->
	<div ng-view></div>
</asp:Content>
