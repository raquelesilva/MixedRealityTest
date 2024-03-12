using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GetOtherVideo : MonoBehaviour
{
    ChuckNorris chuckNorris;
    
    public TextMeshProUGUI videoTitle;
    public Image videoImage;
    public VideoSource video;
    public int likes;
    public int dislikes;

    // Start is called before the first frame update
    void Start()
    {
        chuckNorris = ChuckNorris.instance;
    }

    public void GetChosenVideo()
    {
        chuckNorris.GetChosenVideo(videoTitle.text, video, likes, dislikes);
    }
}