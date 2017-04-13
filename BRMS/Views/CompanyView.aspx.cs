using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.BL.Service;
using BRMS.Model;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using DevExpress.XtraRichEdit.Import.Doc;

namespace BRMS.Views
{
    public partial class CompanyView : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly ICompanyUtility _companyUtility;
        private bool _isDirty;

        public CompanyView()
        {
           
            _lookupValueRepository = new LookupValueRepository(new BrmsContext());
            _companyUtility = new CompanyUtility(new BrmsContext());
        }

        public CompanyView(ILookupValueRepository lookupValueRepository, ICompanyUtility companyUtility)
        {
            _lookupValueRepository = lookupValueRepository;
            _companyUtility = companyUtility;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTaxType();
                CompanyType();
                BindToGrid();
            }
        }

        private void CompanyType()
        {
            var list = _lookupValueRepository.GetLookUpValuesByType(4);
            drpType.DataSource = list;
            drpType.DataTextField = "Value";
            drpType.DataValueField = "ID";
            drpType.DataBind();
            drpType.Items.Insert(0, "--Select--");
            drpType.Items.FindByText("--Select--").Value = "0";
            drpType.SelectedIndex = 0;
        }

        private void FillTaxType()
        {
            var list = _lookupValueRepository.GetLookUpValuesByType(3);
            drpTaxType.DataSource = list;
            drpTaxType.DataTextField = "Value";
            drpTaxType.DataValueField = "ID";
            drpTaxType.DataBind();
            drpTaxType.Items.Insert(0, "--Select--");
            drpTaxType.Items.FindByText("--Select--").Value = "0";
            drpTaxType.SelectedIndex = 0;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            _isDirty = false;
            DoClear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void DoSave()
        {
            BRMS.Model. Company objSave = new BRMS.Model.Company
            {
                CompanyID = Guid.NewGuid(),
                CompanyName = this.txtCompanytName.Text,
                CompanyType = new Guid(drpType.SelectedValue),
                TaxRegistrationNo = txtTaxRegistrationNo.Text,
                TradeRegistrationNo = txtTradeRegistrationNo.Text,
                TaxType = new Guid(drpTaxType.SelectedValue)
            };

            if (_isDirty == false)
            {
                _unitOfWork.CompanyRepository.Insert(objSave);
                _unitOfWork.Save();
            }
            else
            {
                objSave.CompanyID = new Guid(Session["CompanyId"].ToString());
                _unitOfWork.CompanyRepository.Update(objSave);
                _unitOfWork.Save();
            }
            BindToGrid();
            DoClear();
        }

        private void DoClear()
        {
            this.txtCompanytName.Text = "";
            this.txtTaxRegistrationNo.Text = "";
            this.txtTradeRegistrationNo.Text = "";
            this.drpTaxType.SelectedValue = "0";
            this.drpType.SelectedValue = "0";
        }

        private void BindToGrid()
        {
            var list = _companyUtility.GetAllCompany();
            gvCompany.DataSource = list;
            gvCompany.DataBind();

        }

        protected void gvCompany_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pnlMain.Visible = true;
            _isDirty = true;
            var dataKey = gvCompany.DataKeys[e.NewSelectedIndex];
            if (dataKey != null)
            {
                Guid id = new Guid(dataKey.Value.ToString());
                Session["CompanyId"] = id;
                DoFind(id);
            }
        }

        private void DoFind(Guid id)
        {
            var lst = _unitOfWork.CompanyRepository.Get();
            foreach (var item in lst)
            {
                txtCompanytName.Text = item.CompanyName;
                txtTaxRegistrationNo.Text = item.TaxRegistrationNo;
                txtTradeRegistrationNo.Text = item.TradeRegistrationNo;
                drpType.SelectedValue = item.CompanyType.ToString();
                drpTaxType.SelectedValue = item.TaxType.ToString();
            }
        }

        protected void gvCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gvCompany.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                Guid id = new Guid(dataKey.Value.ToString());
                DoDelete(id);
            }
        }

        private void DoDelete(Guid id)
        {
           
            _unitOfWork.PersonRepository.Delete(id);
            _unitOfWork.Save();
            BindToGrid();
        }
    }
}