using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Grounded : MonoBehaviour
{
    // tilgreina breytur
    GameObject Player;
    public GameObject cam;
    public GameObject audio;
    AudioSource deathaudio;
    public Text countLives;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        deathaudio = audio.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // fall sem keyrir þegar að colliderinn kemur við annan collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // gáir hvort að playerinn er stendur ofan á gameobject sem er með taggið Ground
        if(collision.collider.tag == "Ground")
        {
            // Breytir isGrounded breytunni í PlayerController scriptunni í true
            Player.GetComponent<PlayerController>().isGrounded = true;
        }
        // gáir hvort að playerinn er stendur ofan á gameobject sem er með taggið Enemy eða Spikes
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Spikes")
        {
            // minnkar lífið á playernum í CollisionDetection scriptinu.
            Player.GetComponent<CollisionDetection>().lives -= 1;
            // 
            countLives.text = Player.GetComponent<CollisionDetection>().lives.ToString();
            // lætur playerinn og cameruna fara aftur á byrjun.
            Player.transform.position = new Vector2(-12.37f, -4.026641f);
            cam.transform.position = new Vector3(-7.1f, 0f, -10f);
            deathaudio.Play();
            // gáir hvort að playerinn sé með minna en 1 líf
            if (Player.GetComponent<CollisionDetection>().lives < 1)
            {
                // hleður inn GameOver sceneinu
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    // fall sem keyrir þegar að colliderinn fer af öðrum collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // gáir hvort að playerinn er stendur ofan á gameobject sem er með taggið Ground
        if (collision.collider.tag == "Ground")
        {
            // Breytir isGrounded breytunni í PlayerController scriptunni í false
            Player.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
