using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 direction;
    [Range(10, 20)] [SerializeField] private float gravity = 20;

    [Header("Other")]
    [Range(2, 20)] [SerializeField] private float speed;
    [Range(10, 20)] [SerializeField] private float force;

    private readonly float multiplier = -1;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && controller.isGrounded)
        {
            direction.y = force;
            force = 10;
        }
    }

    private void FixedUpdate()
    {
        // move player
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            force += 0.25f;

            if (force > 20) force = 20;
        }

        direction.x = speed;
        direction.y += gravity * multiplier * Time.fixedDeltaTime;

        controller.Move(direction * Time.fixedDeltaTime);
    }
}