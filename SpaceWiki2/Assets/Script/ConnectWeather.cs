using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ConnectWeather : MonoBehaviour {
    RootObject wthr;
    public Text txtDegree;
    public Text txtH;
    public Text txtW;
    public Text txtWfull;
    public Text txtTime;
    public Text txtTimeZone;
    public Text txtWind;
    // Use this for initialization
    void Start () {
        GetWeather();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetWeather()
    {
        WWWForm form = new WWWForm();


        var www = new WWW(ServerURL.Weather);

        StartCoroutine(wfrWeather(www));
    }

    IEnumerator wfrWeather(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Debug.Log("User Login :" + www.text);

             wthr = JsonConvert.DeserializeObject<RootObject>(www.text);

            txtDegree.text = wthr.current_observation.temp_c.ToString() + " C";
            txtH.text ="H "+ wthr.current_observation.relative_humidity.ToString() ;
            txtW.text = wthr.current_observation.weather;

            txtWfull.text = wthr.current_observation.display_location.full;

            //Sat, 29 Apr 2017 08:34:24 + 0300

            txtTime.text = "Local Time : " + wthr.current_observation.local_time_rfc822.Substring(17, 5);
            txtTimeZone.text = "Time Zone : " + wthr.current_observation.local_tz_short;
            txtWind.text = "Wind : " + wthr.current_observation.wind_dir + " " +
                wthr.current_observation.wind_kph + "kph";
            // GetNasaImege(Nasa);
            print(www.text);
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

public class Features
{
    public string conditions { get; set; }
}

public class Response
{
    public string version { get; set; }
    public string termsofService { get; set; }
    public Features features { get; set; }
}

public class Image
{
    public string url { get; set; }
    public string title { get; set; }
    public string link { get; set; }
}

public class DisplayLocation
{
    public string full { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string state_name { get; set; }
    public string country { get; set; }
    public string country_iso3166 { get; set; }
    public string zip { get; set; }
    public string magic { get; set; }
    public string wmo { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string elevation { get; set; }
}

public class ObservationLocation
{
    public string full { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public string country_iso3166 { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string elevation { get; set; }
}

public class Estimated
{
}

public class CurrentObservation
{
    public Image image { get; set; }
    public DisplayLocation display_location { get; set; }
    public ObservationLocation observation_location { get; set; }
    public Estimated estimated { get; set; }
    public string station_id { get; set; }
    public string observation_time { get; set; }
    public string observation_time_rfc822 { get; set; }
    public string observation_epoch { get; set; }
    public string local_time_rfc822 { get; set; }
    public string local_epoch { get; set; }
    public string local_tz_short { get; set; }
    public string local_tz_long { get; set; }
    public string local_tz_offset { get; set; }
    public string weather { get; set; }
    public string temperature_string { get; set; }
    public double temp_f { get; set; }
    public double temp_c { get; set; }
    public string relative_humidity { get; set; }
    public string wind_string { get; set; }
    public string wind_dir { get; set; }
    public string wind_degrees { get; set; }
    public double wind_mph { get; set; }
    public string wind_gust_mph { get; set; }
    public double wind_kph { get; set; }
    public string wind_gust_kph { get; set; }
    public string pressure_mb { get; set; }
    public string pressure_in { get; set; }
    public string pressure_trend { get; set; }
    public string dewpoint_string { get; set; }
    public string dewpoint_f { get; set; }
    public string dewpoint_c { get; set; }
    public string heat_index_string { get; set; }
    public string heat_index_f { get; set; }
    public string heat_index_c { get; set; }
    public string windchill_string { get; set; }
    public string windchill_f { get; set; }
    public string windchill_c { get; set; }
    public string feelslike_string { get; set; }
    public string feelslike_f { get; set; }
    public string feelslike_c { get; set; }
    public string visibility_mi { get; set; }
    public string visibility_km { get; set; }
    public string solarradiation { get; set; }
    public string UV { get; set; }
    public string precip_1hr_string { get; set; }
    public string precip_1hr_in { get; set; }
    public string precip_1hr_metric { get; set; }
    public string precip_today_string { get; set; }
    public string precip_today_in { get; set; }
    public string precip_today_metric { get; set; }
    public string icon { get; set; }
    public string icon_url { get; set; }
    public string forecast_url { get; set; }
    public string history_url { get; set; }
    public string ob_url { get; set; }
    public string nowcast { get; set; }
}

public class RootObject
{
    public Response response { get; set; }
    public CurrentObservation current_observation { get; set; }
}