<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TenantView.aspx.cs" Inherits="BRMS.Views.TenantView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Create a new Tenant</h4>
    <hr />
    <div class="form-group">
    <table class="table table-striped">
        <tr>
            <td style="width: 148px">
                <asp:RadioButton ID="rdoPerson" runat="server" GroupName="tenant" Text="Register Person" CssClass="form-control radio radio-inline" Width="200px" AutoPostBack="True" OnCheckedChanged="rdoPerson_CheckedChanged" />
            </td>
            <td>
                <asp:RadioButton ID="rdoCompany" runat="server" GroupName="tenant" Text="Register Company" CssClass="form-control radio radio-inline" Width="200px" AutoPostBack="True" OnCheckedChanged="rdoCompany_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td style="width: 148px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </div>

</asp:Content>
