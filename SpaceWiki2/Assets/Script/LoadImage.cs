using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour {

    public static LoadImage _instantiate;
    public Sprite image;
    private string _url;
    public string url { get { return _url; } set { _url = value; StartCoroutine(Load()); } }
    private SpriteRenderer sp;

    //public ImageNASA img;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        _instantiate = this;
    }
    IEnumerator Load()
    {
        // Start a download of the given URL
        WWW www = new WWW(url);

        // Wait for download to complete
        yield return www;

        // assign texture
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = www.texture;
        image = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        sp.sprite = image; 
    }
}
