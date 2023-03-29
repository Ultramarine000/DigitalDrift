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

    public bool mouseTestEnable = true;
    public Transform gridXYStartPos;
    public Transform gridXZStartPos;
    public List<Button> SelectButtons;
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

    [Header("Pre Load Group")]
    public List<PlacedObjectTypeSO> preloadObjectTypeSOList;
    private void Awake()
    {
        Instance = this;

        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize1 = 1f;
        float cellSize2 = 5f;
        gridXY = new GridXY<GridObject>(gridWidth, gridHeight, cellSize1, gridXYStartPos.position, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y), false);//show debug
        gridXZ = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize2, gridXZStartPos.position, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z), false);//show debug

        placedObjectTypeSO = placedObjectTypeSOList[0];
        placedObjectTypeSO2 = placedObjectTypeSOList2[0];
        //Debug.Log(placedObjectTypeSO.name + "1");
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
    private void Update()
    {
        

        if (mouseTestEnable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gridXY.GetXY(Mouse3D.GetMouseWorldPosition(), out int x, out int y);//获得鼠标位置的网格坐标
                Debug.Log(x + "+" + y);

                List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, y), dir);//建筑将占用的网格位置list
                //for (int i = 0; i < gridPositionList.Count; i++)
                //{
                //    Debug.Log("gridPositionList[" + i + "]=" + gridPositionList[i]);
                //}

                //Test can Build
                bool canBuild = true;

                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    if (!placedObjectTypeSO.isHerb)//当前选中不是草（是建筑）
                    {
                        if (!gridXY.GetGridObject(gridPosition.x, gridPosition.y).Canbuild())
                        {
                            //不能在此建造
                            canBuild = false;
                            break;
                        }
                    }
                    else //当前选中草
                    {
                        if (!gridXY.GetGridObject(gridPosition.x, gridPosition.y).CanbuildHerb(placedObjectTypeSO))
                        {
                            //不能在此建造
                            canBuild = false;
                            break;
                        }
                    }

                }

                if (canBuild)
                {
                    Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
                    Vector2Int rotationOffset2 = placedObjectTypeSO.GetRotationOffset(dir);
                    //Debug.Log(placedObjectTypeSO.GetRotationOffset(dir));
                    Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.CellSize;
                    Vector3 placedObjectWorldPosition2 = gridXZ.GetWorldPosition(x, y) + new Vector3(rotationOffset2.x, 0, rotationOffset2.y) * gridXZ.CellSize;

                    PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, new Vector2Int(x, y), dir, placedObjectTypeSO, labelParent);
                    GameObject tempLabel = placedObject.gameObject;
                    PlacedObject placedObject2 = PlacedObject.Create2(placedObjectWorldPosition2, new Vector2Int(x, y), dir, placedObjectTypeSO2, tempLabel);

                    foreach (Vector2Int gridPosition in gridPositionList)
                    {
                        gridXY.GetGridObject(gridPosition.x, gridPosition.y).SetPlacedObject(placedObject);//网格中写入占用的BuildingObjectTansform
                                                                                                           //Debug.Log(gridPosition.x + ", " + gridPosition.y);
                    }
                    OnObjectPlaced?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Debug.Log("NOOOOOOOOOOBuildHere!!!!");
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                GridObject gridObject = gridXY.GetGridObject(Mouse3D.GetMouseWorldPosition());
                PlacedObject placedObject = gridObject.GetPlacedObject();

                if (placedObject != null && !placedObject.CheckPreObj())
                {
                    placedObject.DestroySelf();

                    List<Vector2Int> gridPositionList = placedObject.GetGridPositionList();//建筑将占用的网格位置list
                    foreach (Vector2Int gridPosition in gridPositionList)
                    {
                        gridXY.GetGridObject(gridPosition.x, gridPosition.y).ClearPlacedObject();//网格中清除占用的Tansform
                    }
                }
            }
        }

        

        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            placedObjectTypeSO = placedObjectTypeSOList[0];
            placedObjectTypeSO2 = placedObjectTypeSOList2[0];
            RefreshSelectedObjectType();
            //SelectButtons[0].GetComponent<Image>().enabled = true;
            //for (int i = 0; i < SelectButtons.Count; i++)
            //{
            //    if (i != 0) SelectButtons[i].GetComponent<Image>().enabled = false;
            //}
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            placedObjectTypeSO = placedObjectTypeSOList[1];
            placedObjectTypeSO2 = placedObjectTypeSOList2[1];
            RefreshSelectedObjectType();
            
            //SelectButtons[1].GetComponent<Image>().enabled = true;
            //for (int i = 0; i < SelectButtons.Count; i++)
            //{
            //    if (i != 1) SelectButtons[i].GetComponent<Image>().enabled = false;
            //}
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            placedObjectTypeSO = placedObjectTypeSOList[2];
            placedObjectTypeSO2 = placedObjectTypeSOList2[2];
            RefreshSelectedObjectType();

            //SelectButtons[1].GetComponent<Image>().enabled = true;
            //for (int i = 0; i < SelectButtons.Count; i++)
            //{
            //    if (i != 1) SelectButtons[i].GetComponent<Image>().enabled = false;
            //}
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            placedObjectTypeSO = placedObjectTypeSOList[3];
            placedObjectTypeSO2 = placedObjectTypeSOList2[3];
            RefreshSelectedObjectType();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            placedObjectTypeSO = placedObjectTypeSOList[4];
            SelectButtons[4].GetComponent<Image>().enabled = true;
            for (int i = 0; i < SelectButtons.Count; i++)
            {
                if (i != 4) SelectButtons[i].GetComponent<Image>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            placedObjectTypeSO = placedObjectTypeSOList[5];
            SelectButtons[5].GetComponent<Image>().enabled = true;
            for (int i = 0; i < SelectButtons.Count; i++)
            {
                if (i != 5) SelectButtons[i].GetComponent<Image>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            placedObjectTypeSO = placedObjectTypeSOList[6];
            SelectButtons[6].GetComponent<Image>().enabled = true;
            for (int i = 0; i < SelectButtons.Count; i++)
            {
                if (i != 6) SelectButtons[i].GetComponent<Image>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            placedObjectTypeSO = placedObjectTypeSOList[7];
            SelectButtons[7].GetComponent<Image>().enabled = true;
            for (int i = 0; i < SelectButtons.Count; i++)
            {
                if (i != 7) SelectButtons[i].GetComponent<Image>().enabled = false;
            }
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
            if (!placedObjectTypeSO.isHerb)//当前选中不是草（是建筑）
            {
                if (!gridXY.GetGridObject(gridPosition.x, gridPosition.y).Canbuild())
                {
                    //不能在此建造
                    canBuild = false;
                    break;
                }
            }
            else //当前选中草
            {
                if (!gridXY.GetGridObject(gridPosition.x, gridPosition.y).CanbuildHerb(placedObjectTypeSO))
                {
                    //不能在此建造
                    canBuild = false;
                    break;
                }
            }

        }

        if (canBuild)
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
            Vector2Int rotationOffset2 = placedObjectTypeSO.GetRotationOffset(dir);
            //Debug.Log(placedObjectTypeSO.GetRotationOffset(dir));
            Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.CellSize;
            Vector3 placedObjectWorldPosition2 = gridXZ.GetWorldPosition(x, y) + new Vector3(rotationOffset2.x, 0, rotationOffset2.y) * gridXZ.CellSize;

            PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, new Vector2Int(x, y), dir, placedObjectTypeSO, labelParent);
            GameObject tempLabel = placedObject.gameObject;
            PlacedObject placedObject2 = PlacedObject.Create2(placedObjectWorldPosition2, new Vector2Int(x, y), dir, placedObjectTypeSO2, tempLabel);

            foreach (Vector2Int gridPosition in gridPositionList)
            {
                gridXY.GetGridObject(gridPosition.x, gridPosition.y).SetPlacedObject(placedObject);//网格中写入占用的BuildingObjectTansform
                //Debug.Log(gridPosition.x + ", " + gridPosition.y);
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
            placedObject.DestroySelf();

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

    public void PreLoadAllObject()
    {
        foreach (PlacedObjectTypeSO placedObjectTypeSO in preloadObjectTypeSOList)
        {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationWorldOffset(dir);
            //Vector2Int rotationOffset2 = placedObjectTypeSO.GetRotationOffset(dir);
            foreach (Vector2Int loadXZ in placedObjectTypeSO.loadXZ)
            {
                Vector3 placedObjectWorldPosition = gridXY.GetWorldPosition(loadXZ.x, loadXZ.y) + new Vector3(rotationOffset.x, rotationOffset.y, 0) * gridXY.CellSize;
                //Vector3 placedObjectWorldPosition2 = gridXZ.GetWorldPosition(loadXZ.x, loadXZ.y) + new Vector3(rotationOffset2.x, 0, rotationOffset2.y) * gridXZ.CellSize;

                PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, loadXZ, dir, placedObjectTypeSO, labelParent);

                //GameObject tempLabel = placedObject.gameObject;
                //PlacedObject placedObject2 = PlacedObject.Create2(placedObjectWorldPosition2, loadXZ, dir, placedObjectTypeSO2, tempLabel);


                List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(loadXZ, dir);//建筑将占用的网格位置list
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    if (!placedObject.CheckHerb())
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
