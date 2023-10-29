using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_3 : MonoBehaviour
{

    public float traverseSpeed = 5.0f;
    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private float distanceToMove = 10.0f;
    private int forward = 0;

    void Start()
    {
        startingPosition = transform.position;
        targetPosition = getTargetPosition();
    }

    void Update()
    {
        move();

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) {
            targetPosition = getTargetPosition();
            rotate90deg();
        }

    }

    void move() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, traverseSpeed * Time.deltaTime);
    }

    void rotate90deg() {
        transform.Rotate(0, -90, 0);
    }

    Vector3 getTargetPosition() {
        if (forward == 0) {
            forward++;
            return startingPosition + new Vector3(distanceToMove, 0, 0);
        }
        if (forward == 1) {
            forward++;
            return startingPosition + new Vector3(distanceToMove, 0, distanceToMove);
        }
        if (forward == 2) {
            forward++;
            return startingPosition + new Vector3(0, 0, distanceToMove);
        }           
        else {
            forward = 0;
            return startingPosition;
        }
    }

}
