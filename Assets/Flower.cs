using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public Material Material1; // The material you want to assign
    public Material Material2; // The material you want to assign
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("kolize");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            GetComponent<SphereCollider>().enabled = true;
            child.GetComponent<MeshRenderer>().material = Material2;
        }
    }
}
