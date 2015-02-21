<%@ Page Title="Orders" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="PizzaDelivery01.Administration.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 background-plate">
		<h4>Orders</h4>
		<table class="table table-striped no-margin">
			<thead>
				<tr>
					<th>#</th>
					<th>ID</th>
					<th>Date</th>
					<th>Name</th>
					<th>Phone</th>
					<th>Address</th>
					<th>Status</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
                <asp:ListView ID="lstOrders" ItemType="PizzaDelivery01.Entity.Order" runat="server" SelectMethod="getAllOrders">
                    <ItemTemplate>
                        <tr>
					        <td><%# Container.DataItemIndex + 1 %></td>
					        <td><%# Item.id %></td>
					        <td><%# Item.getFormattedDate("yyyy.MM.dd HH:mm:ss") %></td>
					        <td><%# Item.name %></td>
					        <td><%# Item.phone %></td>
					        <td><%# Item.address %></td>
					        <td><%# Item.getFormattedStatus() %></td>
					        <td><a href="/Administration/OrderDetails?id=<%# Item.id %>" class="btn btn-xs btn-default">View</a></td>
				        </tr>
                    </ItemTemplate>
                </asp:ListView>
			</tbody>
		</table>
	</div>
</asp:Content>
