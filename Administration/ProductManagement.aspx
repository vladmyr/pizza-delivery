<%@ Page Title="Product management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="PizzaDelivery01.Administration.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" ng-controller="ProductManageController">
	    <div class="col-sm-12 background-plate">
		    <h4>Product management</h4>
            <asp:FormView ID="product" runat="server" ItemType="PizzaDelivery01.Entity.Product" SelectMethod="getProductById" RenderOuterTable="false">
                <ItemTemplate>
                    <div class="form-group">
			            <label>ID</label>
			            <input type="text" class="form-control" value="<%#: Item.id %>" disabled/>
		            </div>
		            <div class="form-group">
			            <label>Name</label>
			            <input type="text" class="form-control" value="<%#: Item.name %>"/>
		            </div>
		            <div class="form-group">
			            <label>Description</label>
			            <input type="text" class="form-control" value="<%#: Item.description %>"/>
		            </div>
		            <div class="form-group">
			            <label>Size, sm</label>
			            <input type="text" class="form-control" value="<%#: Item.size %>"/>
		            </div>
		            <div class="form-group">
			            <label>Weight, g</label>
			            <input type="text" class="form-control" value="<%#: Item.weight %>"/>
		            </div>
		            <div class="form-group">
			            <label>Price, $</label>
			            <input type="text" class="form-control" value="<%#: Item.price %>"/>
		            </div>
		            <div class="row">
			            <div class="col-sm-3">
				            <a href="/Administration/Products" class="btn btn-default full-width"><b>Back to Products</b></a>
			            </div>
			            <div class="col-sm-3">
				            <button class="btn btn-default full-width" ng-click="resetProduct()"><b>Reset changes</b></button>
			            </div>
			            <div class="col-sm-3">
				            <button class="btn btn-success full-width" ng-click="saveProcuct()"><b>Save changes</b></button>
			            </div>
			            <div class="col-sm-3">
				            <a href="#" class="btn btn-warning full-width"><b>Delete product</b></a>
			            </div>
		            </div>
                </ItemTemplate>
            </asp:FormView>
	    </div>
    </div>
</asp:Content>
