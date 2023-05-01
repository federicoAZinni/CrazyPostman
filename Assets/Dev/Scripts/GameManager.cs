using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] List<TriggerMail> listTriggerMails;
    [SerializeField] int cuantoQueremos;
    [SerializeField] TextMeshProUGUI timeText;

    public float time;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        time = 120;

        for (int i = 0; i < cuantoQueremos; i++)
        {
            int random = Random.Range(0, listTriggerMails.Count);
            listTriggerMails[random].typeMail = (TypeMail)Random.Range(0, 3);
            listTriggerMails[random].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (time <= 0) { Debug.Log("Perdiste"); }
        time -= Time.deltaTime;
        
        timeText.text = Mathf.RoundToInt(time).ToString();
    }


}
