using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chickCountText;
    [SerializeField] TextMeshProUGUI foxCountText;
    [SerializeField] TextMeshProUGUI recordCountText;

    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;

    void Update()
    {
        CountText();
        Medal();
    }
    void Medal()
    {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);
        if (Progress.Instance.PlayerInfo.saveChick >= 20)
        {
            Bronze.SetActive(true);
        }
        if (Progress.Instance.PlayerInfo.saveChick >= 50)
        {
            Bronze.SetActive(false);
            Silver.SetActive(true);
        }
        if (Progress.Instance.PlayerInfo.saveChick >= 100)
        {
            Silver.SetActive(false);
            Gold.SetActive(true);
        }
    }
    void CountText()
    {
        chickCountText.text = " " + Progress.Instance.PlayerInfo.saveChick;
        foxCountText.text = " " + Progress.Instance.PlayerInfo.eatenChick;
        recordCountText.text = " " + Progress.Instance.PlayerInfo.recordSaveChick;
    }
}
