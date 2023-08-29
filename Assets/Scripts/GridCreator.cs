using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridCreator : MonoBehaviour
{
    [SerializeField] int gridSize;
    [SerializeField] GameObject[] gemPrefabs;
    [SerializeField] float gemSpacing;

    public GameObject[,] grid;
    private void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject gem = InstantiateRandomGem();
                gem.transform.position = new Vector2(x * gemSpacing, y * gemSpacing);

                while (HasAdjacentMatches(gem, x, y))
                {
                    Destroy(gem);
                    gem = InstantiateRandomGem();
                    gem.transform.position = new Vector2(x * gemSpacing, y * gemSpacing);
                }
                grid[x, y] = gem;
            }
        }
    }
    private bool HasAdjacentMatches(GameObject gem, int x, int y)
    {
        if (x >= 2)
        {
            GameObject gem1 = grid[x - 1, y];
            GameObject gem2 = grid[x - 2, y];
            if (gem1.tag == gem.tag && gem2.tag == gem.tag)
            {
                return true;
            }
        }
        if (y >= 2)
        {
            GameObject gem1 = grid[x, y - 1];
            GameObject gem2 = grid[x, y - 2];
            if (gem1.tag == gem.tag && gem2.tag == gem.tag)
            {
                return true;
            }
        }
        return false;
    }
    public void CheckForSolvableMatches()
    {

    }
   
    private GameObject InstantiateRandomGem()
    {
        int randomIndex = Random.Range(0, gemPrefabs.Length);
        GameObject gem = Instantiate(gemPrefabs[randomIndex],transform) as GameObject;
        return gem;
    }
    public void ResetGrid()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GetLength(1); j++) 
            {
                Destroy(grid[i, j]);
            } 
        }
        CreateGrid();
    }
}
