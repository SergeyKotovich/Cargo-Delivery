using System;
using UnityEngine;


public class FinishController : MonoBehaviour
{
    
    [SerializeField] private BoxController _boxController; // Ссылка на объект бокс контроллер

   
  private void Update()
  {
      var ray = new Ray(transform.position, transform.up ); // задаем луч из объекта с направлением вверх
      if (!Physics.Raycast(ray,out var hitInfo)) // если луч не попал ни во что ,просто выходим
      {
          return;
      }

      if (hitInfo.collider.gameObject == _boxController.gameObject ) // если луч попал в объект _boxController
      {
          _boxController.DropDown(transform.position); // то у бокс контроллера вызываем метод опускания ящика
      }
  }
}
