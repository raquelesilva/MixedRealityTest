using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChuckNorris : MonoBehaviour
{
    public TextMeshProUGUI jokeText;
    public VideoPlayer video;

    public Joke[] jokesList;

    public Button openCloseNextVideos;

    [SerializeField] Transform nextVideoParent;
    [SerializeField] GameObject nextVideoPrefab;

    private void Start()
    {
        /*Joke[] jokes = APIHelper.GetSomeJokes();
        Debug.Log(jokes.Length);*/

        /*for (int i = 0; i < jokes.Length; i++)
        {
            jokesList.AddRange(jokes);
        }*/

        openCloseNextVideos.onClick.AddListener(() => OpenCloseVideos());

        NewJoke();
        GetNextVideos();
    }

    public void OpenCloseVideos()
    {
        nextVideoParent.gameObject.SetActive(!nextVideoParent.gameObject.activeSelf);
    }

    public void NewJoke()
    {
        Joke j = APIHelper.GetNewJoke();
        jokeText.text = j.value;

        Debug.Log(j.value);
        //video.url = j.source;
    }

    public void GetNextVideos()
    {
        int numberOfVideos = 5;

        /*if (jokesList.Length >= 10)
        {
            numberOfVideos = 10;
        }
        else
        {
            numberOfVideos = jokesList.Length;
        }*/

        for (int i = 0; i < numberOfVideos; i++)
        {
             GameObject currentVideo = Instantiate(nextVideoPrefab, nextVideoParent);
            /*currentVideo.GetComponent<TextMeshProUGUI>().text = jokesList[i].title;*/

            Joke j = APIHelper.GetNewJoke();
            currentVideo.GetComponentInChildren<TextMeshProUGUI>().text = j.value;
        }
    }
}
