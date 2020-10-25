using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    // Declare Queue of type GameObject
    private Queue<GameObject> m_TilePool;

    public int MaxTiles;


    // Start is called before the first frame update
    void Awake()
    {
        // Initialize Tile Pool
        m_TilePool = new Queue<GameObject>();
        _BuildTilePool();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void _BuildTilePool()
    {
        for (var count = 0; count < MaxTiles; count++)
        {
            // Enqueue a new Tile from the Factory
            var tempTile = TileFactory.Instance().CreateTile();
            tempTile.SetActive(false);
            m_TilePool.Enqueue(tempTile);
        }
    }

    /// Removes a GameObject Tile from the Pool
    public GameObject GetTile()
    {
        var tempTile = m_TilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    /// Returns a GameObject Tile back into the Pool
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        m_TilePool.Enqueue(tile);
    }
}
