using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketScript : MonoBehaviour
{
    private float elapsedTime = 0f;
    [SerializeField] private float duration = 200f;
    private CelestialBody body;
    [SerializeField] private float initialApoapsis;
    [SerializeField] private float initialPeriapsis;
    [SerializeField] private float targetApoapsis;
    [SerializeField] private float targetPeriapsis;
    [SerializeField] private float initialOrbitalPeriod;
    [SerializeField] private float targetOrbitalPeriod;

    [SerializeField] private TMP_Text daysText;
    [SerializeField] private Slider timeStepSlider;
    [SerializeField] private TMP_Text TCM_Phase;
    [SerializeField] private TMP_Text TCM_Desc;

    [SerializeField] private List<string> TCMList;
    private bool[] checkpointReached = {false,false,false,false,false,false};

    [TextAreaAttribute]
    public string[] descriptions;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<CelestialBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log($"{timeStepSlider.value}");
            ResetTimestep();
        }
        elapsedTime += GlobalTime.YearTick;
        // Debug.Log(elapsedTime);

        if (elapsedTime < 70) {
            daysText.SetText($"<color=\"green\">{Mathf.RoundToInt(elapsedTime)}</color> day(s) <color=\"yellow\">after</color> launch");
        } else {
            if (elapsedTime < 193) {
                daysText.SetText($"<color=\"red\">{duration - Mathf.RoundToInt(elapsedTime)}</color> day(s) <color=\"yellow\">before</color> landing");
            } else {
                if (duration - elapsedTime > 3f) {
                    daysText.SetText($"<color=\"red\">{Mathf.Round((duration - elapsedTime) * 10.0f) * 0.1f}</color> day(s) <color=\"yellow\">before</color> landing");    
                }
                else {
                    daysText.SetText($"<color=\"red\">{Mathf.Round((duration - elapsedTime) * 24)}</color> hour(s) <color=\"yellow\">before</color> landing");
                }
            }
        }
        int range = CheckRange(elapsedTime);
        if (range != -1 && !checkpointReached[range]) {
            checkpointReached[range] = true;
            ResetTimestep();
        }
        UpdateTCMTexts(range);

        if (elapsedTime > duration - 0.3f) {
            ResetTimestep();
        }

        float normalizedElapsedTime = elapsedTime / duration;
        float calculatedApoapsis = Mathf.Lerp(initialApoapsis, targetApoapsis, normalizedElapsedTime);
        float calculatedPeriapsis = Mathf.Lerp(initialPeriapsis, targetPeriapsis, normalizedElapsedTime);
        float calculatedOrbitalPeriod = Mathf.Lerp(initialOrbitalPeriod, targetOrbitalPeriod, normalizedElapsedTime);

        body.SetApoapsis(calculatedApoapsis);
        body.SetPeriapsis(calculatedPeriapsis);
        body.SetOrbitalPeriod(calculatedOrbitalPeriod);

        body.CalculateOrbit(body.NormalizedOrbit, body.NormalizedRotation);
    }

    private void ResetTimestep() {
        timeStepSlider.value = 0;
    }

    private int CheckRange(float day) {
        if (day > 15f && day < 62f && !checkpointReached[0]) return 0;
        else if (day > 62f && day < 109 && !checkpointReached[1]) return 1;
        else if (Mathf.RoundToInt(duration - day) == 62 && !checkpointReached[2]) return 2;
        else if (duration - day > 8.2 && duration - day < 8.9 && !checkpointReached[3]) return 3;
        else if (duration - day > 2.2 && duration - day < 2.9 && !checkpointReached[4]) return 4;
        else if (Mathf.RoundToInt((duration - day)*24) == 9 && !checkpointReached[5]) return 5;
        else return -1;
    }

    private void UpdateTCMTexts(float index) {
        if (index == -1) {
            if (timeStepSlider.value != 0) {
                TCM_Phase.SetText("");
                TCM_Desc.SetText("");
            }
        } else {
            TCM_Phase.SetText($"TCM {index + 1}");
            TCM_Desc.SetText(descriptions[Mathf.RoundToInt(index)]);
        }
    }
}
