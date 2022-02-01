using UnityEngine;

public class EllipsePrefabs : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject ellipsePrefab;
    [SerializeField] private GameObject axesPrefab;
    [SerializeField] private GameObject semiMajorAxisPrefab;

    [HideInInspector] public LineRenderer ellipse;
    [HideInInspector] public Transform axes;
    [HideInInspector] public Vector semiMajorAxisVector;

    public void InstantiateAllPrefabs()
    {
        if (ellipsePrefab)
        {
            ellipse = Instantiate(ellipsePrefab, transform).GetComponent<LineRenderer>();
            ellipse.positionCount = 0;
            ellipse.name = "Orbit";
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

    public void SetEllipseVisibility(bool visible)
    {
        if (ellipse)
        {
            ellipse.gameObject.SetActive(visible);
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
