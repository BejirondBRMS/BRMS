using System;
using System.Web.UI.WebControls;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.BL.Service;

namespace BRMS.Views
{
    public partial class LookupValue : System.Web.UI.Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ILookupValueRepository _lookupValueRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateType();
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }
         public LookupValue()
        {
            _lookupValueRepository = new LookupValueRepository(new BrmsContext());
        }
         public LookupValue(ILookupValueRepository lookupValueRepository)
        {
            _lookupValueRepository = lookupValueRepository;
        }
        public void PopulateValue(int type)
        {
            gvValue.DataSource = null;
            gvValue.DataBind();
            gvValue.DataSource = _lookupValueRepository.GetLookUpValuesByType(type);
            gvValue.DataBind();
        }

        public void PopulateType()
        {          
            drpType.DataSource = null;
            drpType.DataBind();
            drpType.DataSource = unitOfWork.LookUpTypeRepository.Get(); 
            drpType.DataBind();
            drpType.DataTextField = "Name";
            drpType.DataValueField = "ID";
            drpType.DataBind();
            drpType.Items.Insert(0, "--Select--");
            drpType.Items.FindByText("--Select--").Value = "0";
            drpType.SelectedIndex = 0;
        }

        private void ClearForm()
        {
            drpType.SelectedIndex = 0;
            txtName.Text = string.Empty;
            Session["LookupValueID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }

        private new bool IsValid()
        {
            if (txtName.Text == string.Empty)
            {
                return false;
            }
            if (drpType.SelectedIndex == 0)
            {
                return false;
            }
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (Session["LookupValueID"] == null)
                {
                    var objlV = new Model.LookUpValue
                    {
                        Type = Convert.ToInt32(drpType.SelectedValue),
                        Value = txtName.Text,
                        ID = Guid.NewGuid(),
                        SelfParentID = Guid.Empty
                    };
                    if (ModelState.IsValid)
                    {
                        unitOfWork.LookUpValueRepository.Insert(objlV);
                        unitOfWork.Save();
                    }
                }
                else
                {
                    var objlV = new Model.LookUpValue
                    {
                        Type = Convert.ToInt32(drpType.SelectedValue),
                        Value = txtName.Text,
                        ID = new Guid(Session["LookupValueID"].ToString()),
                        SelfParentID = Guid.Empty
                    };
                    if (ModelState.IsValid)
                    {
                        unitOfWork.LookUpValueRepository.Update(objlV);
                        unitOfWork.Save();
                    }
                }
                PopulateValue(Convert.ToInt32(drpType.SelectedValue));
                ClearForm();
                btnSave.Text = "Save";
            }
        }

        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateValue(Convert.ToInt32(drpType.SelectedValue));
            txtName.Text = string.Empty;
            btnDelete.Visible = false;
            Session["LookupValueID"] = null;
            btnSave.Text = "Save";
        }

        protected void gvValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvValue.SelectedDataKey != null)
            {
                var lv = unitOfWork.LookUpValueRepository.GetById(new Guid(gvValue.SelectedDataKey.Value.ToString()));
                Session["LookupValueID"] = new Guid(gvValue.SelectedDataKey.Value.ToString());                
                txtName.Text = lv.Value;
                drpType.SelectedValue =Convert.ToString(lv.Type);
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateValue(Convert.ToInt32(drpType.SelectedValue));
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
            if (Session["LookupValueID"] != null)
            {
                unitOfWork.LookUpValueRepository.Delete(new Guid(Session["LookupValueID"].ToString()));
                unitOfWork.Save();
            }
            PopulateValue(Convert.ToInt32(drpType.SelectedValue));
            ClearForm();
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }

        protected void gvValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvValue.PageIndex = e.NewPageIndex;
            PopulateValue(Convert.ToInt32(drpType.SelectedValue));
        }

       
    }
}