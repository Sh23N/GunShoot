using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class menu : MonoBehaviour
{
    float t;

    public Button level1;
    public Button level2;
    public Button level3;

    public Sprite lockImage;
    public Sprite notLockImage;
    [SerializeField]
    private InputActionAsset inputAction;

    private InputAction Level1SelectAction;
    private InputAction Level2SelectAvtion;
    private InputAction Level3SelectAction;

    void Awake()
    {
        Level1SelectAction = inputAction.FindAction("Level1Select");
        Level2SelectAvtion = inputAction.FindAction("Level2Select");
        Level3SelectAction = inputAction.FindAction("Level3Select");

    }
    // Start is called before the first frame update
    void Start()
    {  
        t = Time.time;
        //PlayerPrefs.SetInt("lastLevel", 0);
    }

    // Update is called once per frame
    void Update()
    {
       // Control.winLevel = PlayerPrefs.GetInt("lastLevel") + 1;
        print(Control.winLevel);
        if (Time.time - t >= 1.5f)
        {
            level1.gameObject.SetActive(true);
            level2.gameObject.SetActive(true);
            level3.gameObject.SetActive(true);
            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";

        }
        if (Control.winLevel == 1)
        {
            //level1.GetComponent<Image>().sprite = notLockImage;
            // level1.GetComponentInChildren<TMP_Text>().text = "1";
            level2.GetComponent<Image>().sprite = notLockImage;
            level2.GetComponentInChildren<TMP_Text>().text = "2";

            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";
        }
        if (Control.winLevel >= 2)
        { 
            level3.GetComponent<Image>().sprite = notLockImage;
            level3.GetComponentInChildren<TMP_Text>().text = "3";

            level2.GetComponent<Image>().sprite = notLockImage;
            level2.GetComponentInChildren<TMP_Text>().text = "2";

            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";
        }


    }
    //Over loading
    public void OnClicklevel1()
    {
        if (Control.winLevel >= 0)
        {
           
            SceneManager.LoadScene("level1");
        }
    }
    public void OnClicklevel1(InputAction.CallbackContext context)
    {
        if (Control.winLevel >= 0)
        {

            SceneManager.LoadScene("level1");
        }
    }

    public void OnClicklevel2()
    {
        if (Control.winLevel >= 1)
        {
           
            SceneManager.LoadScene("level2");
        }

    }
    public void OnClicklevel2(InputAction.CallbackContext context)
    {
        if (Control.winLevel >= 1)
        {

            SceneManager.LoadScene("level2");
        }

    }
    public void OnClicklevel3()
    {
        if (Control.winLevel >= 2)
        {
            
            SceneManager.LoadScene("level3");
        }
    }
    public void OnClicklevel3(InputAction.CallbackContext context)
    {
        if (Control.winLevel >= 2)
        {

            SceneManager.LoadScene("level3");
        }
    }
    public void OnClickClose()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        Level1SelectAction.Enable();
        Level1SelectAction.started += OnClicklevel1;

        Level2SelectAvtion.Enable();
        Level2SelectAvtion.started += OnClicklevel2;

        Level3SelectAction.Enable();
        Level3SelectAction.started += OnClicklevel3;


    }
    private void OnDisable()
    {
        Level1SelectAction.Disable();
        Level1SelectAction.started -= OnClicklevel1;

        Level2SelectAvtion.Disable();
        Level2SelectAvtion.started -= OnClicklevel2;
        Level3SelectAction.Disable();
        Level3SelectAction.started -= OnClicklevel3;
      
    }

}
