using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlacedObjectTypeSO : ScriptableObject
{
    public static Dir GetNextDir(Dir dir)//枚举方法获取下一个方向
    {
        switch (dir)
        {
            default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
        }
    }

    public enum Dir
    {
        Down,
        Left,
        Up,
        Right,
    }

    public string nameString;
    public Transform prefab;
    public Transform visual;
    public int width;
    public int height;
    public bool isHerb;
    public bool isPreObject;
    public List<Vector2Int> loadXZ;
    public List<Vector2Int> emptyXY;

    private List<Vector2Int> removeList;

    //public bool needShadow;
    //public bool needBlackSoil;
    //public bool needSandySoil;
    //public bool needDryLand;


    public int GetRotationAngle(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return 0;
            case Dir.Left: return 90;
            case Dir.Up: return 180;
            case Dir.Right: return 270;
        }
    }

    public Vector2Int GetRotationOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return new Vector2Int(0, 0);
            case Dir.Left: return new Vector2Int(0, width);
            case Dir.Up: return new Vector2Int(width, height);
            case Dir.Right: return new Vector2Int(height, 0);
        }
    }

    public Vector2Int GetRotationWorldOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return new Vector2Int(0, 0);
            case Dir.Left: return new Vector2Int(height, 0);
            case Dir.Up: return new Vector2Int(width, height);
            case Dir.Right: return new Vector2Int(0, width);
        }
    }

    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        removeList.Clear();
        switch (dir)
        {
            default:
            case Dir.Down:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                        Debug.Log("down: " + x + ", " + y);
                    }
                }
                for (int i = 0; i < emptyXY.Count; i++)
                {
                    removeList.Add(gridPositionList[emptyXY[i].x * height + emptyXY[i].y]);
                    //gridPositionList.RemoveAt(emptyXY[i].x * height + emptyXY[i].y);
                }
                foreach (Vector2Int item in removeList)
                {
                    gridPositionList.Remove(item);
                }
                break;
            case Dir.Up:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                        Debug.Log("up: " + x + ", " + y);
                    }
                }
                for (int i = 0; i < emptyXY.Count; i++)
                {
                    removeList.Add(gridPositionList[(width - 1 - emptyXY[i].x) * height + (height - 1 - emptyXY[i].y)]);
                    //gridPositionList.RemoveAt((width-1-emptyXY[i].x) * height + (height - 1 - emptyXY[i].y));
                }
                foreach (Vector2Int item in removeList)
                {
                    gridPositionList.Remove(item);
                }
                break;
            case Dir.Left:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        Debug.Log("left: " + x + ", " + y);
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                for (int i = 0; i < emptyXY.Count; i++)
                {
                    removeList.Add(gridPositionList[(width - emptyXY[i].y) * width + emptyXY[i].x]);
                    //gridPositionList.RemoveAt((width - emptyXY[i].y) * width + emptyXY[i].x);
                }
                foreach (Vector2Int item in removeList)
                {
                    gridPositionList.Remove(item);
                }
                break;
            case Dir.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                        Debug.Log("right: " + x + ", " + y);
                    }
                }
                for (int i = 0; i < emptyXY.Count; i++)
                {
                    removeList.Add(gridPositionList[emptyXY[i].y * width + (width - 1 - emptyXY[i].x)]);
                    //gridPositionList.RemoveAt(emptyXY[i].y * width + (width-1- emptyXY[i].x));
                }
                foreach (Vector2Int item in removeList)
                {
                    gridPositionList.Remove(item);
                }

                break;
        }
        return gridPositionList;
    }
}