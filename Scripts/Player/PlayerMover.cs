using UnityEngine;

public class PlayerMover
{
    private CharacterController controller;
    private float gravity_force;
    private float jump_force;
    private float speed;
    private Vector3 dir = Vector3.zero;

    public PlayerMover(CharacterController controller, float gravity_force, float jump_force, float speed)
    {
        this.controller = controller;
        this.gravity_force = gravity_force;
        this.jump_force = jump_force;
        this.speed = speed;
    }

    public void Update(float forward, float right, bool jumpbool)
    {
        dir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(right, dir.y, forward);
        if (jumpbool && controller.isGrounded)
            dir.y = jump_force;
        if (controller.isGrounded == false)
            dir.y += gravity_force * Time.deltaTime;
        if (controller.isGrounded == false)
            Debug.Log(dir * speed * Time.deltaTime);
        controller.Move(dir * speed * Time.deltaTime);
    }
}
