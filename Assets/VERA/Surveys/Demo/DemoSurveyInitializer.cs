using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DemoSurveyManager))]
public class DemoSurveyInitializer : MonoBehaviour
{
    private DemoSurveyManager surveyManager;
    [SerializeField] private SurveyInfo surveyInfo;
    [SerializeField] private bool beginSurveyOnStart = false;
    [SerializeField] private Transform xrOrigin;

    void Start()
    {
        surveyManager = GetComponent<DemoSurveyManager>();
        surveyManager.Setup();
        if (beginSurveyOnStart)
            StartCoroutine(BeginSurveyCoroutine());
    }

    private IEnumerator BeginSurveyCoroutine()
    {
        yield return new WaitForSeconds(2f);
        StartSurvey();
    }

    public void StartSurvey()
    {
        xrOrigin.transform.position = new Vector3(71.524f, 22.372f, 20.796f);
        xrOrigin.transform.rotation = Quaternion.identity;
        surveyManager.BeginSurvey(surveyInfo);
    }
}
