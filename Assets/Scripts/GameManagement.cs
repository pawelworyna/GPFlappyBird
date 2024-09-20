using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    private bool isMuteBackgroundAudio = false;
    [SerializeField] Button muteButton;
    [SerializeField] Button resetButton;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] Sprite ButtonImageMute;
    [SerializeField] Sprite ButtonImageUnmute;
    public static float GameSpeed = 5f;
    public static bool IsGameOver = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void HandleMuteButtonClick()
    {
        if (isMuteBackgroundAudio)
        {
            isMuteBackgroundAudio = false;
            backgroundMusic.mute = false;
            muteButton.image.sprite = ButtonImageUnmute;
        }
        else
        {
            isMuteBackgroundAudio = true;
            backgroundMusic.mute = true;
            muteButton.image.sprite = ButtonImageMute;

        }
    }
    public void GameOver()
    {
        IsGameOver = true;
        GameSpeed = 0;
        GetComponent<ScoreManager>().SetHighScore();
        resetButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ResetPosition();
        GameSpeed = 5f;
        GetComponent<ScoreManager>().ResetScore();
        resetButton.gameObject.SetActive(false);
        IsGameOver = false;
    }
}
