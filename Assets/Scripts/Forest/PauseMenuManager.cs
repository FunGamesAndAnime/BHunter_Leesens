using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

        float value = PlayerPrefs.GetFloat(AudioManager.VOLUME_LEVEL_KEY, AudioManager.DEFAULT_VOLUME);
        pausePanel.GetComponentInChildren<Slider>().value = value;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
            _isPaused = true;
        }
    }

    public void CloseMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        _isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}