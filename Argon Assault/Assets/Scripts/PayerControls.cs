using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] float xRange = 1.8f;
    [SerializeField] float yRange = 0.9f;


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
