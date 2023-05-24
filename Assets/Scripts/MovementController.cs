using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CoroutinesManager _coroutinesManager; //Ссылка на менеджер корутин
    [SerializeField] private LineDrawing _lineDrawing; // Ссылка на объект _lineDrawing ,что бы получить из публичного метода маршрут точек
    [SerializeField] private GameObject _rope; // ссылка на объект _rope для доступа к перемещению
    private Vector3[] _lineRenderers; // Поле для хранения всех отрисованных точек
    [SerializeField] private float _speed = 3; // скорость перемещения веревки с ящиком
    private int _currentPointIndex; // текущий индекс в массиве точек
    private int _nextPointIndex = 1; // следущий индекс в массиве точек
    private float _currentTime ; // текущее время 
    
    
    public void StartMovingBox() // метод который вызывается для старта передвижения коробки
    {
        
        _lineRenderers = _lineDrawing.GetAllPoints(); // получаем все точки маршрута и сохраняем в поле _lineRenderers
        _coroutinesManager.StartCoroutine(StartMovingBoxCoroutine()); // запускаем корутину через манеджер корутин
    }
    
    private IEnumerator StartMovingBoxCoroutine() //корутина приводящая в движение коробку
    {
        while (_lineRenderers[_currentPointIndex]!=_lineRenderers[^1]) // запускаем цикл до тех пор , пока текущая точка не будет равна последней точке в массиве
        {
            _currentTime += Time.deltaTime; // накапливаем время
            var startPosition = _lineRenderers[_currentPointIndex]; // в стартовую позицию сохраняем точку с нулевым индексом
            var nextPosition = _lineRenderers[_nextPointIndex]; // в следующую точку сохраняем позицию с индексом 1
            var distance = Vector3.Distance(startPosition, nextPosition); // сохраняем дистанцию между первой и второй точкой
            var travelTime = distance / _speed; // время в пути от первой до второй точки
            var progress = _currentTime / travelTime; // прогресс передвижения
            _rope.transform.position = Vector3.Lerp(startPosition,nextPosition,progress); // перемещение куба с первой точки на вторую относительно текущего прогресса
            if (progress>=1) //если прогресс равен 1
            {
                _currentPointIndex = _nextPointIndex; // меняем текущую точку на следующую
                _nextPointIndex = (_nextPointIndex + 1) % _lineRenderers.Length; // следующую точку  это остаток полученный от деления следующей точки плюс 1 на длинну массива
                _currentTime = 0; //  обнуляем текущее время 
            }

            yield return null; //пропускаем один кадр
        }
        
        

    }
}
