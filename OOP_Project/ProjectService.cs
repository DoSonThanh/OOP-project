using System;

public class ProjectService : IProjectService // (Giả sử bạn đã sửa tên interface cho đúng chính tả)
{
    // Thể hiện Aggregation: Service "chứa" (giữ 1 tham chiếu tới) DataStorage
    private DataStorage _storage;

    // Constructor nhận DataStorage từ bên ngoài truyền vào (Dependency Injection)
    public ProjectService(DataStorage storage)
    {
        this._storage = storage;
    }

    public void CreateProject(ProjectBuilder builder)
    {

        Console.WriteLine("Đã thêm project mới vào DataStorage.");
    }

    public void UpdateProject()
    {
        // Logic update
    }

    public void DeleteProject()
    {
        // Logic delete
    }

    public void GetProject()
    {
        // Logic get
    }
}