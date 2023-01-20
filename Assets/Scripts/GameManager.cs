using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [Range(0.5f,10f)] public float timeScale = 1;
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL!");
            }

            return _instance;
        }
    }

    public SetColor[] colorMappings;
    private GameObject[] surfaceObjects;
    private GameObject[] obstacleObjects;
    private GameObject player;
    private Canvas canvas;

    public int levelCounter;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        surfaceObjects = GameObject.FindGameObjectsWithTag("Surface");
        obstacleObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        canvas = FindObjectOfType<Canvas>();
        
        player.GetComponent<SpriteRenderer>().color = colorMappings[levelCounter].positive;
        for (int i = 0; i < surfaceObjects.Length; i++)
        {
            surfaceObjects[i].GetComponent<SpriteRenderer>().color = colorMappings[levelCounter].positive;
        }
        for (int i = 0; i < obstacleObjects.Length; i++)
        {
            obstacleObjects[i].GetComponent<SpriteRenderer>().color = colorMappings[levelCounter].negative;
        }
        
    }

    private void FixedUpdate()
    {
        Time.timeScale = timeScale;
    }

    public void NextLevel(int index)
    {
        Debug.Log(index);
        StartCoroutine(canvas.FadeAlpha(1, false));
        StartCoroutine(LoadSceneTime(index, 1));
    }

    IEnumerator LoadSceneTime(int index, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }

    public void ResetPosition(Vector2 position)
    {
        FindObjectOfType<PlayerMovement>().startingPos = position;
    }
}