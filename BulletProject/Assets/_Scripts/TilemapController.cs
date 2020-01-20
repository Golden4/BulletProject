using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    public static TilemapController Ins;

    void Awake()
    {
        Ins = this;
        
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Tilemap[] tilemaps = GetComponentsInChildren<Tilemap>();
        Tilemap spawnPoints = null;
        for (int i = 0; i < tilemaps.Length; i++)
        {
            if (tilemaps[i].transform.CompareTag("SpawnPoints"))
            {
                spawnPoints = tilemaps[i];
                break;
            }
        }

        for (int i = -100; i < 100; i++)
        {
            for (int j = -100; j < 100; j++)
            {
                TileBase spawnPointTile = spawnPoints?.GetTile(new Vector3Int(i, j, 0));

                if (spawnPointTile)
                {
                    Vector2 spawnPosition = new Vector2(i, j) + Vector2.right * .5f;

                    if ( spawnPointTile.name == "PlayerPoint")
                    {
                        GameAssets.Get.SpawnCharacter(GameAssets.Characters.Cowboy, spawnPosition, Quaternion.identity, true);
                    }

                    if(spawnPointTile.name == "EnemyPoint")
                    {
                        GameAssets.Get.SpawnCharacter(GameAssets.Characters.Cowboy, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }

        Destroy(spawnPoints.gameObject);
    }

}
