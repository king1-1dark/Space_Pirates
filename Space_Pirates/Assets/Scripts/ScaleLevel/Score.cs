using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public Text Timer;
    public GameObject res;
    public Text record;
    public float startTime = 0f;
    // Start is called before the first frame update
    public void Start()
    {
        Timer.text = startTime.ToString();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        
        res.SetActive(false);
        startTime += Time.deltaTime;
        Timer.text = startTime.ToString("F2").Replace(",", ":");
        if(Time.timeScale ==0)
        {
            res.SetActive(true);
            record.text = "Ваш результат " + Timer.text;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
