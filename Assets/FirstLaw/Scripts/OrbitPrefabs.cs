using UnityEngine;

public class OrbitPrefabs : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject positionVectorPrefab;
    [SerializeField] private GameObject orbitPrefab;
    [SerializeField] private GameObject axesPrefab;
    [SerializeField] private GameObject semiMajorAxisPrefab;

    [HideInInspector] public Vector positionVector;
    [HideInInspector] public LineRenderer orbit;
    [HideInInspector] public Transform axes;
    [HideInInspector] public Vector semiMajorAxisVector;

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

        if (semiMajorAxisPrefab)
        {
            semiMajorAxisVector = Instantiate(semiMajorAxisPrefab, transform).GetComponent<Vector>();
            semiMajorAxisVector.SetPositions(Vector3.zero, Vector3.zero);
            semiMajorAxisVector.name = "Semi-Major Axis Vector";
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

    public void SetSemiMajorAxisVectorVisibility(bool visible)
    {
        if (semiMajorAxisVector)
        {
            semiMajorAxisVector.gameObject.SetActive(visible);
        }
    }
}
