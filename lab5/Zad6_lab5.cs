using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6_lab5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Przeszkoda"))
        {
            Debug.Log("Kolizja z przeszkodą");
        }
    }
}
