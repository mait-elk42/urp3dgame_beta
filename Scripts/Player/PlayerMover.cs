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

    public void Update(float forward, float right, bool jumpbool)
    {
        bool is_grounded = controller.isGrounded;
        dir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(right, dir.y, forward);
        if (jumpbool && is_grounded)
            dir.y = jump_force;
        else
        {
            dir.y += gravity_force * Time.deltaTime;
            if (is_grounded)
                dir.y = 0f;
        }
        controller.Move(dir * speed * Time.deltaTime);
        if (jumpbool && controller.isGrounded)
            Debug.Log(dir * speed * Time.deltaTime);
         Debug.Log("DIRECTION : " + dir);
    }
}
