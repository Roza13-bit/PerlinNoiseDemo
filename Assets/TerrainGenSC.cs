using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenSC : MonoBehaviour
{
    public PaintTerrainSC paintSC;
     
    public float[,] terrainHeightData;

    public int rowsAndColumns = 0;

    public float refinementTop = 0f;

    public float refinementBottom = 0f;

    public float multiplierTop = 0f;

    public float multiplierBottom = 0f;

    float perlinNoise = 0f;

    float refinement = 0f;

    float multiplier = 0f;

    Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrainHeightData = new float[rowsAndColumns, rowsAndColumns];

        terrain = GetComponent<Terrain>();

        refinement = Random.Range(refinementBottom, refinementTop);

        multiplier = Random.Range(multiplierBottom, multiplierTop);

        for (int i = 0; i < rowsAndColumns; i++)
        {
            for (int j = 0; j < rowsAndColumns; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);

                terrainHeightData[i, j] = perlinNoise * multiplier;

            }

        }

        terrain.terrainData.SetHeights(0, 0, terrainHeightData);

        paintSC.PaintTerrain();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
