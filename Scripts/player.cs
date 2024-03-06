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
    [SerializeField] private Vector3 offset_left_targ;
    [SerializeField] private Vector3 offset_right_targ;



    public float rotationSpeed = 50f; // Speed of rotation
    public float radius = 2f; // Radius of the circular path
    private Vector3 ccenterPosition; // Center of the circular path

    void Awake()
    {
        maincam = Camera.main;
    }
    void Start()
    {
        ccenterPosition = transform.parent.position;
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


        //print("Left Foot :" + Vector3.Distance(left_foot_target.transform.position, transform.position + offset_left_targ));
        //if (Vector3.Distance(left_foot_target.transform.position, transform.position + offset_left_targ) > 0.5)
        //    left_foot_target.transform.position = transform.position + offset_left_targ;



        //print("Right Foot :" + Vector3.Distance(right_foot_target.transform.position, transform.position + offset_right_targ));
        //if (Vector3.Distance(right_foot_target.transform.position, transform.position + offset_right_targ) > 0.5)
        //    right_foot_target.transform.position = transform.position + offset_right_targ;


        //right_foot_target.transform.position = right_foot_step.transform.position;

    }
    private void OnDrawGizmos()
    {
        float angle = Time.time * rotationSpeed; // Time.time gives us the time since the start of the game
        float x = ccenterPosition.x + Mathf.Cos(angle) * radius;
        float z = ccenterPosition.z + Mathf.Sin(angle) * radius;

        // Set the object's position to the calculated position
        transform.position = new Vector3(x, transform.position.y, z);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(x, 1, z), 0.1f);
        //Gizmos.DrawSphere(transform.position + offset_right_targ, 0.1f);
        //Gizmos.DrawSphere(transform.position + offset_left_targ, 0.1f);
    }
}
