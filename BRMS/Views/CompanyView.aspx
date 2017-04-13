<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyView.aspx.cs" Inherits="BRMS.Views.CompanyView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:Panel ID="pnlMain" runat="server" Visible="False">
        <div class="form-horizontal">
            <h4>Create a new Company</h4>
            <hr />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCompanytName" CssClass="col-md-2 control-label" ID="lblCompanyName">Company Name</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtCompanytName" CssClass="form-control" Text="" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="drpType" CssClass="col-md-2 control-label" ID="lblType">Company Type</asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="drpType" CssClass="form-control" AutoPostBack="True" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtTradeRegistrationNo" CssClass="col-md-2 control-label" ID="lblTradeRegistrationNo">Trade Registration No</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtTradeRegistrationNo" CssClass="form-control" />
                </div>
            </div>


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtTaxRegistrationNo" CssClass="col-md-2 control-label" ID="lblTaxRegistrationNo">Tax Registration No</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTaxRegistrationNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="drpTaxType" CssClass="col-md-2 control-label" ID="lblTaxType">Tax Type</asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="drpTaxType" runat="server" CssClass="form-control" AutoPostBack="True" />
                </div>
            </div>

        </div>

    </asp:Panel>
    <br />
    <br />
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="New" CssClass="btn btn-default" ID="btnNew" OnClick="btnNew_Click" />
                <asp:Button runat="server" Text="Save" CssClass="btn btn-default" ID="btnSave" OnClick="btnSave_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:GridView ID="gvCompany" runat="server" AutoGenerateColumns="False" PageSize="5" BackColor="White" DataKeyNames="CompanyID"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnSelectedIndexChanging="gvCompany_SelectedIndexChanging" OnRowDeleting="gvCompany_RowDeleting">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Images/_edit.png" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" OnClientClick="return confirm('Are you sure you want to delete this record?');" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/_delete.png" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" />
                        <asp:BoundField DataField="CompanyType" HeaderText="Company Type" SortExpression="CompanyType" />
                        <asp:BoundField DataField="TradeRegistrationNo" HeaderText="Trade Registration No" SortExpression="TradeRegistrationNo" />
                        <asp:BoundField DataField="TaxRegistrationNo" HeaderText="Tax Registration No" SortExpression="TaxRegistrationNo" />
                       <%-- <asp:BoundField DataField="TaxType" HeaderText="Tax Type" SortExpression="TaxType" />--%>


                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
