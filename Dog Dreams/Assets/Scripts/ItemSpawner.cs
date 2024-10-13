using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //Items to spawn
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Item spawn Position: " + transform.position);
        int rand = Random.Range(0, items.Length);
        //Needed to stop the spawner from changing the Z coordinate
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(items[rand], spawnPosition, Quaternion.identity);
    }
}
