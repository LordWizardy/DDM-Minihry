using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    public float waterLevel = 0f; // Level of the water surface
    public float floatHeight = 2f; // Height at which the object floats
    public float bounceDamp = 0.05f; // Damping factor for bouncing
    public Vector3 buoyancyCentreOffset; // Offset for the buoyancy center

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 uplift;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D Hit)
    {
        if (Hit != null && Hit.gameObject.tag == "Balloon")
        {
            actionPoint = Hit.transform.position + Hit.transform.TransformDirection(buoyancyCentreOffset);
            forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

            Debug.Log("Force factor: " + forceFactor);

            if (forceFactor > 0f)
            {
                uplift = -Physics2D.gravity * (forceFactor - Hit.attachedRigidbody.velocity.y * bounceDamp);
                Debug.Log("Uplift: " + uplift);
                Debug.Log("AP: " + actionPoint);
                Hit.attachedRigidbody.AddForceAtPosition(uplift, actionPoint);
            }
        }
    }
}
