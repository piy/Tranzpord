using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Globals/RoutesSetup")]
public class RoutesSetup : ScriptableObject
{
    [Header("Routes Color")]
    public List<Color> RouteColors;

    [Header("Other Settings")]
    public Vector3Variable CellCenterOffset;
}
