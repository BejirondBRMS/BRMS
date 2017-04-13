<%@ Page Title="Inspection" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inspection.aspx.cs" Inherits="BRMS.Views.Inspection" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Floor Rates</h4>
        <hr />
        <div class="form-group">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpBuildings" CssClass="col-md-2 control-label" ID="lblBuildings">Buildings</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpBuildings" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBuildings_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpProperty" CssClass="col-md-2 control-label" ID="lblProperty">Property</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpProperty" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProperty_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtInspectionDate" CssClass="col-md-2 control-label" ID="lblInspectionDate">Inspection Date</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtInspectionDate" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="txtInspectionDate_CalendarExtender" runat="server" BehaviorID="txtInspectionDate_CalendarExtender" TargetControlID="txtInspectionDate"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtDamagedItem" CssClass="col-md-2 control-label" ID="lblDamagedItem">Damaged Item</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtDamagedItem" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpInspectedBy" CssClass="col-md-2 control-label" ID="Label1">Inspected By</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpInspectedBy" CssClass="form-control" Width="280px" runat="server" />
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
                <asp:GridView ID="gvInspections" runat="server" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="InspectionID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvInspections_PageIndexChanging" OnSelectedIndexChanged="gvInspections_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle ForeColor="#3333CC" />
                        </asp:CommandField>
                        <asp:BoundField DataField="InspectionDate" DataFormatString="{0:M-dd-yyyy}" HeaderText="Inspection Date" SortExpression="InspectionDate">
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DamagedItem" HeaderText="Damaged Item" SortExpression="DamagedItem">
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="InspectedBy" HeaderText="Inspected By" SortExpression="InspectedBy">
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Property" HeaderText="Property" SortExpression="Property">
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
