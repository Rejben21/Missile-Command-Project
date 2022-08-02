using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject titleScreen, pauseMenu, gameOverScreen;
    public bool isPaused, hasStarted;

    public GameObject rocket;
    public float timeToSpawn;
    private float timer;

    public int lifes;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
        timer = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            hasStarted = false;
            gameOverScreen.SetActive(true);
        }


        timer -= Time.deltaTime;

        pauseMenu.SetActive(isPaused);
        
        if(Input.GetKeyDown(KeyCode.Escape) && hasStarted)
        {
            PauseUnpause();
        }

        PlayerController.instance.canShoot = hasStarted;

        SpawningRocets();
    }

    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    public void PlayGame()
    {
        titleScreen.SetActive(false);
        hasStarted = true;
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("SampleScene");
    }

    public void SpawningRocets()
    {
        if(hasStarted && timer <= 0)
        {
            Instantiate(rocket, new Vector3(Random.Range(-8.5f, 8.5f), 5, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(-45f, 45f))));
            timer = timeToSpawn;
        }
    }
}
