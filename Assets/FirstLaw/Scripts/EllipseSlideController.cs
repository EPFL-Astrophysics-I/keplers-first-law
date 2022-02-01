using UnityEngine;

public class EllipseSlideController : SimulationSlideController
{
    [Header("Object Visibility")]
    [SerializeField] private bool ellipse;
    [SerializeField] private bool axes;
    [SerializeField] private bool semiMajorAxis;

    private EllipsePrefabs prefabs;

    private void Awake()
    {
        simulation = (EllipseSimulation)simulation;
        if (!simulation.TryGetComponent(out prefabs))
        {
            Debug.LogWarning("Did not find an EllipsePrefabs component");
        }
    }

    public override void ShowAndHideUIElements()
    {
        if (prefabs == null)
        {
            return;
        }

        prefabs.SetEllipseVisibility(ellipse);
        prefabs.SetAxesVisibility(axes);
        prefabs.SetSemiMajorAxisVectorVisibility(semiMajorAxis);
    }
}
