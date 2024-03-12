using UnityEngine;

public class PlayerCamera
{
    private GameObject target;
    private Vector3 pos;
    private Camera cam;
    private float angle;
    private float distance;
    private float xsens;
    private float ysens;
    private float height;

    public PlayerCamera(GameObject target, Camera cam, float distance, float xsens, float ysens)
    {
        this.target = target;
        this.cam = cam;
        this.distance = distance;
        this.xsens = xsens;
        this.ysens = ysens;
        this.pos = Vector3.zero;
    }

    public void Follow(float x, float y)
    {
        angle += x * xsens * Time.deltaTime;
        if (height + y < 5 && height + y > -5)
            height += y * ysens * Time.deltaTime;

        pos.x = Mathf.Sin(angle) * distance;
        pos.y = height;
        pos.z = Mathf.Cos(angle) * distance;

        cam.transform.position = pos + this.target.transform.position;
        cam.transform.LookAt(this.target.transform.position);
    }
}
