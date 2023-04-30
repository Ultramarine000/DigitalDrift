using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Instance { get; private set; }

    public event EventHandler OnSelectedChanged;
    public event EventHandler OnObjectPlaced;

    //[SerializeField] private GameController gameController;

    public bool mouseTestEnable = true;
    [SerializeField] private int currentPOTSO_Index = 0;
    public Transform gridXYStartPos;
    public Transform gridXZStartPos;
    public List<Image> SelectButtons;
    [SerializeField] public GameObject player2D;
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList;
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList2;
    
    private PlacedObjectTypeSO placedObjectTypeSO;
    private PlacedObjectTypeSO placedObjectTypeSO2;
    private GridXY<GridObject> gridXY;
    private GridXZ<GridObject> gridXZ;
    private PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;
    //private Vector3 startPos = new Vector3();
    public GameObject labelParent;

    private bool hasFirstRemove = false;

    [Header("Pre Load Group")]
    public List<PlacedObjectTypeSO> preloadObjectTypeSOList;
    private void Awake()
    {
        Instance = this;

        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize1 = 1f;
        float cellSize2 = 5f;
        gridXY = new GridXY<GridObject>(gridWidth, gridHeight, cellSize1, gridXYStartPos.position, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y), false);//show debug
        gridXZ = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize2, gridXZStartPos.position, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z), false);//show debug

        placedObjectTypeSO = placedObjectTypeSOList[0];
        placedObjectTypeSO2 = placedObjectTypeSOList2[0];
        //Debug.Log(placedObjectTypeSO.name + "1");
        
    }
    private void Start()
    {
        PreLoadAllObject();
    }
    private class GridObject
    {
        private GridXY<GridObject> gridXY;
        private GridXZ<GridObject> gridXZ;
        private int x, y, z;
        private PlacedObject placedObject;
        private PlacedObject placedObject22;
        public GridObject(GridXY<GridObject> gridXY, int x, int y)
        {
            this.gridXY = gridXY;
            this.x = x;
            this.y = y;
        }
        public GridObject(GridXZ<GridObject> gridXZ, int x, int z)
        {
            this.gridXZ = gridXZ;
            this.x = x;
            this.z = z;
        }
        public void SetPlacedObject(PlacedObject placedObject)
        {
            this.placedObject = placedObject;
            gridXY.TriggerGridObjectChanged(x, y);
        }
        public void SetPlacedObject2(PlacedObject placedObject)
        {
            this.placedObject22 = placedObject;
            gridXZ.TriggerGridObjectChanged(x, y);
        }

        public PlacedObject GetPlacedObject()
        {
            return placedObject;
        }
        public PlacedObject GetPlacedObject2()
        {
            Debug.Log(placedObject22);
            return placedObject22;
        }

        public void ClearPlacedObject()
        {
            placedObject = null;
            gridXY.TriggerGridObjectChanged(x, y);
        }
        public void ClearPlacedObject2()
        {
            placedObject = null;
            gridXZ.TriggerGridObjectChanged(x, y);
        }

        public bool CanbuildHerb(PlacedObjectTypeSO placedObjectTypeSO)
        {
            if (placedObject != null)
            {
                if (placedObject.CheckSoil())//格子是土地(且当前选中是草)
                {
                    return true;//能建造
                }
                else
                    return false;
            }
            /*else if (placedObjectTypeSO.isHerb)
                return false;*/
            else
                return false;
        }
        public bool Canbuild()
        {
            return placedObject == null;
        }
        public bool CheckSelectHerb(PlacedObjectTypeSO placedObjectTypeSO)
        {
            return placedObjectTypeSO.isHerb;
        }
        public override string ToString()
        {
            return x + ", " + y + "\n" + placedObject;
        }
        public bool HasFlowerTree()
        {
            return placedObject.CheckShadowTree();//如果格子上是阴影树
        }
    }

    public void BuildBlocks(Vector3 mousePos)
    {
        gridXY.GetXY(mousePos, out int x, out int y);//2D player pos's gridPos
        //Debug.Log(x + "+" + y);

        List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, y), dir);//建筑将占用的网格位置list

        //Test can Build
        bool canBuild = true;

        foreach (Vector2Int gridPosition in gridPositionList)
        {
            if (!gridXY.GetGridObject(gridPosition.x, gridPosition.y).Canbuild())
            {
                //不能在此建造
                canBuild = false;
                break;
            }            
        }

        if (canBuild)
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
            //Vector2Int rotationOffset2 = placedObjectTypeSO.GetRotationOffset(dir);
            //Debug.Log("rotationOffset : " + rotationOffset + " 2 : " + rotationOffset2);

            Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.CellSize;
            Vector3 placedObjectWorldPosition2 = gridXZ.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * gridXZ.CellSize;
            //Debug.Log("x: " + x + " y: " + y);

            PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, new Vector2Int(x, y), dir, placedObjectTypeSO, labelParent);
            GameObject tempLabel = placedObject.gameObject;
            PlacedObject placedObject2 = PlacedObject.Create2(placedObjectWorldPosition2, new Vector2Int(x, y), dir, placedObjectTypeSO2, tempLabel);

            GameController.GetInstance().currentBlockNum++;

            foreach (Vector2Int gridPosition in gridPositionList)
            {
                gridXY.GetGridObject(gridPosition.x, gridPosition.y).SetPlacedObject(placedObject);//网格中写入占用的BuildingObjectTansform
                //Debug.Log("write in : " + gridPosition.x + ", " + gridPosition.y);
            }
            OnObjectPlaced?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("NOOOOOOOOOOBuildHere!!!!");
        }
    }

    public void RemoveBlocks(Vector3 mousePos)
    {
        
        GridObject gridObject = gridXY.GetGridObject(mousePos);
        PlacedObject placedObject = gridObject.GetPlacedObject();

        if (placedObject != null && !placedObject.CheckPreObj())
        {
            if (!hasFirstRemove)
            {
                gameObject.GetComponent<DialogTrigger>().EnterDialogueMode();
                hasFirstRemove = true;
            }

            placedObject.DestroySelf();

            GameController.GetInstance().currentBlockNum--;

            List<Vector2Int> gridPositionList = placedObject.GetGridPositionList();//建筑将占用的网格位置list
            foreach (Vector2Int gridPosition in gridPositionList)
            {
                gridXY.GetGridObject(gridPosition.x, gridPosition.y).ClearPlacedObject();//网格中清除占用的Tansform
            }
        }
    }

    public void RotateBlocks()
    {
        dir = PlacedObjectTypeSO.GetNextDir(dir);
        //Debug.Log(dir);
    }

    public void CurrentSelectChange(int n)
    {
        int listLength = placedObjectTypeSOList.Count;
        currentPOTSO_Index += n;
        if (currentPOTSO_Index < 0)
            currentPOTSO_Index = listLength - 1;
        else if (currentPOTSO_Index > listLength - 1)
            currentPOTSO_Index = 0;

        //Debug.Log(currentPOTSO_Index);
        placedObjectTypeSO = placedObjectTypeSOList[currentPOTSO_Index];
        placedObjectTypeSO2 = placedObjectTypeSOList2[currentPOTSO_Index];

        SelectButtons[currentPOTSO_Index].GetComponent<Image>().enabled = true;
        for (int i = 0; i < SelectButtons.Count; i++)
        {
            if (i != currentPOTSO_Index) SelectButtons[i].GetComponent<Image>().enabled = false;
        }

        RefreshSelectedObjectType();
    }

    public void PreLoadAllObject()
    {
        foreach (PlacedObjectTypeSO placedObjectTypeSO in preloadObjectTypeSOList) //all single preload placedObjectTypeSO
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir); 
            foreach (Vector2Int loadXZ in placedObjectTypeSO.loadXZ) // will located at (X,Z) -> List
            {
                Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(loadXZ.x, loadXZ.y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.CellSize;

                //create at XY grid (2D)
                PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, loadXZ, dir, placedObjectTypeSO, labelParent);

                List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(loadXZ, dir);//建筑将占用的网格位置list
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    gridXY.GetGridObject(gridPosition.x, gridPosition.y).SetPlacedObject(placedObject);//网格中写入占用的BuildingObjectTansform
                }
            }
        }
    }

    private Vector3 GetPlayer2DPos()
    {
        Vector3 player2DPos = player2D.transform.position;
        return player2DPos;
    }
    public Vector3 GetMouseWorldSnappedPosition()
    {
        Vector3 mousePosition = Mouse3D.GetMouseWorldPosition();
        gridXY.GetXY(mousePosition, out int x, out int y);

        if (placedObjectTypeSO != null)
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
            Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.GetCellSize();
            return placedObjectWorldPosition;
        }
        else
        {
            return mousePosition;
        }
    }
    public Vector3 GetPlayer2DWorldSnappedPosition()
    {
        Vector3 player2DPosition = GetPlayer2DPos();
        gridXY.GetXY(player2DPosition, out int x, out int y);

        if (placedObjectTypeSO != null)
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
            Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.GetCellSize();
            return placedObjectWorldPosition;
        }
        else
        {
            return player2DPosition;
        }
    }
    public Quaternion GetPlacedObjectRotation()
    {
        if (placedObjectTypeSO != null)
        {
            return Quaternion.Euler(0, 0, placedObjectTypeSO.GetRotationAngle(dir));
        }
        else
        {
            return Quaternion.identity;
        }
    }
    public PlacedObjectTypeSO GetPlacedObjectTypeSO()
    {
        //Debug.Log(placedObjectTypeSO.name);
        return placedObjectTypeSO;
    }
    private void RefreshSelectedObjectType()
    {
        OnSelectedChanged?.Invoke(this, EventArgs.Empty);
    }
}
