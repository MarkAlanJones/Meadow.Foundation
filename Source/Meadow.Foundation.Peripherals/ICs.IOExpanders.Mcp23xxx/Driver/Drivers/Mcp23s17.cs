﻿using Meadow.Hardware;

namespace Meadow.Foundation.ICs.IOExpanders
{
    /// <summary>
    /// Represent an MCP23017 SPI port expander
    /// </summary>
    public class Mcp23s17 : Mcp23x1x
    {
        /// <summary>
        /// Creates an Mcp23s17 object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPort">Chip select port</param>
        /// <param name="interruptPort">optional interupt port, needed for input interrupts</param>
        /// <param name="resetPort">Optional Meadow output port used to reset the mcp expander</param>
        public Mcp23s17(ISpiBus spiBus, IDigitalOutputPort chipSelectPort, IDigitalInputPort interruptPort = null, IDigitalOutputPort resetPort = null) :
            base(spiBus, chipSelectPort, interruptPort, resetPort)
        {
        }

        /// <summary>
        /// Creates an Mcp23s17 object
        /// </summary>
        /// <param name="device">The device used to create the ports</param>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        /// <param name="interruptPin">optional interupt pin, needed for input interrupts (InterruptMode: EdgeRising, ResistorMode.InternalPullDown)</param>
        public Mcp23s17(IMeadowDevice device, ISpiBus spiBus, IPin chipSelectPin, IPin interruptPin = null) :
            this(spiBus, device.CreateDigitalOutputPort(chipSelectPin), (interruptPin == null) ? null : device.CreateDigitalInputPort(interruptPin, InterruptMode.EdgeRising, ResistorMode.InternalPullDown))
        {
        }
    }
}