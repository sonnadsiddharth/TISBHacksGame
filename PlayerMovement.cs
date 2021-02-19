using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    Rigidbody2D body;
    public float speed = 10f;

    public float timeLeft = 100;
    public float OGtimeLeft = 100;
    public Slider timeBar;

    public AudioSource woodChop1;
    public AudioSource woodChop2;
    public AudioSource woodChop3;

    public Text score;

    float treeScore = 0;

    float h;
    float v;
     
    void Start() 
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (treeScore == 8) 
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

        timeLeft -= Time.deltaTime;

        timeBar.maxValue = OGtimeLeft;
        timeBar.value = timeLeft;

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    {

        Destroy(collision.gameObject);

        treeScore += 1;

        speed += -1;

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
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(h * speed, v * speed);
    }

}