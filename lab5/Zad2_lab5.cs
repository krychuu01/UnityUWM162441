using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad2_lab5 : MonoBehaviour
{
    public float moveSpeed = 2f;        
    public float moveDistance = 5f;     
    private bool isMoving = false;      
    private Vector3 startPosition;      
    private Vector3 targetPosition;        
    private bool movingToEnd = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(startPosition.x + moveDistance, startPosition.y, startPosition.z);
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 nextPosition = movingToEnd ? targetPosition : startPosition;
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

            if (transform.position == nextPosition)
            {
                if (movingToEnd)
                {
                    movingToEnd = false;
                }
                else
                {
                    isMoving = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isMoving)
        {
            movingToEnd = true;
            isMoving = true;
            Debug.Log("wykryto kolizję");
        }
    }

}
