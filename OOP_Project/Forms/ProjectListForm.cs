using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class ProjectListForm : Form
{
    private readonly ProjectController _projectController;
    private readonly bool _focusCreateSection;
    private readonly bool _viewOnlyMode;

    public ProjectListForm(ProjectController projectController)
        : this(projectController, false, false)
    {
    }

    public ProjectListForm(ProjectController projectController, bool focusCreateSection)
        : this(projectController, focusCreateSection, false)
    {
    }

    public ProjectListForm(ProjectController projectController, bool focusCreateSection, bool viewOnlyMode)
    {
        _projectController = projectController;
        _focusCreateSection = focusCreateSection;
        _viewOnlyMode = viewOnlyMode;

        InitializeComponent();
        LoadStatusOptions();
        LoadLeaderOptions();
        LoadEmployeeOptions();
        LoadFilterEmployees();
        LoadProjectsToGrid();

        if (_focusCreateSection && !_viewOnlyMode)
        {
            _txtProjectName.Focus();
            _groupCreateProject.BackColor = Color.FromArgb(234, 244, 252);
        }
    }

    private void ProjectListForm_Resize(object? sender, EventArgs e)
    {
        ApplyResponsiveLayout();
    }

    private void ApplyResponsiveLayout()
    {
        int sidePadding = 20;
        int spacing = 10;
        int contentWidth = ClientSize.Width - (sidePadding * 2);
        if (contentWidth < 760)
        {
            contentWidth = 760;
        }
        int contentRight = sidePadding + contentWidth;

        bool compactVertical = ClientSize.Height < 760;
        int summaryHeight = compactVertical ? 60 : 72;
        int projectEmployeesHeight = compactVertical ? 72 : 90;
        int minTaskHeight = compactVertical ? 90 : 110;
        int minProjectGridHeight = compactVertical ? 100 : 150;

        _groupFilterEmployees.Left = sidePadding;
        _groupFilterEmployees.Top = 90;
        _groupFilterEmployees.Width = contentWidth;

        _chkFilterAllEmployees.Left = 16;
        _chkFilterAllEmployees.Top = 30;

        int filterListTop = 24;
        int filterListHeight = Math.Max(60, (_chkFilterEmployees.ItemHeight * 2) + 12);
        int filterListLeft = 220;
        int filterListWidth = _groupFilterEmployees.ClientSize.Width - filterListLeft - 16;
        if (filterListWidth < 260)
        {
            filterListWidth = 260;
            filterListLeft = _groupFilterEmployees.ClientSize.Width - filterListWidth - 16;
            if (filterListLeft < 16)
            {
                filterListLeft = 16;
            }
        }

        _chkFilterEmployees.Left = filterListLeft;
        _chkFilterEmployees.Top = filterListTop;
        _chkFilterEmployees.Width = filterListWidth;
        _chkFilterEmployees.Height = filterListHeight;

        _lblFilterDescription.Left = 16;
        _lblFilterDescription.Top = _chkFilterEmployees.Bottom + 8;
        _lblFilterDescription.MaximumSize = new Size(_groupFilterEmployees.ClientSize.Width - 32, 0);

        _groupFilterEmployees.Height = _lblFilterDescription.Bottom + 12;

        int contentTopAfterCreate;

        if (_viewOnlyMode)
        {
            _groupCreateProject.Visible = false;
            contentTopAfterCreate = _groupFilterEmployees.Bottom + spacing;
        }
        else
        {
            _groupCreateProject.Visible = true;
            _groupCreateProject.Left = sidePadding;
            _groupCreateProject.Top = _groupFilterEmployees.Bottom + spacing;
            _groupCreateProject.Width = contentWidth;

            int createGroupHeight = compactVertical ? 205 : 220;
            _groupCreateProject.Height = createGroupHeight;

            int createRightPadding = 16;
            int createButtonGap = 10;
            int employeeListLeft = 705;
            int employeeListTop = 53;
            int employeeButtonsWidth = _btnSelectAllEmployees.Width;
            int employeeListWidth = _groupCreateProject.ClientSize.Width - employeeListLeft - createRightPadding - createButtonGap - employeeButtonsWidth;
            int minEmployeeListLeft = _cboCreateLeader.Right + 14;

            if (employeeListWidth < 180)
            {
                employeeListWidth = 180;
                employeeListLeft = _groupCreateProject.ClientSize.Width - createRightPadding - createButtonGap - employeeButtonsWidth - employeeListWidth;
                if (employeeListLeft < minEmployeeListLeft)
                {
                    employeeListLeft = minEmployeeListLeft;
                    employeeListWidth = _groupCreateProject.ClientSize.Width - employeeListLeft - createRightPadding - createButtonGap - employeeButtonsWidth;
                }
            }

            if (employeeListWidth < 120)
            {
                employeeListWidth = 120;
            }

            if (employeeListWidth > 420)
            {
                employeeListWidth = 420;
                employeeListLeft = _groupCreateProject.ClientSize.Width - createRightPadding - createButtonGap - employeeButtonsWidth - employeeListWidth;
            }

            _chkInvolvedEmployees.Left = employeeListLeft;
            _chkInvolvedEmployees.Top = employeeListTop;
            _chkInvolvedEmployees.Width = employeeListWidth;

            int buttonsLeft = _chkInvolvedEmployees.Right + createButtonGap;
            int maxButtonsLeft = _groupCreateProject.ClientSize.Width - createRightPadding - employeeButtonsWidth;
            if (buttonsLeft > maxButtonsLeft)
            {
                int overflow = buttonsLeft - maxButtonsLeft;
                employeeListWidth = _chkInvolvedEmployees.Width - overflow;
                if (employeeListWidth < 120)
                {
                    employeeListWidth = 120;
                }

                _chkInvolvedEmployees.Width = employeeListWidth;
                buttonsLeft = _chkInvolvedEmployees.Right + createButtonGap;
            }

            _btnSelectAllEmployees.Left = buttonsLeft;
            _btnSelectAllEmployees.Top = employeeListTop;

            _btnClearEmployees.Left = _btnSelectAllEmployees.Left;
            _btnClearEmployees.Top = _btnSelectAllEmployees.Bottom + 6;

            _btnCreateProject.Top = _groupCreateProject.ClientSize.Height - _btnCreateProject.Height - 10;
            _btnCreateProject.Left = _groupCreateProject.ClientSize.Width - _btnCreateProject.Width - createRightPadding;

            int employeeListHeight = _btnCreateProject.Top - employeeListTop - 8;
            if (employeeListHeight < 70)
            {
                employeeListHeight = 70;
            }
            _chkInvolvedEmployees.Height = employeeListHeight;

            contentTopAfterCreate = _groupCreateProject.Bottom + spacing;
        }

        _gridProjects.Left = sidePadding;
        _gridProjects.Top = contentTopAfterCreate;
        _gridProjects.Width = contentWidth;

        int detailTopOffsetFromAction = _viewOnlyMode ? 40 : 46;
        int reservedBelowProjectGrid = 8
            + detailTopOffsetFromAction
            + _lblProjectSummary.Height
            + 6
            + summaryHeight
            + 8
            + _lblEmployeeSection.Height
            + 6
            + projectEmployeesHeight
            + 8
            + _lblTaskSection.Height
            + 6
            + minTaskHeight
            + 20;

        int gridProjectHeight = ClientSize.Height - _gridProjects.Top - reservedBelowProjectGrid;
        if (gridProjectHeight < minProjectGridHeight)
        {
            gridProjectHeight = minProjectGridHeight;
        }
        _gridProjects.Height = gridProjectHeight;

        int actionTop = _gridProjects.Bottom + 8;

        if (!_viewOnlyMode)
        {
            _lblProjectStatus.Left = sidePadding;
            _lblProjectStatus.Top = actionTop + 8;

            _cboProjectStatus.Left = _lblProjectStatus.Right + 10;
            _cboProjectStatus.Top = actionTop + 4;

            _btnUpdateStatus.Left = _cboProjectStatus.Right + 12;
            _btnUpdateStatus.Top = actionTop + 2;
        }

        int right = contentRight;

        if (_btnDelete.Visible)
        {
            _btnDelete.Left = right - _btnDelete.Width;
            _btnDelete.Top = actionTop + 2;
            right = _btnDelete.Left - spacing;
        }

        if (_btnRefresh.Visible)
        {
            _btnRefresh.Left = right - _btnRefresh.Width;
            _btnRefresh.Top = actionTop + 2;
            right = _btnRefresh.Left - spacing;
        }

        if (_btnCreateTask.Visible)
        {
            _btnCreateTask.Left = right - _btnCreateTask.Width;
            _btnCreateTask.Top = actionTop + 2;
            right = _btnCreateTask.Left - spacing;
        }

        int detailTop = actionTop + detailTopOffsetFromAction;

        _lblProjectSummary.Left = sidePadding;
        _lblProjectSummary.Top = detailTop;

        _txtProjectSummary.Left = sidePadding;
        _txtProjectSummary.Top = _lblProjectSummary.Bottom + 6;
        _txtProjectSummary.Width = contentWidth;
        _txtProjectSummary.Height = summaryHeight;

        _lblEmployeeSection.Left = sidePadding;
        _lblEmployeeSection.Top = _txtProjectSummary.Bottom + 8;

        _gridProjectEmployees.Left = sidePadding;
        _gridProjectEmployees.Top = _lblEmployeeSection.Bottom + 6;
        _gridProjectEmployees.Width = contentWidth;
        _gridProjectEmployees.Height = projectEmployeesHeight;

        _lblTaskSection.Left = sidePadding;
        _lblTaskSection.Top = _gridProjectEmployees.Bottom + 8;

        _gridTasks.Left = sidePadding;
        _gridTasks.Top = _lblTaskSection.Bottom + 6;
        _gridTasks.Width = contentWidth;
        _gridTasks.Height = ClientSize.Height - _gridTasks.Top - 20;

        if (_gridTasks.Height < minTaskHeight)
        {
            _gridTasks.Height = minTaskHeight;
        }
    }

    private void LoadStatusOptions()
    {
        _cboProjectStatus.Items.Clear();
        _cboCreateStatus.Items.Clear();

        List<EnumStatus> statuses = _projectController.GetStatusOptions();
        for (int i = 0; i < statuses.Count; i++)
        {
            _cboProjectStatus.Items.Add(statuses[i]);
            _cboCreateStatus.Items.Add(statuses[i]);
        }

        if (_cboProjectStatus.Items.Count > 0)
        {
            _cboProjectStatus.SelectedIndex = 0;
        }

        if (_cboCreateStatus.Items.Count > 0)
        {
            _cboCreateStatus.SelectedIndex = 0;
        }
    }

    private void LoadLeaderOptions()
    {
        _cboCreateLeader.Items.Clear();

        List<Employee> leaders = _projectController.GetLeaders();
        for (int i = 0; i < leaders.Count; i++)
        {
            _cboCreateLeader.Items.Add(leaders[i]);
        }

        if (_cboCreateLeader.Items.Count > 0)
        {
            _cboCreateLeader.SelectedIndex = 0;
        }
    }

    private void LoadEmployeeOptions()
    {
        _chkInvolvedEmployees.Items.Clear();

        List<Employee> employees = _projectController.GetEmployees();
        for (int i = 0; i < employees.Count; i++)
        {
            _chkInvolvedEmployees.Items.Add(employees[i], false);
        }

        EnsureLeaderCheckedInEmployeeList();
    }

    private void LoadFilterEmployees()
    {
        _chkFilterEmployees.Items.Clear();

        List<Employee> employees = _projectController.GetEmployees();
        for (int i = 0; i < employees.Count; i++)
        {
            _chkFilterEmployees.Items.Add(employees[i], false);
        }

        _chkFilterAllEmployees.Checked = true;
    }

    private void EnsureLeaderCheckedInEmployeeList()
    {
        if (_cboCreateLeader.SelectedItem == null)
        {
            return;
        }

        Employee? selectedLeader = _cboCreateLeader.SelectedItem as Employee;
        if (selectedLeader == null)
        {
            return;
        }

        for (int i = 0; i < _chkInvolvedEmployees.Items.Count; i++)
        {
            Employee? employee = _chkInvolvedEmployees.Items[i] as Employee;
            if (employee == null)
            {
                continue;
            }

            if (employee.Id == selectedLeader.Id)
            {
                _chkInvolvedEmployees.SetItemChecked(i, true);
                return;
            }
        }
    }

    private List<Project> GetFilteredProjects(List<Project> allProjects)
    {
        List<Project> filtered = new List<Project>();

        if (_chkFilterAllEmployees.Checked)
        {
            for (int i = 0; i < allProjects.Count; i++)
            {
                filtered.Add(allProjects[i]);
            }

            return filtered;
        }

        List<string> selectedEmployeeIds = new List<string>();
        for (int i = 0; i < _chkFilterEmployees.CheckedItems.Count; i++)
        {
            Employee? employee = _chkFilterEmployees.CheckedItems[i] as Employee;
            if (employee != null)
            {
                selectedEmployeeIds.Add(employee.Id);
            }
        }

        if (selectedEmployeeIds.Count == 0)
        {
            return filtered;
        }

        for (int i = 0; i < allProjects.Count; i++)
        {
            Project project = allProjects[i];
            bool match = false;

            if (project.Employees != null)
            {
                for (int j = 0; j < project.Employees.Count; j++)
                {
                    Employee employee = project.Employees[j];
                    for (int k = 0; k < selectedEmployeeIds.Count; k++)
                    {
                        if (employee.Id == selectedEmployeeIds[k])
                        {
                            match = true;
                            break;
                        }
                    }

                    if (match)
                    {
                        break;
                    }
                }
            }

            if (match)
            {
                filtered.Add(project);
            }
        }

        return filtered;
    }

    private void LoadProjectsToGrid()
    {
        _gridProjects.Rows.Clear();

        List<Project> projects = _projectController.GetProjects();
        List<Project> filteredProjects = GetFilteredProjects(projects);

        for (int i = 0; i < filteredProjects.Count; i++)
        {
            Project project = filteredProjects[i];

            string leaderInfo = string.Empty;
            if (project.Leader != null)
            {
                leaderInfo = project.Leader.Name + " - " + project.Leader.GetRole();
            }

            int taskCount = 0;
            if (project.Tasks != null)
            {
                taskCount = project.Tasks.Count;
            }

            _gridProjects.Rows.Add(
                project.ProjectId,
                project.ProjectName,
                project.Description,
                project.Status.ToString(),
                project.StartDate.ToShortDateString(),
                project.EndDate.ToShortDateString(),
                leaderInfo,
                taskCount);
        }

        if (_gridProjects.Rows.Count > 0)
        {
            _gridProjects.Rows[0].Selected = true;
            SyncStatusFromSelectedProject();
            LoadProjectDetailForSelectedProject();
            LoadTasksForSelectedProject();
        }
        else
        {
            ClearProjectDetail();
            _gridTasks.Rows.Clear();
            _lblTaskSection.Text = "Tasks (select a project to view tasks)";
        }
    }

    private string GetSelectedProjectId()
    {
        if (_gridProjects.SelectedRows.Count == 0)
        {
            return string.Empty;
        }

        DataGridViewRow selectedRow = _gridProjects.SelectedRows[0];
        object? cellValue = selectedRow.Cells["ProjectId"].Value;

        if (cellValue == null)
        {
            return string.Empty;
        }

        return cellValue.ToString() ?? string.Empty;
    }

    private Project? GetProjectById(string projectId)
    {
        List<Project> projects = _projectController.GetProjects();

        for (int i = 0; i < projects.Count; i++)
        {
            if (projects[i].ProjectId == projectId)
            {
                return projects[i];
            }
        }

        return null;
    }

    private void SyncStatusFromSelectedProject()
    {
        if (_viewOnlyMode)
        {
            return;
        }

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            return;
        }

        Project? project = GetProjectById(projectId);
        if (project == null)
        {
            return;
        }

        for (int i = 0; i < _cboProjectStatus.Items.Count; i++)
        {
            object? item = _cboProjectStatus.Items[i];
            if (item != null)
            {
                EnumStatus status = (EnumStatus)item;
                if (status == project.Status)
                {
                    _cboProjectStatus.SelectedIndex = i;
                    break;
                }
            }
        }
    }

    private void LoadProjectDetailForSelectedProject()
    {
        _gridProjectEmployees.Rows.Clear();

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            ClearProjectDetail();
            return;
        }

        Project? project = GetProjectById(projectId);
        if (project == null)
        {
            ClearProjectDetail();
            return;
        }

        string leaderInfo = "N/A";
        if (project.Leader != null)
        {
            leaderInfo = project.Leader.Name + " (" + project.Leader.GetRole() + ")";
        }

        string summary = "Project ID: " + project.ProjectId + Environment.NewLine
            + "Project Name: " + project.ProjectName + Environment.NewLine
            + "Status: " + project.Status + " | Leader: " + leaderInfo + Environment.NewLine
            + "Timeline: " + project.StartDate.ToShortDateString() + " - " + project.EndDate.ToShortDateString() + Environment.NewLine
            + "Description: " + project.Description;

        _txtProjectSummary.Text = summary;

        if (project.Employees != null)
        {
            for (int i = 0; i < project.Employees.Count; i++)
            {
                Employee employee = project.Employees[i];
                _gridProjectEmployees.Rows.Add(employee.Id, employee.Name, employee.GetRole());
            }
        }
    }

    private void ClearProjectDetail()
    {
        _txtProjectSummary.Text = "No project selected.";
        _gridProjectEmployees.Rows.Clear();
    }

    private void LoadTasksForSelectedProject()
    {
        _gridTasks.Rows.Clear();

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            _lblTaskSection.Text = "Tasks (select a project to view tasks)";
            return;
        }

        _lblTaskSection.Text = "Tasks for Project: " + projectId;

        List<TaskItem> tasks = _projectController.GetTasksByProjectId(projectId);
        for (int i = 0; i < tasks.Count; i++)
        {
            TaskItem task = tasks[i];
            string assigneeName = string.Empty;

            if (task.Assignee != null)
            {
                assigneeName = task.Assignee.Name + " - " + task.Assignee.GetRole();
            }

            _gridTasks.Rows.Add(
                task.TaskId,
                task.Title,
                task.Description,
                task.Status.ToString(),
                assigneeName);
        }
    }

    private void ChkFilterAllEmployees_CheckedChanged(object? sender, EventArgs e)
    {
        bool isAll = _chkFilterAllEmployees.Checked;

        _chkFilterEmployees.Enabled = !isAll;

        if (isAll)
        {
            for (int i = 0; i < _chkFilterEmployees.Items.Count; i++)
            {
                _chkFilterEmployees.SetItemChecked(i, false);
            }
        }

        LoadProjectsToGrid();
    }

    private void ChkFilterEmployees_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (_chkFilterAllEmployees.Checked)
        {
            return;
        }

        BeginInvoke(new MethodInvoker(TriggerFilterRefresh));
    }

    private void TriggerFilterRefresh()
    {
        LoadProjectsToGrid();
    }

    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        LoadProjectsToGrid();
    }

    private void BtnCreateProject_Click(object? sender, EventArgs e)
    {
        if (_viewOnlyMode)
        {
            MessageBox.Show("View mode does not allow create project.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_cboCreateStatus.SelectedItem == null)
        {
            MessageBox.Show("Please select project status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cboCreateLeader.SelectedItem == null)
        {
            MessageBox.Show("Please select project leader.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EnumStatus selectedStatus = (EnumStatus)_cboCreateStatus.SelectedItem;
        Employee? selectedLeader = _cboCreateLeader.SelectedItem as Employee;

        if (selectedLeader == null)
        {
            MessageBox.Show("Invalid leader selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        List<Employee> involvedEmployees = new List<Employee>();
        for (int i = 0; i < _chkInvolvedEmployees.CheckedItems.Count; i++)
        {
            Employee? employee = _chkInvolvedEmployees.CheckedItems[i] as Employee;
            if (employee != null)
            {
                involvedEmployees.Add(employee);
            }
        }

        string message;
        bool created = _projectController.CreateProject(
            _txtProjectName.Text,
            _txtProjectDescription.Text,
            _dtpProjectStartDate.Value.Date,
            _dtpProjectEndDate.Value.Date,
            selectedStatus,
            selectedLeader,
            involvedEmployees,
            out message);

        if (created)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetCreateProjectForm();
            LoadProjectsToGrid();
        }
        else
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnSelectAllEmployees_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < _chkInvolvedEmployees.Items.Count; i++)
        {
            _chkInvolvedEmployees.SetItemChecked(i, true);
        }
    }

    private void BtnClearEmployees_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < _chkInvolvedEmployees.Items.Count; i++)
        {
            _chkInvolvedEmployees.SetItemChecked(i, false);
        }

        EnsureLeaderCheckedInEmployeeList();
    }

    private void CboCreateLeader_SelectedIndexChanged(object? sender, EventArgs e)
    {
        EnsureLeaderCheckedInEmployeeList();
    }

    private void ResetCreateProjectForm()
    {
        _txtProjectName.Text = string.Empty;
        _txtProjectDescription.Text = string.Empty;
        _dtpProjectStartDate.Value = DateTime.Today;
        _dtpProjectEndDate.Value = DateTime.Today;

        if (_cboCreateStatus.Items.Count > 0)
        {
            _cboCreateStatus.SelectedIndex = 0;
        }

        if (_cboCreateLeader.Items.Count > 0)
        {
            _cboCreateLeader.SelectedIndex = 0;
        }

        for (int i = 0; i < _chkInvolvedEmployees.Items.Count; i++)
        {
            _chkInvolvedEmployees.SetItemChecked(i, false);
        }

        EnsureLeaderCheckedInEmployeeList();
    }

    private void BtnUpdateStatus_Click(object? sender, EventArgs e)
    {
        if (_viewOnlyMode)
        {
            MessageBox.Show("View mode does not allow status update.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            MessageBox.Show("Please select a project.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cboProjectStatus.SelectedItem == null)
        {
            MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EnumStatus selectedStatus = (EnumStatus)_cboProjectStatus.SelectedItem;
        string message;
        bool updated = _projectController.UpdateProjectStatus(projectId, selectedStatus, out message);

        if (updated)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProjectsToGrid();
        }
        else
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnCreateTask_Click(object? sender, EventArgs e)
    {
        if (_viewOnlyMode)
        {
            MessageBox.Show("View mode does not allow creating task.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            MessageBox.Show("Please select a project first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (CreateTaskForm createTaskForm = new CreateTaskForm(_projectController, projectId))
        {
            DialogResult result = createTaskForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                LoadProjectsToGrid();
            }
        }
    }

    private void GridProjects_SelectionChanged(object? sender, EventArgs e)
    {
        SyncStatusFromSelectedProject();
        LoadProjectDetailForSelectedProject();
        LoadTasksForSelectedProject();
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (_viewOnlyMode)
        {
            MessageBox.Show("View mode does not allow deleting project.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string projectId = GetSelectedProjectId();
        if (string.IsNullOrWhiteSpace(projectId))
        {
            MessageBox.Show("Please select a project to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult confirm = MessageBox.Show(
            "Are you sure you want to delete this project?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
        {
            return;
        }

        string message;
        bool deleted = _projectController.DeleteProject(projectId, out message);

        if (deleted)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProjectsToGrid();
        }
        else
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
