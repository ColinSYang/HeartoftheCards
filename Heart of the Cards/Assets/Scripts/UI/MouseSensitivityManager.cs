using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MouseSensitivityManager : MonoBehaviour
{
    public Slider sensitivitySlider;
    public GameObject menu;
    public TextMeshProUGUI sensitivtySliderText;

    public static bool active;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        active = true;
        Time.timeScale = 0f;
        menu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        active = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateSensitivity()
    {
        LevelManager.mouseSensitivity = sensitivitySlider.value;
        sensitivtySliderText.text =sensitivitySlider.value.ToString("f0");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        active = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        active = false;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        active = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
