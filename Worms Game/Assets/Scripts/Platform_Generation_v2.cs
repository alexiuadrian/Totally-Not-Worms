using UnityEngine;
using System.Collections;
using System;
public class Platform_Generation_v2 : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] public int minStoneheight, maxStoneHeight;
    [SerializeField] public GameObject dirt, grass, stone;

    [SerializeField] public int minHeight;
    
    void Start()
    {
        width = UnityEngine.Random.Range(5, 80);
        int minWidth = UnityEngine.Random.Range(0, 100 - width);

        while (minWidth <= 100 - width)
        {
            Generation(minWidth);
            width = UnityEngine.Random.Range(5, 100);
            minWidth = UnityEngine.Random.Range(minWidth + width + 1, 100);
        }
        
    }

    void Generation(int minWidth)
    {
        for (int x = 0 + minWidth; x < width + minWidth; x++)//This will help spawn a tile on the x axis
        {
            // now for procedural generation we need to gradually increase and decrease the height value
            int minHeight = height - 1;
            int maxHeight = height + 2;
            height = UnityEngine.Random.Range(minHeight, maxHeight);
            int minStoneSpawnDistance = height - minStoneheight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = UnityEngine.Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
            //Perlin noise.
            for (int y = 0; y < height; y++)    // This will help spawn a tile on the y axis
            {
                if (y < totalStoneSpawnDistance)
                {
                    spawnObj(stone, x, y);
                }
                else
                {
                    spawnObj(dirt, x, y);
                }
               
            }
            if(totalStoneSpawnDistance == height)
            {
                spawnObj(stone, x, height);
            }
            else
            {
                spawnObj(grass, x, height);
            }

        }
    }
    
    void spawnObj(GameObject obj,int width,int height)    // Whatever we spawn will be a child of our procedural generation gameObj
    {
        obj = Instantiate(obj, new Vector2(width, height + minHeight), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

}