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
    public override IPlacementBoardStructure EquivalentStructure(Structure structure)
    {
      if (structure == null) return null;
      return structure.name switch
      {
        "StructureLogicBatchReader" => Prefab.Find("StructureTinyLogicBatchReader"),
        _ => null
      } as IPlacementBoardStructure;
    }
  }
}
