



using UnityEngine.SceneManagement;
using UnityEngine;

using System;

public class SpownerEnemy : MonoBehaviour
{

    public GameObject Enemy;
    private float interval = 200;
    private float counter = 0;
    int enemyN=0;  //numer of enemies that are instantiated till now

    public GameObject winCanvas;
    public float t;
    // Start is called before the first frame update
    void Start()
    {   //System.Random random=new System.Random();
        interval = Mathf.Floor(100 /SceneManager.GetActiveScene().buildIndex) ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        System.Random random = new System.Random();
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, random.Next(0, Screen.height), 10f));
        counter += 1;
        if (counter > interval  && enemyN<Control.NumOfenemies)
        {
            enemyN++;
            counter = 0;
            Instantiate(Enemy, spawnPos, Quaternion.identity);
            print("instan");
            t = Time.time;
        }
       else if (enemyN == Control.NumOfenemies  && !Control.death && Time.time-t>=5.0f)
        {   
            print("enemyN" + enemyN);
            winCanvas.SetActive(true);
            Control.winLevel = SceneManager.GetActiveScene().buildIndex;
            print("win level");
        }
        

    }

}