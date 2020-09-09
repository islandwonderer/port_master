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

    void DeleteFullRows()
    {
        for(int i=0; i<height; i++){
            if(IsRowFull(i)){
                DeleteRow(i);
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
}
