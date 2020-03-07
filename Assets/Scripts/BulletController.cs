using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public List<string> tagShouldDestroy;
    // Start is called before the first frame update
    void Start()
    {
        tagShouldDestroy.Add("ground");
        tagShouldDestroy.Add("blockPath");
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * speed ; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < tagShouldDestroy.Count; i++)
        {
            if (collision.tag.Equals(tagShouldDestroy[i]))
            {
                Destroy(this.gameObject);
            }
        }
        

    }
}
