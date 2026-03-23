using UnityEngine;

// Dòng này giúp bạn chuột phải trong cửa sổ Project để tạo file dữ liệu
[CreateAssetMenu(fileName = "NewGameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    public string gameVersion = "1.0.0";
    public float playerBaseSpeed = 5f;
    public int maxInventorySlot = 20;
    public Color themeColor = Color.blue;
}