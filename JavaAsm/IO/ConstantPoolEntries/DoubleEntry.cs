﻿using System;
using System.IO;
using BinaryEncoding;

namespace JavaAsm.IO.ConstantPoolEntries
{
    internal class DoubleEntry : Entry
    {
        public double Value { get; }

        public DoubleEntry(double value)
        {
            Value = value;
        }

        public DoubleEntry(Stream stream)
        {
            Value = BitConverter.Int64BitsToDouble(Binary.BigEndian.ReadInt64(stream));
        }

        public override EntryTag Tag => EntryTag.Double;

        public override void ProcessFromConstantPool(ConstantPool constantPool) { }

        public override void Write(Stream stream)
        {
            Binary.BigEndian.Write(stream, BitConverter.DoubleToInt64Bits(Value));
        }

        public override void PutToConstantPool(ConstantPool constantPool) { }

        private bool Equals(DoubleEntry other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((DoubleEntry)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}