using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public float MaxHorizontalPosition;
    public float MaxVerticalPosition;
    public float SpeedKof;
    public static GameData Incstance;

    public void Awake() 
    {
        if (Incstance)
        {
            Destroy(gameObject);
        }
        else
        {
            Incstance = this;
        }
    }
}
