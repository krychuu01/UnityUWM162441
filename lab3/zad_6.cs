using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_6 : MonoBehaviour
{
    Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    void Update()
    {
        // float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        // transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

        float newPosition2 = Mathf.Lerp(transform.position.y, target.position.y, smoothTime * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newPosition2, transform.position.z);
    }

}
