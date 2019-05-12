using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    // tilgreina breitur
    public float lives;
    public GameObject cam;
    public Text countLives;

    public GameObject audio;
    AudioSource deathaudio;

    void Start()
    {
        // ná í hluti s.s. hljóð og stilla líf
        deathaudio = audio.GetComponent<AudioSource>();
        lives = 5f;
        countLives.text = lives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ef að playerinn snertir spikes þá fer hann aftur á byrjunarreit og missir 1 líf
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spikes"))
        {
            lives -= 1;
            countLives.text = lives.ToString();
            transform.position = new Vector2(-12.37f, -4.026641f);
            cam.transform.position = new Vector3(-7.1f, 0f, -10f);
            deathaudio.Play();
            
        }
        if (lives < 1) // ef spilarinn er ekki með nein líf eftir tapar hann
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}