using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // tilgreina breytur
    public float speed;
    public Transform groundDetection;

    private bool movingRight = false;

    void Update()
    {
        // þetta hreyfir óvininn
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // nær í collider sem er á layerinu Ground
        int layer_mask = LayerMask.GetMask("Ground");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, layer_mask);
        if(groundInfo.collider == false) // ef að óvinurinn er að fara útaf colliderinum þá snýr hann við
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
