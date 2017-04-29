using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
    private UnityEngine.UI.Text _text;
    bool IsFade = true;
    public string text { get { return _text.text; } set { _text.text = value; IsFade = true; } }

    public float FadeTime;
    float Timer;
	// Use this for initialization
	void Start () {
        _text = GetComponent<UnityEngine.UI.Text>();
        Timer = FadeTime;
    }

    void RunFadeOut()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a * 0.99f);
    }

    // Update is called once per frame
    void Update () {
		if(IsFade)
        {
            IsFade = false;
            Timer = FadeTime;
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1);
        }
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
            return;
        }
        
        RunFadeOut();

    }
}
