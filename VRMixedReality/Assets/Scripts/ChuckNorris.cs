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
    public int likes;
    public int dislikes;

    public Joke[] jokesList;

    public Button openCloseNextVideos;

    [SerializeField] Transform nextVideoParent;
    [SerializeField] Transform nextVideoContent;
    [SerializeField] GameObject nextVideoPrefab;

    GetOtherVideo getOtherVideo = null;

    public static ChuckNorris instance; 

    private void Start()
    {
        instance = this;
        /*Joke[] jokes = APIHelper.GetSomeJokes();
        Debug.Log(jokes.Length);*/

        /*for (int i = 0; i < jokes.Length; i++)
        {
            jokesList.AddRange(jokes);
        }*/

        openCloseNextVideos.onClick.AddListener(() => OpenCloseVideos());

        NewJoke();
    }

    public void OpenCloseVideos()
    {
        nextVideoParent.gameObject.SetActive(!nextVideoParent.gameObject.activeSelf);
    }

    public void NewJoke()
    {
        /*Joke j = APIHelper.GetNewJoke();
        jokeText.text = j.value;

        Debug.Log(j.value);
        Debug.Log("source: " + j.source);
        video.url = j.source;

        GetNextVideos();*/

        VideoData v = APIHelper.GetVideo();
        jokeText.text = v.title;

        Debug.Log(v.title);
        Debug.Log("videoId: " + v.videoId);
        video.url = v.videoId;

        GetNextVideos();
    }

    public void GetChosenVideo(string chosenTitle, VideoSource chosenVideo, int chosenLikes, int chosenDislikes)
    {
        jokeText.text = chosenTitle;
        video.source = chosenVideo;
        likes = chosenLikes;
        dislikes = chosenDislikes;

        GetNextVideos();
    }

    public void GetNextVideos()
    {
        for (int i = 0; i < nextVideoContent.childCount; i++)
        {
            Destroy(nextVideoContent.GetChild(i).gameObject);
        }

        int numberOfVideos = 10;

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
             GameObject currentVideo = Instantiate(nextVideoPrefab, nextVideoContent);
            /*currentVideo.GetComponent<TextMeshProUGUI>().text = jokesList[i].title;*/

            getOtherVideo = currentVideo.GetComponent<GetOtherVideo>();

            /*Joke j = APIHelper.GetNewJoke();

            if (j.value == jokeText.text)
            {
                j = APIHelper.GetNewJoke();
            }*/
            
            VideoData v = APIHelper.GetVideo();

            if (v.title == jokeText.text)
            {
                v = APIHelper.GetVideo();
            }

            getOtherVideo.videoTitle.text = v.title;
            /*getOtherVideo.videoImage = j.thumbnail;
            getOtherVideo.video = j.video;*/
        }
    }
}
