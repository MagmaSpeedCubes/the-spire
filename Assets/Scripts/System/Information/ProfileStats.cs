using UnityEngine;

public class ProfileStats : MonoBehaviour
{
    public static float infoLevel = 0;
    //-1 = aesthetic
    // 0 = balanced
    // 1 = technical
    // 2 = debug
    public static float masterVolume = 100f;
    public static float uiVolume = 100f;


    public static float musicVolume = 100f;
    public static float alertVolume = 100f;
    public static float playerVolume = 100f;
    public static float obstacleVolume = 100f;

    void Awake()
    {
        infoLevel = PlayerPrefs.GetInt("infoLevel");
        Debug.Log("Loaded infoLevel as " + infoLevel);
        masterVolume = PlayerPrefs.GetFloat("masterVolume");
        // Debug.Log("Loaded masterVolume as " + masterVolume);
        // Debug.Log("ProfileStats loaded");
    }

    public static void SavePrefs()
    {
        PlayerPrefs.SetInt("infoLevel", (int)infoLevel);
        Debug.Log("Saved infoLevel as " + infoLevel);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        // Debug.Log("Saved masterVolume as " + masterVolume);
        // Debug.Log("ProfileStats saved");
    }
}
