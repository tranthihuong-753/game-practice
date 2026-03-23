using UnityEngine;
using System.IO; // Thư viện bắt buộc để xử lý File I/O

public static class SaveSystem
{
    // Đường dẫn lưu file trên ổ cứng
    private static string path = Application.persistentDataPath + "/miniproject_save.json";

    // 1. Hàm Lưu dữ liệu
    public static void Save(SaveData data)
    {
        // Cập nhật thời gian lưu cuối cùng
        data.lastSaveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Chuyển đổi Object thành chuỗi JSON (định dạng đẹp với 'true')
        string json = JsonUtility.ToJson(data, true);

        // Ghi chuỗi JSON vào file
        File.WriteAllText(path, json);

        Debug.Log("<color=green>Game Saved to: </color>" + path);
    }

    // 2. Hàm Tải dữ liệu
    public static SaveData Load()
    {
        if (File.Exists(path))
        {
            // Đọc nội dung file văn bản
            string json = File.ReadAllText(path);

            // Chuyển ngược từ JSON sang Object SaveData
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.LogWarning("No save file found, creating new data.");
            // Nếu không có file, trả về một Object mới (Level 1, Score 0...)
            return new SaveData();
        }
    }

    // 3. Hàm Xóa dữ liệu (Reset) - MỚI THÊM
    public static void DeleteSaveFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("<color=red>Hệ thống: Đã xóa file save vĩnh viễn!</color>");
        }
        else
        {
            Debug.LogWarning("Hệ thống: Không tìm thấy file để xóa.");
        }
    }
}