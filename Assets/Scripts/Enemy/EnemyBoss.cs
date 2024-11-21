using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private int direction; //1 untuk kanan, dan -1 untuk kiri
    private float xspeed = 4;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomize();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction * xspeed , 0);
        if(rb.position.x >= 8){
            Mathf.Clamp(rb.position.x, -8, 8);
            direction *= -1;
            rb.position = new Vector2(7.9f, rb.position.y);
        }
        else if(rb.position.x <= -8){
            Mathf.Clamp(rb.position.x, -8, 8);
            direction *= -1;
            rb.position = new Vector2(-7.9f, rb.position.y);
        }
    }

    void randomize()
    {
        float seed = Random.Range(0, 1); 
        //batas x = 8, batas y = 5
        if(seed < 5f){
            rb.position = new Vector2(-8, Random.Range(1, 5));
            direction = -1;
        }
        else{
            rb.position = new Vector2(8, Random.Range(1, 5));
            direction = 1;
        }
    }
    //tambahkan implementasi senjata
}
