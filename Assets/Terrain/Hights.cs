using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hights : MonoBehaviour
{
    public Texture2D rad,res;
    public float a,b;
    public TreeInstance tri;
    public TerrainData self;
    public enum NoiseType
    { 
        OpenSimplex2,
        OpenSimplex2S,
        Cellular,
        Perlin,
        ValueCubic,
        Value 
    };
    public enum RotationType3D 
    {
        None, 
        ImproveXYPlanes, 
        ImproveXZPlanes 
    };
    
    public enum FractalType 
    {
        None, 
        FBm, 
        Ridged, 
        PingPong, 
        DomainWarpProgressive, 
        DomainWarpIndependent 
    };

    public enum CellularDistanceFunction 
    {
        Euclidean, 
        EuclideanSq, 
        Manhattan, 
        Hybrid 
    };
    
    public enum CellularReturnType 
    {
        CellValue, 
        Distance, 
        Distance2, 
        Distance2Add, 
        Distance2Sub, 
        Distance2Mul, 
        Distance2Div 
    };

    public enum DomainWarpType 
    { 
        OpenSimplex2, 
        OpenSimplex2Reduced, 
        BasicGrid 
    };
    public NoiseType[] nta;

    public NoiseType nt;
    public RotationType3D rt3d;
    public CellularDistanceFunction cd;
    public CellularReturnType cr;
    public DomainWarpType drt;
    public float frequency,lacunarity,gain,weightedStrength,pingPongStrength,cellularJitter;
    public int seed,octaves;
    public int s = 128;
    private void OnValidate() 
    {
        Color[] c = new Color[s*s];
        FastNoiseLite noise = new FastNoiseLite();
        noise.SetSeed(seed);
        noise.SetFrequency(frequency);
        noise.SetFractalOctaves(octaves);
        noise.SetNoiseType((FastNoiseLite.NoiseType)(int)nt);
        noise.SetRotationType3D((FastNoiseLite.RotationType3D)(int)rt3d);
        noise.SetCellularDistanceFunction((FastNoiseLite.CellularDistanceFunction)(int)cd);
        noise.SetCellularReturnType((FastNoiseLite.CellularReturnType)(int)cr);
        noise.SetDomainWarpType((FastNoiseLite.DomainWarpType)(int)drt);
        noise.SetFractalLacunarity(lacunarity);
        noise.SetFractalGain(gain);
        noise.SetFractalWeightedStrength(weightedStrength);
        noise.SetFractalPingPongStrength(pingPongStrength);
        noise.SetCellularJitter(cellularJitter);
        float[,] noiseData = new float[s,s];
        int i =0;
        for (int y = 0; y < s; y++)
        {
            for (int x = 0; x < s; x++)
            {
                noiseData[x,y] = Mathf.Lerp(a,b,rad.GetPixel(x,y).r - Mathf.Clamp01(noise.GetNoise(x, y)));
                c[i] = new Color(noiseData[x,y],noiseData[x,y],noiseData[x,y]);
                i++;
            }
        }
        res = new Texture2D(s,s);
        res.SetPixels(c);
        res.Apply();
        self.SetHeights(0,0,noiseData);
        noise = null;
    }
}
