using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerCamera player_camera;
    private CharacterController controller;
    private Vector3 dir;
    public float speed;
    void Awake()
    {
        dir = Vector3.zero;
        this.player_camera = new PlayerCamera(this.gameObject, Camera.main,  500, new Vector3(0f, 0.5f, 0f), -70, 70);
        controller = this.GetComponent<CharacterController>();
    }
    void Start()
    {
        player_camera.enable();
        
    }
    void Update()
    {
        player_camera.Update(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKey(KeyCode.W))
            dir = transform.forward;
        controller.Move(dir * speed * Time.deltaTime);
        dir = Vector3.zero;
    }
}
