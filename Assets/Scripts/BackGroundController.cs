using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public List<GameObject> Sprites;
    public float MinX;
    public float MinY;
    public float StepX;
    public float BackGroundSpeed;
    public float BackGroundPosition;

    void Awake()
    {
        var position = new Vector3(MinX , 0, BackGroundPosition);
        foreach (var sprite in Sprites)
        {
            sprite.transform.position = position;
            position += new Vector3(-StepX , MinY);
        }
    }

	void Update ()
	{
	    foreach (var sprite in Sprites)
	    {
	        NewSpritePosition(sprite);
	    }
    }

    public void NewSpritePosition(GameObject sprite)
    {
        sprite.transform.position -= new Vector3(0, BackGorundSpeedCalculation());
        if (sprite.transform.position.y > -MinY) return;
        sprite.transform.position += new Vector3(-StepX, MinY * 2);
        if (sprite.transform.position.x > -MinX) return;
        sprite.transform.position += new Vector3(MinX * 2, 0);
    }
    
    public float BackGorundSpeedCalculation()
    {
        return BackGroundSpeed * GameController.Incstance.SpeedKof * Time.deltaTime;
    }
}
