using UnityEngine;
using System.Net;
using System.IO;
using Unity.VisualScripting;

public static class APIHelper
{   
    public static Joke GetNewJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yrezgui-dailymotion.p.rapidapi.com/user/xl");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Joke>(json);
    }

    public static Joke[] GetSomeJokes() 
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yrezgui-dailymotion.p.rapidapi.com/user/xl");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Joke[]>(json);
    }
}