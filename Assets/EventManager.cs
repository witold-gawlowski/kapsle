using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IEvent{}
public class EventManager : Singleton<EventManager>
{
    List<Action<IEvent>> events = new List<Action<IEvent>>();
    public static void AddListener<T>(Action<T> handler) where T: IEvent{
        Instance.events.Add((IEvent arg) => handler((T)arg));
    }
    public static void Trigger<T> (T ev) where T: IEvent {
        foreach(Action<IEvent> a in Instance.events){
            try{
                a(ev);
            }catch(Exception e){

            }
        }
    }
}