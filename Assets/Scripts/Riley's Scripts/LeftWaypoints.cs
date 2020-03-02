using UnityEngine;

public class LeftWaypoints : MonoBehaviour
{
    public static Transform[] leftWaypoints;

    void Awake()
    {
        leftWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < leftWaypoints.Length; i++)
        {
            leftWaypoints[i] = transform.GetChild(i);
        }
    }
}
