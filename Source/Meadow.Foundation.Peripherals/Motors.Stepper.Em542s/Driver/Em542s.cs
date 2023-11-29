﻿using Meadow.Hardware;
using Meadow.Peripherals;
using Meadow.Peripherals.Motors;
using Meadow.Units;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Meadow.Foundation.Motors.Stepper;

/// <summary>
/// This class is for the Em542s Stepper Motor Driver
/// </summary>
public class Em542s : IStepperMotor
{
    private const int MinimumMicrosecondDelayRequiredByDrive = 5; // per the data sheet

    private readonly IDigitalOutputPort pulsePort;
    private readonly IDigitalOutputPort directionPort;
    private readonly IDigitalOutputPort? enablePort;
    private float usPerCall;
    private readonly object syncRoot = new();

    /// <summary>
    /// Gets or sets the minimum step dwell time when motor changes from stationary to moving. Motors with more mass or larger steps require more dwell.
    /// </summary>
    public int MinimumStartupDwellMicroseconds { get; set; } = 50;

    /// <summary>
    /// Gets or sets a constant that affects the rate of linear acceleration for the motor. A lower value yields faster acceleration.
    /// Motors with more mass or larger steps require slower acceleration
    /// </summary>
    public int LinearAccelerationConstant { get; set; } = 40;

    /// <inheritdoc/>
    public RotationDirection Direction { get; set; }

    /// <inheritdoc/>
    public int StepsPerRevolution { get; }

    /// <summary>
    /// Gets a value indicating whether or not the logic for the stepper motor driver is inverted.
    /// </summary>
    public bool InverseLogic { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Em542s"/> class with the specified parameters.
    /// </summary>
    /// <param name="pulse">The digital output port for controlling the pulse signal.</param>
    /// <param name="direction">The digital output port for controlling the direction of rotation.</param>
    /// <param name="enable">The optional digital output port for enabling or disabling the motor (if available).</param>
    /// <param name="stepsPerRevolution">The number of steps per revolution for the stepper motor (default is 200).</param>
    /// <param name="inverseLogic">A value indicating whether the logic for the stepper motor driver is inverted (default is false).</param>
    public Em542s(
        IDigitalOutputPort pulse,
        IDigitalOutputPort direction,
        IDigitalOutputPort? enable = null,
        int stepsPerRevolution = 200,
        bool inverseLogic = false
        )
    {
        StepsPerRevolution = stepsPerRevolution;
        InverseLogic = inverseLogic;

        pulsePort = pulse;
        directionPort = direction;
        enablePort = enable;

        pulsePort.State = !InverseLogic;
        directionPort.State = InverseLogic;

        if (enablePort != null)
        {
            enablePort.State = false;
        }

        CalculateCallDuration();
    }

    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    private void CalculateCallDuration()
    {
        // this estimates how long a method call takes on the current platform.
        // this is used below to provide a sub-millisecond "delay" used for step dwell
        var temp = 0;
        var calls = 100000;

        var start = Environment.TickCount;

        for (var i = 0; i < calls; i++)
        {
            temp = i;
        }

        var et = Environment.TickCount - start;

        usPerCall = et * 1000 / (float)calls;

        Resolver.Log.Info($"us per call: {calls} / {et} = {usPerCall}");
    }

    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    private void MicrosecondSleep(int microseconds)
    {
        var temp = 0;

        for (var i = 0; i < microseconds / usPerCall; i++)
        {
            temp = i;
        }
    }

    /// <inheritdoc/>
    public void Step(int steps, RotationDirection direction, Frequency rate)
    {
        while (usPerCall == 0)
        {
            Thread.Sleep(10);
        }

        lock (syncRoot)
        {
            var directionState = direction == RotationDirection.Clockwise;
            if (InverseLogic) directionState = !directionState;
            directionPort.State = directionState;

            if (enablePort != null)
            {
                enablePort.State = !InverseLogic;
            }

            var targetus = (int)(1000000d / rate.Hertz);

            if (targetus < MinimumMicrosecondDelayRequiredByDrive) throw new ArgumentOutOfRangeException(
                "Rate cannot have pulses shorter than 5us. Use 200KHz or less.");

            var us = targetus < MinimumStartupDwellMicroseconds ? MinimumStartupDwellMicroseconds : targetus;

            for (var step = 0; step < steps; step++)
            {
                pulsePort.State = InverseLogic; // low means "step"

                MicrosecondSleep(us);

                pulsePort.State = !InverseLogic;

                MicrosecondSleep(us);

                // DEV NOTE:
                // naive linear acceleration tested only with STP-MTR-34066 motor
                if (us > targetus && step % LinearAccelerationConstant == 0)
                {
                    us--;
                }
            }

            if (enablePort != null)
            {
                enablePort.State = !InverseLogic;
            }
        }
    }
}