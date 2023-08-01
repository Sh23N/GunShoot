
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWalk : MonoBehaviour
{
    float enemySpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 2 * SceneManager.GetActiveScene().buildIndex + 3;//hard base level
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime); 
    }
    void OnCollisionEnter(Collision collision)
    {

    }
}
