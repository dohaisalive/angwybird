using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float launchforce = 500;
    [SerializeField] float maxdragdistance = 5;

    Vector2 startPosition;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool isdragging { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = rb.position;
        rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        isdragging = true;
        sr.color = Color.red; 
    }

    void OnMouseUp()
    {
        Vector2 currentposition = rb.position;
        Vector2 direction = startPosition - currentposition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * launchforce);
        sr.color = Color.white;
        isdragging = false;
    }

    void OnMouseDrag()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredposition = mousePosition;
       

        float distance = Vector2.Distance(desiredposition, startPosition);
        if (distance > maxdragdistance)
        {
            Vector2 direction = desiredposition - startPosition;
            direction.Normalize();
            desiredposition = startPosition + (direction * maxdragdistance);
        }

        if (desiredposition.x > startPosition.x)
            desiredposition.x = startPosition.x;
        rb.position = desiredposition;
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Resetafterdelay());
       
    }

    IEnumerator Resetafterdelay()
    {
        yield return new WaitForSeconds(3); 
        rb.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
}
