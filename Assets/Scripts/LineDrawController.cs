using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private bool _isFinishedDrawing;
    private List<LineRenderer> _arrayPoints;

    private void Update()
    {
        if (!_isFinishedDrawing)
        {
            LineDrawing();
        }
        
    }


    private void LineDrawing()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                var lastPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
                if (Vector3.Distance(lastPosition,hitInfo.point)<0.1f)
                {
                    return;
                }
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hitInfo.point);
                _arrayPoints.Add(_lineRenderer);
            }

            _isFinishedDrawing = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isFinishedDrawing = true;
            
        }
    }

    public List<LineRenderer> GetAllPositionsPoints()
    {
        return _arrayPoints;
    }
    

    

    
}
