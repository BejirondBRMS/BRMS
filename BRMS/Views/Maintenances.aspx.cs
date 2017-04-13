using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Service;

namespace BRMS.Views
{
    public partial class Maintenances : Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        public void PopulateMaintenances(Guid propertyID)
        {
            gvMaintenances.DataSource = null;
            gvMaintenances.DataBind();
            gvMaintenances.DataSource = unitOfWork.MaintenanceRepository.Get().Where(b => b.PropertyID == propertyID).ToList();
            gvMaintenances.DataBind();
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
            if (chkInspection.Checked == false && Session["InspectionMaintenanceID"] == null)
                Session["InspectionMaintenanceID"] = Guid.Empty;
            if (chkInspection.Checked == true && Session["InspectionMaintenanceID"] == null)
                Session["InspectionMaintenanceID"] = Guid.Empty;
            if (Session["MaintenanceID"] == null)
            {
                var objMn = new Model.Maintenance
                {
                    MaintenanceID = Guid.NewGuid(),
                    DamageDate = Convert.ToDateTime(txtDamageDate.Text),
                    DamagedItem = txtDamagedItem.Text,
                    IsMaintained = chkIsMaintained.Checked,
                    MaintenanceDate = Convert.ToDateTime(txtMaintenanceDate.Text),
                    MaintenanceDescription = txtMaintenanceDescription.Text,                    
                    InspectionID =new Guid(Session["InspectionMaintenanceID"].ToString()),
                    PropertyID = new Guid(drpProperty.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.MaintenanceRepository.Insert(objMn);
                    unitOfWork.Save();
                }
            }
            else
            {
                var objMn = new Model.Maintenance
                {
                    MaintenanceID = new Guid(Session["MaintenanceID"].ToString()),
                    DamageDate = Convert.ToDateTime(txtDamageDate.Text),
                    DamagedItem = txtDamagedItem.Text,
                    IsMaintained = chkIsMaintained.Checked,
                    MaintenanceDate = Convert.ToDateTime(txtMaintenanceDate.Text),
                    MaintenanceDescription = txtMaintenanceDescription.Text,
                    InspectionID = new Guid(Session["InspectionMaintenanceID"].ToString()),
                    PropertyID = new Guid(drpProperty.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.MaintenanceRepository.Update(objMn);
                    unitOfWork.Save();
                }
            }
            ClearForm();
            if (drpBuildings.SelectedIndex == 0)
                PopulateMaintenances(Guid.Empty);
            else
                PopulateMaintenances(new Guid(drpProperty.SelectedValue));
            btnSave.Text = "Save";
        }
        private void ClearForm()
        {
            txtDamageDate.Text = string.Empty;
            txtDamagedItem.Text = string.Empty;
            chkIsMaintained.Checked = false;
            txtMaintenanceDate.Text = String.Empty;
            txtMaintenanceDescription.Text = string.Empty;
            Session["MaintenanceID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }
        protected void gvInspections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvInspections.SelectedDataKey != null)
            {
                var insp = unitOfWork.vwInspectionsRepository.GetById(new Guid(gvInspections.SelectedDataKey.Value.ToString()));
                if (insp!=null)
                {
                    pnlInspectionInformation.Visible = true;
                }
                Session["InspectionMaintenanceID"] = new Guid(gvInspections.SelectedDataKey.Value.ToString());                
                lblInspectionDateValue.Text = insp.InspectionDate.ToShortDateString();
                lblPropertyVal.Text = insp.Property;
                lblDamagedItemValue.Text = insp.DamagedItem;
                lblInspectedByValue.Text = insp.InspectedBy;
                gvInspections.Visible = false;
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
            if (Session["MaintenanceID"] != null)
            {
                unitOfWork.MaintenanceRepository.Delete(new Guid(Session["MaintenanceID"].ToString()));
                unitOfWork.Save();
            }
            ClearForm();
            if (drpBuildings.SelectedIndex == 0)
                PopulateMaintenances(Guid.Empty);
            else
                PopulateMaintenances(new Guid(drpBuildings.SelectedValue));
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
            txtDamageDate.Text = string.Empty;
            drpProperty.SelectedIndex = 0;
            txtDamagedItem.Text = string.Empty;
            btnDelete.Visible = false;
            Session["MaintenanceID"] = null;
            btnSave.Text = "Save";
        }       
        protected void chkInspection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInspection.Checked)
            {
                if (drpProperty.SelectedIndex == 0)
                    PopulateInspection(Guid.Empty);
                else
                {
                    PopulateInspection(new Guid(drpProperty.SelectedValue));
                    gvInspections.Visible = true;
                }
            }
            else
            {
                PopulateInspection(Guid.Empty);
            }
        }
        protected void gvMaintenances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvMaintenances.SelectedDataKey != null)
            {
                var main = unitOfWork.MaintenanceRepository.GetById(new Guid(gvMaintenances.SelectedDataKey.Value.ToString()));
                Session["MaintenanceID"] = new Guid(gvMaintenances.SelectedDataKey.Value.ToString());
                var pro = unitOfWork.PropertyRepository.GetById(main.PropertyID);
                drpBuildings.SelectedValue = pro.BuildingID.ToString();
                drpProperty.SelectedValue = main.PropertyID.ToString();
                txtDamageDate.Text = main.DamageDate.ToShortDateString();
                txtDamagedItem.Text = main.DamagedItem.ToString(CultureInfo.InvariantCulture);
                chkIsMaintained.Checked = main.IsMaintained;
                txtMaintenanceDate.Text =Convert.ToDateTime(main.MaintenanceDate).ToShortDateString();
                txtMaintenanceDescription.Text = main.MaintenanceDescription;
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void gvMaintenances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMaintenances.PageIndex = e.NewPageIndex;
            PopulateMaintenances(new Guid(drpProperty.SelectedValue));
        }

        protected void drpProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpProperty.SelectedIndex == 0)
                PopulateMaintenances(Guid.Empty);
            else
                PopulateMaintenances(new Guid(drpProperty.SelectedValue));
        }
    }
}