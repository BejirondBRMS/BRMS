<%@ Page Title="Building Utility" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuildingUtility.aspx.cs" Inherits="BRMS.Views.BuildingUtility" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="form-horizontal">
        <h4>Building Utilities</h4>
        <hr />
        <div class="form-group">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpBuildings" CssClass="col-md-2 control-label" ID="lblBuildings">Buildings</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpBuildings" CssClass="form-control" Width="280px" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtChargeDate" CssClass="col-md-2 control-label" ID="lblChargeDate">Charge Date</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtChargeDate" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="txtChargeDate_CalendarExtender" runat="server" BehaviorID="txtChargeDate_CalendarExtender" TargetControlID="txtChargeDate"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpChargeType" CssClass="col-md-2 control-label" ID="lblChargeType">Charge Type</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpChargeType" CssClass="form-control" Width="280px" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtChargeAmount" CssClass="col-md-2 control-label" ID="lblChargeAmount">Charge Amount</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtChargeAmount" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="New" CssClass="btn btn-default" ID="btnNew" OnClick="btnNew_Click" />
                        <asp:Button runat="server" Text="Save" CssClass="btn btn-default" ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button runat="server" Text="Delete" CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click" />
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <%--<div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-6">--%>
                            <asp:GridView ID="gvBuildingUtility" runat="server" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="BuildingUtilID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvBuildingUtility_PageIndexChanging" OnSelectedIndexChanged="gvBuildingUtility_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle ForeColor="#3333CC" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="ChargeDate" DataFormatString="{0:M-dd-yyyy}" HeaderText="Charge Date" SortExpression="ChargeDate">
                                        <ItemStyle Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChargeAmount" HeaderText="Charge Amount" SortExpression="ChargeAmount">
                                        <ItemStyle Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChargeType" HeaderText="Charge Type" SortExpression="ChargeType">
                                        <ItemStyle Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BuildingName" HeaderText="Building Name" SortExpression="BuildingName">
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
                       <%-- </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

    <dx:ASPxPopupControl ID="ASPxPopupControlDelete" HeaderText="Delete" PopupElementID="btnDelete" runat="server" Theme="RedWine">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
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
