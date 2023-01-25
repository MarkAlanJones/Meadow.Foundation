﻿using Meadow.Foundation.Graphics;
using Meadow.Hardware;
using Meadow.Units;

namespace Meadow.Foundation.Displays
{
    /// <summary>
    /// Represents a Ili9341 TFT color display
    /// </summary>
    public class Ili9341 : TftSpiBase
    {
        /// <summary>
        /// The default SPI bus frequency
        /// </summary>
        public static Frequency DefaultSpiBusSpeed = new Frequency(24000, Frequency.UnitType.Kilohertz);

        /// <summary>
        /// The default display color mode
        /// </summary>
        public override ColorType DefautColorMode => ColorType.Format12bppRgb444;

        /// <summary>
        /// Create a new Ili9341 color display object
        /// </summary>
        /// <param name="device">Meadow device</param>
        /// <param name="spiBus">SPI bus connected to display</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        /// <param name="dcPin">Data command pin</param>
        /// <param name="resetPin">Reset pin</param>
        /// <param name="width">Width of display in pixels</param>
        /// <param name="height">Height of display in pixels</param>
        /// <param name="colorMode">The color mode to use for the display buffer</param>
        public Ili9341(IMeadowDevice device, ISpiBus spiBus, IPin chipSelectPin, IPin dcPin, IPin resetPin,
            int width, int height, ColorType colorMode = ColorType.Format12bppRgb444)
            : base(device, spiBus, chipSelectPin, dcPin, resetPin, width, height, colorMode)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new Ili9341 color display object
        /// </summary>
        /// <param name="spiBus">SPI bus connected to display</param>
        /// <param name="chipSelectPort">Chip select output port</param>
        /// <param name="dataCommandPort">Data command output port</param>
        /// <param name="resetPort">Reset output port</param>
        /// <param name="width">Width of display in pixels</param>
        /// <param name="height">Height of display in pixels</param>
        /// <param name="colorMode">The color mode to use for the display buffer</param>
        public Ili9341(ISpiBus spiBus, IDigitalOutputPort chipSelectPort,
                IDigitalOutputPort dataCommandPort, IDigitalOutputPort resetPort,
                int width, int height, ColorType colorMode = ColorType.Format12bppRgb444) :
            base(spiBus, chipSelectPort, dataCommandPort, resetPort, width, height, colorMode)
        {
            Initialize();
        }

        /// <summary>
        /// Initalize the display
        /// </summary>
        protected override void Initialize()
        {
            if (resetPort != null)
            {
                resetPort.State = true;
                DelayMs(50);
                resetPort.State = false;
                DelayMs(50);
                resetPort.State = true;
                DelayMs(50);
            }
            else
            {
                DelayMs(150); //Not sure if this is needed but can't hurt
            }

            SendCommand(0xEF, new byte[] { 0x03, 0x80, 0x02 });
            SendCommand(0xCF, new byte[] { 0x00, 0xC1, 0x30 });
            SendCommand(0xED, new byte[] { 0x64, 0x03, 0x12, 0x81 });
            SendCommand(0xe8, new byte[] { 0x85, 0x00, 0x78 });

            SendCommand(0xCB, new byte[] { 0x39, 0x2C, 0x00, 0x34, 0x02 });
            SendCommand(0xF7, new byte[] { 0x20 });
            SendCommand(0xEA, new byte[] { 0x00, 0x00 });
            SendCommand(ILI9341_PWCTR1, new byte[] { 0x23 });
            SendCommand(ILI9341_PWCTR2, new byte[] { 0x10 });
            SendCommand(ILI9341_VMCTR1, new byte[] { 0x3e, 0x28 });
            SendCommand(ILI9341_VMCTR2, new byte[] { 0x86 });
            SendCommand((byte)Register.MADCTL, new byte[] { (byte)(Register.MADCTL_MX | Register.MADCTL_BGR) }); //13

            if (ColorMode == ColorType.Format16bppRgb565)
            { 
                SendCommand((byte)Register.COLOR_MODE, new byte[] { 0x55 }); //color mode - 16bpp  
            }
            else
            {      
                SendCommand((byte)Register.COLOR_MODE, new byte[] { 0x53 }); //color mode - 12bpp 
            }
            SendCommand((byte)Register.FRMCTR1, new byte[] { 0x00, 0x18 });
            SendCommand(ILI9341_DFUNCTR, new byte[] { 0x08, 0x82, 0x27 });
            SendCommand(0xF2, new byte[] { 0x00 });
            SendCommand(ILI9341_GAMMASET, new byte[] { 0x01 });
            SendCommand(ILI9341_GMCTRP1, new byte[] { 0x0F, 0x31, 0x2B, 0x0C, 0x0E, 0x08, 0x4E, 0xF1, 0x37, 0x07, 0x10, 0x03, 0x0E, 0x09, 0x00 });
            SendCommand(ILI9341_GMCTRN1, new byte[] { 0x00, 0x0E, 0x14, 0x03, 0x11, 0x07, 0x31, 0xC1, 0x48, 0x08, 0x0F, 0x0C, 0x31, 0x36, 0x0F });
            SendCommand(Register.SLPOUT);
            DelayMs(120);
            SendCommand(Register.DISPON);

            SetAddressWindow(0, 0, Width - 1,  Height - 1);

            dataCommandPort.State = (Data);
        }

        /// <summary>
        /// Set addrees window for display updates
        /// </summary>
        /// <param name="x0">X start in pixels</param>
        /// <param name="y0">Y start in pixels</param>
        /// <param name="x1">X end in pixels</param>
        /// <param name="y1">Y end in pixels</param>
        protected override void SetAddressWindow(int x0, int y0, int x1, int y1)
        {
            SendCommand(LcdCommand.CASET);  // column addr set
            dataCommandPort.State = Data;
            Write((byte)(x0 >> 8));
            Write((byte)(x0 & 0xff));   // XSTART 
            Write((byte)(x1 >> 8));
            Write((byte)(x1 & 0xff));   // XEND

            SendCommand(LcdCommand.RASET);  // row addr set
            dataCommandPort.State = Data;
            Write((byte)(y0 >> 8));
            Write((byte)(y0 & 0xff));    // YSTART
            Write((byte)(y1 >> 8));
            Write((byte)(y1 & 0xff));    // YEND

            dataCommandPort.State = Command;
            Write((byte)LcdCommand.RAMWR);  // write to RAM */
        }

        void SendCommand(byte command, byte[] data)
        {
            dataCommandPort.State = Command;
            Write(command);

            if (data != null)
            {
                dataCommandPort.State = Data;
                Write(data);
            }
        }

        static byte ILI9341_GAMMASET = 0x26;

        static byte ILI9341_DFUNCTR = 0xB6;

        static byte ILI9341_PWCTR1 = 0xC0;
        static byte ILI9341_PWCTR2 = 0xC1;
        static byte ILI9341_VMCTR1 = 0xC5;
        static byte ILI9341_VMCTR2 = 0xC7;

        static byte ILI9341_GMCTRP1 = 0xE0;
        static byte ILI9341_GMCTRN1 = 0xE1;
    }
}