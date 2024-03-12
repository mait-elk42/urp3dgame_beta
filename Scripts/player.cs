using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCamera player_cam;
    public float xsens = 10f;
    public float ysens = 10f;
    void Awake()
    {
        this.player_cam = new PlayerCamera(this.gameObject, Camera.main, 5, xsens, ysens);
    }
    void Update()
    {
        player_cam.Follow(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
