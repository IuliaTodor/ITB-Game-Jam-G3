using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public List<TextMeshPro> nameTexts;
    public List<TextMeshPro> scoreTexts;

    public void Start()
    {
        List<PersistantData> list = DataManager.LoadData();

        list.OrderBy(x => x.score);

        for (int i= 0;  i < list.Count; i++)
        {
            nameTexts[i].text = list[i].playerName;
            scoreTexts[i].text = list[i].score.ToString();
        }
    }
}
