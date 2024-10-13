using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemGenerator : MonoBehaviour
{
    //Items to spawn
    public GameObject[] sceneItems;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene spawn Position: " + transform.position);
        int rand = Random.Range(0, sceneItems.Length);
        //Needed to stop the spawner from changing the Z coordinate
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(sceneItems[rand], spawnPosition, Quaternion.identity);
    }
}
