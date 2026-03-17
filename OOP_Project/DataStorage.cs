using System;
using System.Collections.Generic;

public class DataStorage
{
    // Thể hiện Aggregation: DataStorage "chứa" một tập hợp các Employee
    public List<Employee> EmployeeRecords { get; set; }

    public DataStorage()
    {
        // Khởi tạo cái danh sách (cái tủ rỗng)
        EmployeeRecords = new List<Employee>();
        Console.WriteLine("[DataStorage] Kho lưu trữ nhân sự đã sẵn sàng.");
    }

    // Dependency Injection qua phương thức: Nhận nhân viên từ bên ngoài
    public void AddEmployee(Employee emp)
    {
        EmployeeRecords.Add(emp);
        Console.WriteLine($"[DataStorage] Đã lưu hồ sơ của nhân viên: {emp.name} vào kho.");
    }

    public void ShowAllRecords()
    {
        Console.WriteLine($"--- KHO DỮ LIỆU ĐANG CÓ {EmployeeRecords.Count} HỒ SƠ ---");
        foreach (var emp in EmployeeRecords)
        {
            Console.WriteLine($"- {emp.id} | {emp.name} | {emp.position}");
        }
    }
}