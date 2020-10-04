﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Tilemaps_Painter : MonoBehaviour
{
    public Tilemap tilemap; //drawboard
    public Tile[] tiles; //drawable tiles
    public List<GameObject> UITiles;

    public int selectedTile = 0;

    public Transform tileGridUI; 

    void Start() {
        int i = 0;
        foreach (Tile tile in tiles){
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f,1f,1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
                tileColor.a = 1;

            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;

        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            selectedTile = 0;
            RenderUITiles();
        } else if(Input.GetKeyDown(KeyCode.Alpha2)){
            selectedTile = 1;
            RenderUITiles();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            selectedTile = 2;
            RenderUITiles();
        }

        if (Input.GetMouseButtonDown(0)){
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), tiles[selectedTile]);
        }
    }

    void RenderUITiles(){
        int i = 0;
        foreach (GameObject tile in UITiles){
            Image UIImage = tile.GetComponent<Image>();
            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile) 
                tileColor.a = 1f;
            
            UIImage.color = tileColor;

            i++;
        }
    }

}
