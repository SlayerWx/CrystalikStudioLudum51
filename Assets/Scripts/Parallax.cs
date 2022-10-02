using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Parallax : MonoBehaviour
{
    public enum CustomAxis
    {
        none,left,right,up,down
    }
    public CustomAxis axis;
    public RawImage[] backgrounds;
    public float[] speedBackGrounds;
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (axis == CustomAxis.left)
                backgrounds[i].uvRect = new Rect(backgrounds[i].uvRect.x + speedBackGrounds[i] * Time.deltaTime, backgrounds[0].uvRect.y, backgrounds[0].uvRect.width, backgrounds[0].uvRect.height);
            if (axis == CustomAxis.right)
                backgrounds[i].uvRect = new Rect(backgrounds[i].uvRect.x - speedBackGrounds[i] * Time.deltaTime, backgrounds[0].uvRect.y, backgrounds[0].uvRect.width, backgrounds[0].uvRect.height);
            if (axis == CustomAxis.up)
                backgrounds[i].uvRect = new Rect(backgrounds[i].uvRect.x, backgrounds[0].uvRect.y  - speedBackGrounds[i] * Time.deltaTime, backgrounds[0].uvRect.width, backgrounds[0].uvRect.height);
            if (axis == CustomAxis.down)
                backgrounds[i].uvRect = new Rect(backgrounds[i].uvRect.x , backgrounds[0].uvRect.y + speedBackGrounds[i] * Time.deltaTime, backgrounds[0].uvRect.width, backgrounds[0].uvRect.height);
        }
    }
}
