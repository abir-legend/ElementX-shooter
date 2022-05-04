using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainJoiner : MonoBehaviour
{
    public TreeInstance[] tree; 
    public TreeInstance t;
    public TerrainData td;
    public bool clear;
    public Color c,cl;
    public float s,f,ws;
    public int i,count;
    public Vector3 pos;
    public Vector2Int p1;
    private void OnValidate() 
    {
        Debug.Log(td.GetHeight(p1.x,p1.y));
        t = new TreeInstance();
        t.color = c;
        t.heightScale	 = s;
        t.lightmapColor  = cl;
        t.position  = pos;
        t.prototypeIndex  = i;
        t.rotation	  = f;
        t.widthScale = ws;
        tree = td.treeInstances;
        if(clear)
        {
            tree = td.treeInstances;
            foreach (TreeInstance t in tree)
            {
                Debug.Log(t.position);
            }
            td.SetTreeInstances(new TreeInstance[0],false);
        }
        else
        {
            TreeInstance[] ti = new TreeInstance[count];
            for(int i = 0; i <count ; i++)
            {
                t.position  = new Vector3(Random.Range(0f,1f), 0, Random.Range(0f,1f));
                ti[i] = t;
            }
            td.SetTreeInstances(ti,true);
        }
    }
}
