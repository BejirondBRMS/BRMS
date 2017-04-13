using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.BL.Service;
using BRMS.Model;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Import.Doc;

namespace BRMS.Views
{
    public partial class PersonView : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly IPersonRepository _personRepository;
        private bool _isDirty;
        public PersonView()
        {

            _lookupValueRepository = new LookupValueRepository(new BrmsContext());
            _personRepository = new PersonRepository(new BrmsContext());
        }

        public PersonView(ILookupValueRepository lookupValueRepository, IPersonRepository personRepository)
        {
            _lookupValueRepository = lookupValueRepository;
            _personRepository = personRepository;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillIdType();
                FillTitile();
                BindToGrid();
            }
        }

        private void BindToGrid()
        {
            var list = _personRepository.GetAllPerson();
            gvPerson.DataSource = list;
            gvPerson.DataBind();
        }

        private void FillTitile()
        {
            var lst = _lookupValueRepository.GetLookUpValuesByType(2);
            drpTitle.DataSource = lst;
            drpTitle.DataTextField = "value";
            drpTitle.DataValueField = "id";
            drpTitle.DataBind();
            drpTitle.Items.Insert(0, "--Select--");
            drpTitle.Items.FindByText("--Select--").Value = "0";
            drpTitle.SelectedIndex = 0;
        }

        private void FillIdType()
        {
            var lst = _lookupValueRepository.GetLookUpValuesByType(1);
            drpType.DataSource = lst;
            drpType.DataTextField = "value";
            drpType.DataValueField = "id";
            drpType.DataBind();
            drpType.Items.Insert(0, "--Select--");
            drpType.Items.FindByText("--Select--").Value = "0";
            drpType.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void DoSave()
        {
            Person objSave = new Person
            {
                PersonID = Guid.NewGuid(),
                Title = new Guid(drpTitle.SelectedValue),
                PersonIDGov = txtIdNumber.Text,
                GovIDType = drpType.SelectedValue,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Sex = drpSex.SelectedValue,
                BirthDate = Convert.ToDateTime(txtBirthDate.Text)
            };
            if (ModelState.IsValid)
            {
                if (_isDirty)
                {
                    _unitOfWork.PersonRepository.Insert(objSave);
                    _unitOfWork.Save();
                }
                else
                {
                    objSave.PersonID = (Guid) Session["personId"];
                    _unitOfWork.PersonRepository.Update(objSave);
                    _unitOfWork.Save();
                }

            } 
            BindToGrid();
            DoClear();
        }

        private void DoClear()
        {
            this.txtFirstName.Text = "";
            this.txtMiddleName.Text = "";
            this.txtLastName.Text = "";
            this.txtBirthDate.Text = "";
            this.drpTitle.SelectedValue = "0";
            this.drpType.SelectedValue = "0";
            this.drpSex.SelectedValue = "-1";
            this.txtIdNumber.Text = "";
            _isDirty = true;
        }

        protected void gvPerson_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var dataKey = gvPerson.DataKeys[e.NewSelectedIndex];
            if (dataKey != null)
            {
                var id = new Guid(dataKey.Value.ToString());
                Session["personId"] = id;
                FindPerson(id);
            }
            pnlMain.Visible = true;
        }

        private void FindPerson(Guid id)
        {
            List<Person> lst = _personRepository.GetPersonById(id);
            foreach (var item in lst)
            {
                this.txtFirstName.Text = item.FirstName;
                this.txtMiddleName.Text = item.MiddleName;
                this.txtLastName.Text = item.LastName;
                this.txtBirthDate.Text = item.BirthDate.ToString(CultureInfo.InvariantCulture);
                this.drpTitle.SelectedValue = item.Title.ToString();
                this.drpType.SelectedValue = item.GovIDType.ToString();
                this.drpSex.SelectedValue = item.Sex == "1" ? "1" : "0";
                this.txtIdNumber.Text = item.PersonIDGov;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            DoClear();
            pnlMain.Visible = true;
        }

        protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gvPerson.DataKeys[e.RowIndex];
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