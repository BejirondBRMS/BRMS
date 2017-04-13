using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Service;
using BRMS.Model;

namespace BRMS.Views
{
    public partial class FloorRates : Page
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
        public void PopulateFloorRate(Guid buildingID)
        {
            gvFloorRates.DataSource = null;
            gvFloorRates.DataBind();
            gvFloorRates.DataSource = unitOfWork.FloorRateRepository.Get().Where(b => b.BuildingID == buildingID).ToList();
            gvFloorRates.DataBind();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Session["FloorRatesID"] == null)
            {
                var objFr = new FloorRate
                {
                    FloorRateID = Guid.NewGuid(),
                    FloorNo = txtFloorNo.Text,
                    RentAmount = Convert.ToDecimal(txtRentAmount.Text),
                    BuildingID = new Guid(drpBuildings.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.FloorRateRepository.Insert(objFr);
                    unitOfWork.Save();
                }
            }
            else
            {
                var objFr = new FloorRate
                {
                    FloorRateID = new Guid(Session["FloorRatesID"].ToString()),
                    FloorNo = txtFloorNo.Text,
                    RentAmount = Convert.ToDecimal(txtRentAmount.Text),
                    BuildingID = new Guid(drpBuildings.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.FloorRateRepository.Update(objFr);
                    unitOfWork.Save();
                }
            }
            ClearForm();
            if (drpBuildings.SelectedIndex == 0)
                PopulateFloorRate(Guid.Empty);
            else
                PopulateFloorRate(new Guid(drpBuildings.SelectedValue));
            btnSave.Text = "Save";
        }
        private void ClearForm()
        {            
            txtFloorNo.Text = string.Empty;
            txtRentAmount.Text = string.Empty;
            Session["FloorRatesID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }
        protected void gvFloorRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvFloorRates.SelectedDataKey != null)
            {
                var bu = unitOfWork.FloorRateRepository.GetById(new Guid(gvFloorRates.SelectedDataKey.Value.ToString()));
                Session["FloorRatesID"] = new Guid(gvFloorRates.SelectedDataKey.Value.ToString());
                drpBuildings.SelectedValue = bu.BuildingID.ToString();
                txtFloorNo.Text = bu.FloorNo;
                txtRentAmount.Text = bu.RentAmount.ToString(CultureInfo.InvariantCulture);
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void gvFloorRates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFloorRates.PageIndex = e.NewPageIndex;
            PopulateFloorRate(new Guid(drpBuildings.SelectedValue));
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            drpBuildings.SelectedIndex = 0;
            ClearForm();
            if(drpBuildings.SelectedIndex==0)
                PopulateFloorRate(Guid.Empty);
            else
            PopulateFloorRate(new Guid(drpBuildings.SelectedValue));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDelete.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = true;
        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            if (Session["FloorRatesID"] != null)
            {
                unitOfWork.FloorRateRepository.Delete(new Guid(Session["FloorRatesID"].ToString()));
                unitOfWork.Save();
            }
            ClearForm();
            drpBuildings.SelectedIndex = 0;
            if (drpBuildings.SelectedIndex == 0)
                PopulateFloorRate(Guid.Empty);
            else
                PopulateFloorRate(new Guid(drpBuildings.SelectedValue));
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
            PopulateFloorRate(new Guid(drpBuildings.SelectedValue));
            txtFloorNo.Text = string.Empty;
            txtRentAmount.Text = string.Empty;
            btnDelete.Visible = false;
            Session["FloorRatesID"] = null;
            btnSave.Text = "Save";
        }

        
    }
}