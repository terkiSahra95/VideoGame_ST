using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this function allows to define how often the pipes spawn and change the position of the range(randomize where the pipe spawn)
public class Spaw : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;

    // position of the pipe range between min and max 
    public float min = -1f;

    public float max = 2f;

    //Repeating when is enable
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    //If player lose we disable the spawner and stop everything
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    //Clone our prefab
    private void Spawn()
    {
        //"Instantiate" allows us to create a new object and it's going to clone an existing one
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        pipes.transform.position += Vector3.up * Random.Range(min, max);
    }

}

