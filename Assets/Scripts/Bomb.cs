using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Score scoreObject;
    private GameManager gameManager;
    private Rigidbody rb;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreObject = FindObjectOfType<Score>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * 0.5f, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Knife"))
        {
            gameManager.EndGame(0);
        }
    }
}
