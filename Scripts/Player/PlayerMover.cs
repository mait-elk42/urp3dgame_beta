using UnityEngine;

public class PlayerMover
{
    private CharacterController controller;
    private float gravity;
    private float jump_force;
    private float speed;
    private Vector3 velocity = Vector3.zero;

    public PlayerMover(CharacterController controller, float gravity, float jump_force, float speed)
    {
        this.controller = controller;
        this.gravity = gravity;
        this.jump_force = jump_force;
        this.speed = speed;
    }

    public void Update(float vertical, float horizontal, bool jumpbool)
    {
        Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        velocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded && jumpbool)
            velocity.y = jump_force;
        movement += velocity * Time.deltaTime;
        controller.Move(movement);
    }
}
