using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{

    Rigidbody2D body;
    public float speed = 10f;

    public AudioSource woodChop;

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
            Debug.Log("YAY");
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(collision.gameObject);
        treeScore += 1;
        woodChop.Play();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(h * speed, v * speed);
    }

}