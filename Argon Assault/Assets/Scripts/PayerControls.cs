using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] float xRange = 1.8f;
    [SerializeField] float yRange = 1.5f;

    [SerializeField] float PositionPitchFactor = 15f;
    [SerializeField] float PositionRollFactor = 15f;
    [SerializeField] float PositionYawFactor = 40f;


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        float pitch =  - (transform.localPosition.y / yRange) * PositionPitchFactor;
        float yaw = 0f; 
        float roll = 0f;

        Debug.Log(pitch);
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
