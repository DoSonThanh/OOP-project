# Hệ Thống Quản Lý Dự Án WinForms
## Thành viên
- Đỗ Sơn Thành (DoSonThanh)
- Nguyễn Tuấn Khôi (NetherScreech)
- Lê Trung Phong(Kannar04)
- Nguyễn Minh Thức (cucuctt1)
## 1. Giới Thiệu
Đây là đồ án C# WinForms quản lý dự án theo hướng OOP, lưu dữ liệu bằng JSON và tổ chức theo mô hình phân tầng gồm Models, Builders, Services, Controllers, Data và Forms.

Ứng dụng hỗ trợ các luồng chính:
- Tạo dự án
- Xem danh sách và chi tiết dự án
- Cập nhật trạng thái dự án
- Tạo task và gán nhân viên
- Lọc dự án theo nhân viên
- Xóa dự án

## 2. Công Nghệ Sử Dụng
- Ngôn ngữ: C#
- Framework: .NET 8 Windows Desktop
- Giao diện: Windows Forms
- Lưu trữ: file `data.json`
- Tuần tự hóa: `System.Text.Json` thông qua `ISerialization`

## 3. Phân Tích Và Thiết Kế

### 3.1 Mô Hình Hệ Thống
Hệ thống được thiết kế theo kiến trúc phân tầng:
- `Models`: chứa các thực thể nghiệp vụ
- `Builders`: xây dựng đối tượng `Project`
- `Services`: xử lý logic nghiệp vụ
- `Controllers`: trung gian giữa UI và service
- `Data`: lưu và nạp dữ liệu
- `Forms`: giao diện người dùng

### 3.2 Dữ Liệu Và Nghiệp Vụ Chính
- `Project` là thực thể trung tâm, chứa thông tin dự án, leader, employees và tasks.
- `TaskItem` đại diện cho công việc thuộc một project.
- `EnumStatus` dùng chung cho trạng thái project và task.
- `SystemContext` giữ dữ liệu chạy trong bộ nhớ.
- `DataStorage` đọc/ghi dữ liệu ra file JSON.

## 4. 4 Tính Chất OOP

### 4.1 Encapsulation
Các lớp model dùng private field và public property để kiểm soát dữ liệu. Điều này giúp bảo vệ trạng thái nội bộ và giảm truy cập trực tiếp từ bên ngoài.

### 4.2 Abstraction
Tính trừu tượng thể hiện qua `AbsPerson`, `IProjectService` và `ISerialization`. Các lớp này chỉ định nghĩa hợp đồng chung, còn phần hiện thực nằm ở lớp con hoặc lớp triển khai.

### 4.3 Inheritance
Chuỗi kế thừa của nhân sự là `AbsPerson -> Employee -> ProjectLeader`. Cấu trúc này tái sử dụng thuộc tính chung và thể hiện rõ quan hệ “is-a”.

### 4.4 Polymorphism
`GetRole()` được override ở lớp con để trả về vai trò đúng theo kiểu thực tế của đối tượng. Khi UI hiển thị employee/leader, cùng một lời gọi nhưng kết quả thay đổi theo object runtime.

## 5. Trách Nhiệm Từng Lớp

### 5.1 Models
- `AbsPerson`: lớp gốc cho nhân sự
- `Employee`: nhân viên thường
- `ProjectLeader`: trưởng dự án
- `Project`: dữ liệu dự án
- `TaskItem`: dữ liệu task
- `EnumStatus`: trạng thái dùng chung

### 5.2 Builders
- `ProjectBuilder`: xây dựng project theo từng bước, hỗ trợ thêm danh sách nhân viên và đảm bảo leader nằm trong danh sách tham gia.

### 5.3 Data
- `SystemContext`: singleton lưu trạng thái ứng dụng
- `ISerialization`: hợp đồng serialize/deserialize
- `JsonSerialization`: triển khai JSON serializer
- `DataStorage`: singleton lưu và nạp dữ liệu từ file

### 5.4 Services
- `IProjectService`: hợp đồng nghiệp vụ
- `ProjectService`: hiện thực logic tạo project, update status, tạo task, lọc dữ liệu và validate

### 5.5 Controllers
- `ProjectController`: cầu nối giữa form và service

### 5.6 Forms
- `MainForm`: màn hình khởi đầu
- `ProjectListForm`: dashboard chính, có 2 chế độ create/view
- `CreateTaskForm`: form tạo task và gán nhân viên
- `CreateProjectForm`: form tạo project độc lập để tương thích

## 6. Lưu Trữ Dữ Liệu
`DataStorage` sử dụng `ISerialization` để tách cơ chế lưu trữ khỏi phần xử lý file. Hiện tại hệ thống dùng `JsonSerialization`, nên sau này có thể thay serializer khác mà không ảnh hưởng phần còn lại.

File dữ liệu được lưu tại thư mục output của ứng dụng dưới tên `data.json`.

## 7. Quy Tắc Nghiệp Vụ
- `ProjectName`, `Description`, `Leader` là bắt buộc khi tạo project
- `Task Title`, `Task Description`, `Assignee` là bắt buộc khi tạo task
- `StartDate` phải nhỏ hơn hoặc bằng `EndDate`
- Nhân viên trong dự án không được trùng nhau
- Leader luôn được đảm bảo có trong danh sách nhân viên tham gia

## 8. Giao Diện Ứng Dụng
Ứng dụng dùng WinForms với giao diện chính gồm:
- Màn hình menu chính
- Dashboard quản lý project
- Khối lọc project theo nhân viên
- Khối tạo project
- Bảng danh sách project
- Vùng hiển thị chi tiết project, employees và tasks

Dashboard có 2 chế độ:
- `Create`: cho phép tạo, cập nhật, xóa, tạo task
- `View`: chỉ xem và lọc dữ liệu, không cho thao tác ghi

## 9. Chạy Chương Trình
Từ thư mục gốc `D:\oop_pro`:

Build:
```bash
dotnet build .\ProjectManagementSystem.sln
```

Run:
```bash
dotnet run --project .\ProjectManagementSystem\ProjectManagementSystem.csproj
```

Chạy self-test:
```bash
dotnet run --project .\ProjectManagementSystem\ProjectManagementSystem.csproj -- --selftest
```

Kết quả self-test được ghi tại:
`ProjectManagementSystem/bin/Debug/net8.0-windows/selftest-result.txt`

## 10. Cấu Trúc Thư Mục
```text
ProjectManagementSystem
|-- Program.cs
|-- ProjectManagementSystem.csproj
|-- Builders
|   `-- ProjectBuilder.cs
|-- Controllers
|   `-- ProjectController.cs
|-- Data
|   |-- ISerialization.cs
|   |-- JsonSerialization.cs
|   |-- DataStorage.cs
|   `-- SystemContext.cs
|-- Forms
|   |-- MainForm.cs
|   |-- ProjectListForm.cs
|   |-- ProjectListForm.Designer.cs
|   |-- CreateProjectForm.cs
|   `-- CreateTaskForm.cs
|-- Models
|   |-- AbsPerson.cs
|   |-- Employee.cs
|   |-- ProjectLeader.cs
|   |-- EnumStatus.cs
|   |-- Project.cs
|   `-- TaskItem.cs
`-- Services
    |-- IProjectService.cs
    `-- ProjectService.cs
```

