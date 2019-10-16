using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public List<EnemyCourse> _courses = new List<EnemyCourse>();
    private void Awake()
    {
        Core.Routes = this;
    }

    internal EnemyCourse GetRoute(string routeName)
    {
        if(_courses.Exists(p=>p.Name == routeName))
        {
            return _courses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = "UnSet" };
    }
}
