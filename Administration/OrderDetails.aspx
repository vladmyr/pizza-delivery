<%@ Page Title="Order #" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="PizzaDelivery01.Administration.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
	<div class="col-sm-12 background-plate">
		<h4>Order</h4>
        <asp:FormView ID="orderForm" runat="server" ItemType="PizzaDelivery01.Entity.Order" SelectMethod="getOrderById" RenderOuterTable="false">
            <ItemTemplate>
			    <dl class="dl-horizontal">
			            <dt>ID</dt>
				        <dd><%# Item.id %></dd>
				        <dt>Date</dt>
				        <dd><%# Item.getFormattedDate("yyyy.MM.dd HH:mm:ss") %></dd>
				        <dt>Name</dt>
				        <dd><%# Item.name %></dd>
				        <dt>Phone</dt>
				        <dd><%# Item.phone %></dd>
				        <dt>Address</dt>
				        <dd><%# Item.address %></dd>
				        <dt>Status</dt>
				        <dd><%# Item.getFormattedStatus() %></dd>
			    </dl>
			    <table class="table table-hover cart-products">
				    <thead>
					    <tr>
						    <th>#</th>
						    <th>ID</th>
						    <th>Name</th>
						    <th>Quantity</th>
					    </tr>
				    </thead>
				    <tbody>
				        <asp:ListView ID="orderItems" ItemType="PizzaDelivery01.Entity.OrderItem" runat="server" DataSource="<%# Item.OrderItems %>">
				            <ItemTemplate>
				                <tr>
						            <td>
						                <%# Container.DataItemIndex + 1 %>
						            </td>
						            <td>
							            <%# Item.id %>
						            </td>
						            <td>
							            <%# getProductById(Item.productId).name %>
						            </td>
						            <td>
							            <%# Item.quantity %>
						            </td>
					            </tr>
				            </ItemTemplate>
                        </asp:ListView>
				    </tbody>
			    </table>
		        <div class="row">
			        <div class="col-sm-3">
				        <a runat="server" href="~/Administration/Orders" type="button" class="btn btn-default btn-product-to-cart"><b>Back to Orders</b></a>
			        </div>
			        <div class="col-sm-9">
			            <asp:PlaceHolder runat="server" ID="isCompleted" Visible="<%# !Item.isCompleted %>">
			                <asp:Button runat="server" CssClass="btn btn-success btn-product-to-cart text-bold" Text="Completed" OnClick="statusCompleted_Click"/>
			            </asp:PlaceHolder>
			        </div>
		        </div>
            </ItemTemplate>
        </asp:FormView>
	</div>
</div>
</asp:Content>
