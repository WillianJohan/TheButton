using UnityEngine;

public class DATA : MonoBehaviour
{

    public static readonly string CountDownRecordKey = "CountDownRecordKey";
    public static readonly string StandardRecordKey = "StandardRecordKey";

    public static int Load_CountDownRecord()
    {
        return PlayerPrefs.GetInt(CountDownRecordKey, 0);
    }

    public static int Load_StandardRecord()
    {
        return PlayerPrefs.GetInt(StandardRecordKey, 0);
    }

    public static void Save_CountDownRecord(int clicks)
    {
        PlayerPrefs.SetInt(CountDownRecordKey, clicks);
    }

    public static void Save_StandardRecord(int clicks)
    {
        PlayerPrefs.SetInt(CountDownRecordKey, clicks);
    }

}
