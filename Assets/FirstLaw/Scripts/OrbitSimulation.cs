using UnityEngine;

public class OrbitSimulation : Simulation
{
    private OrbitPrefabs prefabs;

    public TwoBodySimulation twoBodySim;
    public float radiusScale = 1;

    private Camera mainCamera;

    private void Awake()
    {
        if (!TryGetComponent(out prefabs))
        {
            Debug.LogWarning("No OrbitPrefabs component found.");
            Pause();
            return;
        }

        prefabs.InstantiateAllPrefabs();

        mainCamera = Camera.main;
    }

    private void Start()
    {
        if (!twoBodySim)
        {
            return;
        }

        if (prefabs.orbit)
        {
            int numSteps = 360;
            float a = twoBodySim.SemiMajorAxis;
            float e = twoBodySim.Eccentricity;

            Vector3[] positions = new Vector3[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                float theta = i * 2f * Mathf.PI / numSteps;
                float r = radiusScale * a * (1f - e * e) / (1f + e * Mathf.Cos(theta));
                positions[i] = r * (Mathf.Cos(theta) * Vector3.right + Mathf.Sin(theta) * Vector3.up);
            }

            prefabs.orbit.positionCount = numSteps;
            prefabs.orbit.SetPositions(positions);
            prefabs.orbit.loop = true;
        }
    }

    private void Update()
    {
        if (transform.rotation != mainCamera.transform.rotation)
        {
            Debug.Log("Rotating Orbit Simulation");
            transform.rotation = mainCamera.transform.rotation;
        }

        if (prefabs.positionVector && twoBodySim)
        {
            float r = twoBodySim.r.magnitude;
            float theta = -twoBodySim.theta;

            Vector3 position = radiusScale * r * (Mathf.Cos(theta) * Vector3.right + Mathf.Sin(theta) * Vector3.up);
            prefabs.positionVector.SetPositions(Vector3.zero, position);
            prefabs.positionVector.Redraw();
        }
    }

    public override void Reset()
    {
        
    }
}
