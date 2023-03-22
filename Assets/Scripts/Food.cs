using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    public float startForce = 0.001f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * startForce, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
