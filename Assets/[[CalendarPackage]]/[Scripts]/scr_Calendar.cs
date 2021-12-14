using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject specialDayPrefab;

    [SerializeField]
    public List<Day> dayList = new List<Day>();


    [Header("CalendarUIDimensions")]
    [SerializeField] 
    private int calendarDaysWidth = 1000;
    private int calendarDaysHeight = 800;

    private static GridLayoutGroup calendarDaysGridLayoutGroup;


    private void Start()
    {
        SetGridSize();
        SetCurrentDay(currentDay);
        SetDayNumbers();
        SetSpecialDays();
    }

    private void OnEnable()
    {
        scr_TimePasser.dayPassedEvent += SetCurrentDay; 
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

    private void SetDayNumbers()
    {
        for(int i = 0; i < calendarDaysGridLayoutGroup.transform.childCount; i++)
        {
            Transform childDay = calendarDaysGridLayoutGroup.transform.GetChild(i);

            childDay.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    //private void SetSeasonColors()
    //{
    //    Transform childDay = calendarDaysGridLayoutGroup.transform.GetChild(i);
    //    for (int i = 0; i < calendarDaysGridLayoutGroup.transform.childCount; i++)
    //    {

    //        if (i < daysInWeek)
    //        {
    //            childDay.gameObject.GetComponent<Image>().color = Color.yellow;
    //        }
    //        else if (i < daysInWeek * 2)
    //        {
    //            childDay.gameObject.GetComponent<Image>().color = Color.red;
    //        }
    //        else if (i < daysInWeek * 3)
    //        {
    //            childDay.gameObject.GetComponent<Image>().color = Color.green;
    //        }
    //        else if (i < daysInWeek * 4)
    //        {
    //            childDay.gameObject.GetComponent<Image>().color = Color.blue;
    //        }
    //    }
    //}

    // Use this for adding calendar days using the script instead of manually adding them in.
    //private void InstantiateCalendarDays()
    //{
    //    int totalDays = daysInWeek * weeksInMonth;

    //    for (int i = 0; i < totalDays; i++)
    //    {
    //        GameObject newDay = Instantiate(dayPrefab, calendarDaysGridLayoutGroup.transform);

    //    }
    //}


    public void SetCurrentDay(float dayToSet)
    {
      
        Debug.Log("THE DAY IS" + dayToSet);
        currentDay = (int)dayToSet;

        Debug.Log("CURRENT DAY IS" + currentDay);


        if (currentDay > 0)
        {
            calendarDaysGridLayoutGroup.transform.GetChild(currentDay - 1).GetComponent<Image>().color = Color.gray;
        }
        calendarDaysGridLayoutGroup.transform.GetChild(currentDay).GetComponent<Image>().color = Color.cyan;    // Color indicating which day is today.


        foreach(Day specialDay in dayList)
        {
            if (currentDay == specialDay.date - 1)   // Check if it is a specialDay
            {
                specialDay.specialEvent.DayStart();
            }

            if (currentDay - 1 == specialDay.date - 1) // Check if the day ending was a special day, to disable special effects.
            {
                specialDay.specialEvent.DayEnd();
            }
        }
    }

    public void SetSpecialDays()
    {
        foreach(Day specialDay in dayList)
        {
            GameObject day = calendarDaysGridLayoutGroup.transform.GetChild(specialDay.date - 1).gameObject;
            GameObject specialDayObject = Instantiate(specialDayPrefab, day.transform);
            specialDayObject.GetComponent<Image>().sprite = specialDay.specialEvent.dayImage;

        }
    }
}

[System.Serializable]
public class Day
{
    public so_SpecialEvent specialEvent; 

    public int date;
  
}
