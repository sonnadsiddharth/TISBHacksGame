using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmillGrow : MonoBehaviour
{
    
    public Transform size;

    public float time = 10;

    float scale = 0.09f;
    float pos = 0.26f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        size.localScale += new Vector3(0f, scale * Time.deltaTime, 0f);
        size.localPosition += new Vector3(0f, pos * Time.deltaTime, 0f);

        time -= Time.deltaTime;

        if (time < 0)
        {
            scale = 0;
            pos = 0;
        }
    }
}
