using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<EventType, List<IListener>> Listeners = new Dictionary<EventType, List<IListener>>();

        public void AddListener(EventType eventType, IListener Listener) //подписываемся на событие
        {
            List<IListener> ListenList = null;
            if (Listeners.TryGetValue(eventType, out ListenList))
            {
                ListenList.Add(Listener);
                return;
            }

            ListenList = new List<IListener>();
            ListenList.Add(Listener);
            Listeners.Add(eventType, ListenList);
        }

        public void PostNotification(EventType eventType) //оповещаем всех подписчиков о событии
        {
            List<IListener> ListenList = null;
            if (!Listeners.TryGetValue(eventType, out ListenList))
                return;
            for (int i = 0; i < ListenList.Count; i++)
            {
                if (!ListenList[i].Equals(null))
                    ListenList[i].OnEvent(eventType);
            }
        }
    }
}
