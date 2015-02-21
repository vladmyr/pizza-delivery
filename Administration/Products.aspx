<%@ Page Title="Products" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PizzaDelivery01.Checkout.CheckoutStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-sm-12 background-plate">
            <div class="row">
                <div class="col-sm-10">
                    <h4>Products</h4>
                </div>
                <div class="col-sm-2">
                    <a runat="server" href="~/Administration/ProductManagement" class="margin-15-0 btn btn-xs btn-success full-width text-bold">New product</a>
                </div>
            </div>            
            <asp:PlaceHolder runat="server" ID="SuccessMessage" Visible="false">
                <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <p class="text-success">
                        <asp:Literal runat="server" ID="SuccessText" />
                    </p>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <div class="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </div>
            </asp:PlaceHolder>
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
					        <td><a href="/Administration/ProductManagement?id=<%#: Item.id %>" class="btn btn-xs btn-default">View</a></td>
				        </tr>   
			        </ItemTemplate>
			    </asp:ListView>
			</tbody>
		</table>
        </div>
    </div>
</asp:Content>
