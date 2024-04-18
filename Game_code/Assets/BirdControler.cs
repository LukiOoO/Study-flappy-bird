using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdControler : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float JumpForce;
    public int Points;
    public static bool GameOver;
    public static bool FirstJump;
    public GameObject gameOverScrean;

    // Start is called before the first frame update   
    void Start()
    {
        rb2d.gravityScale = 0; 
    }

    // Update is called once per frame
    void Update()
    {

        if (GameOver)
        {
            return;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if(!FirstJump) 
            { 
            FirstJump = true;
            rb2d.gravityScale = 1f;
            }

            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("die");
        GameOver = true;
        gameOverScrean.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointZone"))
        {
            Points++;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("flappybird-gameplay");
        
    }
}
