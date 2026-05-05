namespace ProjectManagementSystem.Forms;

public partial class MainForm
{
    private Panel _headerPanel = null!;
    private Label _lblSubtitle = null!;
    private Button _btnCreateProject = null!;
    private Button _btnViewProjects = null!;
    private Label _lblTitle = null!;

    private void InitializeComponent()
    {
        Text = "Project Management System";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimumSize = new Size(560, 330);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(244, 247, 252);
        Width = 560;
        Height = 330;

        _headerPanel = new Panel();
        _headerPanel.BackColor = Color.FromArgb(31, 78, 121);
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 105;

        _lblTitle = new Label();
        _lblTitle.Text = "Project Management System";
        _lblTitle.AutoSize = true;
        _lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        _lblTitle.ForeColor = Color.White;
        _lblTitle.Location = new Point(22, 24);

        _lblSubtitle = new Label();
        _lblSubtitle.Text = "Track projects, update status, and assign tasks to employees";
        _lblSubtitle.AutoSize = true;
        _lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        _lblSubtitle.ForeColor = Color.FromArgb(220, 230, 240);
        _lblSubtitle.Location = new Point(24, 62);

        _btnCreateProject = new Button();
        _btnCreateProject.Text = "Create Project";
        _btnCreateProject.Height = 52;
        _btnCreateProject.BackColor = Color.FromArgb(46, 125, 50);
        _btnCreateProject.ForeColor = Color.White;
        _btnCreateProject.FlatStyle = FlatStyle.Flat;
        _btnCreateProject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnCreateProject.Click += BtnCreateProject_Click;

        _btnViewProjects = new Button();
        _btnViewProjects.Text = "View Projects";
        _btnViewProjects.Height = 52;
        _btnViewProjects.BackColor = Color.FromArgb(31, 78, 121);
        _btnViewProjects.ForeColor = Color.White;
        _btnViewProjects.FlatStyle = FlatStyle.Flat;
        _btnViewProjects.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnViewProjects.Click += BtnViewProjects_Click;

        _headerPanel.Controls.Add(_lblTitle);
        _headerPanel.Controls.Add(_lblSubtitle);

        Controls.Add(_headerPanel);
        Controls.Add(_btnCreateProject);
        Controls.Add(_btnViewProjects);

        _headerPanel.BringToFront();
    }
}
