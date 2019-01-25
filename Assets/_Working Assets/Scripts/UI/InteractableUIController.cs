using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUIController : MonoBehaviour
{
    [SerializeField] private float m_TimeToWaitBeforeDisable;

    private Coroutine m_DisableRoutine;
    private float m_ElapsedTime;

    void Start()
    {
        GameManager.Instance.PlanetStatWasChanged += ResetTimer;
    }

    public void Init()
    {
        GetComponentInChildren<SizeSliderController>().UpdateValues();
        GetComponentInChildren<MaterialSliderController>().UpdateValues();
    }

    void OnEnable()
    {
        if (m_DisableRoutine == null)
        {
            m_DisableRoutine = StartCoroutine(DisableTimer());
        }
    }

    private void ResetTimer()
    {
        m_ElapsedTime = 0;
    }

    private IEnumerator DisableTimer()
    {
        while (m_ElapsedTime < m_TimeToWaitBeforeDisable)
        {
            m_ElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        m_ElapsedTime = 0;
        m_DisableRoutine = null;
        gameObject.SetActive(false);
    }
}
