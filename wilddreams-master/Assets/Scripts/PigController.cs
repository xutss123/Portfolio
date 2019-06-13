using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool hasObject = false;
    public bool isjumping;
    public float jumpAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isjumping = false;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && !isjumping)
        {
            rb.AddForce(new Vector3(0, 40, 0), ForceMode.Impulse);
            isjumping = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasObject = true;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Dirt(Clone)" || c.gameObject.name == "Put(Clone)")
        {
            isjumping = false;
        }
    }
}