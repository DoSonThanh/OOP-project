using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class ProjectListForm
{
    private GroupBox _groupFilterEmployees = null!;
    private CheckBox _chkFilterAllEmployees = null!;
    private CheckedListBox _chkFilterEmployees = null!;
    private Label _lblFilterDescription = null!;

    private GroupBox _groupCreateProject = null!;
    private TextBox _txtProjectName = null!;
    private TextBox _txtProjectDescription = null!;
    private DateTimePicker _dtpProjectStartDate = null!;
    private DateTimePicker _dtpProjectEndDate = null!;
    private ComboBox _cboCreateStatus = null!;
    private ComboBox _cboCreateLeader = null!;
    private CheckedListBox _chkInvolvedEmployees = null!;
    private Button _btnCreateProject = null!;
    private Button _btnSelectAllEmployees = null!;
    private Button _btnClearEmployees = null!;

    private DataGridView _gridProjects = null!;
    private Button _btnDelete = null!;
    private Button _btnRefresh = null!;
    private Button _btnUpdateStatus = null!;
    private Button _btnCreateTask = null!;
    private ComboBox _cboProjectStatus = null!;
    private Label _lblProjectStatus = null!;

    private Label _lblProjectSummary = null!;
    private TextBox _txtProjectSummary = null!;
    private Label _lblEmployeeSection = null!;
    private DataGridView _gridProjectEmployees = null!;

    private Label _lblTaskSection = null!;
    private DataGridView _gridTasks = null!;

    private void InitializeComponent()
    {
        Text = _viewOnlyMode ? "Project Viewer" : "Project Dashboard";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimumSize = new Size(1120, 720);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = true;
        Width = 1260;
        Height = 820;
        BackColor = Color.FromArgb(245, 248, 252);

        Panel headerPanel = new Panel();
        headerPanel.BackColor = Color.FromArgb(31, 78, 121);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Height = 72;

        Label lblHeader = new Label();
        lblHeader.Text = _viewOnlyMode ? "Project Viewer Dashboard" : "Project Management Dashboard";
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeader.ForeColor = Color.White;
        lblHeader.Location = new Point(20, 20);
        headerPanel.Controls.Add(lblHeader);

        _groupFilterEmployees = new GroupBox();
        _groupFilterEmployees.Text = "Project Filter by Employee";
        _groupFilterEmployees.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _groupFilterEmployees.BackColor = Color.FromArgb(241, 247, 252);
        _groupFilterEmployees.Location = new Point(20, 90);
        _groupFilterEmployees.Width = 1200;
        _groupFilterEmployees.Height = 110;
        _groupFilterEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        _chkFilterAllEmployees = new CheckBox();
        _chkFilterAllEmployees.Text = "All Employees";
        _chkFilterAllEmployees.AutoSize = true;
        _chkFilterAllEmployees.Location = new Point(16, 30);
        _chkFilterAllEmployees.CheckedChanged += ChkFilterAllEmployees_CheckedChanged;

        _lblFilterDescription = new Label();
        _lblFilterDescription.Text = "Uncheck All Employees and tick one or many employees to filter related projects.";
        _lblFilterDescription.AutoSize = true;
        _lblFilterDescription.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        _lblFilterDescription.Location = new Point(16, 65);

        _chkFilterEmployees = new CheckedListBox();
        _chkFilterEmployees.Location = new Point(220, 22);
        _chkFilterEmployees.Width = 950;
        _chkFilterEmployees.Height = 72;
        _chkFilterEmployees.CheckOnClick = true;
        _chkFilterEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _chkFilterEmployees.ItemCheck += ChkFilterEmployees_ItemCheck;

        _groupFilterEmployees.Controls.Add(_chkFilterAllEmployees);
        _groupFilterEmployees.Controls.Add(_lblFilterDescription);
        _groupFilterEmployees.Controls.Add(_chkFilterEmployees);

        _groupCreateProject = new GroupBox();
        _groupCreateProject.Text = "Create New Project";
        _groupCreateProject.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _groupCreateProject.BackColor = Color.FromArgb(241, 247, 252);
        _groupCreateProject.Location = new Point(20, 210);
        _groupCreateProject.Width = 1200;
        _groupCreateProject.Height = 185;
        _groupCreateProject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblProjectName = new Label();
        lblProjectName.Text = "Name:";
        lblProjectName.AutoSize = true;
        lblProjectName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblProjectName.Location = new Point(16, 33);

        _txtProjectName = new TextBox();
        _txtProjectName.Location = new Point(95, 29);
        _txtProjectName.Width = 300;
        _txtProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        Label lblProjectDescription = new Label();
        lblProjectDescription.Text = "Description:";
        lblProjectDescription.AutoSize = true;
        lblProjectDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblProjectDescription.Location = new Point(16, 71);

        _txtProjectDescription = new TextBox();
        _txtProjectDescription.Location = new Point(95, 67);
        _txtProjectDescription.Width = 300;
        _txtProjectDescription.Height = 72;
        _txtProjectDescription.Multiline = true;
        _txtProjectDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        Label lblStart = new Label();
        lblStart.Text = "Start:";
        lblStart.AutoSize = true;
        lblStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStart.Location = new Point(16, 150);

        _dtpProjectStartDate = new DateTimePicker();
        _dtpProjectStartDate.Location = new Point(62, 146);
        _dtpProjectStartDate.Width = 120;
        _dtpProjectStartDate.Format = DateTimePickerFormat.Short;

        Label lblEnd = new Label();
        lblEnd.Text = "End:";
        lblEnd.AutoSize = true;
        lblEnd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEnd.Location = new Point(194, 150);

        _dtpProjectEndDate = new DateTimePicker();
        _dtpProjectEndDate.Location = new Point(233, 146);
        _dtpProjectEndDate.Width = 120;
        _dtpProjectEndDate.Format = DateTimePickerFormat.Short;

        Label lblCreateStatus = new Label();
        lblCreateStatus.Text = "Status:";
        lblCreateStatus.AutoSize = true;
        lblCreateStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCreateStatus.Location = new Point(430, 33);

        _cboCreateStatus = new ComboBox();
        _cboCreateStatus.Location = new Point(492, 29);
        _cboCreateStatus.Width = 180;
        _cboCreateStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        Label lblCreateLeader = new Label();
        lblCreateLeader.Text = "Leader:";
        lblCreateLeader.AutoSize = true;
        lblCreateLeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCreateLeader.Location = new Point(430, 71);

        _cboCreateLeader = new ComboBox();
        _cboCreateLeader.Location = new Point(492, 67);
        _cboCreateLeader.Width = 180;
        _cboCreateLeader.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboCreateLeader.SelectedIndexChanged += CboCreateLeader_SelectedIndexChanged;

        Label lblEmployees = new Label();
        lblEmployees.Text = "Involved Employees:";
        lblEmployees.AutoSize = true;
        lblEmployees.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmployees.Location = new Point(705, 29);

        _chkInvolvedEmployees = new CheckedListBox();
        _chkInvolvedEmployees.Location = new Point(705, 53);
        _chkInvolvedEmployees.Width = 330;
        _chkInvolvedEmployees.Height = 105;
        _chkInvolvedEmployees.CheckOnClick = true;
        _chkInvolvedEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        _btnSelectAllEmployees = new Button();
        _btnSelectAllEmployees.Text = "Select All";
        _btnSelectAllEmployees.Width = 92;
        _btnSelectAllEmployees.Height = 28;
        _btnSelectAllEmployees.Location = new Point(1048, 53);
        _btnSelectAllEmployees.BackColor = Color.White;
        _btnSelectAllEmployees.FlatStyle = FlatStyle.Flat;
        _btnSelectAllEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnSelectAllEmployees.Click += BtnSelectAllEmployees_Click;

        _btnClearEmployees = new Button();
        _btnClearEmployees.Text = "Clear";
        _btnClearEmployees.Width = 92;
        _btnClearEmployees.Height = 28;
        _btnClearEmployees.Location = new Point(1048, 87);
        _btnClearEmployees.BackColor = Color.White;
        _btnClearEmployees.FlatStyle = FlatStyle.Flat;
        _btnClearEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnClearEmployees.Click += BtnClearEmployees_Click;

        _btnCreateProject = new Button();
        _btnCreateProject.Text = "Create Project";
        _btnCreateProject.Width = 200;
        _btnCreateProject.Height = 32;
        _btnCreateProject.Location = new Point(940, 147);
        _btnCreateProject.BackColor = Color.FromArgb(46, 125, 50);
        _btnCreateProject.ForeColor = Color.White;
        _btnCreateProject.FlatStyle = FlatStyle.Flat;
        _btnCreateProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnCreateProject.Click += BtnCreateProject_Click;

        _groupCreateProject.Controls.Add(lblProjectName);
        _groupCreateProject.Controls.Add(_txtProjectName);
        _groupCreateProject.Controls.Add(lblProjectDescription);
        _groupCreateProject.Controls.Add(_txtProjectDescription);
        _groupCreateProject.Controls.Add(lblStart);
        _groupCreateProject.Controls.Add(_dtpProjectStartDate);
        _groupCreateProject.Controls.Add(lblEnd);
        _groupCreateProject.Controls.Add(_dtpProjectEndDate);
        _groupCreateProject.Controls.Add(lblCreateStatus);
        _groupCreateProject.Controls.Add(_cboCreateStatus);
        _groupCreateProject.Controls.Add(lblCreateLeader);
        _groupCreateProject.Controls.Add(_cboCreateLeader);
        _groupCreateProject.Controls.Add(lblEmployees);
        _groupCreateProject.Controls.Add(_chkInvolvedEmployees);
        _groupCreateProject.Controls.Add(_btnSelectAllEmployees);
        _groupCreateProject.Controls.Add(_btnClearEmployees);
        _groupCreateProject.Controls.Add(_btnCreateProject);

        _gridProjects = new DataGridView();
        _gridProjects.Location = new Point(20, 405);
        _gridProjects.Width = 1200;
        _gridProjects.Height = 180;
        _gridProjects.AllowUserToAddRows = false;
        _gridProjects.AllowUserToDeleteRows = false;
        _gridProjects.ReadOnly = true;
        _gridProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridProjects.MultiSelect = false;
        _gridProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridProjects.RowHeadersVisible = false;
        _gridProjects.BackgroundColor = Color.White;
        _gridProjects.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _gridProjects.SelectionChanged += GridProjects_SelectionChanged;

        DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
        colId.Name = "ProjectId";
        colId.HeaderText = "Project ID";
        _gridProjects.Columns.Add(colId);

        DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
        colName.Name = "ProjectName";
        colName.HeaderText = "Name";
        _gridProjects.Columns.Add(colName);

        DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
        colDescription.Name = "Description";
        colDescription.HeaderText = "Description";
        _gridProjects.Columns.Add(colDescription);

        DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
        colStatus.Name = "Status";
        colStatus.HeaderText = "Status";
        _gridProjects.Columns.Add(colStatus);

        DataGridViewTextBoxColumn colStartDate = new DataGridViewTextBoxColumn();
        colStartDate.Name = "StartDate";
        colStartDate.HeaderText = "Start Date";
        _gridProjects.Columns.Add(colStartDate);

        DataGridViewTextBoxColumn colEndDate = new DataGridViewTextBoxColumn();
        colEndDate.Name = "EndDate";
        colEndDate.HeaderText = "End Date";
        _gridProjects.Columns.Add(colEndDate);

        DataGridViewTextBoxColumn colLeader = new DataGridViewTextBoxColumn();
        colLeader.Name = "Leader";
        colLeader.HeaderText = "Leader";
        _gridProjects.Columns.Add(colLeader);

        DataGridViewTextBoxColumn colTaskCount = new DataGridViewTextBoxColumn();
        colTaskCount.Name = "TaskCount";
        colTaskCount.HeaderText = "Tasks";
        _gridProjects.Columns.Add(colTaskCount);

        _lblProjectStatus = new Label();
        _lblProjectStatus.Text = "Update Status:";
        _lblProjectStatus.AutoSize = true;
        _lblProjectStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _lblProjectStatus.Location = new Point(20, 600);

        _cboProjectStatus = new ComboBox();
        _cboProjectStatus.Location = new Point(130, 596);
        _cboProjectStatus.Width = 190;
        _cboProjectStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        _btnUpdateStatus = new Button();
        _btnUpdateStatus.Text = "Apply Status";
        _btnUpdateStatus.Width = 120;
        _btnUpdateStatus.Height = 32;
        _btnUpdateStatus.Location = new Point(334, 593);
        _btnUpdateStatus.BackColor = Color.FromArgb(31, 78, 121);
        _btnUpdateStatus.ForeColor = Color.White;
        _btnUpdateStatus.FlatStyle = FlatStyle.Flat;
        _btnUpdateStatus.Click += BtnUpdateStatus_Click;

        _btnCreateTask = new Button();
        _btnCreateTask.Text = "Create Task + Assign";
        _btnCreateTask.Width = 180;
        _btnCreateTask.Height = 32;
        _btnCreateTask.Location = new Point(470, 593);
        _btnCreateTask.BackColor = Color.FromArgb(46, 125, 50);
        _btnCreateTask.ForeColor = Color.White;
        _btnCreateTask.FlatStyle = FlatStyle.Flat;
        _btnCreateTask.Click += BtnCreateTask_Click;

        _btnRefresh = new Button();
        _btnRefresh.Text = "Refresh";
        _btnRefresh.Width = 120;
        _btnRefresh.Height = 32;
        _btnRefresh.Location = new Point(960, 593);
        _btnRefresh.BackColor = Color.White;
        _btnRefresh.FlatStyle = FlatStyle.Flat;
        _btnRefresh.Click += BtnRefresh_Click;

        _btnDelete = new Button();
        _btnDelete.Text = "Delete";
        _btnDelete.Width = 120;
        _btnDelete.Height = 32;
        _btnDelete.Location = new Point(1100, 593);
        _btnDelete.BackColor = Color.FromArgb(183, 28, 28);
        _btnDelete.ForeColor = Color.White;
        _btnDelete.FlatStyle = FlatStyle.Flat;
        _btnDelete.Click += BtnDelete_Click;

        _lblProjectSummary = new Label();
        _lblProjectSummary.Text = "Selected Project Details";
        _lblProjectSummary.AutoSize = true;
        _lblProjectSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _lblProjectSummary.Location = new Point(20, 640);

        _txtProjectSummary = new TextBox();
        _txtProjectSummary.Location = new Point(20, 666);
        _txtProjectSummary.Width = 1200;
        _txtProjectSummary.Height = 72;
        _txtProjectSummary.Multiline = true;
        _txtProjectSummary.ReadOnly = true;
        _txtProjectSummary.ScrollBars = ScrollBars.Vertical;
        _txtProjectSummary.BackColor = Color.White;
        _txtProjectSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        _lblEmployeeSection = new Label();
        _lblEmployeeSection.Text = "Employees in Selected Project";
        _lblEmployeeSection.AutoSize = true;
        _lblEmployeeSection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _lblEmployeeSection.Location = new Point(20, 746);

        _gridProjectEmployees = new DataGridView();
        _gridProjectEmployees.Location = new Point(20, 772);
        _gridProjectEmployees.Width = 1200;
        _gridProjectEmployees.Height = 90;
        _gridProjectEmployees.AllowUserToAddRows = false;
        _gridProjectEmployees.AllowUserToDeleteRows = false;
        _gridProjectEmployees.ReadOnly = true;
        _gridProjectEmployees.MultiSelect = false;
        _gridProjectEmployees.RowHeadersVisible = false;
        _gridProjectEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridProjectEmployees.BackgroundColor = Color.White;
        _gridProjectEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        DataGridViewTextBoxColumn empId = new DataGridViewTextBoxColumn();
        empId.Name = "EmployeeId";
        empId.HeaderText = "Employee ID";
        _gridProjectEmployees.Columns.Add(empId);

        DataGridViewTextBoxColumn empName = new DataGridViewTextBoxColumn();
        empName.Name = "EmployeeName";
        empName.HeaderText = "Name";
        _gridProjectEmployees.Columns.Add(empName);

        DataGridViewTextBoxColumn empRole = new DataGridViewTextBoxColumn();
        empRole.Name = "EmployeeRole";
        empRole.HeaderText = "Role";
        _gridProjectEmployees.Columns.Add(empRole);

        _lblTaskSection = new Label();
        _lblTaskSection.Text = "Tasks (select a project to view tasks)";
        _lblTaskSection.AutoSize = true;
        _lblTaskSection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _lblTaskSection.Location = new Point(20, 872);

        _gridTasks = new DataGridView();
        _gridTasks.Location = new Point(20, 898);
        _gridTasks.Width = 1200;
        _gridTasks.Height = 130;
        _gridTasks.AllowUserToAddRows = false;
        _gridTasks.AllowUserToDeleteRows = false;
        _gridTasks.ReadOnly = true;
        _gridTasks.MultiSelect = false;
        _gridTasks.RowHeadersVisible = false;
        _gridTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridTasks.BackgroundColor = Color.White;
        _gridTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        DataGridViewTextBoxColumn taskId = new DataGridViewTextBoxColumn();
        taskId.Name = "TaskId";
        taskId.HeaderText = "Task ID";
        _gridTasks.Columns.Add(taskId);

        DataGridViewTextBoxColumn taskTitle = new DataGridViewTextBoxColumn();
        taskTitle.Name = "TaskTitle";
        taskTitle.HeaderText = "Title";
        _gridTasks.Columns.Add(taskTitle);

        DataGridViewTextBoxColumn taskDescription = new DataGridViewTextBoxColumn();
        taskDescription.Name = "TaskDescription";
        taskDescription.HeaderText = "Description";
        _gridTasks.Columns.Add(taskDescription);

        DataGridViewTextBoxColumn taskStatus = new DataGridViewTextBoxColumn();
        taskStatus.Name = "TaskStatus";
        taskStatus.HeaderText = "Status";
        _gridTasks.Columns.Add(taskStatus);

        DataGridViewTextBoxColumn taskAssignee = new DataGridViewTextBoxColumn();
        taskAssignee.Name = "TaskAssignee";
        taskAssignee.HeaderText = "Assignee";
        _gridTasks.Columns.Add(taskAssignee);

        Controls.Add(headerPanel);
        Controls.Add(_groupFilterEmployees);
        Controls.Add(_groupCreateProject);
        Controls.Add(_gridProjects);
        Controls.Add(_lblProjectStatus);
        Controls.Add(_cboProjectStatus);
        Controls.Add(_btnUpdateStatus);
        Controls.Add(_btnCreateTask);
        Controls.Add(_btnRefresh);
        Controls.Add(_btnDelete);
        Controls.Add(_lblProjectSummary);
        Controls.Add(_txtProjectSummary);
        Controls.Add(_lblEmployeeSection);
        Controls.Add(_gridProjectEmployees);
        Controls.Add(_lblTaskSection);
        Controls.Add(_gridTasks);

        if (_viewOnlyMode)
        {
            _groupCreateProject.Visible = false;
            _lblProjectStatus.Visible = false;
            _cboProjectStatus.Visible = false;
            _btnUpdateStatus.Visible = false;
            _btnCreateTask.Visible = false;
            _btnDelete.Visible = false;
        }

        Resize += ProjectListForm_Resize;
        ApplyResponsiveLayout();
    }
}
