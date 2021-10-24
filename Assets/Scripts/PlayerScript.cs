using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed = 0;
    public Text scoreText;

    private int scoreValue = 0;  
    public Text livesText;
    private int livesValue = 3;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreText.text = "Score:" + scoreValue.ToString();
        livesText.text = "Lives:" + livesValue.ToString();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

    if (Input.GetKeyDown(KeyCode.Escape))
        {
          Application.Quit();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = "Score:" + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
       if (scoreValue == 4) 
        {
           scoreText.text = "Score: " + scoreValue.ToString();
            Destroy(this);
            winText.text = "You Win! This game was created by Anique(MintyTriforce25).";
        }
      
    }
    private void OnCollisionEnter2D(Collider other)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            livesValue -= 1;
            livesText.text = "Lives:" + livesValue.ToString();
            SetLivesText();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }
void SetLivesText()
{
    livesText.text = "Lives: " + livesValue.ToString();
        if (livesValue <= 0)
        {
            Destroy(this);
            winText.text = "Sorry, you lost! Better luck next time?";
        }
}
}
