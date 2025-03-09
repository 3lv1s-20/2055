using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" || collision.gameObject.tag == "trap")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" || collision.gameObject.tag == "trap")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
