<%@ Page Title="Setting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LookupValue.aspx.cs" Inherits="BRMS.Views.LookupValue" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     

    <div class="form-horizontal">
        <h4>Create a new Setting</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="drpType"   CssClass="col-md-2 control-label" ID="lblSelectType">Select Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="drpType" CssClass="form-control" Width="280px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpType_SelectedIndexChanged"/>                              
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label" ID="lblValueName">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"  />
            </div>
        </div>        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server"  Text="New" CssClass="btn btn-default" ID="btnNew" OnClick="btnNew_Click"  />
                <asp:Button runat="server"  Text="Save" CssClass="btn btn-default" ID="btnSave" OnClick="btnSave_Click" />
                <asp:Button runat="server"  Text="Delete" CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click"  />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
            <asp:GridView ID="gvValue" runat="server" AutoGenerateColumns="False" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" ForeColor="Black" GridLines="Horizontal" AllowPaging="True"  OnSelectedIndexChanged="gvValue_SelectedIndexChanged" OnPageIndexChanging="gvValue_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"  >
                    <ItemStyle ForeColor="#3333CC" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Value"  HeaderText="Value" SortExpression="Value" >                    
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
