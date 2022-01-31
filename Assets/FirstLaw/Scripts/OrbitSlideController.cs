using UnityEngine;

public class OrbitSlideController : SimulationSlideController
{
    [Header("Object Visibility")]
    [SerializeField] private bool positionVector;
    [SerializeField] private bool orbit;
    [SerializeField] private bool axes;

    private OrbitPrefabs prefabs;

    private void Awake()
    {
        simulation = (OrbitSimulation)simulation;
        if (!simulation.TryGetComponent(out prefabs))
        {
            Debug.LogWarning("Did not find a OrbitPrefabs component");
        }
    }

    public override void ShowAndHideUIElements()
    {
        if (prefabs == null)
        {
            return;
        }

        prefabs.SetPositionVectorVisibility(positionVector);
        prefabs.SetOrbitVisibility(orbit);
        prefabs.SetAxesVisibility(axes);
    }
}
