using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
    class ReadonlyBytes : IEnumerable
    {
        byte[] Bytes { get; set; }
        public int Length { get { return Bytes.Length; } }
        int hash = -1;

        public override int GetHashCode()
        {
            if (hash == -1) hash = Convert.ToBase64String(Bytes).GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            return (this.GetHashCode() == obj.GetHashCode());
        }

        public override string ToString()
        {
            return '[' + string.Join(", ", Bytes) + ']';
        }

        public ReadonlyBytes(params byte[] bytes)
        {
            Bytes = bytes ?? throw new ArgumentNullException();
        }

        public byte this[int index]
        {
            get { return Bytes[index]; }
            set { Bytes[index] = value; }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return Bytes[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    // TODO: Создайте класс ReadonlyBytes
}