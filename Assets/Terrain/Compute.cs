using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compute : MonoBehaviour
{
    public ComputeShader c;
    public RenderTexture rt;
    public Texture2D t;
    public Material mat;
    public bool b;
    public RectTransform re;
    public Rect r;
    // Start is called before the first frame update
    private void OnValidate() 
    {
        rt = new RenderTexture(256,256,24);
        rt.enableRandomWrite = true;
        rt.Create();
        c.SetTexture(0,"Result",rt);
        c.Dispatch(0,rt.width/8,rt.height/8,1);
        t = new Texture2D(256,256);
        t.ReadPixels(re.rect,0,0,true);
        t.Apply();
        //r = re.rect;
        if(b)
        {mat.SetTexture("_BaseMap", t);}
        else
        {
            mat.SetTexture("_BaseMap", rt);
        }
    }
}
