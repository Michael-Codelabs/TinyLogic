using Assets.Scripts.Objects;
using LibConstruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tinylogic
{
  public class LogicBoard : PlacementBoard
  {
    public override float GridSize => 0.5f / 8;
    public override IPlacementBoardStructure EquivalentStructure(Structure structure) => structure as IPlacementBoardStructure;
  }
}
