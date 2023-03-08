using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;
//using Newtonsoft.Json;

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

        /*OnGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) =>
        {
            DebugTextArray[eventArgs.x, eventArgs.y].text = GridArray[eventArgs.x, eventArgs.y]?.ToString();
        };*/
    }

    /*public void SetDebugText(int x, int y, string text)
    {
        DebugTextArray[x, y].text = text;
    }*/

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * CellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / CellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / CellSize);
    }

    /*public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < Width && y < Height)
        {
            GridArray[x, y] = value;
            TriggerGridObjectChanged(x, y);
        }
    }*/

    public void TriggerGridObjectChanged(int x, int y)
    {
        OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    /*public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }*/

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
        return GetGridObject(x, y);
    }

    public float GetCellSize()
    {
        return CellSize;
    }
    /*public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        return new Vector2Int(
            Mathf.Clamp(gridPosition.x, 0, Width - 1),
            Mathf.Clamp(gridPosition.y, 0, Height - 1)
        );
    }*/

}