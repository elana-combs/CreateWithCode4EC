using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;


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

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // allows the powerup indicator to follow the player sphere, offset by -0.5 on the y.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) // when the player collides with an object with the Powerup tag, the Powerup object will be destroyed, and the hasPowerup boolean will change to True.
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true); // activates the powerup indicator game object.
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); //when the Enumerator is triggered, the script must wait 7 seconds before changing powerup to false.
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false); // disables the powerup indicator game object.
    }

    private void OnCollisionEnter(Collision collision) // only activates if the player has a powerup AND collides with an enemy.
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;


            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse); //immediately (impulse) applies extra force to the enemy upon impact.
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }


}
