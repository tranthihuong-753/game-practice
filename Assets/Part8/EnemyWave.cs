using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[System.Serializable]
public class EnemyWave
{
    public Transform enemyPrefab;
    public int numberOfEnemy;
    public Vector3 formationOffset;
    public FlyPath flyPath;
    public float speed;
    public float nextWaveDelay;
}