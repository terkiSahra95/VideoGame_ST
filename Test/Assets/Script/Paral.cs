using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paral : MonoBehaviour
{
    //reference to the mesh renderer, to have access and change the material
    //same as our player.c
    private MeshRenderer meshRenderer;
    //customize the speed
    public float animatSpeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animatSpeed * Time.deltaTime, 0);
    }
}

