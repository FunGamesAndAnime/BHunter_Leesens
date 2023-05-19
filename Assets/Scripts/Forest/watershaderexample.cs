using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class watershaderexample : MonoBehaviour
{
    
    private Renderer rend;
    public Color setColor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame 
    void Update()
    {
        rend.material.SetColor("Color_7529ff2e66c54c049786327660f46e56", setColor);
    }
}
