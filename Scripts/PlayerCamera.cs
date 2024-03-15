using UnityEngine;

public class PlayerCamera
{
    private bool        enabled;
    private GameObject  player;
    private Camera      main_camera;
    private float        camera_sensitivity;
    private float        xRotation;
    private Vector3      camera_offset;
    private float        y_min;
    private float        y_max;

    public PlayerCamera(GameObject player, Camera main_camera, float camera_sensitivity, Vector3 camera_offset, float y_min, float y_max)
    {
        this.enabled = false;
        this.player = player;
        this.main_camera = main_camera;
        this.camera_sensitivity = camera_sensitivity;
        this.camera_offset = camera_offset;
        this.y_min = y_min;
        this.y_max = y_max;
        main_camera.transform.position = player.transform.position + camera_offset;
    }

    public void enable()
    {
        this.enabled = true;
    }
    public void disable()
    {
        this.enabled = false;
    }
    public void Update(float x, float y)
    {
        main_camera.transform.position = player.transform.position + camera_offset;
        if (this.enabled == false)
            return;
        xRotation -= y * camera_sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, y_min, y_max);

        main_camera.transform.rotation = Quaternion.Euler(xRotation, player.transform.eulerAngles.y, 0f);
        player.transform.Rotate(Vector3.up * x * camera_sensitivity * Time.deltaTime);
    }
}
