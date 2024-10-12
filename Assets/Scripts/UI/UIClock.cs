using System;
using TMPro;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        string date, time;
        UpdateTime(out date, out time);
        UpdateClock(date, time);
    }

    private void UpdateTime(out string _date, out string _time)
    {
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;

        int hour = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;

        bool isAfternoon = false;
        if (hour / 12 > 0)
            isAfternoon = true;

        _date = string.Format($"{month,2}월 {day,2}일");
        if (!isAfternoon)
            _time = string.Format($"오전 {hour % 12,2}시 {minute,2}분");
        else
            _time = string.Format($"오후 {hour % 12,2}시 {minute,2}분");
    }

    private void UpdateClock(string _date, string _time)
    {
        dateText.text = _date;
        timeText.text = _time;
    }
}