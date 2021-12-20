using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGen : MonoBehaviour
{
    public GameObject brickPrefab;
    public Transform bricks;
    public Vector2 fieldTiles = new Vector2(7, 5);
    public Material mat;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 brickSize;
    private Vector2 fieldSize;
    private Vector2 spaceSize;
    private GameObject _brick;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight / 2));
        endPos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        fieldTiles = new Vector2(7, 5);
        brickSize = brickPrefab.transform.localScale;
        fieldSize = endPos - startPos;
        spaceSize = (fieldSize - fieldTiles * brickSize) / (fieldTiles + Vector2.one);
        
        for (int x = 0; x < fieldTiles.x; x++)
        {
            for (int y = 0; y < fieldTiles.y; y++)
            {
                Instantiate(brickPrefab, startPos + brickSize / 2 + spaceSize + new Vector2((brickSize + spaceSize).x * x, (brickSize + spaceSize).y * y), Quaternion.identity, bricks);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
