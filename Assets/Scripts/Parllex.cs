using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parllex : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float aniSpeed = 2f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(aniSpeed* Time.deltaTime, 0f);
    }
}
