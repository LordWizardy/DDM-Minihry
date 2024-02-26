using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float speed = 2f; // Speed at which the enemy follows the player

    public Material Material1; // The material you want to assign
    public Material Material2; // The material you want to assign

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Rotate to look at the player
            transform.LookAt(target);
        }
        else
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("kolize");
        if (collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
            GetComponent<MeshRenderer>().material = Material2;
        }
    }
}
