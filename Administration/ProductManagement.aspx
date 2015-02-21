<%@ Page Title="Product management" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="PizzaDelivery01.Administration.ProductManagement" %>
<%@ Import Namespace="Microsoft.Owin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
	    <div class="col-sm-12 background-plate">
		    <h4>Product management</h4>
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
            <asp:FormView ID="productForm" runat="server" ItemType="PizzaDelivery01.Entity.Product" SelectMethod="getProductById" RenderOuterTable="false">
                <ItemTemplate>
                    <div class="form-group">
			            <label>ID</label>
                        <asp:TextBox ID="productId" runat="server" CssClass="form-control" value="<%#: Item.id %>" disabled></asp:TextBox>
		            </div>
		            <div class="form-group">
			            <label>Name</label>
                        <asp:TextBox ID="productName" runat="server" CssClass="form-control" value="<%#: Item.name %>"></asp:TextBox>
		            </div>
		            <div class="form-group">
			            <label>Description</label>
                        <asp:TextBox ID="productDescription" runat="server" CssClass="form-control" value="<%#: Item.description %>"></asp:TextBox>
		            </div>
		            <div class="form-group">
			            <label>Size, sm</label>
                        <asp:TextBox ID="ProductSize" runat="server" CssClass="form-control" value="<%#: Item.size %>"></asp:TextBox>
		            </div>
		            <div class="form-group">
			            <label>Weight, g</label>
                        <asp:TextBox ID="productWeight" runat="server" CssClass="form-control" value="<%#: Item.weight %>"></asp:TextBox>
		            </div>
		            <div class="form-group">
			            <label>Price, $</label>
                        <asp:TextBox ID="productPrice" runat="server" CssClass="form-control" value="<%#: Item.price %>"></asp:TextBox>
		            </div>
		            <div class="row">
			            <div class="col-sm-4">
				            <a runat="server" href="~/Administration/Products" class="btn btn-default full-width"><b>Back to Products</b></a>
			            </div>
			            <div class="col-sm-4">
			                <asp:Button runat="server" ID="updateProductBtn"  Text="Save" CssClass="btn btn-success text-bold full-width" OnClick="createUpdateProduct_Click"/>
			            </div>
			            <div class="col-sm-4">
			                <asp:Button runat="server" ID="deleteProductBtn"  Text="Delete" CssClass="btn btn-warning text-bold full-width" OnClick="deleteProduct_Click"/>
			            </div>
		            </div>
                </ItemTemplate>
            </asp:FormView>
	    </div>
    </div>
</asp:Content>
