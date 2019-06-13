using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int[,] map;
    private MapType type;

    public int[,] GetMap
    {
        get { return map; }
    }

    public MapType Type
    {
        get { return type; }
    }

    public Map(int[,] map, MapType type)
    {
        this.map = this.AddAdditionalMapObjects(map, type);
        this.type = type;
    }

    private int[,] AddAdditionalMapObjects(int[,] map, MapType type)
    {
        switch (type)
        {
            case MapType.Outside:
                return this.AddOutsideObjectsToMap(map);
            case MapType.Inside:
                return this.AddInsideObjectsToMap(map);
            default:
                return map;
        }
    }

    // TODO: Implement adding low poly trees
    private int[,] AddOutsideObjectsToMap(int[,] map)
    {
        return map;
    }

    // TODO: Implement adding black background
    private int[,] AddInsideObjectsToMap(int[,] map)
    {
        RenderSettings.skybox = null;
        return map;
    }
}
