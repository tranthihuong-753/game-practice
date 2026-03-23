[System.Serializable]
public class SaveData
{
    public int level;
    public int score;
    public float timePlayed; // Tính bằng giây
    public string lastSaveTime; // Lưu ngày giờ lưu file (để hiển thị)

    public SaveData() // Giá trị mặc định khi mới chơi
    {
        level = 1;
        score = 0;
        timePlayed = 0f;
        lastSaveTime = "";
    }
}