Xây dựng Chương trình quản lý công việc nhóm (kiểu project management) 

Đỗ Sơn Thành (DoSonThanh)
Nguyễn Tuấn Khôi (NetherScreech)
Lê Trung Phong(Kannar04)
Nguyễn Minh Thức (cucutt1)

## Phân tích Association

Trong dự án này, Association được thể hiện qua các mối liên kết giữa `Project`, `Employee` và lớp dịch vụ quản lý dự án.

- `Project` liên kết `1-1` với `Employee` thông qua thuộc tính `leader`.
- `Project` liên kết `1-n` với `Employee` thông qua danh sách `members` (nội bộ là `list_employees`).
- Quan hệ được quản lý bằng các hành vi `SetLeader`, `AddMember`, `RemoveMember` để đảm bảo dữ liệu nhất quán.

Luồng xử lý Association trong tầng service:

- `ProjectService.AssignLeader(projectId, employee)` gán một `Employee` làm leader của project.
- `ProjectService.AddMember(projectId, employee)` thêm thành viên vào project.
- `ProjectService.RemoveMember(projectId, employeeId)` xóa liên kết thành viên khỏi project.

Ý nghĩa của Association trong bài toán:

- Thể hiện đúng nghiệp vụ: một dự án có trưởng nhóm và nhiều thành viên.
- Tách rõ trách nhiệm: lớp `Project` quản lý quan hệ dữ liệu, lớp `ProjectService` điều phối thao tác nghiệp vụ.
- Giúp mở rộng dễ hơn cho các chức năng sau như phân quyền theo vai trò, thống kê nhân sự theo dự án.

## Đoạn code minh họa Association

Ví dụ trong lớp `Project`, dự án giữ liên kết trực tiếp đến `leader` và danh sách `members`:

```csharp
public class Project : AbsProject
{
	public Employee? leader { get; private set; }

	private readonly List<Employee> list_employees;
	public IReadOnlyList<Employee> members
	{
		get { return list_employees.AsReadOnly(); }
	}

	public void SetLeader(Employee employee)
	{
		leader = employee;
		// Đảm bảo leader cũng thuộc danh sách members
		bool exists = false;
		for (int i = 0; i < list_employees.Count; i++)
		{
			if (list_employees[i].id == employee.id)
			{
				exists = true;
				break;
			}
		}
		if (!exists)
		{
			list_employees.Add(employee);
		}
	}
}
```

Giải thích:

- `leader` thể hiện quan hệ association `1-1` giữa `Project` và `Employee`.
- `members` thể hiện quan hệ association `1-n` giữa `Project` và nhiều `Employee`.
- Khi gọi `SetLeader`, code đồng bộ dữ liệu để leader luôn là một thành viên của dự án.

Ví dụ trong lớp `ProjectService`, thao tác nghiệp vụ đi qua service để thay đổi quan hệ:

```csharp
public bool AddMember(string projectId, Employee employee)
{
	var project = FindProjectInternal(projectId);
	if (project == null)
	{
		return false;
	}

	return project.AddMember(employee);
}

public bool AssignLeader(string projectId, Employee employee)
{
	var project = FindProjectInternal(projectId);
	if (project == null)
	{
		return false;
	}

	project.SetLeader(employee);
	return true;
}
```

Giải thích:

- Service tìm đúng `Project` theo `projectId` rồi mới cập nhật quan hệ.
- Việc quản lý quan hệ được chia lớp rõ ràng: service điều phối, project xử lý dữ liệu nội tại.

