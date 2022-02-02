using UnityEngine;

public class EllipseSimulation : Simulation
{
    [SerializeField] private float semiMajorAxis = 10;
    [SerializeField, Range(0, 1)] public float eccentricity = 0.5f;

    private EllipsePrefabs prefabs;
    private Camera mainCamera;

    public float SemiMajorAxis => semiMajorAxis;
    public float Eccentricity => eccentricity;

    private void Awake()
    {
        if (!TryGetComponent(out prefabs))
        {
            Debug.LogWarning("No EllipsePrefabs component found.");
            Pause();
            return;
        }

        prefabs.InstantiateAllPrefabs();

        mainCamera = Camera.main;
    }

    private void Start()
    {
        RedrawEllipse();
        RedrawSemiMajorAxis();
    }

    private void Update()
    {
        if (transform.rotation != mainCamera.transform.rotation)
        {
            //Debug.Log("Rotating Ellipse Simulation");
            transform.rotation = mainCamera.transform.rotation;
        }
    }

    public override void Reset()
    {

    }

    private void RedrawEllipse()
    {
        if (prefabs.ellipse)
        {
            int numSteps = 360;
            float a = SemiMajorAxis;
            float e = Eccentricity;

            Vector3[] positions = new Vector3[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                float theta = i * 2f * Mathf.PI / numSteps;
                float r = a * (1f - e * e) / (1f + e * Mathf.Cos(theta));
                positions[i] = r * (Mathf.Cos(theta) * Vector3.left + Mathf.Sin(theta) * Vector3.up);
            }

            prefabs.ellipse.positionCount = numSteps;
            prefabs.ellipse.SetPositions(positions);
            prefabs.ellipse.loop = true;
        }
    }

    private void RedrawSemiMajorAxis()
    {
        if (prefabs.semiMajorAxisVector)
        {
            float a = SemiMajorAxis;
            float e = Eccentricity;
            Vector3 tailPosition = transform.position + a * e * Vector3.right;
            Vector3 headPosition = tailPosition + a * Vector3.right;
            prefabs.semiMajorAxisVector.SetPositions(tailPosition, headPosition);
            prefabs.semiMajorAxisVector.Redraw();
        }
    }

    public void SetSemiMajorAxis(float a)
    {
        semiMajorAxis = a;
        RedrawEllipse();
        RedrawSemiMajorAxis();
    }

    public void SetEccentricity(float e)
    {
        eccentricity = e;
        RedrawEllipse();
        RedrawSemiMajorAxis();
    }
}
