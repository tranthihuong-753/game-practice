using UnityEngine;

public class Lab4Manager : MonoBehaviour
{
    public PlayerData myData;

    void Start()
    {
        // 1. Khởi tạo dữ liệu mẫu
        myData = new PlayerData();
        myData.playerName = "Vudun";
        myData.level = 10;
        myData.coin = 500;
        myData.health = 95.5f;

        // 2. CHUYỂN OBJECT THÀNH CHUỖI JSON (Serialization)
        // Tham số 'true' giúp chuỗi JSON xuống dòng dễ đọc hơn
        string jsonString = JsonUtility.ToJson(myData, true);

        Debug.Log("Chuỗi JSON vừa tạo:\n" + jsonString);

        // 3. CHUYỂN CHUỖI JSON NGƯỢC LẠI THÀNH OBJECT (Deserialization)
        PlayerData restoredData = JsonUtility.FromJson<PlayerData>(jsonString);

        Debug.Log($"Dữ liệu đã khôi phục: Tên: {restoredData.playerName}, Level: {restoredData.level}");
    }
}