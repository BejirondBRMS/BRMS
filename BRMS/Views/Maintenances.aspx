<%@ Page Title="Maintenances" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenances.aspx.cs" Inherits="BRMS.Views.Maintenances" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Maintenances</h4>
        <hr />
        <div class="form-group">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpBuildings" CssClass="col-md-3 control-label" ID="lblBuildings">Buildings</asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="drpBuildings" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBuildings_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="drpProperty" CssClass="col-md-3 control-label" ID="lblProperty">Property</asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="drpProperty" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProperty_SelectedIndexChanged" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="chkInspection" CssClass="col-md-7 control-label" ID="lblInspection">Is the maintenance based on inspection ?</asp:Label>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkInspection" runat="server" AutoPostBack="True" OnCheckedChanged="chkInspection_CheckedChanged" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtDamageDate" CssClass="col-md-3 control-label" ID="lblDamageDate">Damage Date</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtDamageDate" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="txtDamageDate_CalendarExtender" runat="server" BehaviorID="txtDamageDate_CalendarExtender" TargetControlID="txtDamageDate"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtDamagedItem" CssClass="col-md-3 control-label" ID="lblDamagedItem">Damaged Item</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtDamagedItem" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="chkIsMaintained" CssClass="col-md-3 control-label" ID="lblIsMaintained">Is Maintained ?</asp:Label>
                    <div class="col-md-8">
                        <asp:CheckBox ID="chkIsMaintained" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtMaintenanceDate" CssClass="col-md-3 control-label" ID="lblMaintenanceDate">Maintenance Date</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtMaintenanceDate" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="txtMaintenanceDate_CalendarExtender" runat="server" BehaviorID="txtMaintenanceDate_CalendarExtender" TargetControlID="txtMaintenanceDate"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtMaintenanceDescription" CssClass="col-md-3 control-label" ID="lblMaintenanceDescription">Maintenance Description</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtMaintenanceDescription" TextMode="MultiLine" CssClass="form-control" />
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
                <div class="form-group">
                    <asp:Panel ID="pnlInspectionInformation" Visible="False" runat="server">
                        <h4>Inspection Information</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblInspectionDate" AssociatedControlID="lblInspectionDateValue" runat="server" Text="Inspection Date : "></asp:Label>
                                <br />
                                <asp:Label ID="lblInspectionDateValue" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblDamagedItemins" AssociatedControlID="lblDamagedItemValue" runat="server" Text="Damaged Item : "></asp:Label>
                                <br />
                                <asp:Label ID="lblDamagedItemValue" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblInspectedBy" AssociatedControlID="lblInspectedByValue" runat="server" Text="Inspected By : "></asp:Label>
                                <br />
                                <asp:Label ID="lblInspectedByValue" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblPropertyInsp" AssociatedControlID="lblPropertyVal" runat="server" Text="Property : "></asp:Label>
                                <br />
                                <asp:Label ID="lblPropertyVal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
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
                <div class="form-group">
                    <asp:GridView ID="gvMaintenances" runat="server" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="MaintenanceID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvMaintenances_PageIndexChanging" OnSelectedIndexChanged="gvMaintenances_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle ForeColor="#3333CC" />
                            </asp:CommandField>
                            <asp:BoundField DataField="DamageDate" DataFormatString="{0:M-dd-yyyy}" HeaderText="Damaged Date" SortExpression="DamageDate">
                                <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DamagedItem" HeaderText="Damaged Item" SortExpression="DamagedItem">
                                <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IsMaintained" HeaderText="Is Maintained" SortExpression="IsMaintained">
                                <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaintenanceDate" DataFormatString="{0:M-dd-yyyy}" HeaderText="Maintenance Date" SortExpression="MaintenanceDate">
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
