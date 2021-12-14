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

    public GameObject dayPrefab;
    //TODO: Make this add the calendar days to the Calendar Days object 

    [Header("CalendarUIDimensions")]
    [SerializeField] 
    private int calendarDaysWidth = 1000;
    private int calendarDaysHeight = 800;

    private GridLayoutGroup calendarDaysGridLayoutGroup;

    private void Start()
    {
        SetGridSize();
        InstantiateCalendarDays();
    }

    private void SetGridSize()
    {
        calendarDaysGridLayoutGroup = gameObject.GetComponentInChildren<GridLayoutGroup>();
        int usableCalendarWidth = calendarDaysWidth - (calendarDaysGridLayoutGroup.padding.left + calendarDaysGridLayoutGroup.padding.right);
        int usableCalendarHeight = calendarDaysHeight - (calendarDaysGridLayoutGroup.padding.top + calendarDaysGridLayoutGroup.padding.bottom);
        calendarDaysGridLayoutGroup.cellSize = new Vector2((usableCalendarWidth / daysInWeek), (usableCalendarHeight / weeksInMonth));
    }

    private void InstantiateCalendarDays()
    {
        int totalDays = daysInWeek * weeksInMonth;
        
        for (int i = 0; i < totalDays; i++)
        {
            GameObject newDay = Instantiate(dayPrefab, calendarDaysGridLayoutGroup.transform);
            
        }
    }
}
