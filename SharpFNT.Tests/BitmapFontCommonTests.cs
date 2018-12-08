﻿// ****************************************************************************
// BitmapFontCommonTests.cs
// Copyright 2018 Todd Berta-Oldham
// This code is licensed under MIT.
// ****************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace SharpFNT.Tests
{
    [TestClass]
    public class BitmapFontCommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ReadBinaryWrongBlockSize()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8, true))
                {
                    binaryWriter.Write(8);
                    binaryWriter.Write(2);
                    binaryWriter.Write(1);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8, true))
                {
                    BitmapFontCommon.ReadBinary(binaryReader, out int _);
                }
            }
        }
    }
}