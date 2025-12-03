using Assets.Scripts.Objects;
using LibConstruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tinylogic
{
  public class LogicBoardStructure : SmallGrid, IPlacementBoardHost
  {
    private BoardRef<LogicBoard> logicBoard;
    public LogicBoard Board => this.logicBoard?.Board;
    public List<Collider> BoardColliders;
    public Transform BoardOrigin;
    public IEnumerable<BoxCollider> CollidersForBoard(PlacementBoard board)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<PlacementBoard> GetPlacementBoards()
    {
      throw new System.NotImplementedException();
    }

    public void OnBoardStructureDeregistered(PlacementBoard board, IPlacementBoardStructure structure)
    {
      throw new System.NotImplementedException();
    }

    public void OnBoardStructureRegistered(PlacementBoard board, IPlacementBoardStructure structure)
    {
      throw new System.NotImplementedException();
    }
  }
}
