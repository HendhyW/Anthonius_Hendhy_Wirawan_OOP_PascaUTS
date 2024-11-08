using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;
    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = (-2) * maxSpeed / (timeToFullSpeed * timeToFullSpeed); 
        stopFriction = (-2) * maxSpeed / (timeToStop * timeToStop);
    }

    // Update is called once per frame
    public void Move()
    {
        // moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float xvel = 0;
        float yvel = 0;
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //selama ada input
        if(moveDirection != Vector2.zero)
        {
            //kalau dikasi input ke kanan, maka dikurang friction (frictionnya ke kiri)
            if(moveDirection.x > 0){
                xvel = Mathf.Clamp(moveDirection.x * moveVelocity.x * Time.fixedDeltaTime ,0,maxSpeed.x) + GetFriction().x;
            }
            //kalau dikasi input ke kiri, maka ditambah friction (frictionnya ke kanan)
            else if(moveDirection.x < 0){
                xvel = Mathf.Clamp(moveDirection.x * moveVelocity.x* Time.fixedDeltaTime, -maxSpeed.x, 0) - GetFriction().x;
            }
            else{
                if(rb.velocity.x >0){
                    xvel = Mathf.Clamp(rb.velocity.x + GetFriction().x* Time.fixedDeltaTime, 0, maxSpeed.x);
                }
                else if(rb.velocity.x < 0){
                    xvel = Mathf.Clamp(rb.velocity.x - GetFriction().x* Time.fixedDeltaTime, -maxSpeed.x, 0);
                }
            }

            //kalau dikasi input ke atas, maka dikurang friction (friction ke bawah)
            if(moveDirection.y > 0){
                yvel = Mathf.Clamp(moveDirection.y * moveVelocity.y* Time.fixedDeltaTime,0,maxSpeed.y) +  GetFriction().y;
            }
            //kalau dikasi input ke bawah, maka ditambah friction (friction ke atas)
            else if(moveDirection.y < 0){
                yvel = Mathf.Clamp(moveDirection.y * moveVelocity.y* Time.fixedDeltaTime, -maxSpeed.y, 0) - GetFriction().y;
            }
            else{
                if(rb.velocity.y >0){
                    yvel = Mathf.Clamp(rb.velocity.y + GetFriction().y * Time.fixedDeltaTime, 0, maxSpeed.y);
                }
                else if(rb.velocity.y < 0){
                    yvel = Mathf.Clamp(rb.velocity.y - GetFriction().y * Time.fixedDeltaTime, -maxSpeed.y, 0);
                }
            }
            xvel = Mathf.Clamp(xvel, -maxSpeed.x, maxSpeed.x);
            yvel = Mathf.Clamp(yvel, -maxSpeed.y, maxSpeed.y);
            rb.velocity = new Vector2(-xvel, -yvel);
        }
        //kalau nggak dikasih input
        // Jika tidak ada input
    else 
    {
        // Kurangi kecepatan dengan stopFriction hingga mencapai nol
        xvel = Mathf.Clamp((rb.velocity.x + GetFriction().x * Time.fixedDeltaTime), -maxSpeed.x, maxSpeed.x);
        yvel = Mathf.Clamp((rb.velocity.y + GetFriction().y * Time.fixedDeltaTime), -maxSpeed.y, maxSpeed.y);

        if(rb.velocity.x > 0){
            xvel = Mathf.Clamp(rb.velocity.x + GetFriction().x * Time.fixedDeltaTime, 0, maxSpeed.x);
        }
        else if(rb.velocity.x < 0){
            xvel = Mathf.Clamp(rb.velocity.x - GetFriction().x * Time.fixedDeltaTime, -maxSpeed.x, 0);
        }

        if(rb.velocity.y > 0){
            yvel = Mathf.Clamp(rb.velocity.y + GetFriction().y * Time.fixedDeltaTime, 0, maxSpeed.y);
        }
        else if(rb.velocity.y < 0){
            yvel = Mathf.Clamp(rb.velocity.y - GetFriction().y * Time.fixedDeltaTime, -maxSpeed.y, 0);
        }

        // Jika kecepatan kurang dari stopClamp, set ke nol
        if (Mathf.Abs(xvel) < stopClamp.x)
        {
            xvel = 0;
        }
        if (Mathf.Abs(yvel) < stopClamp.y)
        {
            yvel = 0;
        }

        // Tetapkan kecepatan baru
        rb.velocity = new Vector2(-xvel, -yvel);
    }

    MoveBound();

        // Debug.Log(moveDirection);
        // Debug.Log(xvel);
        // Debug.Log(yvel);
        // Debug.Log(rb.velocity);
    }

    public void MoveBound()
    {
        //kasih boundary supaya pesawat gabisa keluar dari kamera
        rb.position = new Vector2 (Mathf.Clamp(rb.position.x, -8.64f, 8.64f), Mathf.Clamp(rb.position.y, -5f, 4.64f));
    }

    public bool IsMoving()
    {
        if(rb.velocity == Vector2.zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    Vector2 GetFriction() 
    {
        // if(rb.velocity == Vector2.zero)
        // {
        //     return Vector2.zero;
        // }

        if(moveDirection == Vector2.zero)
        {
            return stopFriction;
        }
        else
        {
            return moveFriction;
        }
    }
    
}

