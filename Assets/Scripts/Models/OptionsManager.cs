using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

  public Button optionButton;

  public RectTransform optionsPanel;

  public List<string> actionsTaken;

  [HideInInspector]
  public Options allOptions { get; set; }

  [HideInInspector]
  public Signal<List<string>> ImpactOptionSelected = new Signal<List<string>>();

  void Start()
  {
    DontDestroyOnLoad(this);
  }

  public void OptionSelected(string type)
  {
    actionsTaken.Add(type);
    List<Option> options = allOptions.data;
    Option selectedOption = options.Find(option => option.name == type);
    if (selectedOption.isLeaf)
    {
      Debug.Log("Network Call");
      ImpactOptionSelected.Dispatch(actionsTaken);
    }
    else
    {
      List<Option> children = new List<Option>();
      selectedOption.children.ForEach((child) =>
      {
        Option childOption = options.Find(option => option.name == child);
        children.Add(childOption);
      });
      SpawnOptions(children);
    }
  }

  private void ResetOptions()
  {
    foreach (Transform child in optionsPanel)
    {
      Destroy(child.gameObject);
    }
  }

  public void SpawnOptions(List<Option> options)
  {
    ResetOptions();
    options.ForEach((option) =>
    {
      Button spawnedButton = GameObject.Instantiate(optionButton, Vector3.zero, Quaternion.identity);
      OptionView optionView = spawnedButton.GetComponent<OptionView>();
      optionView.SetProperties(option.name, option.name);
      RectTransform buttonTransform = spawnedButton.GetComponent<RectTransform>();
      buttonTransform.SetParent(optionsPanel);
      buttonTransform.SetPositionAndRotation(optionsPanel.position, optionsPanel.rotation);
    });
  }
}
