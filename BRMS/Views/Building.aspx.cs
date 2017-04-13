using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Service;

namespace BRMS.Views
{
    public partial class Building : System.Web.UI.Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBuildings();
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }

        public void PopulateBuildings()
        {
            gvBuilding.DataSource = null;
            gvBuilding.DataBind();
            gvBuilding.DataSource = unitOfWork.BuildingRepository.Get();
            gvBuilding.DataBind();
        }


        private void ClearForm()
        {
            txtBuildingName.Text = string.Empty;
            txtStorey.Text = string.Empty;
            txtBlockNumber.Text = string.Empty;
            txtKifleKetama.Text = string.Empty;
            txtWoreda.Text = string.Empty;
            txtKebele.Text = string.Empty;
            txtHouseNumber.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            Session["BuildingID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BuildingID"] == null)
            {
                var objBuilding = new Model.Building
                {
                    BuildingID = Guid.NewGuid(),
                    BuildingName = txtBuildingName.Text,
                    Storey = txtStorey.Text,
                    BlockNumber = txtBlockNumber.Text,
                    KifleKetema = txtKifleKetama.Text,
                    Woreda = txtWoreda.Text,
                    Kebele = txtKebele.Text,
                    HouseNumber = txtHouseNumber.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text

                };
                if (ModelState.IsValid)
                {
                    unitOfWork.BuildingRepository.Insert(objBuilding);
                    unitOfWork.Save();
                }
            }
            else
            {

                var objBuilding = new Model.Building
                {
                    BuildingID = new Guid(Session["BuildingID"].ToString()),
                    BuildingName = txtBuildingName.Text,
                    Storey = txtStorey.Text,
                    BlockNumber = txtBlockNumber.Text,
                    KifleKetema = txtKifleKetama.Text,
                    Woreda = txtWoreda.Text,
                    Kebele = txtKebele.Text,
                    HouseNumber = txtHouseNumber.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.BuildingRepository.Update(objBuilding);
                    unitOfWork.Save();
                }
            }
            PopulateBuildings();
            ClearForm();
            btnSave.Text = "Save";
        }



        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateBuildings();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDelete.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = true;

        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            ASPxPopupControlDelete.PopupElementID = btnDeleteNo.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            if (Session["BuildingID"] != null)
            {
                unitOfWork.BuildingRepository.Delete(new Guid(Session["BuildingID"].ToString()));
                unitOfWork.Save();
            }
            PopulateBuildings();
            ClearForm();
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void gvBuilding_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuilding.PageIndex = e.NewPageIndex;
            PopulateBuildings();
        }

        protected void gvBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvBuilding.SelectedDataKey != null)
            {
                var bu = unitOfWork.BuildingRepository.GetById(new Guid(gvBuilding.SelectedDataKey.Value.ToString()));
                Session["BuildingID"] = new Guid(gvBuilding.SelectedDataKey.Value.ToString());
                txtBuildingName.Text = bu.BuildingName;
                txtStorey.Text = bu.Storey;
                txtBlockNumber.Text = bu.BlockNumber;
                txtKifleKetama.Text = bu.KifleKetema;
                txtWoreda.Text = bu.Woreda;
                txtKebele.Text = bu.Kebele;
                txtHouseNumber.Text = bu.HouseNumber;
                txtCity.Text = bu.City;
                txtCountry.Text = bu.Country;
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }
    }

}