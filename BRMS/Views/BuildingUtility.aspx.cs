using System;
using System.Globalization;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.BL.Service;


namespace BRMS.Views
{
    public partial class BuildingUtility : System.Web.UI.Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ILookupValueRepository _lookupValueRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBuildingUtility();
                PopulateChargeType();
                PopulateBuilding();
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }
        public BuildingUtility()
        {
            _lookupValueRepository = new LookupValueRepository(new BrmsContext());
        }
        public BuildingUtility(ILookupValueRepository lookupValueRepository)
        {
            _lookupValueRepository = lookupValueRepository;
        }
        public void PopulateBuildingUtility()
        {
            gvBuildingUtility.DataSource = null;
            gvBuildingUtility.DataBind();
            gvBuildingUtility.DataSource = unitOfWork.VwBuildingUtilitiesRepository.Get();
            gvBuildingUtility.DataBind();
        }
        public void PopulateChargeType()
        {
            drpChargeType.DataSource = null;
            drpChargeType.DataBind();
            drpChargeType.DataSource = _lookupValueRepository.GetLookUpValuesByType(3); 
            drpChargeType.DataBind();
            drpChargeType.DataTextField = "Value";
            drpChargeType.DataValueField = "ID";
            drpChargeType.DataBind();
            drpChargeType.Items.Insert(0, "--Select--");
            drpChargeType.Items.FindByText("--Select--").Value = "0";
            drpChargeType.SelectedIndex = 0;
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

            if (Session["BuildingUtilityID"] == null)
            {
                var objBU = new Model.BuildingUtility
                {
                    BuildingUtilID = Guid.NewGuid(),
                    ChargeDate = Convert.ToDateTime(txtChargeDate.Text),
                    ChargeType = new Guid(drpChargeType.SelectedValue),
                    ChargeAmount = Convert.ToDecimal(txtChargeAmount.Text),
                    BuildingID = new Guid(drpBuildings.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.BuildingUtilityRepository.Insert(objBU);
                    unitOfWork.Save();
                }
            }
            else
            {
                var objBU = new Model.BuildingUtility
                {
                    BuildingUtilID = new Guid(Session["BuildingUtilityID"].ToString()),
                    ChargeDate = Convert.ToDateTime(txtChargeDate.Text),
                    ChargeType = new Guid(drpChargeType.SelectedValue),
                    ChargeAmount = Convert.ToDecimal(txtChargeAmount.Text),
                    BuildingID = new Guid(drpBuildings.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                     unitOfWork.BuildingUtilityRepository.Update(objBU);
                    unitOfWork.Save();
                }
            }
            PopulateBuildingUtility();
            ClearForm();
            btnSave.Text = "Save";
        }
        private void ClearForm()
        {
            drpBuildings.SelectedIndex = 0;
            txtChargeDate.Text = string.Empty;
            txtChargeAmount.Text = string.Empty;
            drpChargeType.SelectedIndex = 0;            
            Session["BuildingUtilityID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }

        protected void gvBuildingUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvBuildingUtility.SelectedDataKey != null)
            {
                var bu = unitOfWork.BuildingUtilityRepository.GetById(new Guid(gvBuildingUtility.SelectedDataKey.Value.ToString()));
                Session["BuildingUtilityID"] = new Guid(gvBuildingUtility.SelectedDataKey.Value.ToString());
                drpBuildings.SelectedValue =bu.BuildingID.ToString();
                txtChargeDate.Text =bu.ChargeDate.ToShortDateString();
                txtChargeAmount.Text =Convert.ToDecimal(bu.ChargeAmount).ToString();
                drpChargeType.SelectedValue = bu.ChargeType.ToString();                
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void gvBuildingUtility_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvBuildingUtility.PageIndex = e.NewPageIndex;
            PopulateBuildingUtility();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateBuildingUtility();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDelete.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = true;
        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            if (Session["BuildingUtilityID"] != null)
            {
                unitOfWork.BuildingUtilityRepository.Delete(new Guid(Session["BuildingUtilityID"].ToString()));
                unitOfWork.Save();
            }
            PopulateBuildingUtility();
            ClearForm();
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDeleteNo.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }
    }
}