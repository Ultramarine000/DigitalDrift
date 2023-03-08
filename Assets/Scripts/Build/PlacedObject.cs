using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    public static PlacedObject Create(Vector3 worldPosition, Vector2Int origin, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO, GameObject labelParent)
    {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition, Quaternion.Euler(0, 0, placedObjectTypeSO.GetRotationAngle(dir)));//placedObjectTypeSO.GetRotationAngle(dir)
        placedObjectTransform.parent = labelParent.transform;//设置父物体

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.origin = origin;
        placedObject.dir = dir;

        return placedObject;
    }
    public static PlacedObject Create2(Vector3 worldPosition, Vector2Int origin, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO, GameObject labelParent)
    {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition, Quaternion.Euler(0,  placedObjectTypeSO.GetRotationAngle(dir),0));//placedObjectTypeSO.GetRotationAngle(dir)
        placedObjectTransform.parent = labelParent.transform;//设置父物体

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.origin = origin;
        placedObject.dir = dir;

        return placedObject;
    }

    private PlacedObjectTypeSO placedObjectTypeSO;
    private Vector2Int origin;
    private PlacedObjectTypeSO.Dir dir;

    public List<Vector2Int> GetGridPositionList()//获得Object占据的所有网格位置
    {
        return placedObjectTypeSO.GetGridPositionList(origin, dir);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public bool CheckShadowTree()
    {
        if (this.placedObjectTypeSO.nameString == "FlowerTree")
            return true;
        else
            return false;
    }
    public bool CheckSoil()
    {
        if (this.placedObjectTypeSO.nameString == "BlackSoil" || this.placedObjectTypeSO.nameString == "SandySoil")
            return true;
        else
            return false;
    }
    public bool CheckHerb()
    {
        return placedObjectTypeSO.isHerb;
    }
    public bool CheckPreObj()
    {
        return placedObjectTypeSO.isPreObject;
    }
}
