using UnityEngine;

public class PlayerMover
{
    private CharacterController controller;
    private float gravity_force;
    private float jump_force;
    private float speed;
    private Vector3 dir;

    public PlayerMover(CharacterController controller, float gravity_force, float jump_force, float speed)
    {
        this.controller = controller;
        this.gravity_force = gravity_force;
        this.jump_force = jump_force;
        this.speed = speed;
    }

    public void    Update(float forward, float right, bool jumpbool)
    {
        bool player_grounded = controller.isGrounded;
        dir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(right, 0, forward);
        if (jumpbool && player_grounded)
            dir.y += jump_force;
        dir.y += gravity_force * Time.deltaTime;
        controller.Move(dir * speed * Time.deltaTime);
    }
}
