using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public List<EnemyCourse> _rightCourses = new List<EnemyCourse>();
    public List<EnemyCourse> _bottomCourses = new List<EnemyCourse>();
    public List<EnemyCourse> _leftCourses = new List<EnemyCourse>();
    public List<EnemyCourse> _topCourses = new List<EnemyCourse>();
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
    internal EnemyCourse GetBottomRoute(ROUTENAMES routeName)
    {
        if (_bottomCourses.Exists(p => p.Name == routeName))
        {
            return _bottomCourses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = ROUTENAMES.UNSET };
    }
    internal EnemyCourse GetLeftRoute(ROUTENAMES routeName)
    {
        if (_leftCourses.Exists(p => p.Name == routeName))
        {
            return _leftCourses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = ROUTENAMES.UNSET };
    }
    internal EnemyCourse GetTopRoute(ROUTENAMES routeName)
    {
        if (_topCourses.Exists(p => p.Name == routeName))
        {
            return _topCourses.Find(p => p.Name == routeName);
        }
        return new EnemyCourse() { Name = ROUTENAMES.UNSET };
    }
}
