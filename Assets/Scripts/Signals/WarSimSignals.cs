using System.Collections;
using System.Collections.Generic;
using strange.extensions.signal.impl;
using UnityEngine;

public class StartSignal : Signal { }

public class SpawnOptionsSignal : Signal<List<Option>> { }

public class GetChildrenSignal : Signal<Option> { }

public class OptionSelectedSignal : Signal<string> { }
