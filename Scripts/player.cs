using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCamera player_camera;
    private CharacterController controller;
    private Vector3 dir;
    public float gravity;
    public float speed;
    public float jump_force;

    void Awake()
    {
        player_camera = new PlayerCamera(this.gameObject, Camera.main, 400f, new Vector3(0, 0.5f, 0), -70, 70);
        controller = this.GetComponent<CharacterController>();
    }
    void Start()
    {
        player_camera.enable();
    }
    void Update()
    {
        player_camera.Update(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (controller.isGrounded == false)
            dir.y += gravity * Time.deltaTime;
        else
            dir.y = 0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(gameObject.transform.position, -transform.up, 1.3f, LayerMask.GetMask("Default")))
            {
                dir.y += jump_force;
                Debug.Log("grounded");
            }
        }
        if (Input.GetKey(KeyCode.W))
            dir += transform.forward;
        if (Input.GetKey(KeyCode.S))
            dir += -transform.forward;
        if (Input.GetKey(KeyCode.D))
            dir += transform.right;
        if (Input.GetKey(KeyCode.A))
            dir += -transform.right;
        controller.Move(dir * speed * Time.deltaTime);
        dir.x = 0f;
        dir.z = 0f;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Gizmos.DrawLine(gameObject.transform.position, transform.up * );
    //}
}
