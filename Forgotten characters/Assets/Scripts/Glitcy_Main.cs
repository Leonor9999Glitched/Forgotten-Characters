using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitcy_Main : MonoBehaviour
{
    public float maxSpeed = 5000.0f;
    public float jumpspeed = 100.0f;
    public float jumpMaxTime = 0.1f;

    public float amplitude = 90.0f;

    public Transform Checkground;
    public LayerMask groundLayers;

    Rigidbody2D rb;
    float       jumpTime;
    int contagem = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Checking for mistakes");
        for (int i = 1; i <= 3; i++)
        {
            Debug.Log(i);
        }
        
        Debug.Log("No Mistakes Here.");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento da personagem
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        if(currentVelocity.y == 0)
        {
            currentVelocity = new Vector2 (maxSpeed * hAxis, currentVelocity.y);
        }

        if(currentVelocity.x < -0.5f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentVelocity.x > 0.5f)
        {
            transform.rotation = Quaternion.identity;
        }

        //Verifica se o personagem está a tocar no chão
        Collider2D groundCollision = Physics2D.OverlapCircle(Checkground.position, 5, groundLayers);

        bool onGround = groundCollision != null;
        
        //O salto da personagem
        if (Input.GetButtonDown("Jump"))
        {
	        if(onGround)
            {    
                currentVelocity.y = jumpspeed;
                rb.gravityScale = 0.0f;

                jumpTime = Time.time;
                contagem = 5;
            }

            if(!onGround)
            {
                if(contagem > 0)
                {
                    currentVelocity.y = jumpspeed + amplitude;
                    contagem --;
                }
            }
        }
        else if ((Input.GetButton("Jump")) && ((Time.time - jumpTime) < jumpMaxTime))
        {
            currentVelocity.y = jumpspeed - 80.0f;
        }
        else
        {
            rb.gravityScale = 1.0f;
        }

        rb.velocity = currentVelocity;
    }

}
