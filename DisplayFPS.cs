using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class DisplayFPS : MonoBehaviour
{
    public enum Alignment { TopLeft, TopRight, BottomLeft, BottomRight }
    public bool showFPS = true;
    public float refreshRate = 0.2f;
    public Alignment alignment = Alignment.TopRight;
    public Vector2 offset = new Vector2(2f, 0f);
    public int fontSize = 14;
    public Font customFont = null;
    public FontStyle fontStyle = FontStyle.Normal;
    public Color lowFPS = new Color(1f, 0.2f, 0f, 0.8f); //Lower than 30 FPS
    public Color highFPS = new Color(1f, 1f, 1f, 0.8f); //Higher than 30 FPS
 
    private Vector2 curOffset;
    private float rTimer;
    private float accum;
    private int elapsedFrames;
 
    private float finalFPS;
 
    void OnGUI()
    {
        float oX = Mathf.Clamp(offset.x, 0f, Screen.width);
        float oY = Mathf.Clamp(offset.y, 0f, Screen.height);
        offset = new Vector2(oX, oY);
 
        if (!showFPS && Application.isPlaying)
        {
            return;
        }
 
        if (customFont != null)
        {
            GUI.skin.font = customFont;
        }
 
        if (alignment == Alignment.TopLeft)
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
        }
        else if (alignment == Alignment.TopRight)
        {
            GUI.skin.label.alignment = TextAnchor.UpperRight;
        }
        else if (alignment == Alignment.BottomLeft)
        {
            GUI.skin.label.alignment = TextAnchor.LowerLeft;
        }
        else
        {
            GUI.skin.label.alignment = TextAnchor.LowerRight;
        }
 
        if (alignment == Alignment.TopLeft)
        {
            curOffset = new Vector2(offset.x, offset.y);
        }
        else if (alignment == Alignment.TopRight)
        {
            curOffset = new Vector2(-offset.x, offset.y);
        }
        else if (alignment == Alignment.BottomLeft)
        {
            curOffset = new Vector2(offset.x, -offset.y);
        }
        else
        {
            curOffset = new Vector2(-offset.x, -offset.y);
        }
 
        GUI.skin.label.fontSize = fontSize;
        GUI.skin.label.fontStyle = fontStyle;
        GUI.color = Color.Lerp(lowFPS, highFPS, Mathf.Clamp01(finalFPS / 30f));
        if (finalFPS >= Mathf.Infinity)
        {
            GUI.Label(new Rect(curOffset.x, curOffset.y, Screen.width, Screen.height), "-- FPS");
        }
        else
        {
            GUI.Label(new Rect(curOffset.x, curOffset.y, Screen.width, Screen.height), finalFPS.ToString() + " FPS");
        }
    }
 
    void Start()
    {
        rTimer = refreshRate;
    }
 
    void Update()
    {
        if (!showFPS || Time.timeScale <= 0f)
        {
            return;
        }
 
        rTimer += Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        elapsedFrames++;
 
        if (rTimer >= refreshRate)
        {
            finalFPS = Mathf.Round(accum / elapsedFrames);
 
            elapsedFrames = 0;
            accum = 0f;
            rTimer = 0f;
        }
    }
}