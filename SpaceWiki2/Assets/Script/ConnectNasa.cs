using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectNasa : MonoBehaviour {

    Assets Nasa;
    ImageNASA NasaImage;
    bool IsCall = false;

    string lat = "25.251400";
    string lon = "55.232400";
    
    // Use this for initialization
    void Start()
    {
        GetNasaData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetNasaData()
    {
        WWWForm form = new WWWForm();

          string begin = "2000-02-01";

        var www = new WWW(ServerURL.NASA + "?lon=" + lon + "&lat=" + lat + "&begin=" + begin + "&api_key=K6OQ8f2kARhP5q382FesamNF89Sbd2T5zKhUCylL");

        StartCoroutine(wfrNasaData(www));
    }

    IEnumerator wfrNasaData(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Debug.Log("User Login :" + www.text);
            
            Nasa= JsonConvert.DeserializeObject<Assets>(www.text);
            GetNasaImege(Nasa);
           // print(Nasa);
            //LoadScene();
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Error: " + www.text);
            //txt.text = www.error;
        }
    }

    public void GetNasaImege(Assets Nasa)
    {
        if (IsCall)
            return;
        IsCall = true;

        WWWForm form = new WWWForm();

      
        //for (int x = 0; x < Nasa.assets.Count; x++)
        {
            var www = new WWW(ServerURL.NASAImage + "?lon=" + lon + "&lat=" + lat + "&date=" + Nasa.assets[3].date.Split('T')[0] + "&cloud_score=TRUE" + "&api_key=K6OQ8f2kARhP5q382FesamNF89Sbd2T5zKhUCylL");

            StartCoroutine(wfrNASAImage(www));
        }
    }

    IEnumerator wfrNASAImage(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Debug.Log("User Login :" + www.text);

           

            NasaImage = JsonConvert.DeserializeObject<ImageNASA>(www.text);
            LoadImage._instantiate.url = NasaImage.url; 
            //GetNasaImege(Nasa);
            // print(Nasa);
            //LoadScene();
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Error: " + www.text);
            //txt.text = www.error;
        }
    }

}


public class Assets
{
    public int count { get; set; }
    [JsonProperty("results")]
    public System.Collections.Generic.List<Asset> assets { get; set; }
}
public class Asset
{
    public string date { get; set; }
    public string id { get; set; }
}
public class ImageNASA
{
    public string date { get; set; }
    public string id { get; set; }
    public decimal cloud_score { get; set; }
    public string url { get; set; }
}