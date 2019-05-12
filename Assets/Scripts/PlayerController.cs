using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // tilgreina breytur
    public GameObject check;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public Text countText;
    public BoxCollider2D playerBox2;

    public GameObject audio;
    AudioSource jumpaudio;

    private int count;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D playerBox;
    BoxCollider2D box;
    AudioSource coinSound;



    // Start is called before the first frame update
    void Start()
    {
        // sækir í componentanna
        jumpaudio = audio.GetComponent<AudioSource>();
        coinSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerBox = GetComponent<BoxCollider2D>();
        box = check.GetComponent<BoxCollider2D>();
        // teljari fyrir coins
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        // 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        // gáir hvort að playerinn sé að fara til vinstri
        if (movement.x < 0)
        {
            animator.Play("Player_runAnimation");
            spriteRenderer.flipX = true;
            // laga alla boxcollidera þegar að spriteið er snúð við
            playerBox.offset = new Vector2(0.015f, 0.1699184f);
            playerBox2.offset = new Vector2(-0.025f, 0.1699184f);
            box.offset = new Vector2(0.015f, 0.005015949f);
        }
        // gáir hvort að playerinn sé að fara til hægri
        else if (movement.x > 0)
        {
            animator.Play("Player_runAnimation");
            spriteRenderer.flipX = false;
            // laga alla boxcollidera þegar að spriteið er snúð við
            playerBox.offset = new Vector2(-0.015f, 0.1699184f);
            playerBox2.offset = new Vector2(-0.055f, 0.1699184f);
            box.offset = new Vector2(-0.015f, 0.005015949f);

        }
        // spilar idle animation ef playerinn er ekki á hreyfingu
        else
        {
            animator.Play("Player_idleAnimation");
        }
    }
    void Jump()
    {
        // gáir hvort að það var ýtt á spacebarinn og hvort að playerinn er á jörðinni.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
            jumpaudio.Play();
        }
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        // gáir hvort að playerinn sé að collidea við gameobject með coin taggið
        if (other.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            // lætur coinið hverfa
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        // gáir hvort að playerinn sé að collidea við gameobject með EndGame taggið
        if (other.gameObject.CompareTag("EndGame"))
        {
            // Hleður inn win Sceneið
            SceneManager.LoadScene("Win");
        }
    }

    // fall sem byritir hve margar coins playerinn er búinn að ná í.
    void SetCountText()
    {
        countText.text = "Coins: " + (count /2).ToString();
    } 

}
