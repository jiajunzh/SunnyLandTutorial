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
    private float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /**
     * The method controls the movement of the players
     */
    void Move()
    {
        // 0 for no movement, -1 for left movement and 1 for right movement
        float horizontalDirection = Input.GetAxis("Horizontal");

        if (horizontalDirection != 0)
        {
            rigidbody2D.velocity = new Vector2(horizontalDirection * speed, rigidbody2D.velocity.y);
        }
    }
}
