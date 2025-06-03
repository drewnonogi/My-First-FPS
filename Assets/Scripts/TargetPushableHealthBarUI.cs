using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TargetPushableHealthBarUI : MonoBehaviour
{
    [SerializeField] private TargetPushable targetPushable;
    [SerializeField] private Image barImage;

    private void Start()
    {
        targetPushable.OnTargetPushableHealthChanged += TargetPushable_OnTargetPushableHealthChanged;
    }

    private void TargetPushable_OnTargetPushableHealthChanged(object sender, TargetPushable.OnTargedPushableHealthChangedEventArgs e)
    {
        barImage.fillAmount = e.healthNormalized;
    }
}
