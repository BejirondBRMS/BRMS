<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonView.aspx.cs" Inherits="BRMS.Views.PersonView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Panel ID="pnlMain" runat="server" Visible="False">
        <div class="form-horizontal">
            <h4>Create a new Person</h4>
            <hr />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="drpTitle" CssClass="col-md-2 control-label" ID="lblTitle">Title</asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="drpTitle" CssClass="form-control" runat="server" AutoPostBack="True" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtIdNumber" CssClass="col-md-2 control-label" ID="lblIdNumber">Id Number</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtIdNumber" CssClass="form-control" Width="280px" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblIdType" runat="server" AssociatedControlID="drpType" CssClass="col-md-2 control-label" Text="Type of ID"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="drpType" runat="server" CssClass="form-control" AutoPostBack="True" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label" ID="lblFirstName">First Name</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" Text="" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtMiddleName" CssClass="col-md-2 control-label" ID="lblMiddleName">Middle Name</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label" ID="lblLastName">Last Name</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="drpSex" CssClass="col-md-2 control-label" ID="lblSex">Sex</asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="drpSex" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtBirthDate" CssClass="col-md-2 control-label" ID="lblBirthDate">Birth Date</asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtBirthDate" runat="server" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
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
                <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" PageSize="5" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" DataKeyNames="PersonID" BorderWidth="1px"
                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnSelectedIndexChanging="gvPerson_SelectedIndexChanging" OnRowDeleting="gvPerson_RowDeleting">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Images/_edit.png" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" OnClientClick="return confirm('Are you sure you want to delete this record?');" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/_delete.png" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                        <asp:BoundField DataField="IdNo" HeaderText="Id Number" SortExpression="IdNo" />
                        <%--<asp:BoundField DataField="GovIDType" HeaderText="Id Type" SortExpression="GovIDType" />--%>
                        <asp:BoundField DataField="Name" HeaderText="First Name" SortExpression="Name" />
                        <asp:BoundField DataField="MName" HeaderText="Middle Name" SortExpression="MName" />
                        <asp:BoundField DataField="LName" HeaderText="Last Name" SortExpression="LName" />

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
