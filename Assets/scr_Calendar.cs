using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Calendar : MonoBehaviour
{
    [Header("Calendar Details")]
    [SerializeField]
    private int daysInWeek;
    [SerializeField]
    private int weeksInMonth;

    [SerializeField]
    public static int currentDay = 0;

    [Header("Prefabs")]
    [SerializeField]
    public GameObject dayPrefab;

    //public List<int[,,]> specialDatesList = new List<int[,,]>();
    //[SerializeField]

    //public Dictionary<int, float> specialDatesDictionary = new Dictionary<int, float>();

    //[SerializeField]
    //public List<Day> dayList = new List<Day>();


    [Header("CalendarUIDimensions")]
    [SerializeField] 
    private int calendarDaysWidth = 1000;
    private int calendarDaysHeight = 800;

    private static GridLayoutGroup calendarDaysGridLayoutGroup;


    private void Start()
    {
        SetGridSize();
        //InstantiateCalendarDays();
        SetCurrentDay();
    }

    private void SetGridSizeBasedOnCustomCalendar()
    {
        int numberOfDays = calendarDaysGridLayoutGroup.transform.childCount;
    }

    private void SetGridSize()
    {
        calendarDaysGridLayoutGroup = gameObject.GetComponentInChildren<GridLayoutGroup>();
        int usableCalendarWidth = calendarDaysWidth - (calendarDaysGridLayoutGroup.padding.left + calendarDaysGridLayoutGroup.padding.right);
        int usableCalendarHeight = calendarDaysHeight - (calendarDaysGridLayoutGroup.padding.top + calendarDaysGridLayoutGroup.padding.bottom);
        calendarDaysGridLayoutGroup.cellSize = new Vector2((usableCalendarWidth / daysInWeek), (usableCalendarHeight / weeksInMonth));
    }

    // Use this for adding calendar days using the script instead of manually adding them in.
    //private void InstantiateCalendarDays()
    //{
    //    int totalDays = daysInWeek * weeksInMonth;
        
    //    for (int i = 0; i < totalDays; i++)
    //    {
    //        GameObject newDay = Instantiate(dayPrefab, calendarDaysGridLayoutGroup.transform);
            
    //    }
    //}


    public static void SetCurrentDay()
    {
        if (currentDay > 0)
            calendarDaysGridLayoutGroup.transform.GetChild(currentDay -1 ).GetComponent<Image>().color = Color.gray;
        calendarDaysGridLayoutGroup.transform.GetChild(currentDay).GetComponent<Image>().color = Color.cyan;
    }
}

//[System.Serializable]
//public class Day
//{
//    public int date;
//    public List<int> specialThings = new List<int>();
//}
