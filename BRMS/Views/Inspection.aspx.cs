using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Service;

namespace BRMS.Views
{
    public partial class Inspection : Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateInspectedBy();
                PopulateBuilding();
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }
        public void PopulateInspection(Guid propertyID)
        {
            gvInspections.DataSource = null;
            gvInspections.DataBind();
            gvInspections.DataSource = unitOfWork.vwInspectionsRepository.Get().Where(b => b.PropertyID == propertyID).ToList();
            gvInspections.DataBind();
        }
        public void PopulateBuilding()
        {
            drpBuildings.DataSource = null;
            drpBuildings.DataBind();
            drpBuildings.DataSource = unitOfWork.BuildingRepository.Get();
            drpBuildings.DataBind();
            drpBuildings.DataTextField = "BuildingName";
            drpBuildings.DataValueField = "BuildingID";
            drpBuildings.DataBind();
            drpBuildings.Items.Insert(0, "--Select--");
            drpBuildings.Items.FindByText("--Select--").Value = "0";
            drpBuildings.SelectedIndex = 0;
        }
        public void PopulateInspectedBy()
        {
            drpInspectedBy.DataSource = null;
            drpInspectedBy.DataBind();
            drpInspectedBy.DataSource = unitOfWork.vwEmployeePersonRepository.Get();
            drpInspectedBy.DataBind();
            drpInspectedBy.DataTextField = "FullName";
            drpInspectedBy.DataValueField = "EmployeeID";
            drpInspectedBy.DataBind();
            drpInspectedBy.Items.Insert(0, "--Select--");
            drpInspectedBy.Items.FindByText("--Select--").Value = "0";
            drpInspectedBy.SelectedIndex = 0;
        }
        public void PopulateProperties(Guid buildingID)
        {
            drpProperty.DataSource = null;
            drpProperty.DataBind();
            drpProperty.DataSource = unitOfWork.PropertyRepository.Get().Where(p => p.BuildingID == buildingID).ToList();
            drpProperty.DataBind();
            drpProperty.DataTextField = "RoomNo";
            drpProperty.DataValueField = "PropertyID";
            drpProperty.DataBind();
            drpProperty.Items.Insert(0, "--Select--");
            drpProperty.Items.FindByText("--Select--").Value = "0";
            drpProperty.SelectedIndex = 0;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Session["InspectionsID"] == null)
            {
                var objIn = new Model.Inspection
                {
                    InspectionID = Guid.NewGuid(),
                    InspectionDate = Convert.ToDateTime(txtInspectionDate.Text),
                    PropertyID = new Guid(drpProperty.SelectedValue),
                    DamagedItem = txtDamagedItem.Text,
                    InspectedBy = new Guid(drpInspectedBy.SelectedValue),                    
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.InspectionRepository.Insert(objIn);
                    unitOfWork.Save();
                }
            }
            else
            {
                var objIn = new Model.Inspection
                {                    
                    InspectionID = new Guid(Session["InspectionsID"].ToString()),
                    InspectionDate = Convert.ToDateTime(txtInspectionDate.Text),
                    PropertyID = new Guid(drpProperty.SelectedValue),
                    DamagedItem = txtDamagedItem.Text,
                    InspectedBy = new Guid(drpInspectedBy.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.InspectionRepository.Update(objIn);
                    unitOfWork.Save();
                }
            }
            ClearForm();
            if (drpBuildings.SelectedIndex == 0)
                PopulateInspection(Guid.Empty);
            else
                PopulateInspection(new Guid(drpProperty.SelectedValue));
            btnSave.Text = "Save";
        }
        private void ClearForm()
        {
            txtInspectionDate.Text = string.Empty;
            txtDamagedItem.Text = string.Empty;
            drpInspectedBy.SelectedIndex = 0;
            Session["InspectionsID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }
        protected void gvInspections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvInspections.SelectedDataKey != null)
            {
                var insp = unitOfWork.InspectionRepository.GetById(new Guid(gvInspections.SelectedDataKey.Value.ToString()));
                Session["InspectionsID"] = new Guid(gvInspections.SelectedDataKey.Value.ToString());
                var buld = unitOfWork.PropertyRepository.GetById(insp.PropertyID);
                drpBuildings.SelectedValue = buld.BuildingID.ToString();
                drpProperty.SelectedValue = insp.PropertyID.ToString();
                txtInspectionDate.Text = insp.InspectionDate.ToShortDateString();
                txtDamagedItem.Text = insp.DamagedItem.ToString(CultureInfo.InvariantCulture);
                drpInspectedBy.SelectedValue = insp.InspectedBy.ToString();
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void gvInspections_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInspections.PageIndex = e.NewPageIndex;
            PopulateInspection(new Guid(drpBuildings.SelectedValue));
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            drpBuildings.SelectedIndex = 0;
            ClearForm();
            if (drpBuildings.SelectedIndex == 0)
                PopulateInspection(Guid.Empty);
            else
                PopulateInspection(new Guid(drpBuildings.SelectedValue));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDelete.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = true;
        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            if (Session["InspectionsID"] != null)
            {
                unitOfWork.InspectionRepository.Delete(new Guid(Session["InspectionsID"].ToString()));
                unitOfWork.Save();
            }
            ClearForm();            
            if (drpBuildings.SelectedIndex == 0)
                PopulateInspection(Guid.Empty);
            else
                PopulateInspection(new Guid(drpBuildings.SelectedValue));
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDeleteNo.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void drpBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpBuildings.SelectedIndex == 0)
            {
                PopulateProperties(Guid.Empty);
                PopulateInspection(Guid.Empty);
            }
            else
                PopulateProperties(new Guid(drpBuildings.SelectedValue));
            txtInspectionDate.Text = string.Empty;
            drpProperty.SelectedIndex = 0;
            txtDamagedItem.Text = string.Empty;
            drpInspectedBy.SelectedIndex = 0;
            btnDelete.Visible = false;
            Session["InspectionsID"] = null;
            btnSave.Text = "Save";
        }
        protected void drpProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpProperty.SelectedIndex == 0)
                PopulateInspection(Guid.Empty);
            else
                PopulateInspection(new Guid(drpProperty.SelectedValue));
        }
    }
}