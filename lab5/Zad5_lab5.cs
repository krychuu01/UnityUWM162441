using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad5_lab5 : MonoBehaviour
{
    [SerializeField]
    private float jumpMultiplier; // Mnożnik siły skoku

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("wszedl na płytke");
            // Pobranie MoveWithCharacterController z obiektu gracza
            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();

            if (playerController != null)
            {
                Debug.Log("Wyrzucenie gracza w powietrze"); 
                playerController.Jump(jumpMultiplier);
            }
        }
    }
}
