using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragline : MonoBehaviour
{
    LineRenderer lineRenderer;
    Bird bird; 

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        bird = FindObjectOfType<Bird>();

        Vector3 linezero = new Vector3(
            bird.transform.position.x,
            bird.transform.position.y,
            -0.1f);
        lineRenderer.SetPosition(0, linezero);
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.isdragging)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, bird.transform.position);
        }
            
        else
            lineRenderer.enabled = false;
    }
}
