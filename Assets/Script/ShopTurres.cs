using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTurres : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint lazerTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurretPrepab()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurretPrepab()
    {
        buildManager.SelectTurretToBuild(anotherTurret);
    }
    public void SelectLazerTurretPrepab()
    {
        buildManager.SelectTurretToBuild(lazerTurret);
    }
}
