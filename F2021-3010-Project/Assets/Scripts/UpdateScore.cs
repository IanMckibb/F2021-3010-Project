using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    //public Text myText;
    public RectTransform myPanel;
    public GameState gs;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + gs.points.ToString();
        myPanel.sizeDelta = new Vector2(GetComponent<TMPro.TextMeshProUGUI>().text.Length * 54 - 232, 80);

        //myText.text = "Score: " + gs.points.ToString();
        //myPanel.sizeDelta = new Vector2(myText.text.Length * 54 - 232, 80);
    }
}