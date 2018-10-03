using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Inheritance.DataStructure
{
    /// <summary>
    /// Класс сообщений, содержит текст сообщения, тему и тип
    /// </summary>
    public class Category : IComparable
    {
        public string MessageText { get; set; }
        public MessageType MessageType { get; set; }
        public MessageTopic MessageTopic { get; set; }

        public Category(string msg, MessageType msgType, MessageTopic msgTopic)
        {
            this.MessageText = msg;
            this.MessageType = msgType;
            this.MessageTopic = msgTopic;
        }

        /// <summary>
        /// Выполняет сравнение сначала по тексту сообщения, потом по типу, потом по теме
        /// Позволяет сравнивать так же null - объекты и объекты, содержащие null - поля
        /// </summary>
        public int CompareTo(object obj)
        {
            if ((object)this == null && obj == null)
                return 0;
            if (obj == null)
                return 1;
            if (!(obj is Category))
                throw new ArgumentException();
            if ((object)this == null)
                return -1;
            sbyte compareResult = 0;
            if ((MessageText == null) != (((Category)obj).MessageText == null))
                return ((Category)obj).MessageText == null ? 1 : -1;
            else if (MessageText != null)
                compareResult = (sbyte)MessageText.CompareTo(((Category)obj).MessageText);
            if (compareResult != 0)
                return compareResult;
            else
            {
                compareResult = (sbyte)MessageType.CompareTo(((Category)obj).MessageType);
                if (compareResult != 0)
                    return compareResult;
                else
                    return MessageTopic.CompareTo(((Category)obj).MessageTopic);
            }
        }

        public static bool operator <(Category a, Category b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator >(Category a, Category b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator !=(Category a, Category b)
        {
            return !a.Equals(b);
        }
        public static bool operator ==(Category a, Category b)
        {
            return a.Equals(b);
        }
        public static bool operator >=(Category a, Category b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator <=(Category a, Category b)
        {
            return a.CompareTo(b) <= 0;
        }

        public override int GetHashCode()
        {
            // тесты прошло, а как известно:
            // работает - не трогай
            return base.GetHashCode(); 
        }

        public override bool Equals(object obj)
        {
            if ((object)this == null && obj == null)
                return true;
            if (!(obj is Category))
                return false;
            return MessageText == ((Category)obj).MessageText &&
                MessageTopic == ((Category)obj).MessageTopic &&
                MessageType == ((Category)obj).MessageType;
        }

        public override string ToString()
        {
            return $"{MessageText}.{MessageType}.{MessageTopic}";
        }
    }
}