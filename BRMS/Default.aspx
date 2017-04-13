<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BRMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>BRMS</h1>
        <div class="row">
            <div class="col-md-8">
                        <p class="lead">
            Building Rental Management System (BRMS) is a one-stop database for managing your rental property information. BRMS is designed by a property manager to meet your unique needs. It is for real estate professionals and private property investors alike. 
Using BRMS, you can save and manage data about your properties, tenants, and financial transactions. BRMS includes advanced reporting functions that create spreadsheets with the rental information you need.
Is your property portfolio residential, commercial, rural, or varied? Do you have two or three properties, or two or three hundred? BRMS can grow with your portfolio. It provides the following functions:
        </p>
                </div>
            <div class="col-md-4">
                <asp:Image ID="Image1" Width="380px" Height="250px" ImageUrl="Images/addis_ababa1.jpg" runat="server" />
                </div>
            </div>

        <p><a href="#" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">

        <div class="col-md-4">
            <h2>Manage data about every property, including:</h2>
            <p>
                •	Complete data<br />
                •	Specific notes, including a property log and photographs<br />
                •	Detailed, customizable lists of assets and property dimensions<br />
                •	Full Inspection records, including digital photos of your property<br />

            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Manage data about your tenants, including:</h2>
            <p>
                •	Detailed tenant and tenancy data, including scans and images<br />
                •	Link tenants to properties<br />
                •	View tenants' current rent, amount owing, and upcoming payments<br />

            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Record and report on financial data for your properties, including: </h2>
            <p>
                •	Income,Expenditures<br />
                •	Automatic Calculate Rents function provides fast updates of who owes you rent<br />
                •	BRMS Contacts now provides details of non-tenant contacts - record cleaners, builders and other service providers<br />
                •	Create reports with practical information about your properties, tenants, assets, expenditures, and more<br />

            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
