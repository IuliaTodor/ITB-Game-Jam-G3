using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public void Awake()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
    public void FixedUpdate()
    {
        if (transform.localScale.x >= 1) Destroy(this);
        else transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.06f);
    }
}
