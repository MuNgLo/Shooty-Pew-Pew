using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public List<EnemyCourse> _rightCourses = new List<EnemyCourse>();
    public List<EnemyCourse> _verticalCourses = new List<EnemyCourse>();
    private void Awake()
    {
        Core.Routes = this;
    }

    internal EnemyCourse GetRightRoute(ROUTENAMES routeName)
    {
        if (_rightCourses.Exists(p => p.Name == routeName))
        {
            return _rightCourses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = ROUTENAMES.UNSET };
    }
  
  
    internal EnemyCourse GetVerticalRoute(ROUTENAMES routeName)
    {
        if (_verticalCourses.Exists(p => p.Name == routeName))
        {
            return _verticalCourses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = ROUTENAMES.UNSET };
    }
}
