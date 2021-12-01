using UnityEngine;
using MajinLib.Utilities;

public class TestManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log(MagicLibrary.AddDaysDuration(3));
        Debug.Log(MagicLibrary.AddHoursDuration(10));

        Debug.Log(MagicLibrary.NowMilliseconds());
        
        Debug.Log(MagicLibrary.Add(5,6));
        Debug.Log(MagicLibrary.Sub(1, 6));
    }

}
