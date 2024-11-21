using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for storing and accessing events all in one place.
/// Source: https://youtu.be/RPhTEJw6KbI?si=-_n_Dyt1jjGXp6BY
/// Pro: This event system is less resource intensive than one that uses UnityEvents
/// Con: not as good for team collaboration, because of potential merge conflicts from creating events in this class.
///
/// Tip: use { get; } to expose where the event is used
/// </summary>
public static class EventManager
{
    //public static Event<bool> onGamePaused { get; } = new (); // bool: true if game is paused
    public static Event OnFinishTurn { get; } = new ();
    public static Event OnStartTurn { get; } = new ();
    public static Event OnAllPlayersTurnFinished { get; } = new ();
    
    public static Event OnFinishRound { get; } = new ();
    public static Event<int> OnStartRound { get; } = new (); // int: Round number
    public static Event OnEndMatch { get; } = new ();
    public static Event OnStartMatch { get; } = new ();
    
    
}