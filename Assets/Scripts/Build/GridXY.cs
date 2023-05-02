using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridXY<TGridObject>
{

    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    public TGridObject[,] GridArray;
    public int Width;
    public int Height;
    public float CellSize;
    //[JsonIgnore]
    public TextMesh[,] DebugTextArray { get; private set; }
    private Vector3 originPosition;

    public GridXY() { }

    public GridXY(int width, int height, float cellSize, Vector3 originPosition, Func<GridXY<TGridObject>, int, int, TGridObject> createGridObject, bool showDebug)
    {
        this.Width = width;
        this.Height = height;
        this.CellSize = cellSize;
        this.originPosition = originPosition;

        GridArray = new TGridObject[width, height];

        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                GridArray[x, y] = createGridObject(this, x, y);
            }
        }

        if (showDebug)
        {
            InitializeDebugTextArray(width, height, cellSize);
        }
    }

    public void InitializeDebugTextArray(int width, int height, float cellSize)
    {
        DebugTextArray = new TextMesh[width, height];
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                DebugTextArray[x, y] = WorldText.CreateWorldText(GridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, 0, cellSize) * 0.5f,
                 4, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center);
                //Debug.Log(GridArray[x, y].ToString());
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * CellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / CellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / CellSize);
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < Width && y < Height)
        {
            return GridArray[x, y];
        }
        else
        {
            return default(TGridObject);
        }
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        //Debug.Log("mousePos: x=" + x+",y="+y); 
        return GetGridObject(x, y);
    }

    public float GetCellSize()
    {
        return CellSize;
    }
}