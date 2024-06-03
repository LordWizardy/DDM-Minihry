using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBigger : MonoBehaviour
{
    public Material[] materials;

    public float waterLevel = 0f; // Level of the water surface
    public float floatHeight = 2f; // Height at which the object floats
    public float bounceDamp = 0.05f; // Damping factor for bouncing
    public Vector3 buoyancyCentreOffset; // Offset for the buoyancy center

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 uplift;

    public float inflate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        if (materials.Length > 0)
        {
            int randomIndex = Random.Range(0, materials.Length); // Generate a random index within the array bounds
            Material randomMaterial = materials[randomIndex]; // Get the randomly selected material

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component

            if (spriteRenderer != null && randomMaterial != null)
            {
                spriteRenderer.material = randomMaterial; // Assign the random material to the object's sprite
            }
            else
            {
                Debug.LogWarning("SpriteRenderer component or random material is missing.");
            }
        }
        else
        {
            Debug.LogWarning("No materials assigned in the array.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Mouse clicked on: " + hit.collider.gameObject.name);
                transform.localScale *= inflate;

                // Add your custom logic here for when the object is clicked
            }
        }
    }

    //void OnTriggerStay2D(Collider2D Hit)
    //{
    //    if (Hit != null && Hit.gameObject.name == "Water")
    //    {
    //        actionPoint = Hit.transform.position + Hit.transform.TransformDirection(buoyancyCentreOffset);
    //        forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

    //        Debug.Log("Force factor: " + forceFactor);

    //        if (forceFactor > 0f)
    //        {
    //            uplift = -Physics2D.gravity * (forceFactor - Hit.attachedRigidbody.velocity.y * bounceDamp);
    //            Debug.Log("Uplift: " + uplift);
    //            Debug.Log("AP: " + actionPoint);
    //            Hit.attachedRigidbody.AddForceAtPosition(uplift, actionPoint);
    //        }
    //    }
    //}
}
