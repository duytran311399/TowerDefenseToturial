using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color overColor;
    public Transform turretPoint;

    [Header("Optional")]
    public GameObject turretBuilded;

    private Renderer rend;
    private Color startColor;

    public static bool isSelected;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        isSelected = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)     // canbuild = false -> ko the say dung, canbuild = true -> co the xay dung
        {
            return;
        }

        if(turretBuilded != null)
        {
            return;
        }
        if (isSelected)
        {
            buildManager.BuildTurretOn(this);
            isSelected = false;
        }
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasZenny && isSelected)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = overColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
