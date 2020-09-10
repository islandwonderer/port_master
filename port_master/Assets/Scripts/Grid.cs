using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 15;
    [SerializeField] private Group[,] grid;


    // Start is called before the first frame update
    void Start()
    {
        grid = new Group[width,height];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DecreaseRow(int row)
    {
        for(int i = 0; i<width; i++)
        {
            if(grid[i,row])
            {
                // Move piece one row up
                grid[i, row - 1] = grid[i, row];
                // Mark cell as empty
                grid[i, row] = null;
                // Move the piece object
                grid[i, row - 1].gameObject.transform.position += Vector3.down;
            }
        }
    }

    void DecreaseRowsAbove(int row)
    {
        for(int i = 0; i<height; i++){
            DecreaseRow(i);
        }
    }
    void DeleteFullRows()
    {
        for(int i=0; i<height; i++){
            if(IsRowFull(i)){
                DeleteRow(i);
                DecreaseRowsAbove(i);
            }
        }
    }
    
    
    void DeleteRow(int row){
        for(int i=0; i<width; i++)
        {
            Destroy(grid[i,row].gameObject);
        }
    }
    bool IsRowFull(int row){
        
        for(int i=0; i<width; i++)
        {
            if(!grid[i,row]){
                return false;
            }
        }
             
        return true;
    }

    bool IsWithinBoard(Vector2 boardPosition)
    {
        if(boardPosition.x >= 0 && boardPosition.x < width)
        {
            if(boardPosition.y >= 0 && boardPosition.y < height){
                return true;
            }
        }
        return false;
    }
}
