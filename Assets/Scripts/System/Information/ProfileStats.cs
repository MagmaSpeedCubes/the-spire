using UnityEngine;

public class ProfileStats : MonoBehaviour
{
    public static int infoLevel = 0;
    //-1 = aesthetic
    // 0 = balanced
    // 1 = technical
    // 2 = debug
    public static float masterVolume = 100f;

    void Awake()
    {
        infoLevel = PlayerPrefs.GetInt("infoLevel");
        Debug.Log("Loaded infoLevel as " + infoLevel);
        masterVolume = PlayerPrefs.GetFloat("masterVolume");
        Debug.Log("Loaded masterVolume as " + masterVolume);
        Debug.Log("ProfileStats loaded");
    }

    public static void SavePrefs()
    {
        PlayerPrefs.SetInt("infoLevel", infoLevel);
        Debug.Log("Saved infoLevel as " + infoLevel);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        Debug.Log("Saved masterVolume as " + masterVolume);
        Debug.Log("ProfileStats saved");
    }
}
