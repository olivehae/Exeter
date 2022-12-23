using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
    }
}
