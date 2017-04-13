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
    public partial class BankAccount : System.Web.UI.Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBankAccount();
                btnSave.Text = "Save";
                btnDelete.Visible = false;
            }
        }
       
        public void PopulateBankAccount()
        {
            gvBankAccount.DataSource = null;
            gvBankAccount.DataBind();
            gvBankAccount.DataSource = unitOfWork.BankAccountRepository.Get();
            gvBankAccount.DataBind();
        }

      
        private void ClearForm()
        {
            txtAccountNumber.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            Session["AccountID"] = null;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["AccountID"] == null)
            {
                var objBankAcc = new Model.BankAccount
                {
                    AccountID = Guid.NewGuid(),
                    AccountNumber = txtAccountNumber.Text,
                    BankName = txtBankName.Text,
                    AccountAreaBank = txtBranchName.Text
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.BankAccountRepository.Insert(objBankAcc);
                    unitOfWork.Save();
                }
            }
            else
            {
              
                var objBankAcc = new Model.BankAccount
                {
                    AccountID = new Guid(Session["AccountID"].ToString()),
                    AccountNumber = txtAccountNumber.Text,
                    BankName = txtBankName.Text,
                    AccountAreaBank = txtBranchName.Text
                };
                if (ModelState.IsValid)
                {
                    unitOfWork.BankAccountRepository.Update(objBankAcc);
                    unitOfWork.Save();
                }
            }
            PopulateBankAccount();
            ClearForm();
            btnSave.Text = "Save";
        }

       

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateBankAccount();
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
            if (Session["AccountID"] != null)
            {
                unitOfWork.BankAccountRepository.Delete(new Guid(Session["AccountID"].ToString()));
                unitOfWork.Save();
            }
            PopulateBankAccount();
            ClearForm();
            ASPxPopupControlDelete.PopupElementID = btnDeleteYes.ToString();
            ASPxPopupControlDelete.ShowOnPageLoad = false;
        }



        protected void gvBankAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBankAccount.PageIndex = e.NewPageIndex;
            PopulateBankAccount();
        }

        protected void gvBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvBankAccount.SelectedDataKey != null)
            {
                var ba = unitOfWork.BankAccountRepository.GetById(new Guid(gvBankAccount.SelectedDataKey.Value.ToString()));
                Session["AccountID"] = new Guid(gvBankAccount.SelectedDataKey.Value.ToString());
                txtAccountNumber.Text = ba.AccountNumber;
                txtBankName.Text = ba.BankName;
                txtBranchName.Text = ba.AccountAreaBank;
                btnSave.Text = "Update";
                btnDelete.Visible = true;
            }
        }
        
    }
}