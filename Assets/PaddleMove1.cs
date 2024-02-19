using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove1 : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
