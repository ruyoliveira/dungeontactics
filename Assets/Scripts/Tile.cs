using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color[] colors;
    private Renderer _renderer;

    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    public void SetColor(int id)
    {
        if(id < colors.Length)
        {
            _renderer.material.color = colors[id];
        }
    }
}
