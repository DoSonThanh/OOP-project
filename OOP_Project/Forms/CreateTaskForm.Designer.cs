using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Forms;

public partial class CreateTaskForm
{
    private TextBox _txtTitle = null!;
    private TextBox _txtDescription = null!;
    private ComboBox _cboStatus = null!;
    private ComboBox _cboAssignee = null!;
    private Button _btnCreate = null!;

    private void InitializeComponent()
    {
        Text = "Create Task";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimumSize = new Size(540, 420);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(245, 248, 252);
        Width = 540;
        Height = 420;

        Label lblTitle = new Label();
        lblTitle.Text = "Task Title:";
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 35);

        _txtTitle = new TextBox();
        _txtTitle.Location = new Point(170, 30);
        _txtTitle.Width = 320;
        _txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblDescription = new Label();
        lblDescription.Text = "Description:";
        lblDescription.AutoSize = true;
        lblDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDescription.Location = new Point(30, 90);

        _txtDescription = new TextBox();
        _txtDescription.Location = new Point(170, 85);
        _txtDescription.Width = 320;
        _txtDescription.Height = 90;
        _txtDescription.Multiline = true;
        _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblStatus = new Label();
        lblStatus.Text = "Status:";
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblStatus.Location = new Point(30, 205);

        _cboStatus = new ComboBox();
        _cboStatus.Location = new Point(170, 200);
        _cboStatus.Width = 320;
        _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        Label lblAssignee = new Label();
        lblAssignee.Text = "Assign Employee:";
        lblAssignee.AutoSize = true;
        lblAssignee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblAssignee.Location = new Point(30, 260);

        _cboAssignee = new ComboBox();
        _cboAssignee.Location = new Point(170, 255);
        _cboAssignee.Width = 320;
        _cboAssignee.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboAssignee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        _btnCreate = new Button();
        _btnCreate.Text = "Create Task";
        _btnCreate.Width = 140;
        _btnCreate.Height = 38;
        _btnCreate.Location = new Point(350, 315);
        _btnCreate.BackColor = Color.FromArgb(31, 78, 121);
        _btnCreate.ForeColor = Color.White;
        _btnCreate.FlatStyle = FlatStyle.Flat;
        _btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _btnCreate.Click += BtnCreate_Click;

        Controls.Add(lblTitle);
        Controls.Add(_txtTitle);
        Controls.Add(lblDescription);
        Controls.Add(_txtDescription);
        Controls.Add(lblStatus);
        Controls.Add(_cboStatus);
        Controls.Add(lblAssignee);
        Controls.Add(_cboAssignee);
        Controls.Add(_btnCreate);
    }
}
