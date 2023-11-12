using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad1_lab5 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isMoving = false;
    public float distance = 6.6f;
    private float startPosition;
    private float endPosition;
    private bool movingToEnd = true;
    private Transform oldParent;

    void Start()
    {
        endPosition = transform.position.x + distance;
        startPosition = transform.position.x;
    }

    void Update()
    {
        if (isMoving)
        {
            float targetPosition = movingToEnd ? endPosition : startPosition;
            float step = elevatorSpeed * Time.deltaTime;
            float newPosition = Mathf.MoveTowards(transform.position.x, targetPosition, step);
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

            // Sprawdzanie, czy platforma osiągnęła pozycję docelową
            if (transform.position.x == targetPosition)
            {
                if (movingToEnd)
                {
                    movingToEnd = false; // Zmiana kierunku
                }
                else
                {
                    isMoving = false; // Zatrzymanie platformy po powrocie do pozycji startowej
                }
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            if (!isMoving)
            {
                isMoving = true;
                movingToEnd = true; // Rozpoczęcie ruchu do końcowej pozycji
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
