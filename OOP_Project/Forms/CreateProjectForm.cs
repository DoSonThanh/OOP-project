using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class CreateProjectForm : Form
{
    private readonly ProjectController _projectController;

    public CreateProjectForm(ProjectController projectController)
    {
        _projectController = projectController;
        InitializeComponent();
        LoadStatusOptions();
        LoadLeaderOptions();
    }

    private void LoadStatusOptions()
    {
        _cboStatus.Items.Clear();
        List<EnumStatus> statuses = _projectController.GetStatusOptions();

        for (int i = 0; i < statuses.Count; i++)
        {
            _cboStatus.Items.Add(statuses[i]);
        }

        if (_cboStatus.Items.Count > 0)
        {
            _cboStatus.SelectedIndex = 0;
        }
    }

    private void LoadLeaderOptions()
    {
        _cboLeader.Items.Clear();
        List<Employee> leaders = _projectController.GetLeaders();

        for (int i = 0; i < leaders.Count; i++)
        {
            _cboLeader.Items.Add(leaders[i]);
        }

        if (_cboLeader.Items.Count > 0)
        {
            _cboLeader.SelectedIndex = 0;
        }
    }

    private void BtnCreate_Click(object? sender, EventArgs e)
    {
        if (_cboStatus.SelectedItem == null)
        {
            MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cboLeader.SelectedItem == null)
        {
            MessageBox.Show("Please select a leader.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EnumStatus selectedStatus = (EnumStatus)_cboStatus.SelectedItem;
        Employee? selectedLeader = _cboLeader.SelectedItem as Employee;

        if (selectedLeader == null)
        {
            MessageBox.Show("Invalid leader selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string message;
        bool created = _projectController.CreateProject(
            _txtName.Text,
            _txtDescription.Text,
            _dtpStartDate.Value.Date,
            _dtpEndDate.Value.Date,
            selectedStatus,
            selectedLeader,
            out message);

        if (created)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
