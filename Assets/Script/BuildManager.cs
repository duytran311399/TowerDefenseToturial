using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public TurretBlueprint turretToBuild;                   // Turret selected to build

    //public GameObject standardTurretPrepfab;
    //public GameObject anotherTurretPrepfab;
    //public GameObject lazerTurretPrefab;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("More than one BuildManager in Scene");
            return;
        }
    }

    public bool CanBuild { get { return turretToBuild != null; } }      // kiem tra co null hay ko, neu !null tra ve true => canbuild, else => false
    public bool HasZenny { get { return PlayerStart.Zenny >= turretToBuild.cost; } }      // kiem tra co null hay ko, neu !null tra ve true => canbuild, else => false
    
    public void BuildTurretOn(Node node)
    {
        if(PlayerStart.Zenny < turretToBuild.cost)
        {
            Debug.Log("Not enough Zenny to build that!");
            return;
        }
        PlayerStart.Zenny -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.turretBlueprint, node.turretPoint.position, Quaternion.identity);
        node.turretBuilded = turret;

        Debug.Log("Turret Builded! Zenny left: " + PlayerStart.Zenny);
    }
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        Node.isSelected = true;
    }
}
