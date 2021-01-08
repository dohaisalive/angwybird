using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite deadsprite;
    [SerializeField] ParticleSystem particle;

    bool hasdied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Shoulddie(collision))
            StartCoroutine(Die());
    }

    bool Shoulddie(Collision2D collision)
    {
        if (hasdied)
            return false;

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5) //object is coming from above
            return true;


        return false;
    }

    IEnumerator Die()
    {
        hasdied = true;
        GetComponent<SpriteRenderer>().sprite = deadsprite;
        particle.Play();
        
        yield return new WaitForSeconds(1);
        
        gameObject.SetActive(false);
    }
        

}
