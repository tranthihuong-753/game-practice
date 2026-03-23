using UnityEngine;
using TMPro; // Sử dụng TextMeshPro cho UI

public class GameManager : MonoBehaviour
{
    [Header("Save Data")]
    public SaveData currentData;

    [Header("UI Reference")]
    // Kéo object TextMeshProUGUI từ Hierarchy vào ô này trong Inspector
    public TextMeshProUGUI displayUI;

    private bool isGameRunning = true;

    void Start()
    {
        // 1. Tự động Load dữ liệu cũ ngay khi khởi chạy game
        LoadGame();
    }

    void Update()
    {
        // 2. Tự động cộng dồn thời gian đã chơi (Time Played)
        if (isGameRunning)
        {
            currentData.timePlayed += Time.deltaTime;
            UpdateStatusUI();
        }
    }

    // 3. Hệ thống bắt phím bấm (Dùng OnGUI để đảm bảo luôn nhận phím trên máy bạn)
    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            // Nhấn S để Save
            if (e.keyCode == KeyCode.S) SaveGame();

            // Nhấn L để Load (Tải lại save cũ nhất)
            if (e.keyCode == KeyCode.L) LoadGame();

            // Nhấn Space để tăng 10 điểm (Ăn điểm)
            if (e.keyCode == KeyCode.Space) AddScore(10);

            // Nhấn N để tăng Level (Qua màn)
            if (e.keyCode == KeyCode.N)
            {
                currentData.level++;
                Debug.Log($"<color=cyan>Level Up!</color> Hiện tại: {currentData.level}");
            }

            // NHẤN R ĐỂ RESET GAME (XÓA FILE SAVE)
            if (e.keyCode == KeyCode.R)
            {
                ResetGame();
            }
        }
    }

    // Hàm Reset toàn bộ dữ liệu
    public void ResetGame()
    {
        // Gọi hàm xóa file từ SaveSystem
        SaveSystem.DeleteSaveFile();

        // Tạo lại một bộ dữ liệu mới tinh (Level 1, Score 0, Time 0)
        currentData = new SaveData();

        Debug.Log("<color=orange>Hệ thống: Toàn bộ dữ liệu đã được Reset về mặc định!</color>");
    }

    // Cập nhật nội dung hiển thị lên màn hình UI
    private void UpdateStatusUI()
    {
        if (displayUI != null)
        {
            // Định dạng chuỗi hiển thị: :F1 để lấy 1 số thập phân cho thời gian
            displayUI.text = $"<b>LEVEL:</b> {currentData.level}\n" +
                             $"<b>SCORE:</b> {currentData.score}\n" +
                             $"<b>TIME:</b> {currentData.timePlayed:F1}s";
        }
    }

    public void AddScore(int amount)
    {
        currentData.score += amount;
        Debug.Log($"+{amount} Score! Tổng hiện tại: {currentData.score}");
    }

    public void SaveGame()
    {
        SaveSystem.Save(currentData);
        Debug.Log($"<color=green>Hệ thống: Đã lưu file thành công tại {currentData.timePlayed:F2}s</color>");
    }

    public void LoadGame()
    {
        currentData = SaveSystem.Load();
        Debug.Log($"<color=yellow>Hệ thống: Dữ liệu đã được nạp lại thành công!</color>");
    }

    public void SetGameRunning(bool state)
    {
        isGameRunning = state;
    }
}