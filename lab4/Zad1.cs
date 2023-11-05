using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;

    [SerializeField]
    private int objectsToGenerate; // ilosc obiektow do generowania

    [SerializeField]
    private List<Material> materials;
    // obiekt do generowania
    [SerializeField]
    private GameObject block;
    

    void Start()
    {
        Bounds bounds = GetComponent<Collider>().bounds;

        for(int i=0; i< objectsToGenerate; i++)
        {
            float xPosition = UnityEngine.Random.Range(bounds.center.x -15, bounds.center.x + 15);
            float zPosition = UnityEngine.Random.Range(bounds.center.z -15, bounds.center.z + 15);
            positions.Add(new Vector3(xPosition, 5, zPosition));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        int counter = 0;
        foreach(Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, positions.ElementAt(counter), Quaternion.identity);
            MeshRenderer newBlockMesh = newBlock.GetComponent<MeshRenderer>();
            newBlockMesh.material = getRandomMaterial();
            counter++;
            yield return new WaitForSeconds(delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }

    private Material getRandomMaterial() {
        int randomMaterial = UnityEngine.Random.Range(0, 5);
        return materials[randomMaterial];
    }
}