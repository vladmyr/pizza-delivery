<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PizzaDelivery01.Checkout.CheckoutStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-sm-12 background-plate">
            <h4>Products</h4>
            <table class="table table-striped no-margin">
			<thead>
				<tr>
					<th>#</th>
					<th>ID</th>
					<th>Name</th>
					<th>Description</th>
					<th>Size</th>
					<th>Weight</th>
					<th>Price</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
			    <asp:ListView ID="lstProduct" ItemType="PizzaDelivery01.Entity.Product" runat="server" SelectMethod="getAllProducts">
			        <ItemTemplate>
			            <tr>
					        <td><%# Container.DataItemIndex + 1 %></td>
					        <td><%# Item.id %></td>
					        <td><%# Item.name %></td>
					        <td><%# Item.description %></td>
					        <td><%# Item.size %>sm</td>
					        <td><%# Item.weight %>g</td>
					        <td>$<%# Item.price %></td>
					        <td><a href="/Administration/ProductManagement?id=<%#: Item.id %>" class="btn btn-sm btn-default">View</a></td>
				        </tr>   
			        </ItemTemplate>
			    </asp:ListView>
			</tbody>
		</table>
        </div>
    </div>
</asp:Content>
