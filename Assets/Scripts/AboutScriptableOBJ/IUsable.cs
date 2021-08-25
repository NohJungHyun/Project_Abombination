﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable 
{
    IEnumerator Use();

    IEnumerator PlayUseAnimation();
}