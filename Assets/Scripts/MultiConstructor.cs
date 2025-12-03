using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Objects;
using UnityEngine;

namespace TinyLogic
{
  public class MultiConstructor : Assets.Scripts.Objects.MultiConstructor
  {
    [SerializeField]
    public string ModelCopyPrefab;

    public void PatchOnLoad()
    {
      if (this.ModelCopyPrefab != "")
      {
        var src = Prefab.Find(this.ModelCopyPrefab);
        this.Thumbnail = src.Thumbnail;
        this.Blueprint = src.Blueprint;
        this.PaintableMaterial = src.PaintableMaterial;

        var srcMf = src.GetComponent<MeshFilter>();
        var mf = this.GetComponent<MeshFilter>();
        mf.mesh = srcMf.mesh;

        var srcRenderer = src.GetComponent<MeshRenderer>();
        var renderer = this.GetComponent<MeshRenderer>();
        renderer.materials = srcRenderer.materials;

        var srcCollider = src.GetComponent<BoxCollider>();
        var collider = this.GetComponent<BoxCollider>();
        collider.center = srcCollider.center;
        collider.size = srcCollider.size;
      }
    }
  }
}