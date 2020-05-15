using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    // All start-teleports/end-teleports(their plate*):
    GameObject[] startTeleports;
    GameObject[] endTeleports;  

    // Absolute position of each start-teleport/end-teleport:
    List<Vector3> startTeleportsPositions;
    List<Vector3> endTeleportsPositions;    

    public Vector3 GetTeleportPosition(string teleportName)
    {
        print($"counter: {startTeleportsPositions.Count}");
        int index = (int)teleportName[5] - '0' - 1;
        print($"String: {index}");

        return startTeleportsPositions[index + 1];
    }

    void Start()
    {
        startTeleportsPositions = new List<Vector3>();
        endTeleportsPositions = new List<Vector3>();

        startTeleports = GameObject.FindGameObjectsWithTag("StartTeleport");
        endTeleports = GameObject.FindGameObjectsWithTag("EndTeleport");

        // Filling startTeleportsPositions:
        for (int n = 0; n < startTeleports.Length - 1; n++)
        {
            Vector3 absolutePosition = startTeleports[n].transform.position + startTeleports[n].transform.parent.position + startTeleports[n].transform.parent.parent.position;
            startTeleportsPositions.Add(absolutePosition);
        }

        // Filling endTeleportsPositions:
        for (int n = 0; n < endTeleports.Length; n++)
        {
            Vector3 absolutePosition = endTeleports[n].transform.position + endTeleports[n].transform.parent.position + endTeleports[n].transform.parent.parent.position;
            endTeleportsPositions.Add(absolutePosition);
        }
    }

    

}
