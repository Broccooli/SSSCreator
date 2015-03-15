using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSCreator
{
    public partial class Main : Form
    {
        private String m_savedFilePath;
        private Int32 m_numHidden;

        private List<StageSelectPage> m_pages;

        GCTFileHandler m_handler;

        public Main()
        {
            InitializeComponent();
            m_savedFilePath = String.Empty;
            m_pages = new List<StageSelectPage>(2);

            this.Text = "Broccoli's PM SSS Creator";

            txtFilePath.ReadOnly = true;
            btnBrowse.MouseClick += btnBrowse_MouseClick;
            btnLoad.MouseClick += btnLoad_MouseClick;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            lblPage.AutoSize = true;
            lblPage.Text = "Selected Page: ";
            lblPageSize.Text = "Page Size: ";
            grpbxPageProperties.Text = "Page x";

            SetupComboBoxes();
            ToggleControlVisibility(false);

            this.Icon = new Icon(".\\index.ico");

            cmbSelectedPage.SelectedValueChanged += cmbSelectedPage_SelectedValueChanged;
            cmbPageSize.SelectedValueChanged += cmbPageSize_SelectedValueChanged;
            btnExport.MouseClick += btnExport_MouseClick;

            //Debug values
            m_savedFilePath = @"G:\Old\PM Stagelist Starter Pack\Nebulus Stagelist";
            txtFilePath.Text = m_savedFilePath;
        }

        #region Private Methods

        private void LoadProperComboBoxes()
        {
            StageSelectPage temp = cmbSelectedPage.SelectedValue as StageSelectPage;

            Byte tempSize = (Byte)cmbPageSize.SelectedValue;
            temp.Size = tempSize;
            if (temp.Name.CompareTo("Page One") == 0)
            {
                if (tempSize > 14)
                {
                    MessageBox.Show("Page One cannot be larger than 14, due to limitations with this editor. If you would like a full page one (default), just reinstall PM", "Page one too large...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (temp != null)
            {
                for (Int32 ii = 1; ii <= Constants.MAX_STAGES_PAGE_TWO; ii++)
                {
                    ComboBox cBox = grpbxPageProperties.Controls["cmbStage" + ii] as ComboBox;
                    if (ii > tempSize)
                    {
                        cBox.Visible = false;
                    }
                    else
                    {
                        cBox.Visible = true;
                    }
                }
            }
        }

        private void PopulateComboBoxes()
        {
            StageSelectPage temp = cmbSelectedPage.SelectedValue as StageSelectPage;

            if (temp != null)
            {
                for (Int32 ii = 0; ii < temp.StageList.Count; ii++)
                {
                    ComboBox tempComboBox = grpbxPageProperties.Controls["cmbStage" + (ii + 1)] as ComboBox;

                    Int32 tempSelectedIndex = temp.StageList[ii];

                    if (tempSelectedIndex == 43) // Special case for training room
                    {
                        tempSelectedIndex = 41;
                    }

                    tempComboBox.SelectedIndex = tempSelectedIndex;
                }
            }

            switch (temp.Size)
            {
                case(10):
                    cmbPageSize.SelectedIndex = 0;
                    break;
                case(11):
                    cmbPageSize.SelectedIndex = 1;
                    break;
                case(12):
                    cmbPageSize.SelectedIndex = 2;
                    break;
                case(13):
                    cmbPageSize.SelectedIndex = 3;
                    break;
                case(14):
                    cmbPageSize.SelectedIndex = 4;
                    break;
                case(21):
                    cmbPageSize.SelectedIndex = 5;
                    break;
            }
            grpbxPageProperties.Text = temp.Name;
        }

        private void ToggleControlVisibility(Boolean visible)
        {
            lblPage.Visible = visible;
            cmbSelectedPage.Visible = visible;
            grpbxPageProperties.Visible = visible;
            lblPageSize.Visible = visible;
            cmbPageSize.Visible = visible;
            btnExport.Visible = visible;
        }

        private void SetupComboBoxes()
        {
            for (Int32 ii = 1; ii <= Constants.MAX_STAGES_PAGE_TWO; ii++)
            {
                ComboBox temp = grpbxPageProperties.Controls["cmbStage" + ii] as ComboBox;
                temp.DataSource = new List<Stage>(Constants.STAGE_LIST.AsEnumerable<Stage>());
            }

            cmbPageSize.DataSource = Constants.POSSIBLE_STAGE_SIZES;
        }

        private void BrowseGCTFilePath()
        {
            using(FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Select the folder containing the RCT file...";

                if (m_savedFilePath != String.Empty)
                {
                    dialog.SelectedPath = m_savedFilePath;
                }

                DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    String newFilePath = dialog.SelectedPath;

                    if (newFilePath.CompareTo(m_savedFilePath) != 0)
                    {
                        m_savedFilePath = newFilePath;
                    }

                    txtFilePath.Text = m_savedFilePath;
                }
            }
        }

        private void LoadGCTFile()
        {
            if (Directory.Exists(m_savedFilePath))
            {
                String tempTestPath = m_savedFilePath + "\\RSBE01.gct";
                if (File.Exists(tempTestPath))
                {
                    try
                    {
                        m_handler = new GCTFileHandler(tempTestPath);
                    }
                    catch (GCTFileException gctfe)
                    {
                        MessageBox.Show(gctfe.ErrorMessage, "Validation Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // If we got this far, the gct file is valid.
                    MessageBox.Show("GCT File loaded successfully", "Load Successful...", MessageBoxButtons.OK);

                    m_pages.Add(new StageSelectPage("Page One", 1, m_handler.PageOneSize, m_handler.PageOneStageList));
                    m_pages.Add(new StageSelectPage("Page Two", 2, m_handler.PageTwoSize, m_handler.PageTwoStageList));
                    cmbSelectedPage.DataSource = m_pages;

                    ToggleControlVisibility(true);
                }
                else
                {
                    MessageBox.Show("RSBE01.gct does not exist in the path you specified.", "File does not exist...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetNewStageList()
        {
            cmbSelectedPage.SelectedIndex = 0;

            Byte stageCountPageOne = (Byte)cmbPageSize.SelectedValue;
            Byte[] newStageListPageOne = new Byte[stageCountPageOne];

            for (Int32 ii = 0; ii < newStageListPageOne.Length; ii++)
            {
                ComboBox tempComboBox = grpbxPageProperties.Controls["cmbStage" + (ii + 1)] as ComboBox;

                if (tempComboBox != null)
                {
                    Stage tempStage = tempComboBox.SelectedValue as Stage;
                    if (tempStage != null)
                    {
                        newStageListPageOne[ii] = Convert.ToByte(tempStage.Value);
                    }
                }
            }

            cmbSelectedPage.SelectedIndex = 1;

            Byte stageCountPageTwo = (Byte)cmbPageSize.SelectedValue;
            Byte[] newStageListPageTwo = new Byte[stageCountPageTwo];

            for (Int32 ii = 0; ii < newStageListPageTwo.Length; ii++)
            {
                ComboBox tempComboBox = grpbxPageProperties.Controls["cmbStage" + (ii + 1)] as ComboBox;

                if (tempComboBox != null)
                {
                    Stage tempStage = tempComboBox.SelectedValue as Stage;
                    if (tempStage != null)
                    {
                        newStageListPageTwo[ii] = Convert.ToByte(tempStage.Value);
                    }
                }
            }

            m_handler.ExportNewStageList(stageCountPageOne, newStageListPageOne, stageCountPageTwo, newStageListPageTwo);
        }

        #endregion

        #region Events

        void btnBrowse_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseGCTFilePath();
        }

        void btnLoad_MouseClick(object sender, MouseEventArgs e)
        {
            LoadGCTFile();
        }

        void cmbSelectedPage_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadProperComboBoxes();
            PopulateComboBoxes();
        }
        void cmbPageSize_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadProperComboBoxes();
            PopulateComboBoxes();
        }
        void btnExport_MouseClick(object sender, MouseEventArgs e)
        {
            GetNewStageList();
        }

        #endregion
    }
}
