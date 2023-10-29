using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_4 : MonoBehaviour
{

    public float traverseSpeed = 5.0f;

    void Update()
    {
        float horizontalVal = Input.GetAxis("Horizontal");
        float verticalVal = Input.GetAxis("Vertical"); 

        Vector3 move = new Vector3(horizontalVal, 0, verticalVal);

        transform.Translate(move * traverseSpeed * Time.deltaTime);
    }

}
