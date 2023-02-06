using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles : MonoBehaviour
{
    public int I = 1;
    public int value;
    //public string [] names;

    //public Vector3[] positions;
    //public GameObject prefab;

    void Start()
    {
        /*foreach(Vector3 p in positions)
        {
            Instantiate(prefab, p, Quaternion.identity);
        }*/
        while (I <= 10)
        {
            Debug.Log(message: $"{value} x {I} = {value * I}");
            I++;
        }
        /*for(int i = 1; i <= 10; i++)
        {
            Debug.Log(message:$"{value} x {i} = {value * i}");
        }
        for(int i = 0; i <names.Length; i++)
        {
            Debug.Log(names[i]);
        }*/
        /*for (int i = 10; i < positions.Length; i++)
        {
            Instantiate(prefab, positions[i], Quaternion.identity);
        }*/
    }

}
