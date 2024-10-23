using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class XRInitializer : MonoBehaviour
{

    public static XRInitializer Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

#if UNITY_ANDROID
        UpdateJsonSettings();
        StartCoroutine(StartXR());
#endif
    }

    private void UpdateJsonSettings()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                IgnoreSerializableInterface = true
            },
        };
    }

    IEnumerator StartXR()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }
}