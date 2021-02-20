using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    //Vars for movement
    Rigidbody2D body;
    public float speed = 10f;

    //Vars for timer bar
    public float timeLeft = 100;
    public float OGtimeLeft = 100;
    public Slider timeBar;

    //Vars for audio
    public AudioSource woodChop1;
    public AudioSource woodChop2;
    public AudioSource woodChop3;

    //Vars for keeping points
    float treeScore = 0;

    //More vars for movement
    float h;
    float v;
     
    void Start() 
    {
        //Get rigidbody component
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        //Get player input
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Check if player can go to the next level
        if (treeScore == 8) 
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

        //Basic timer
        timeLeft -= Time.deltaTime;

        //Timer bar
        timeBar.maxValue = OGtimeLeft;
        timeBar.value = timeLeft;

        //Game over loop
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    //Check for collision with othor colliders
    void OnCollisionEnter2D(Collision2D collision) 
    {

        //Destroy the object that the player colided with
        Destroy(collision.gameObject);

        //Increase score when collect wood
        treeScore += 1;

        //Lower speed because the player has more wood
        speed += -1;

        //Random sound generation 
        int num = Random.Range(1, 4);
        if (num == 1) {
            woodChop1.Play();
            Debug.Log(num);
        }
        if (num == 2) {
            woodChop2.Play();
            Debug.Log(num);
        }
        if (num == 3) {
            woodChop3.Play();
            Debug.Log(num);
        }

        //Small bonus for timer bar if you get a tree
        timeLeft += Time.deltaTime * 0.5f;
    }

    void FixedUpdate()
    {
        //Take input from before and turn it into movement
        body.velocity = new Vector2(h * speed, v * speed);
    }

}
