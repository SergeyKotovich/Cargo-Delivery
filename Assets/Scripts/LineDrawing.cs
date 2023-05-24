using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineDrawing : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer; // получаем доступ к линии
    [SerializeField] private float _minDistanceBetweenLastPointAndCurrentPoint = 0.1f; // поле для хранения минимальной дистанции между последней точкой и текущей точкой
    [SerializeField] private UnityEvent OnBoxMove;
    private bool _isDrawingDisable;


    private void Update()
    {
        Draw();
    }

    private void Draw() //метод для рисования линии
    {
        if (_isDrawingDisable)
        {
            return;
        }
        if (Input.GetMouseButton(0)) // если нажата левая кнопка мыши, то
        {
            var mousePosition = Input.mousePosition; // получаем точку мыши
            var ray = Camera.main.ScreenPointToRay(mousePosition); // получаем луч из камеры в то место где находится мышь
            if (!Physics.Raycast(ray, out var hitInfo )) // если луч не попал никуда, то просто выходим
            {
                return;
            }

            if (_lineRenderer.positionCount <= 0) //если количество точек в линии меньше или равно 0 , то просто выходим
            {
                return;
            }
            var lastPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1); // то , в переменную lastPosition сохраняем позицию последней точки
            if (Vector3.Distance(lastPosition,hitInfo.point)<_minDistanceBetweenLastPointAndCurrentPoint) // если расстояние между последней точкой и точкой в которой находится мышь меньше чем минимальная дистанция между точками
            {
                return; // просто выходим и не добавляем новую точку          
            }

            _lineRenderer.positionCount++; // добавляем одну точку 
            _lineRenderer.SetPosition(_lineRenderer.positionCount-1,hitInfo.point); // сетим этой точке позицию мыши
             
        }
        
        if (Input.GetMouseButtonUp(0)) //если подняли левую кнопку мыши, то закончили рисовать линию
        {
            _isDrawingDisable = true;
            OnBoxMove.Invoke(); // когда подняли левую кнопу мыши, вызываем событие
        }
        
    }

    public Vector3 [] GetAllPoints() //метод для получения всех точек
    {
        var arrayPoints = new Vector3[_lineRenderer.positionCount]; // создаем массив равный длинне массива точек _lineRenderer
        _lineRenderer.GetPositions(arrayPoints); // добавляем все точки в созданный массив
        return arrayPoints; // возвращаем его
    }

    
}
