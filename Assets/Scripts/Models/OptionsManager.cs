using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

  public List<string> actionsTaken;

  [HideInInspector]
  public Options allOptions { get; set; }

  [HideInInspector]
  public Signal<List<string>> ImpactOptionSelected = new Signal<List<string>>();

  [HideInInspector]
  public Signal<List<Option>> SpawnOptions = new Signal<List<Option>>();

  [HideInInspector]
  public Signal ClearOptions = new Signal();

  void Start()
  {
    DontDestroyOnLoad(this);
  }

  public void OptionSelected(string id)
  {
    actionsTaken.Add(id);
    List<Option> options = allOptions.data;
    Option selectedOption = options.Find(option => option._id == id);
    if (selectedOption.isLeaf)
    {
      Debug.Log("Network Call");
      ImpactOptionSelected.Dispatch(actionsTaken);
    }
    else
    {
      List<Option> children = options.FindAll((option) => option.parent == selectedOption._id);
      ClearOptions.Dispatch();
      SpawnOptions.Dispatch(children);
    }
  }
}
