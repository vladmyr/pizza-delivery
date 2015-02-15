<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PizzaDelivery01.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="col-sm-2"></div>
            <div class="col-sm-8 background-plate">
                <h4><%: Title %></h4>
                
                    <%--<div class="alert alert-danger alert-dismissable">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                        
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    </div>--%>
                
                <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>

                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label>Confirm password</label>
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                </div>    
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Sign up" CssClass="btn btn-success full-width" />
                <%-- <p>Already have an account? <a href="#/login">Sign in</a>.</p> --%>
            </div>
        <div class="col-sm-2"></div>
    </div>
</asp:Content>
