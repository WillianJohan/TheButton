using UnityEngine;

public class PlayerDATA : MonoBehaviour
{
    public enum GameMode { Standard, CountDown5, CountDown10, CountDown15, CountDown30 };

    public static string GetStringKey(GameMode mode)    => mode.ToString();
    
    public static int Load(GameMode mode)               => PlayerPrefs.GetInt(mode.ToString(), 0);
    public static void Save(GameMode mode, int clicks)  => PlayerPrefs.SetInt(mode.ToString(), clicks);
    
    public static void ResetAll()                       => PlayerPrefs.DeleteAll();
    public static void ResetData(GameMode mode)         => PlayerPrefs.SetInt(GetStringKey(mode), 0);

}
