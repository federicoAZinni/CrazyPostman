using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<TriggerMail> listTriggerMails;
    [SerializeField] int cuantoQueremos;

    private void Start()
    {
        for (int i = 0; i < cuantoQueremos; i++)
        {
            int random = Random.Range(0, listTriggerMails.Count);
            listTriggerMails[random].typeMail = (TypeMail)Random.Range(0, 3);
            listTriggerMails[random].gameObject.SetActive(true);
        }
    }

}
