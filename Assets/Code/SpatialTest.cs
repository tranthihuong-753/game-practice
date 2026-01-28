using UnityEngine;

public class SpatialTest : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _audio.spatialBlend = 0;
            Debug.Log("Chế độ: 2D Audio");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _audio.spatialBlend = 1;
            Debug.Log("Chế độ: 3D Audio (Spatial)");
        }
    }
}