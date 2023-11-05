using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        float verticalRotation = mouseYMove;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(0, verticalRotation, 0);
        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);
    }
}
