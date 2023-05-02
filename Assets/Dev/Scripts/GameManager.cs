using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] List<TriggerMail> listTriggerMails;
    [SerializeField] int cuantoQueremos;
    [SerializeField] Text timeText;
    [SerializeField] TextMeshProUGUI scoreUI;


    public float time;
    private int score;
    public int Score { get => score; set { if(value % 3 == 0) MailTriggerCreate(); scoreUI.text = "X " + value.ToString(); score = value; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        time = 120;

        MailTriggerCreate();
    }

    private void MailTriggerCreate()
    {
        for (int i = 0; i < cuantoQueremos; i++)
        {
            int random = Random.Range(0, listTriggerMails.Count);

            while (listTriggerMails[random].gameObject.activeSelf)
            {
                random = Random.Range(0, listTriggerMails.Count);
            }

            listTriggerMails[random].typeMail = (TypeMail)Random.Range(0, 3);
            listTriggerMails[random].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (time <= 0) { Debug.Log("Perdiste"); }
        time -= Time.deltaTime;
        
        timeText.text = Mathf.RoundToInt(time).ToString();

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");
    }


}
