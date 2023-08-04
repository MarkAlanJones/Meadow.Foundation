﻿using System.Collections;
using System.Collections.Generic;

namespace Meadow.Foundation.Displays.UI;

/// <summary>
/// Represents a collection of display controls on a <see cref="DisplayScreen"/>.
/// </summary>
public sealed class ControlsCollection : IEnumerable<IDisplayControl>
{
    private DisplayScreen _screen;
    private List<IDisplayControl> _controls = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlsCollection"/> class.
    /// </summary>
    /// <param name="screen">The <see cref="DisplayScreen"/> that owns the controls collection.</param>
    internal ControlsCollection(DisplayScreen screen)
    {
        _screen = screen;
    }

    /// <summary>
    /// Removes all display controls from the collection.
    /// </summary>
    public void Clear()
    {
        _controls.Clear();

        // _screen.Invalidate();  // TODO: Decide whether to invalidate the screen after clearing controls.
    }

    /// <summary>
    /// Gets the number of display controls in the collection.
    /// </summary>
    public int Count => _controls.Count;

    /// <summary>
    /// Adds one or more display controls to the collection.
    /// </summary>
    /// <param name="controls">The display controls to add.</param>
    public void Add(params IDisplayControl[] controls)
    {
        // Apply screen theme to the added controls, if available.
        if (_screen.Theme != null)
        {
            foreach (var control in controls)
            {
                control.ApplyTheme(_screen.Theme);
            }
        }

        _controls.AddRange(controls);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection of display controls.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<IDisplayControl> GetEnumerator()
    {
        return _controls.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection of display controls.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
