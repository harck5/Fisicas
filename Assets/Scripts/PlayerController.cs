using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    public bool hasPowerup, hasPowerup2;
    private float powerupForce = 15f;
    public GameObject[]powerupIndicators;
    private float oiginalScale = 1.5f;
    private float powerUpScale = 2f;



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
            StartCoroutine (PowerupCountDown());
        }
        if (other.gameObject.CompareTag("PowerUp2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine (PowerupCountDown());
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
    /*private IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(6);
        hasPowerup = false;
        
    }*/
    private IEnumerator PowerupCountDown()
    {
        if (hasPowerup2)
        {
            transform.localScale = powerUpScale * Vector3.one;
        }
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }
        if (hasPowerup2)
        {
            transform.localScale = oiginalScale * Vector3.one;
        }

    }
}
