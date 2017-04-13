<%@ Page Title="Register Properties" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Properties.aspx.cs" Inherits="BRMS.Views.Properties" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="form-horizontal">
        <h4>Create a new Property</h4>
        <hr />
         <div class="form-group">
              <div class="col-md-4">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFloorNo"   CssClass="col-md-3 control-label" ID="lblFloorNo">Floor No.</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtFloorNo" CssClass="form-control"  />
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtRoomNo" CssClass="col-md-3 control-label" ID="lblStorey">Room No.</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtRoomNo" CssClass="form-control"  />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtArea" CssClass="col-md-3 control-label" ID="lblArea">Area</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtArea" CssClass="form-control"  />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUnitPrice" CssClass="col-md-3 control-label" ID="Label1">Unit Price</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control"  />
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="drpRoomUse"   CssClass="col-md-2 control-label" ID="lblSelectType">Select Room Use</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="drpRoomUse" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpRoomUse_SelectedIndexChanged"/>                              
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="drpAvailiability"   CssClass="col-md-2 control-label" ID="lblAvailiability">Availiability</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="drpAvailiability" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpAvailiability_SelectedIndexChanged"/>                              
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="drpRoomType"   CssClass="col-md-2 control-label" ID="lblRoomType">Room Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="drpRoomType" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpRoomType_SelectedIndexChanged"/>                              
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtRoomDescription" CssClass="col-md-3 control-label" ID="lblRoomDescription">Description</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtRoomDescription" CssClass="form-control"  />
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="drpBuildingName"   CssClass="col-md-2 control-label" ID="lblBuildingName">Building Name</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="drpBuildingName" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBuildingName_SelectedIndexChanged"/>                              
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-3 col-md-6">
                <asp:Button runat="server"  Text="New" CssClass="btn btn-default" ID="btnNew" OnClick="btnNew_Click"  />
                <asp:Button runat="server"  Text="Save" CssClass="btn btn-default" ID="btnSave" OnClick="btnSave_Click" />
                <asp:Button runat="server"  Text="Delete" CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click"  />
            </div>
        </div>
        </div>
             <div class="col-md-6">
                 <div class="form-group">
            <div class="col-md-offset-2 col-md-6">
            <asp:GridView ID="gvProperties" runat="server" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="PropertyID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvProperties_PageIndexChanging" OnSelectedIndexChanged="gvProperties_SelectedIndexChanged" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True"  >
                    <ItemStyle ForeColor="#3333CC" />
                    </asp:CommandField>
                    <asp:BoundField DataField="FloorNo"  HeaderText="Floor No.">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="RoomNo"  HeaderText="No.">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Area"  HeaderText="Area">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UnitPrice"  HeaderText="Unit Price">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RoomUse"  HeaderText="Use">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Availiability"  HeaderText="Availiability">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="RoomType"  HeaderText="Type">                    
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="RoomDescription"  HeaderText="Description">                    
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
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True" >Are you sure do you want to delete this data?<br/><br/>
    <div class="col-md-offset-2 col-md-10"> 
    <asp:Button ID="btnDeleteYes" CssClass="btn btn-danger"  runat="server" Text="Yes" OnClick="btnDeleteYes_Click" />
    <asp:Button ID="btnDeleteNo" CssClass="btn btn-primary" runat="server" Text="No" OnClick="btnDeleteNo_Click"  />
        <br/><br/></div>
</dx:PopupControlContentControl>
</ContentCollection>
</dx:ASPxPopupControl>

</asp:Content>
