<%@ Page Title="Sign in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PizzaDelivery01.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="container">
            <div class="col-sm-2"></div>
            <div class="col-sm-8 background-plate">
                <h4><%: Title %></h4>
                <section id="loginForm">
                    <div class="">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <label>Email</label>
                            <div class="">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="you@email.com"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="The email field is required." Display="dynamic"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <div class="">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="secret-password"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." Display="dynamic"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                </div>    
                        </div>
                        <div class="form-group">
                                <asp:Button runat="server" OnClick="LogIn" Text="Sign in" CssClass="btn btn-success full-width" />
                        </div>
                        <p class="no-margin">Don't have an account? <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Sign up</asp:HyperLink>.</p>
                    </div>
                </section>
            </div>
            <div class="col-sm-2"></div>
    </div>
</asp:Content>
