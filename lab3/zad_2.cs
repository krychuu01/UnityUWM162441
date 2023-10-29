using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_2 : MonoBehaviour
{

    public float traverseSpeed = 5.0f;
    private Vector3 startingPosition;
    private float distanceToMove = 10.0f;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move(direction);

        if (direction == 1 && transform.position.x - startingPosition.x >= distanceToMove) {
            direction = -1;
        }

        if (direction == -1 && transform.position.x <= startingPosition.x) {
            direction = 1;
        }
    }

    void move(int direction) {
        transform.Translate(direction * traverseSpeed * Time.deltaTime, 0, 0);
    }
}