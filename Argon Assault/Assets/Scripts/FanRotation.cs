using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] float ro = 1f;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, ro) * Time.deltaTime);
    }
}
