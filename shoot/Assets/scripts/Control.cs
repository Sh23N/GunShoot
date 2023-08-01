
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Hand;
   
    bool trigger = false;//****
    public AudioSource GunSound;
    static public int winLevel = 0;
   static  public int NumOfenemies = 0;

    public GameObject RKnee;
    public GameObject LKnee;
    public GameObject LLeg;

    bool standUp = true;

    static public bool death=false;

    float TriggerTime;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        NumOfenemies = 2 * SceneManager.GetActiveScene().buildIndex + 1; //hard base level
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time-TriggerTime   >= 0.7f)
            trigger = false;
        Shoot();
       
    }
    void Shoot()
    {
        Vector3 rayPos=Gun.transform.position;
        Vector3 rayDir=Gun.transform.right;
        RaycastHit hit;
        if(Physics.Raycast(rayPos,rayDir,out hit, 300f))
        {
            Debug.DrawRay(rayPos, rayDir, Color.green);
            if(hit.collider.CompareTag("Enemy") && trigger==true )
            {
                    Destroy(hit.collider.gameObject);
            }
            
        }
        else
            Debug.DrawRay(rayPos, rayDir, Color.red);
    }
    public void Rotate(float d)
    {
        Hand.transform.Rotate(d, 0.0f, 0.0f, Space.Self);
    }
    public void pushTrigger()
    {
        GameObject Bullet=Instantiate(bullet,Gun.transform.position, Gun.transform.rotation);
        Rigidbody projectileRb = Bullet.GetComponent<Rigidbody>();
        projectileRb.AddForce(100 * Gun.transform.right, ForceMode.Impulse);
        trigger = true;
        GunSound.Play();
        TriggerTime = Time.time;
    }
    public void standUpDown()
    {
        if (!standUp)// to stand up
        {
            RKnee.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
            LLeg.transform.Rotate(2f, 0.0f, 90.0f, Space.Self);
            LKnee.transform.Rotate(2f, 0.0f, -90.0f, Space.Self);
            transform.position += new Vector3(0.0f, 50f * Time.deltaTime, 0f);
            standUp = true;

        }
        else//to sit down
        {
            RKnee.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            LLeg.transform.Rotate(2f, 0.0f, -90.0f, Space.Self);
            LKnee.transform.Rotate(2f, 0.0f, 90.0f, Space.Self);
            transform.position -= new Vector3(0.0f,50f * Time.deltaTime, 0f);
            standUp = false;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("level" + (winLevel+1));
    }
    public void levelSelect()
    {
        SceneManager.LoadScene("menu");
    }
    public void NextSelect()
    {
        
        if(winLevel == 3)
        {
            SceneManager.LoadScene("level3");
        }
        else
            SceneManager.LoadScene("level" + winLevel + 1);
    }
    public void OnClickClose()
    {
        Application.Quit();
    }
}
