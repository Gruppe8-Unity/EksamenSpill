
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class IslandSpawner : MonoBehaviour
{
    public Tilemap islandTilemap;
    public Tilemap oceanTilemap;
    public RuleTile islandTile;
    public int minSize = 2;
    public int maxSize = 5;
    public float spawnInterval = 0.5f;
    private float timer = 0f;
    public float scrollSpeed = 1f;

    //Level endring

    private float levelTimer = 0f;
    public float timeToChangeLevel = 10f;

    [System.Serializable]
    public class LevelTheme
    {
        public RuleTile islandTile;
        public TileBase oceanTile;
        public AudioClip music;
    }
    public List<LevelTheme> levels = new List<LevelTheme>();
    private int currentLevel = 0;

    //musikk for nivåene
    public AudioSource musicSource;



    /*dekorasjon for øyene
    public Tilemap decorationTilemap;
    public TileBase houseTile;
    */
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        //Musikk starter på nivå 1
        if (levels.Count > 0)
        {
            var theme = levels[0]; 
            islandTile = theme.islandTile;

            if (musicSource != null && theme.music != null)
            {
                musicSource.clip = theme.music;
                musicSource.loop = true;
                musicSource.Play();
            }
        }

    }

   
    void Update()
    {
        timer += Time.deltaTime;
        

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnIsland();
        }
        islandTilemap.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        //fjerne øyer som ikke er på skjermen
        if (Time.frameCount % 60 == 0)
        {
            BoundsInt bounds = islandTilemap.cellBounds;
            for (int x = bounds.xMin; x <= bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y <= bounds.yMax; y++)
                {
                    Vector3Int tilePos = new Vector3Int(x, y, 0);
                    Vector3 worldPos = islandTilemap.CellToWorld(new Vector3Int(x, y, 0));
                    if (worldPos.y < mainCam.ViewportToWorldPoint(Vector3.zero).y - 1f)
                    {
                        islandTilemap.SetTile(tilePos, null);
                        //decorationTilemap.SetTile(tilePos, null);
                    }
                }
            }
        }
        levelTimer += Time.deltaTime;
        if (levelTimer >= timeToChangeLevel)
        {
            ChangeLevel();
            levelTimer = 0f; 
        }
    }

    void SpawnIsland()
    {
        int size = Random.Range(minSize, maxSize + 1); //random 2 til 5

        float topY = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1.1f, 0)).y;
        float worldWidth = mainCam.orthographicSize * mainCam.aspect * 2;
        float minX = mainCam.transform.position.x - worldWidth / 2 + 1;
        float maxX = mainCam.transform.position.x + worldWidth / 2 - size;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnWorldPos = new Vector3(randomX, topY, 0);

        Vector3Int spawnPos = islandTilemap.WorldToCell(spawnWorldPos);
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Vector3Int tilePos = spawnPos + new Vector3Int(x, y, 0);
                islandTilemap.SetTile(tilePos, islandTile);
            }
        }
        /*dekorasjon på øyene
        if (size > 2 && houseTile != null && decorationTilemap != null)
        {
            int houseCount = Random.Range(1, 4);
            for (int i = 0; i < houseCount; i++)
            {
                int x = Random.Range(1, size - 1);
                int y = Random.Range(1, size - 1);

                Vector3Int housePos = spawnPos + new Vector3Int(x, y, 0);
                decorationTilemap.SetTile(housePos, houseTile);
            }
            //nextSpawnPos += new Vector3Int(size + 1, 0, 0);
        } */
    }

    void ChangeLevel()
    {
        if (currentLevel >= levels.Count)
        {
            Debug.Log("Ingen flere nivåer å endre til");
            return;
        }

        var theme = levels[currentLevel];

        //Musikk for nivåene
        if (musicSource != null && theme.music != null)
        {
            musicSource.Stop();
            musicSource.clip = theme.music;
            musicSource.loop = true;
            musicSource.Play();
        }
        Debug.Log($"Endrer til nivå:{currentLevel + 1}");

        // Ny tiles til fremtidige øyer
        islandTile = theme.islandTile;

        // erstatte øy tiles
        BoundsInt islandBounds = islandTilemap.cellBounds;
        for (int x = islandBounds.xMin; x <= islandBounds.xMax; x++)
        {
            for (int y = islandBounds.yMin; y <= islandBounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (islandTilemap.GetTile(pos) != null)
                {
                    islandTilemap.SetTile(pos, theme.islandTile);
                }
            }
        }

    // Erstatte hav tiles
        BoundsInt oceanBounds = oceanTilemap.cellBounds;
        for (int x = oceanBounds.xMin; x <= oceanBounds.xMax; x++)
        {
            for (int y = oceanBounds.yMin; y <= oceanBounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (oceanTilemap.GetTile(pos) != null)
                {
                    oceanTilemap.SetTile(pos, theme.oceanTile);
                }
            }
        }

    currentLevel++;
    }


}
