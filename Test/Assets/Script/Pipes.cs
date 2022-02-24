using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Pipes : MonoBehaviour
{
    
    public Transform top;
    public Transform bottom;

    public float speed = 5f;
    
    private float OutScreen;

    private void Start()
    {
        OutScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    //move the position of our object
    private void Update()
    {
        //
        transform.position += Vector3.left * speed * Time.deltaTime;
        //destroy the pipe when they're out the screen
        if (transform.position.x < OutScreen) {
            Destroy(gameObject);
        }
    }

}
