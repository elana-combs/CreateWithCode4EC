using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // "gets" the Rigidbody the script is applied to.
        player = GameObject.Find("Player"); // finds the GameObject, Player, within the scene.
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed); //the Enemy tracks the player, but with "normalized", it pursues at a standard speed.
    }
}
