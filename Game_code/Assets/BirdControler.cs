using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdControler : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float JumpForce;
    public float MaxVelocityY;
    public int Points;
    public static bool GameOver;
    public static bool FirstJump;
    public GameObject gameOverScrean;
    public Animator animator;   
    public AudioSource audioSource;
    public AudioClip jumpsound;
    public AudioClip scoresound;
    public AudioClip hitsound;



    // Start is called before the first frame update   
    void Start()
    {
        rb2d.gravityScale = 0; 
        GameOver = false;
        FirstJump = false;
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

            audioSource.clip = jumpsound;
            audioSource.Play();
            animator.SetTrigger("FlapWings");
            
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            if (rb2d.velocity.y > MaxVelocityY ) 
            {
                rb2d.velocity = new Vector2(0, MaxVelocityY);
            }
        }
        

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("die");
        GameOver = true;
        gameOverScrean.SetActive(true);
        if(Points > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Points);
        }
        audioSource.clip = hitsound;
        audioSource.Play();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointZone"))
        {
            Points++;
        }
        audioSource.clip = scoresound;
        audioSource.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("flappybird-gameplay");
        
    }
}
