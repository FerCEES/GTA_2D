using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;

    public float runSpeed = 9f;


    public float maxStamina = 5f;      // максимум стаміни
    public float stamina = 5f;
    public float staminaDrain = 1f;    // витрата за секунду
    public float staminaRegen = 0.5f;  // відновлення за секунду

    private Rigidbody2D rb;
    private Vector2 movement;
    public float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
    }
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // if (Input.GetKey(KeyCode.W))
        //     moveY = 1f;
        // if (Input.GetKey(KeyCode.S))
        //     moveY = -1f;
        // if (Input.GetKey(KeyCode.A))
        //     moveX = -1f;
        // if (Input.GetKey(KeyCode.D))
        //     moveX = 1f;

        //Vector2 move = new Vector2(moveX, moveY);
        //transform.Translate(move * walkSpeed * Time.deltaTime);



        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && stamina > 0;

        if (isRunning)
        {
            currentSpeed = runSpeed;
            stamina -= staminaDrain * Time.deltaTime;
        }
        else
        {
            currentSpeed = walkSpeed;
            stamina += staminaRegen * Time.deltaTime;
        }
        // Обмеження стаміни
        stamina = Mathf.Clamp(stamina, 0, maxStamina); 
    }

    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
    }

}
