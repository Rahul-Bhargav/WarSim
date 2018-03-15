using System.Collections;
using System.Collections.Generic;
using SocketIO;
using strange.extensions.context.impl;
using UnityEngine;

public class WarSimContextView : ContextView
{
  void Awake()
  {
      this.context = new WarSimContext(this);
  }
}
