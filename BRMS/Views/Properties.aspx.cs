using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.BL.Service;

namespace BRMS.Views
{
    public partial class Properties : System.Web.UI.Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProperties();
                PopulateDrpRoomUse();
                PopulateDrpAvailiability();
                PopulateDrpRoomType();
                PopulateDrpBuildingName();
              
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }
        private ILookupValueRepository _lookupValueRepository;
        public Properties()
        {
            _lookupValueRepository = new LookupValueRepository(new BrmsContext());
        }
        public Properties(ILookupValueRepository lookupValueRepository)
        {
            _lookupValueRepository = lookupValueRepository;
        }

        public void PopulateDrpRoomUse()
        {
            drpRoomUse.DataSource = null;
            drpRoomUse.DataBind();
            drpRoomUse.DataSource = _lookupValueRepository.GetLookUpValuesByType(3); 
            drpRoomUse.DataBind();
            drpRoomUse.DataTextField = "Value";
            drpRoomUse.DataValueField = "ID";
            drpRoomUse.DataBind();
            drpRoomUse.Items.Insert(0, "--Select--");
            drpRoomUse.Items.FindByText("--Select--").Value = "0";
            drpRoomUse.SelectedIndex = 0;
        }
        public void PopulateDrpAvailiability()
        {
            drpAvailiability.DataSource = null;
            drpAvailiability.DataBind();
            drpAvailiability.DataSource = _lookupValueRepository.GetLookUpValuesByType(4);
            drpAvailiability.DataBind();
            drpAvailiability.DataTextField = "Value";
            drpAvailiability.DataValueField = "ID";
            drpAvailiability.DataBind();
            drpAvailiability.Items.Insert(0, "--Select--");
            drpAvailiability.Items.FindByText("--Select--").Value = "0";
            drpAvailiability.SelectedIndex = 0;
        }
        public void PopulateDrpRoomType()
        {
            drpRoomType.DataSource = null;
            drpRoomType.DataBind();
            drpRoomType.DataSource = _lookupValueRepository.GetLookUpValuesByType(5);
            drpRoomType.DataBind();
            drpRoomType.DataTextField = "Value";
            drpRoomType.DataValueField = "ID";
            drpRoomType.DataBind();
            drpRoomType.Items.Insert(0, "--Select--");
            drpRoomType.Items.FindByText("--Select--").Value = "0";
            drpRoomType.SelectedIndex = 0;
        }
        public void PopulateDrpBuildingName()
        {
            drpBuildingName.DataSource = null;
            drpBuildingName.DataBind();
            drpBuildingName.DataSource = unitOfWork.BuildingRepository.Get();
            drpBuildingName.DataBind();
            drpBuildingName.DataTextField = "BuildingName";
            drpBuildingName.DataValueField = "BuildingID";
            drpBuildingName.DataBind();
            drpBuildingName.Items.Insert(0, "--Select--");
            drpBuildingName.Items.FindByText("--Select--").Value = "0";
            drpBuildingName.SelectedIndex = 0;
        }
        public void PopulateProperties()
        {
            gvProperties.DataSource = null;
            gvProperties.DataBind();
            gvProperties.DataSource = unitOfWork.PropertyRepository.Get();
            gvProperties.DataBind();

           
            

        }


        private void ClearForm()
        {
            txtFloorNo.Text = string.Empty;
            txtRoomNo.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            drpRoomUse.SelectedIndex = 0;
            drpAvailiability.SelectedIndex = 0;
            drpRoomType.SelectedIndex = 0;
            txtRoomDescription.Text = string.Empty;
            drpBuildingName.SelectedIndex = 0;
            Session["PropertyID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["PropertyID"] == null)
            {
                var objProp = new Model.Property
                {
                    PropertyID = Guid.NewGuid(),
                    FloorNo = txtFloorNo.Text,
                    RoomNo = txtRoomNo.Text,
                    Area = txtArea.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    RoomUse = new Guid(drpRoomUse.SelectedValue),
                    Availiability = new Guid(drpAvailiability.SelectedValue),
                    RoomType = new Guid(drpRoomType.SelectedValue),
                    RoomDescription = txtRoomDescription.Text,
                    BuildingID = new Guid(drpBuildingName.SelectedValue)

                };
                if (ModelState.IsValid)
                {
                    unitOfWork.PropertyRepository.Insert(objProp);
                    unitOfWork.Save();
                }
            }
            else
            {

                var objProp = new Model.Property
                {
                    PropertyID = new Guid(Session["PropertyID"].ToString()),
                    FloorNo = txtFloorNo.Text,
                    RoomNo = txtRoomNo.Text,
                    Area = txtArea.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    RoomUse = new Guid(drpRoomUse.SelectedValue),
                    Availiability = new Guid(drpAvailiability.SelectedValue),
                    RoomType = new Guid(drpRoomType.SelectedValue),
                    RoomDescription = txtRoomDescription.Text,
                    BuildingID = new Guid(drpBuildingName.SelectedValue)
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.PropertyRepository.Update(objProp);
                    unitOfWork.Save();
                }
            }
            PopulateProperties();
            PopulateDrpRoomUse();
            PopulateDrpAvailiability();
            PopulateDrpRoomType();
            PopulateDrpBuildingName();
            ClearForm();
            btnSave.Text = "Save";
        }



        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateProperties();
            PopulateDrpRoomUse();
            PopulateDrpAvailiability();
            PopulateDrpRoomType();
            PopulateDrpBuildingName();
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
            if (Session["PropertyID"] != null)
            {
                unitOfWork.PropertyRepository.Delete(new Guid(Session["PropertyID"].ToString()));
                unitOfWork.Save();
            }
            PopulateProperties();
            PopulateDrpRoomUse();
            PopulateDrpAvailiability();
            PopulateDrpRoomType();
            PopulateDrpBuildingName();
            ClearForm();
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void gvProperties_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProperties.PageIndex = e.NewPageIndex;
            PopulateProperties();
            PopulateDrpRoomUse();
            PopulateDrpAvailiability();
            PopulateDrpRoomType();
            PopulateDrpBuildingName();
        }

        protected void gvProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvProperties.SelectedDataKey != null)
            {
                var prop = unitOfWork.PropertyRepository.GetById(new Guid(gvProperties.SelectedDataKey.Value.ToString()));
                Session["PropertyID"] = new Guid(gvProperties.SelectedDataKey.Value.ToString());
                txtFloorNo.Text = prop.FloorNo;
                txtRoomNo.Text = prop.RoomNo;
                txtArea.Text = prop.Area;
                txtUnitPrice.Text = Convert.ToString(prop.UnitPrice);
                drpRoomUse.Text = Convert.ToString(prop.RoomUse);
                drpAvailiability.Text = Convert.ToString(prop.Availiability);
                drpRoomType.Text = Convert.ToString(prop.RoomType);
                txtRoomDescription.Text = prop.RoomDescription;
                drpBuildingName.Text = Convert.ToString(prop.BuildingID);
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void drpRoomUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drpRoomUse.Text = drpRoomUse.SelectedValue;
            //btnDelete.Visible = false;
            //Session["PropertyID"] = null;
            //btnSave.Text = "Save";
        }

        protected void drpAvailiability_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            drpAvailiability.Text = drpAvailiability.SelectedValue;
            //btnDelete.Visible = false;
            //Session["PropertyID"] = null;
            //btnSave.Text = "Save";
        }

        protected void drpRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drpRoomType.Text = drpRoomType.SelectedValue;
            //btnDelete.Visible = false;
            //Session["PropertyID"] = null;
            //btnSave.Text = "Save";
        }

        protected void drpBuildingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drpBuildingName.Text = drpBuildingName.SelectedValue;
            //btnDelete.Visible = false;
            //Session["PropertyID"] = null;
            //btnSave.Text = "Save";

        }
    }
}