[System.Serializable] // Bắt buộc phải có để JsonUtility nhận diện được
public class PlayerData
{
    public string playerName;
    public int level;
    public int coin;
    public float health;
}