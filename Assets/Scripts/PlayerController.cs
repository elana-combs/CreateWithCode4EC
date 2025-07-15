using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private GameObject focalPoint;

    public float speed = 5.0f;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // sets playerRb as the rigidbody already on the object the script is attached to.
        focalPoint = GameObject.Find("FocalPoint"); // finds the FocalPoint GameObject in the object hierarchy.
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); //automatically up/down as movement keys

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed); //Allows the player to move directionally with the rotation of the focal point.
    }
}
