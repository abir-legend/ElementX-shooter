using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{   
    public int s;
    public float[] multiplier;
    public Texture2D[] values;
    public bool[] sub;
    public Texture2D rad,tex;
    public TerrainData self;
    public bool draw;

    public void OnValidate() 
    {
        if(draw)
        {
            MakeTerrain();
        }
    }
    public void MakeTerrain()
    {
        float[,] hights = new float[s,s];
        int j= 0;
        Color[] c = new Color[s*s];
        for (int y = 0; y < s; y++)
        {
            for (int x = 0; x < s; x++)
            {
                /*for(int i = 0 ; i< values.Length ; i++)
                {
                    if(!sub[i])
                    {
                        hights[x,y] += values[i].GetPixel(x,y).r * multiplier[i];               
                    }
                    else
                    {
                        hights[x,y] -= values[i].GetPixel(x,y).r * multiplier[i];
                    }
                }
                hights[x,y] = Mathf.Lerp(0,1,hights[x,y]);*/
                hights[x,y] = rad.GetPixel(x,y).r ;// hights[x,y];
                c[j] = new Color(hights[x,y],hights[x,y],hights[x,y]);
                j++;
            }
        }
        self.SetHeights(0,0,hights);
        tex = new Texture2D(s,s);
        tex.SetPixels(c);
        tex.Apply();
        tex.name = "result";
    }
}