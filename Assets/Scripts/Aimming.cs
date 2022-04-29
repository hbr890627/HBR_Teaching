using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimming : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotaion = Vector3.zero;
    private Vector3 camRotaion = Vector3.zero;
    [SerializeField]
    private float mouseSensitivity = 3f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 v = (Vector3.right * x + Vector3.forward * y).normalized * speed;
        velocity = v;


        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 r = new Vector3(0, yRotation, 0) * mouseSensitivity;
        rotaion = r;

        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cr = new Vector3(xRotation, 0, 0) * mouseSensitivity;
        camRotaion = cr;
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
            rb.MovePosition(transform.position + velocity * Time.deltaTime);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotaion));
        if (cam != null)
        {
            cam.transform.Rotate(-camRotaion);
        }
    }
}
