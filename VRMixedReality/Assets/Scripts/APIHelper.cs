//using UnityEngine;
//using System.Net;
//using System.IO;
//using Unity.VisualScripting;

//public static class APIHelper
//{   
//    public static Joke GetNewJoke()
//    {
//        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
//        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sandbox.api.video/videos");
//        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yrezgui-dailymotion.p.rapidapi.com/user/xl");
//        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//        StreamReader reader = new StreamReader(response.GetResponseStream());
//        string json = reader.ReadToEnd();
//        return JsonUtility.FromJson<Joke>(json);
//    }

//    public static Joke[] GetSomeJokes() 
//    {
//        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
//        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sandbox.api.video/videos");
//        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yrezgui-dailymotion.p.rapidapi.com/user/xl");
//        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//        StreamReader reader = new StreamReader(response.GetResponseStream());
//        string json = reader.ReadToEnd();
//        return JsonUtility.FromJson<Joke[]>(json);
//    }
//}


using UnityEngine;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public static class APIHelper
{
    private const string ApiKey = "YOUR_API_KEY"; // Replace with your actual API key
    private const string VideoId = "YOUR_VIDEO_ID"; // Replace with the ID of the video you want to retrieve

    public static VideoData GetVideo()
    {
        string apiUrl = "https://ws.api.video/videos/";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
        request.Method = "GET";
        //request.Headers.Add("Authorization", ApiKey);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        response.Close();

        return JsonConvert.DeserializeObject<VideoData>(jsonResponse);
    }
}

[System.Serializable]
public class VideoData
{
    public string videoId;
    public string title;
    public string description;
    public string publishedAt;
    public string[] tags;
    public string[] assets;
    // Add more fields as per your API response structure
}