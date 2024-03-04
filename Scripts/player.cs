using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    private Camera maincam;
    public float speed = 10;
    public float foots_follow_speed = 10;
    [SerializeField]
    private GameObject left_foot_target;
    [SerializeField]
    private GameObject right_foot_target;
    [SerializeField]
    private GameObject left_foot_step;
    [SerializeField]
    private GameObject right_foot_step;
    void Awake()
    {
        maincam = Camera.main;
    }
    void Start()
    {
        
    }

    void player_move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.S))
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.A))
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.D))
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void camera_follow()
    {
        maincam.transform.position = Vector3.Lerp(maincam.transform.position, this.transform.position + offset, 10);
    }

    void Update()
    {
        camera_follow();
        player_move();
        if (Vector3.Distance(left_foot_step.transform.position, left_foot_target.transform.position) > 1)
            left_foot_target.transform.position = left_foot_step.transform.position;
        if (Vector3.Distance(right_foot_step.transform.position, right_foot_target.transform.position) > 1)
            right_foot_target.transform.position = right_foot_step.transform.position;
    }
}
