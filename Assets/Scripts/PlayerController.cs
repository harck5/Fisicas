using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    public bool hasPowerup;
    private float powerupForce = 15f;


    private GameObject FocalPoint;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(FocalPoint.transform.forward * speed * forwardInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }
}