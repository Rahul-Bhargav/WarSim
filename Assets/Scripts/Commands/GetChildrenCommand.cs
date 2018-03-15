using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetChildrenCommand : Command
{
  public override void Execute() {
    Debug.Log("get children");
  }
}
