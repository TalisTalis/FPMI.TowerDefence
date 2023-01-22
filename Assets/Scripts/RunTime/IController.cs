using UnityEngine;

namespace RunTime
{
    // интерфейс характеризует контаркт который объясняет что может делать объект
    // общие функции
    internal interface IController
    {
        // методы
        // вызывается на момент создания контроллера
        void OnStart()
        {
            Debug.Log("Start");
        }
        // вызывается в момент все контроллеры остановятся
        void OnStop()
        {
            Debug.Log("Stop");
        }
        // вызывается каждый кадр
        void Tick()
        {
            Debug.Log("Tick");
        }
    }
}
