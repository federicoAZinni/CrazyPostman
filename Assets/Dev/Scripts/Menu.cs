using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button options;
    [SerializeField] Button credits;
    [SerializeField] Button creditsBack;
    [SerializeField] Button quit;

    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject menuPanel;

    private void Awake()
    {
        play.onClick.AddListener(() => { SceneManager.LoadScene("Game"); });
        options.onClick.AddListener(() => { });
        credits.onClick.AddListener(() => { 
            creditsPanel.SetActive(true);
            menuPanel.SetActive(false);
        });
        creditsBack.onClick.AddListener(() => {
            creditsPanel.SetActive(false);
            menuPanel.SetActive(true);
        });
        quit.onClick.AddListener(() => { Application.Quit(); });
    }

}
