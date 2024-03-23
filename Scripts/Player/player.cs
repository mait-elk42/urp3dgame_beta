using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCamera player_camera;
    private PlayerMover player_mover;

    void Awake()
    {
        player_camera = new PlayerCamera(this.gameObject, Camera.main, 400f, Vector3.zero, -70f, 70f);
        player_mover = new PlayerMover(transform.GetComponent<CharacterController>(), -60f, 20f, 10f);
    }
    void Start()
    {
        player_camera.enable();
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward , out hit, 2f, LayerMask.GetMask("Default")))
        {
            Debug.Log("asdasdasd" + hit.collider.name);
        }
        player_camera.Update(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        player_mover.Update(Input.GetAxis("Vertical"),
                            Input.GetAxis("Horizontal"),
                            Input.GetKeyDown(KeyCode.Space));
    }
}
