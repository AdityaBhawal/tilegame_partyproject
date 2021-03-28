﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksHandle : MonoBehaviour
{

    public GameObject[] LHall;
    public GameObject[] RHall;
    public GameObject[] UHall;
    public GameObject[] BHall;

    public GameObject[] LRooms;
    public GameObject[] RRooms;
    public GameObject[] URooms;
    public GameObject[] BRooms;
    public GameObject[] FloorTileBlocks;
    public GameObject[] WallTileBlocks;

    public int RoomSize;

    public GameObject[] Enemies;
    public GameObject[] Items;

    public int MaxEnemies = 10;
    public int MinEnemies = 6;
    private int enemiesToPlace;

    public int MaxItems = 15;
    public int MinItems = 10;
    private int itemsToPlace;

    public LayerMask ActorLayer; 

    // Start is called before the first frame update
    void Start()
    {
        enemiesToPlace = Random.Range(MinEnemies, MaxEnemies);
        itemsToPlace = Random.Range(MinItems, MaxItems);
        Invoke("CreateEnemies", 2f);
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemies()
    {
        GameObject[] Tiles = GameObject.FindGameObjectsWithTag("FloorTile");

        for (int i = 0; i < enemiesToPlace; i++)
        {
            //get random tile
            GameObject Tle = Tiles[Random.Range(0, Tiles.Length)];

            //check if tile has no other player/enemy
            Collider2D CheckBlock = Physics2D.OverlapCircle(Tle.transform.position, 0.1f, ActorLayer);

            if (CheckBlock)
            {
                //can't place here
                Debug.Log("Other Character Already Placed");
        
            }
            else
            {
                //place enemy
                int randenemy = Random.Range(0, Enemies.Length);
                GameObject Enemy = Instantiate(Enemies[randenemy], Tle.transform.position, Quaternion.identity);

                Debug.Log("Enemy Placed");
            }
        }

        for (int i = 0; i < itemsToPlace; i++)
        {
            //get random tile
            GameObject Tle = Tiles[Random.Range(0, Tiles.Length)];

            //check if tile has no other player/enemy
            Collider2D CheckBlock = Physics2D.OverlapCircle(Tle.transform.position, 0.1f, ActorLayer);

            if (CheckBlock)
            {
                //can't place here
                Debug.Log("Item can't be place");

            }
            else
            {
                //place enemy
                int randItem = Random.Range(0, Items.Length);
                GameObject Item = Instantiate(Enemies[randItem], Tle.transform.position, Quaternion.identity);

                Debug.Log("Item Placed");
            }
        }
    }
}