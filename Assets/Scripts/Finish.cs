using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator portalAnimator;

    private AudioSource finishSound;
    private bool levelCompleted = false;

    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        boss = GameObject.FindGameObjectWithTag("boss");
        portalAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && !levelCompleted && BossIsDestroyed() == true)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("completeLevel", 1f);
        }
    }
    private bool BossIsDestroyed()
    {
        return boss == null || !boss.activeSelf;
    }

    private void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BossIsDestroyed() == true)
        {
            portalAnimator.SetTrigger("Open");
        }
    }
}
