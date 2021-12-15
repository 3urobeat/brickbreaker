using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGen : MonoBehaviour
{
    public GameObject brickPrefab;
    public Transform bricks;
    public int rows = 5;
    public int cols = 7;
    public Material mat;

    private Vector2 startPos;
    private Vector2 endPos;
    private GameObject _brick;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight / 2));
        endPos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Instantiate(brickPrefab, startPos + new Vector2 ((endPos.x - startPos.x) / cols * x + brickPrefab.transform.localScale.x * 0.8f, (endPos.y - startPos.y) / rows * y + brickPrefab.transform.localScale.y * 0.8f), Quaternion.identity, bricks);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
