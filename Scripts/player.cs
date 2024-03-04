using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    private Camera maincam;
    //[SerializeField]
    //private float speed = 500;
    [SerializeField]
    private GameObject left_foot_target;
    [SerializeField]
    private GameObject right_foot_target;
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
            left_foot_target.transform.position += Vector3.forward * Time.deltaTime;
            //right_foot_target.transform.position += Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            left_foot_target.transform.position += Vector3.back * Time.deltaTime;
            //right_foot_target.transform.position += Vector3.back * Time.deltaTime;
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
        player_move();
    }
}
