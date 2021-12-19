using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The PlayerController controls the movement of the players
 */
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float speed = 400f;
    [SerializeField]
    private float jumpingForce = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move();
    }

    /**
     * FixedUpdate is called before each internal physical update (moving things due to physics e.g. gravity)
     * 
     * * Difference between Update and FixedUpdate *
     * 
     * - Update: user inputs, visual effects and interpolation between game states. Frequency of being called
     *   varies by host device. 150 times per second for 150 FPS. Bad experience for low FPS. This could lead 
     *   to the speed in it being defined as unit/frame instead of unit/second.
     * - FixedUpdate: physics-related updates, game state. Unity's fixed timestep is 0.02s, which translates 
     *   to 50 times of calls per second.
     * 
     * Resource: https://john-tucker.medium.com/unity-update-versus-fixedupdate-7a4d4d7bc1f5
     */
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        HorizontalMove();
        Jump();
    }

    /**
     * The method controls the horizontal movement of the players
     */
    private void HorizontalMove()
    {
        // 0 for no movement, negative number for left movement and positive number for right movement
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (horizontalMovement != 0)
        {
            rigidbody2D.velocity = new Vector2(horizontalMovement * speed * Time.fixedDeltaTime, rigidbody2D.velocity.y);

            // transform defines the position/rotation/scale of the player. The direction that the player faces changes based on the keyboard input.
            transform.localScale = new Vector3(Mathf.Sign(horizontalMovement), 1, 1);
        }
    }

    /**
     * The method controls player's jumping operation
     */
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingForce * Time.fixedDeltaTime);
        }
    }
}
