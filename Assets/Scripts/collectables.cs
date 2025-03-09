using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectables : MonoBehaviour
{
    private int crystals = 0;

    [SerializeField] private AudioSource collectionSound;

    [SerializeField] private Text crystalsText; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("crystal"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            crystals++;
            crystalsText.text = "Crystals: " + crystals;
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
