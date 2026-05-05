using ProjectManagementSystem.Controllers;

namespace ProjectManagementSystem.Forms;

public partial class MainForm : Form
{
    private readonly ProjectController _projectController;

    public MainForm()
    {
        _projectController = new ProjectController();
        InitializeComponent();
        Resize += MainForm_Resize;
        ApplyResponsiveLayout();
    }

    private void MainForm_Resize(object? sender, EventArgs e)
    {
        ApplyResponsiveLayout();
    }

    private void ApplyResponsiveLayout()
    {
        int sidePadding = 24;
        int gap = 18;
        int top = _headerPanel.Bottom + 40;

        int availableWidth = ClientSize.Width - (sidePadding * 2) - gap;
        int buttonWidth = availableWidth / 2;

        if (buttonWidth < 180)
        {
            buttonWidth = 180;
        }

        int totalButtonsWidth = (buttonWidth * 2) + gap;
        int left = (ClientSize.Width - totalButtonsWidth) / 2;
        if (left < sidePadding)
        {
            left = sidePadding;
        }

        _btnCreateProject.Width = buttonWidth;
        _btnCreateProject.Location = new Point(left, top);

        _btnViewProjects.Width = buttonWidth;
        _btnViewProjects.Location = new Point(_btnCreateProject.Right + gap, top);
    }

    private void BtnCreateProject_Click(object? sender, EventArgs e)
    {
        using (ProjectListForm projectListForm = new ProjectListForm(_projectController, true, false))
        {
            projectListForm.ShowDialog(this);
        }
    }

    private void BtnViewProjects_Click(object? sender, EventArgs e)
    {
        using (ProjectListForm projectListForm = new ProjectListForm(_projectController, false, true))
        {
            projectListForm.ShowDialog(this);
        }
    }
}
