﻿using UnityEngine;
using System.Collections;
using System;
public class Procedural_Generation : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] public int minStoneheight, maxStoneHeight;
    [SerializeField] public GameObject dirt, grass, stone, water;
    
    void Start()
    {
        Generation(); 
    }

    void Generation()
    {
        for (int x = -40; x < width + 40; ++x)
        {
            for (int y = -30; y < 0; y++)
            {
                spawnObj(water, x, y, 1);
            }
        }
        
        for (int x = 0; x < width; x++)     // This will help spawn a tile on the x axis
        {
            // now for procedural generation we need to gradually increase and decrease the height value
            int minHeight = height - 1;
            int maxHeight = height + 2;
            do
            {
                height = UnityEngine.Random.Range(minHeight, maxHeight);
            } while (height < 1);
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
    
    void spawnObj(GameObject obj,int width,int height, int depth = 0)    // Whatever we spawn will be a child of our procedural generation gameObj
    {
        obj = Instantiate(obj, new Vector3(width, height, depth), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

}