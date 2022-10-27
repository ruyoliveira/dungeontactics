using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EffectType { None, Damage};
[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    public Color[] colors;
    public Vector3[] hsvcolors;

    public Vector3 currHSVColor;
    private Renderer _renderer;

    [SerializeField]
    private EffectType _currentEffect;
    [SerializeField]
    private bool _isTimedEffect;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _time;

    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _currentEffect = EffectType.None;
    }
    public void Start()
    {
        hsvcolors = new Vector3[colors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            Color.RGBToHSV(colors[1], out hsvcolors[i].x, out hsvcolors[i].y, out hsvcolors[i].z);

        }
    }
    public void Update()
    {
        // Update timer only if there is any timed effect running (_time=0 means the effect is not timed)
        if( _isTimedEffect == true && _currentEffect != EffectType.None)
        {
            // Blink effect
            Vector3 _hsv = currHSVColor;
            _hsv.z = Mathf.Abs(Mathf.Sin(_timer / _time * 360 * Mathf.PI / 180)) /2.0f + 0.5f; //    *4 + 0.5f;
            _renderer.material.color = Color.HSVToRGB(_hsv.x, _hsv.y, _hsv.z);
            
            // Increment timer
            _timer += Time.deltaTime;
            // If time is up
            if (_timer > _time)
            {
                ResetTile();
            }

        }
    }
    public void SetColor(int id)
    {
        // Change Tile color
        if(id < colors.Length)
        {
            _renderer.material.color = colors[id];
            currHSVColor = hsvcolors[id];
        }
    }
    public void SetColor(Color color)
    {
        // Change Tile color
        _renderer.material.color = color;
        Color.RGBToHSV(color, out currHSVColor.x, out currHSVColor.y, out currHSVColor.z);


    }
    // Apply effect to tile for a limited time, delay maight be considered in the future
    public void SetTimedEffect(EffectType effect, float time, float delay)
    {
        _currentEffect = effect;
        _isTimedEffect = true;
        _time = time;
        _timer = 0;
        SetColor(1);
    }
    public void SetTimedEffect(EffectType effect, float time, float delay,  Color color)
    {
        _currentEffect = effect;
        _isTimedEffect = true;
        _time = time;
        _timer = 0;
        SetColor(color);
    }
    // Get current effect applied to tile
    public EffectType GetEffect()
    {
        return _currentEffect;
    }
    private void ResetTile()
    {
        // No effect
        _currentEffect = EffectType.None;
        // Neutral color
        SetColor(0);

    }
}
