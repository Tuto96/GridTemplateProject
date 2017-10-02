
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UISliderShowNumber : MonoBehaviour {
    Text t;
    Slider s;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        s = GetComponentInParent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        t.text = s.value.ToString();
	}
}
