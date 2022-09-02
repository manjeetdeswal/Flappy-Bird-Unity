using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject prefab;
    public float spwanRate = 1f;
    public float minH = -1f;
    public float maxH = 1f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spwan),spwanRate,spwanRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spwan));
    }

    void Spwan()
    {
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minH, maxH);

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
