using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Player;
    public AudioSource deathSound;

    public GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            deathSound.Play();
           Control.death = true;
            GameOver.SetActive(true);
           Player.SetActive(false);
             mainCanvas.SetActive(false);

        }
    }
}
