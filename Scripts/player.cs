using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    private Camera maincam;
    [SerializeField]
    private float speed = 500;
    void Awake()
    {
        maincam = Camera.main;
    }
    void Start()
    {

    }

    void Update()
    {
        maincam.transform.position = this.transform.position + offset;
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
