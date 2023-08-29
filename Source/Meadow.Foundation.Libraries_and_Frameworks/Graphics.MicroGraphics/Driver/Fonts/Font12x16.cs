﻿namespace Meadow.Foundation.Graphics
{
    /// <summary>
    /// Represents a 12x16 bitmap font
    /// </summary>
    public class Font12x16 : IFont
    {
        /// <summary>
        /// Width of a character in the font.
        /// </summary>
        public int Width => 12;

        /// <summary>
        /// Height of a character in the font.
        /// </summary>
        public int Height => 16;

        /// <summary>
        /// Font table containing the binary representation of ASCII characters.
        /// </summary>
        private static readonly byte[][] _fontTable =
        {
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //0020( )
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0021(!)
            new byte[] {0x00, 0x00, 0x00, 0x98, 0x81, 0x19, 0x98, 0x81, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //0022(")
            new byte[] {0x00, 0x80, 0x19, 0x98, 0x81, 0x19, 0xFE, 0xE7, 0x7F, 0x98, 0x81, 0x19, 0xFE, 0xE7, 0x7F, 0x98, 0x81, 0x19, 0x98, 0x01, 0x00, 0x00, 0x00, 0x00}, //0023(#)
            new byte[] {0x00, 0x00, 0x06, 0xF8, 0xC1, 0x3F, 0x6C, 0xC3, 0x06, 0xFC, 0x81, 0x3F, 0x60, 0x03, 0x36, 0x6C, 0xC3, 0x1F, 0xF8, 0x00, 0x06, 0x00, 0x00, 0x00}, //0024($)
            new byte[] {0x00, 0xC0, 0x00, 0x12, 0x26, 0x71, 0x92, 0xC3, 0x1C, 0xE0, 0x00, 0x07, 0x38, 0xC3, 0x49, 0x8E, 0x64, 0x48, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00}, //0025(%)
            new byte[] {0x00, 0x80, 0x03, 0x7C, 0xC0, 0x06, 0x6C, 0x80, 0x03, 0x7C, 0xE6, 0x6F, 0xC6, 0x63, 0x1C, 0xC6, 0xE3, 0x6F, 0x7C, 0x06, 0x00, 0x00, 0x00, 0x00}, //0026(&)
            new byte[] {0x00, 0x80, 0x01, 0x18, 0x80, 0x01, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //0027(')
            new byte[] {0x00, 0x00, 0x0C, 0xE0, 0x00, 0x07, 0x30, 0x00, 0x03, 0x30, 0x00, 0x03, 0x30, 0x00, 0x03, 0x70, 0x00, 0x0E, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00}, //0028(()
            new byte[] {0x00, 0x00, 0x03, 0x70, 0x00, 0x0E, 0xC0, 0x00, 0x0C, 0xC0, 0x00, 0x0C, 0xC0, 0x00, 0x0C, 0xC0, 0x00, 0x07, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00}, //0029())
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x01, 0x09, 0x60, 0xC0, 0x3F, 0x60, 0x00, 0x09, 0x08, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //002A(*)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0xFC, 0xC3, 0x3F, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //002B(+)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x04, 0x40, 0x00, 0x06}, //002C(,)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFC, 0xC3, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //002D(-)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //002E(.)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x06, 0x70, 0x80, 0x03, 0x1C, 0xE0, 0x00, 0x07, 0x38, 0xC0, 0x01, 0x0E, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //002F(/)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x70, 0x86, 0x67, 0x6C, 0x66, 0x66, 0x66, 0x36, 0xE6, 0x61, 0x0E, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0030(0)
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0031(1)
            new byte[] {0x00, 0xC0, 0x3F, 0xFC, 0x07, 0x60, 0x00, 0x06, 0x60, 0xFC, 0xE7, 0x3F, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //0032(2)
            new byte[] {0x00, 0xE0, 0x3F, 0xFE, 0x07, 0x60, 0x00, 0x06, 0x60, 0xFC, 0xC3, 0x3F, 0x00, 0x06, 0x60, 0x00, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0033(3)
            new byte[] {0x00, 0x60, 0x30, 0x06, 0x63, 0x30, 0x06, 0x63, 0x30, 0x06, 0xE3, 0x7F, 0xFE, 0x07, 0x30, 0x00, 0x03, 0x30, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00}, //0034(4)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0xFE, 0xE3, 0x7F, 0x00, 0x06, 0x60, 0x00, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0035(5)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x63, 0x00, 0x06, 0x60, 0x00, 0xFE, 0xE3, 0x7F, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0036(6)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00}, //0037(7)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFC, 0xE3, 0x7F, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0038(8)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xC7, 0x7F, 0x00, 0x06, 0x60, 0x00, 0xC6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0039(9)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //003A(:)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x04, 0x60, 0x00, 0x00}, //003B(;)
            new byte[] {0x00, 0x00, 0x18, 0xC0, 0x01, 0x0E, 0x70, 0x80, 0x03, 0x18, 0x80, 0x01, 0x38, 0x00, 0x07, 0xE0, 0x00, 0x1C, 0x80, 0x01, 0x00, 0x00, 0x00, 0x00}, //003C(<)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFE, 0xE7, 0x7F, 0x00, 0x00, 0x00, 0xFE, 0xE7, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //003D(=)
            new byte[] {0x00, 0x80, 0x01, 0x38, 0x00, 0x07, 0xE0, 0x00, 0x1C, 0x80, 0x01, 0x18, 0xC0, 0x01, 0x0E, 0x70, 0x80, 0x03, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00}, //003E(>)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x60, 0x00, 0x06, 0x60, 0xE0, 0x07, 0x7E, 0x60, 0x00, 0x06, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //003F(?)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0xF6, 0x67, 0x3F, 0x06, 0xE0, 0x7F, 0xFC, 0x07, 0x00, 0x00, 0x00, 0x00}, //0040(@)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xE7, 0x7F, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0041(A)
            new byte[] {0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xE3, 0x3F, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0042(B)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0043(C)
            new byte[] {0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0044(D)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0xFE, 0xE3, 0x3F, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //0045(E)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0xFE, 0xE3, 0x3F, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00}, //0046(F)
            new byte[] {0x00, 0xC0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0x86, 0x67, 0x78, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0047(G)
            new byte[] {0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xE7, 0x7F, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0048(H)
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0049(I)
            new byte[] {0x00, 0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //004A(J)
            new byte[] {0x00, 0x60, 0x18, 0xC6, 0x61, 0x0E, 0x76, 0xE0, 0x03, 0x1E, 0xE0, 0x03, 0x76, 0x60, 0x0E, 0xC6, 0x61, 0x38, 0x06, 0x03, 0x00, 0x00, 0x00, 0x00}, //004B(K)
            new byte[] {0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //004C(L)
            new byte[] {0x00, 0x60, 0x60, 0x0E, 0xE7, 0x79, 0xFE, 0x67, 0x6F, 0x66, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //004D(M)
            new byte[] {0x00, 0x60, 0x60, 0x0E, 0xE6, 0x61, 0x3E, 0x66, 0x67, 0xE6, 0x66, 0x7C, 0x86, 0x67, 0x70, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //004E(N)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //004F(O)
            new byte[] {0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xE7, 0x3F, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00}, //0050(P)
            new byte[] {0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x01, 0x78, 0x00, 0x06, 0x00}, //0051(Q)
            new byte[] {0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0xFE, 0xE3, 0x7F, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0052(R)
            new byte[] {0x00, 0xC0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0xFE, 0xC3, 0x7F, 0x00, 0x06, 0x60, 0x00, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0053(S)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0054(T)
            new byte[] {0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0055(U)
            new byte[] {0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0xC6, 0x30, 0x0C, 0x83, 0x19, 0x98, 0x01, 0x0F, 0xF0, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0056(V)
            new byte[] {0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0xE6, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //0057(W)
            new byte[] {0x00, 0x60, 0x60, 0x0E, 0xC7, 0x39, 0xF8, 0x01, 0x0F, 0x60, 0x00, 0x06, 0xF0, 0x80, 0x1F, 0x9C, 0xE3, 0x70, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0058(X)
            new byte[] {0x00, 0x60, 0x60, 0x06, 0xC6, 0x30, 0x0C, 0x83, 0x19, 0x98, 0x01, 0x0F, 0xF0, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0059(Y)
            new byte[] {0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x70, 0x80, 0x03, 0x1C, 0xE0, 0x00, 0x07, 0x38, 0xC0, 0x01, 0x0E, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //005A(Z)
            new byte[] {0x00, 0x00, 0x1F, 0xF0, 0x01, 0x03, 0x30, 0x00, 0x03, 0x30, 0x00, 0x03, 0x30, 0x00, 0x03, 0x30, 0x00, 0x1F, 0xF0, 0x01, 0x00, 0x00, 0x00, 0x00}, //005B([)
            new byte[] {0x00, 0x00, 0x00, 0x06, 0xE0, 0x00, 0x1C, 0x80, 0x03, 0x70, 0x00, 0x0E, 0xC0, 0x01, 0x38, 0x00, 0x07, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //005C(\)
            new byte[] {0x00, 0x00, 0x1F, 0xF0, 0x01, 0x18, 0x80, 0x01, 0x18, 0x80, 0x01, 0x18, 0x80, 0x01, 0x18, 0x80, 0x01, 0x1F, 0xF0, 0x01, 0x00, 0x00, 0x00, 0x00}, //005D(])
            new byte[] {0x60, 0x00, 0x0F, 0xF8, 0xC1, 0x39, 0x0C, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //005E(^)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //005F(_)
            new byte[] {0x0C, 0xC0, 0x01, 0x38, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //0060(`)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x3F, 0xFC, 0x07, 0x60, 0xFC, 0xE7, 0x7F, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x00, 0x00, 0x00, 0x00}, //0061(a)
            new byte[] {0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0062(b)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x7F, 0xFE, 0x67, 0x00, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x7F, 0xFC, 0x07, 0x00, 0x00, 0x00, 0x00}, //0063(c)
            new byte[] {0x00, 0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0xC6, 0x7F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x00, 0x00, 0x00, 0x00}, //0064(d)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0xFE, 0xE7, 0x7F, 0x06, 0xE0, 0x3F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //0065(e)
            new byte[] {0x00, 0x00, 0x3F, 0xF8, 0x83, 0x01, 0x18, 0xE0, 0x0F, 0xFE, 0x80, 0x01, 0x18, 0x80, 0x01, 0x18, 0x80, 0x01, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00}, //0066(f)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x60, 0xFC, 0xC7, 0x3F}, //0067(g)
            new byte[] {0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0068(h)
            new byte[] {0x00, 0x00, 0x00, 0x60, 0x00, 0x06, 0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0069(i)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x06, 0x60, 0x00, 0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x66, 0x60, 0xFE, 0xC7, 0x3F}, //006A(j)
            new byte[] {0x00, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x30, 0x86, 0x63, 0x1C, 0xFE, 0xE0, 0x1F, 0x86, 0x63, 0x70, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //006B(k)
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //006C(l)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x39, 0xFE, 0x67, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x06, 0x00, 0x00, 0x00, 0x00}, //006D(m)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //006E(n)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x03, 0x00, 0x00, 0x00, 0x00}, //006F(o)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFE, 0x63, 0x00, 0x06, 0x60, 0x00}, //0070(p)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x7F, 0xFE, 0x67, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x60, 0x00, 0x06, 0x60}, //0071(q)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x3F, 0xFE, 0x67, 0x60, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00}, //0072(r)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x7F, 0xFE, 0x67, 0x00, 0xFE, 0xC3, 0x7F, 0x00, 0xE6, 0x7F, 0xFE, 0x03, 0x00, 0x00, 0x00, 0x00}, //0073(s)
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0xC0, 0x3F, 0xFC, 0x03, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0074(t)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x00, 0x00, 0x00, 0x00}, //0075(u)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x60, 0x06, 0xC6, 0x30, 0x0C, 0x83, 0x19, 0xF8, 0x01, 0x0F, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00}, //0076(v)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x66, 0x66, 0x66, 0x66, 0xE6, 0x7F, 0x9C, 0x03, 0x00, 0x00, 0x00, 0x00}, //0077(w)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x60, 0x0E, 0xC7, 0x39, 0xF8, 0x81, 0x1F, 0x9C, 0xE3, 0x70, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00}, //0078(x)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x60, 0x06, 0x66, 0x60, 0x06, 0x66, 0x60, 0x06, 0xE6, 0x7F, 0xFC, 0x07, 0x60, 0xFC, 0xC7, 0x3F}, //0079(y)
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE0, 0x7F, 0xFE, 0x07, 0x38, 0xE0, 0x81, 0x07, 0x1C, 0xE0, 0x7F, 0xFE, 0x07, 0x00, 0x00, 0x00, 0x00}, //007A(z)
            new byte[] {0x00, 0x00, 0x18, 0xC0, 0x01, 0x0E, 0x60, 0x00, 0x06, 0x30, 0x00, 0x03, 0x60, 0x00, 0x06, 0xE0, 0x00, 0x1C, 0x80, 0x01, 0x00, 0x00, 0x00, 0x00}, //007B({)
            new byte[] {0x00, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x06, 0x60, 0x00, 0x00}, //007C(|)
            new byte[] {0x00, 0x80, 0x01, 0x38, 0x00, 0x07, 0x60, 0x00, 0x06, 0xC0, 0x00, 0x0C, 0x60, 0x00, 0x06, 0x70, 0x80, 0x03, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00}, //007D(})
            new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x86, 0x73, 0xFC, 0xE3, 0x1E, 0xC6, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, //007E(~)
        };

        /// <summary>
        /// Get the binary representation of an ASCII character from the
        /// font table.
        /// </summary>
        /// <param name="character">Character to look up.</param>
        /// <returns>
        /// Byte array containing the rows of pixels in the character.  Unknown byte codes will result in a space being
        /// returned.
        /// </returns>
        public byte[] this[char character]
        {
            get
            {
                var index = (byte)character;
                if ((index < 32) || (index >= 127))
                {
                    return _fontTable[0x20];
                }
                return _fontTable[(byte)character - 0x20];
            }
        }
    }
}