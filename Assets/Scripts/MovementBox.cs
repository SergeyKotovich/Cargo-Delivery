using System;
using System.Collections;
using UnityEngine;

public class MovementBox : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _totalTravelTime;
    [SerializeField] private LineDrawController _lineDrawController;

    private void GetAllPositionsPoints()
    {
        var arrayPositions = _lineDrawController.GetAllPositionsPoints();
        for (var i = 0; i < arrayPositions.Count; i++)
        {
            
        }
    }


    public void StartMoving()
    {
        StartCoroutine(BoxMoving());
    }

    private IEnumerator BoxMoving()
    {
        var currentTime = 0f;
        currentTime += Time.deltaTime;
        var progress = currentTime / _totalTravelTime;
        while (currentTime<_totalTravelTime)
        {
            
            transform.position =  Vector3.Lerp(_startPosition.transform.position, _endPosition.position, progress);
            yield return null;
        }
        


        
    }
}

