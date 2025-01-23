using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Draw();
    }

    private void Draw()
    {
        var points = new Vector3[]
        {
            transform.position,
            _targetPoint.position
        };

        _lineRenderer.SetPositions(points);
    }
}
