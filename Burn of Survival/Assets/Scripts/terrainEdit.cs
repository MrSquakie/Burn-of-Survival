using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainEdit : MonoBehaviour
{
    public Terrain terrainMain;

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //get terrain heightmap width and height
            int xRes = terrainMain.terrainData.heightmapWidth;
            int yRes = terrainMain.terrainData.heightmapHeight;



            //getHeights    - get the points of the terrain. Stores the values in a float array.
            float[,] heights = terrainMain.terrainData.GetHeights(0,0, xRes, yRes);

            //manipulate    height data
            heights[10, 10] = 1f;   //values are 0-1

            for(int x = 0; x < xRes; x++)
            {
                for(int y = 0; y < yRes; y++)
                {
                    print(heights[x, y]);
                }
            }

            //setHeights    change height
            terrainMain.terrainData.SetHeights(0, 0, heights); 
        }
    }


}
