using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 0.01f;
    private Rigidbody _rigidbody;
    private GameObject player;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {//            pera persecución      primero destino y luego origen
        Vector3 direction = (player.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * speed);

    }
}
