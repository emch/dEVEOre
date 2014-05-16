using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dEVEOre
{
    public partial class frmSystems : Form
    {
        // Parameters
        private DataManager data;
        private frmMain parent;
        private int selectedItem;
        private bool edit;

        // Methods
        public frmSystems(frmMain parent, DataManager data)
        {
            InitializeComponent();

            this.parent = parent;
            this.data = data;
            this.selectedItem = -1;
            this.edit = false;
        }

        private void frmSystems_Load(object sender, EventArgs e)
        {
            this.Text = Program.PROGRAM_NAME + " - Systems management";
            this.UpdateList();
        }

        private void UpdateList()
        {
            this.lstSystems.Items.Clear();
            this.txtName.Text = "";
            this.txtId.Text = "";
            this.selectedItem = -1;
            this.edit = false;

            for (int k = 0; k < this.data.GetEveSystemData().Length; k++)
            {
                this.lstSystems.Items.Add(this.data.GetEveSystemData()[k].GetName() + " ("
                    + this.data.GetEveSystemData()[k].GetId().ToString() + ")");
            }
        }

        private void SaveNewSystemsList(String datapath)
        {
            String saveString;
            TextWriter tw = new StreamWriter(datapath);

            for (int k = 0; k < this.data.GetEveSystemData().Length; k++ )
            {
                saveString = this.data.GetEveSystemData()[k].GetId().ToString() + " \"" +
                    this.data.GetEveSystemData()[k].GetName() + "\"";
                tw.WriteLine(saveString);
            }

            tw.Close();
        }

        private void UpdateData()
        {
            // update systems.dat file
            this.SaveNewSystemsList(DataManager.EVESYSTEM_DATAFILE_PATH);

            // update this.parent.data
            this.parent.GetDataManager().LoadEveSystemData(DataManager.EVESYSTEM_DATAFILE_PATH);

            // update parent list of systems
            this.parent.UpdateSystemCmb();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedItem = this.lstSystems.SelectedIndex;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.selectedItem >= 0)
            {
                this.txtName.Text = this.data.GetEveSystemData()[this.selectedItem].GetName();
                this.txtId.Text = this.data.GetEveSystemData()[this.selectedItem].GetId().ToString();
                this.edit = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this system?",
                "Delete System",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.selectedItem >= 0)
                {
                    this.data.DeleteSystem(this.selectedItem);
                }
            }

            this.UpdateList();
            this.UpdateData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text != "" && this.txtName.Text != "")
            {
                try
                {
                    if (this.edit)
                    { // the item is being edited
                        this.data.GetEveSystemData()[this.selectedItem].SetId(int.Parse(this.txtId.Text));
                        this.data.GetEveSystemData()[this.selectedItem].SetName(this.txtName.Text);
                    }
                    else
                    { // a new item is being added
                    
                            this.data.AddSystem(new EveSystem(int.Parse(this.txtId.Text), this.txtName.Text));
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception was thrown when trying to add System: " + ex.Message, "Exception",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("One or more field(s) is empty!", "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }

            this.UpdateList();
            this.UpdateData();
        }
    }
}
