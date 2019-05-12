using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject Player;

    void LateUpdate()
    {
        // gáir hvort að x ásinn á playernum sé stærri en -7,1 eð minni en 75,69
        if (Player.transform.position.x > -7.1f && Player.transform.position.x < 75.69f)
        {
            // breytir x ásnum á camerunni í það samma og er á playerinum. 
            transform.position = new Vector3(Player.transform.position.x, 0f, -10f);
        }
        
    }
}
