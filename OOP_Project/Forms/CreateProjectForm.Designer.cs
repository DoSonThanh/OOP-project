using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class CreateProjectForm
{
    private TextBox _txtName = null!;
    private TextBox _txtDescription = null!;
    private DateTimePicker _dtpStartDate = null!;
    private DateTimePicker _dtpEndDate = null!;
    private ComboBox _cboStatus = null!;
    private ComboBox _cboLeader = null!;
    private Button _btnCreate = null!;

    private void InitializeComponent()
    {
        Text = "Create Project";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimumSize = new Size(650, 520);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(245, 248, 252);
        Width = 650;
        Height = 520;

        Panel headerPanel = new Panel();
        headerPanel.BackColor = Color.FromArgb(31, 78, 121);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Height = 82;

        Label lblHeaderTitle = new Label();
        lblHeaderTitle.Text = "Create New Project";
        lblHeaderTitle.AutoSize = true;
        lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeaderTitle.ForeColor = Color.White;
        lblHeaderTitle.Location = new Point(20, 18);

        Label lblHeaderSub = new Label();
        lblHeaderSub.Text = "Fill all required fields and pick a leader";
        lblHeaderSub.AutoSize = true;
        lblHeaderSub.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblHeaderSub.ForeColor = Color.FromArgb(220, 230, 240);
        lblHeaderSub.Location = new Point(22, 49);

        headerPanel.Controls.Add(lblHeaderTitle);
        headerPanel.Controls.Add(lblHeaderSub);

        GroupBox groupProjectInfo = new GroupBox();
        groupProjectInfo.Text = "Project Information";
        groupProjectInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        groupProjectInfo.Location = new Point(20, 98);
        groupProjectInfo.Width = 600;
        groupProjectInfo.Height = 172;
        groupProjectInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblName = new Label();
        lblName.Text = "Project Name:";
        lblName.AutoSize = true;
        lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblName.Location = new Point(16, 36);

        _txtName = new TextBox();
        _txtName.Location = new Point(150, 32);
        _txtName.Width = 430;
        _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblDescription = new Label();
        lblDescription.Text = "Description:";
        lblDescription.AutoSize = true;
        lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDescription.Location = new Point(16, 84);

        _txtDescription = new TextBox();
        _txtDescription.Location = new Point(150, 80);
        _txtDescription.Width = 430;
        _txtDescription.Height = 72;
        _txtDescription.Multiline = true;
        _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        groupProjectInfo.Controls.Add(lblName);
        groupProjectInfo.Controls.Add(_txtName);
        groupProjectInfo.Controls.Add(lblDescription);
        groupProjectInfo.Controls.Add(_txtDescription);

        GroupBox groupPlan = new GroupBox();
        groupPlan.Text = "Schedule and Assignment";
        groupPlan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        groupPlan.Location = new Point(20, 282);
        groupPlan.Width = 600;
        groupPlan.Height = 178;
        groupPlan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblStartDate = new Label();
        lblStartDate.Text = "Start Date:";
        lblStartDate.AutoSize = true;
        lblStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStartDate.Location = new Point(16, 36);

        _dtpStartDate = new DateTimePicker();
        _dtpStartDate.Location = new Point(150, 32);
        _dtpStartDate.Width = 200;
        _dtpStartDate.Format = DateTimePickerFormat.Short;

        Label lblEndDate = new Label();
        lblEndDate.Text = "End Date:";
        lblEndDate.AutoSize = true;
        lblEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEndDate.Location = new Point(16, 78);

        _dtpEndDate = new DateTimePicker();
        _dtpEndDate.Location = new Point(150, 74);
        _dtpEndDate.Width = 200;
        _dtpEndDate.Format = DateTimePickerFormat.Short;

        Label lblStatus = new Label();
        lblStatus.Text = "Status:";
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStatus.Location = new Point(16, 120);

        _cboStatus = new ComboBox();
        _cboStatus.Location = new Point(150, 116);
        _cboStatus.Width = 200;
        _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        Label lblLeader = new Label();
        lblLeader.Text = "Leader:";
        lblLeader.AutoSize = true;
        lblLeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblLeader.Location = new Point(366, 36);

        _cboLeader = new ComboBox();
        _cboLeader.Location = new Point(430, 32);
        _cboLeader.Width = 150;
        _cboLeader.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboLeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        _btnCreate = new Button();
        _btnCreate.Text = "Create Project";
        _btnCreate.Width = 150;
        _btnCreate.Height = 40;
        _btnCreate.Location = new Point(430, 116);
        _btnCreate.BackColor = Color.FromArgb(46, 125, 50);
        _btnCreate.ForeColor = Color.White;
        _btnCreate.FlatStyle = FlatStyle.Flat;
        _btnCreate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _btnCreate.Click += BtnCreate_Click;

        groupPlan.Controls.Add(lblStartDate);
        groupPlan.Controls.Add(_dtpStartDate);
        groupPlan.Controls.Add(lblEndDate);
        groupPlan.Controls.Add(_dtpEndDate);
        groupPlan.Controls.Add(lblStatus);
        groupPlan.Controls.Add(_cboStatus);
        groupPlan.Controls.Add(lblLeader);
        groupPlan.Controls.Add(_cboLeader);
        groupPlan.Controls.Add(_btnCreate);

        Controls.Add(headerPanel);
        Controls.Add(groupProjectInfo);
        Controls.Add(groupPlan);
    }
}
