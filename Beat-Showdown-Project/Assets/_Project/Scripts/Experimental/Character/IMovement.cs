using System;
using UnityEngine;

namespace Experimental
{
    public interface IMovement
    {
        Action OnMove { get; set; }
    }

    public interface IMovementInput : IMovement
    {
        Vector3 MoveDelta { get; }
    }
}