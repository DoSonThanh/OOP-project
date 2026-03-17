using System;
using System.Collections.Generic;

public class DataStorage
{
    // Kho chứa danh sách các dự án chung của cả hệ thống
    public List<AbsProject> AllProjects { get; set; }

    public DataStorage()
    {
        AllProjects = new List<AbsProject>();
        Console.WriteLine("DataStorage đã được tạo. Kho dữ liệu sẵn sàng!");
    }

    public void SaveData()
    {
        Console.WriteLine("Dữ liệu đã được lưu trữ an toàn.");
    }
}