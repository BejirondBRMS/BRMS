<%@ Page Title="Register Building" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Building.aspx.cs" Inherits="BRMS.Views.Building" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4>Create a new Building</h4>
        <hr />
        <div class="form-group">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtBuildingName" CssClass="col-md-3 control-label" ID="lblBuildingName">Building Name</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtBuildingName" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtStorey" CssClass="col-md-3 control-label" ID="lblStorey">Storey</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtStorey" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtBlockNumber" CssClass="col-md-3 control-label" ID="lblBlockNumber">Block Number</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtBlockNumber" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtKifleKetama" CssClass="col-md-3 control-label" ID="lblKifleKetama">Kifle Ketama</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtKifleKetama" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtWoreda" CssClass="col-md-3 control-label" ID="lblWoreda">Woreda</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtWoreda" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtKebele" CssClass="col-md-3 control-label" ID="lblKebele">Kebele</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtKebele" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtHouseNumber" CssClass="col-md-3 control-label" ID="lblHouseNumber">House Number</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtHouseNumber" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col-md-3 control-label" ID="lblCity">City</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCountry" CssClass="col-md-3 control-label" ID="lblCountry">Country</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-6">
                        <asp:Button runat="server" Text="New" CssClass="btn btn-default" ID="btnNew" OnClick="btnNew_Click" />
                        <asp:Button runat="server" Text="Save" CssClass="btn btn-default" ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button runat="server" Text="Delete" CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-6">
                        <asp:GridView ID="gvBuilding" runat="server" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="BuildingID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvBuilding_PageIndexChanging" OnSelectedIndexChanged="gvBuilding_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle ForeColor="#3333CC" />
                                </asp:CommandField>
                                <asp:BoundField DataField="BuildingName" HeaderText="Building Name">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Storey" HeaderText="Storey">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="KifleKetema" HeaderText="Kefle Ketama">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Woreda" HeaderText="Woreda">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Kebele" HeaderText="Kebele">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HouseNumber" HeaderText="House Number">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="City" HeaderText="City">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Country" HeaderText="Country">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
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
        </div>


    </div>

    <dx:ASPxPopupControl ID="ASPxPopupControlDelete" PopupElementID="btnDelete" runat="server" HeaderText="Delete Confirmation" Theme="RedWine">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                Are you sure do you want to delete this data?<br />
                <br />
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button ID="btnDeleteYes" CssClass="btn btn-danger" runat="server" Text="Yes" OnClick="btnDeleteYes_Click" />
                    <asp:Button ID="btnDeleteNo" CssClass="btn btn-primary" runat="server" Text="No" OnClick="btnDeleteNo_Click" />
                    <br />
                    <br />
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
