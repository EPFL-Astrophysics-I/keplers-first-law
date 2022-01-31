using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPrefabs : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject positionVectorPrefab;
    [SerializeField] private GameObject orbitPrefab;
    [SerializeField] private GameObject axesPrefab;

    [HideInInspector] public Vector positionVector;
    [HideInInspector] public LineRenderer orbit;
    [HideInInspector] public Transform axes;

    public void InstantiateAllPrefabs()
    {
        if (positionVectorPrefab)
        {
            positionVector = Instantiate(positionVectorPrefab, transform).GetComponent<Vector>();
            positionVector.SetPositions(Vector3.zero, Vector3.zero);
            positionVector.name = "Position Vector";
        }

        if (orbitPrefab)
        {
            orbit = Instantiate(orbitPrefab, transform).GetComponent<LineRenderer>();
            orbit.positionCount = 0;
            orbit.name = "Orbit";
        }

        if (axesPrefab)
        {
            axes = Instantiate(axesPrefab, transform).transform;
            axes.name = "Axes";
        }
    }

    public void SetPositionVectorVisibility(bool visible)
    {
        if (positionVector)
        {
            positionVector.gameObject.SetActive(visible);
        }
    }


    public void SetOrbitVisibility(bool visible)
    {
        if (orbit)
        {
            orbit.gameObject.SetActive(visible);
        }
    }

    public void SetAxesVisibility(bool visible)
    {
        if (axes)
        {
            axes.gameObject.SetActive(visible);
        }
    }
}
