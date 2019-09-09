using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTreeInteraction : MonoBehaviour
{
    public Terrain terrain;
    public TerrainData data;

    public void Start()
    {
        terrain = GameObject.FindWithTag("Terrain").GetComponent<Terrain>();
        int numOfTrees = terrain.terrainData.treeInstanceCount;
        for (int i = 0; i < numOfTrees; i++)
        {
            Vector3 treePosition = Vector3.Scale(terrain.terrainData.treeInstances[i].position, terrain.terrainData.size + terrain.transform.position);
        }
    }
}
