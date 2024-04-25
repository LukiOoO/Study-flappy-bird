using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textpoint;
    public BirdControler birdControler;
    void Start()
    {
        textpoint.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        
        textpoint.text = birdControler.Points.ToString();
    }
}
