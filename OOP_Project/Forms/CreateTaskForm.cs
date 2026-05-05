using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class CreateTaskForm : Form
{
    private readonly ProjectController _projectController;
    private readonly string _projectId;

    public CreateTaskForm(ProjectController projectController, string projectId)
    {
        _projectController = projectController;
        _projectId = projectId;
        InitializeComponent();
        LoadStatusOptions();
        LoadAssigneeOptions();
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

    private void LoadAssigneeOptions()
    {
        _cboAssignee.Items.Clear();
        List<Employee> employees = _projectController.GetEmployees();

        for (int i = 0; i < employees.Count; i++)
        {
            _cboAssignee.Items.Add(employees[i]);
        }

        if (_cboAssignee.Items.Count > 0)
        {
            _cboAssignee.SelectedIndex = 0;
        }
    }

    private void BtnCreate_Click(object? sender, EventArgs e)
    {
        if (_cboStatus.SelectedItem == null)
        {
            MessageBox.Show("Please select a task status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cboAssignee.SelectedItem == null)
        {
            MessageBox.Show("Please select an employee.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EnumStatus selectedStatus = (EnumStatus)_cboStatus.SelectedItem;
        Employee? selectedAssignee = _cboAssignee.SelectedItem as Employee;

        if (selectedAssignee == null)
        {
            MessageBox.Show("Invalid assignee selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string message;
        bool created = _projectController.CreateTask(
            _projectId,
            _txtTitle.Text,
            _txtDescription.Text,
            selectedStatus,
            selectedAssignee,
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
