using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2._1._22
{
    public class Transaction : IComparable<Transaction>
    {
        public string Who { get; }
        public Date When { get; }
        public double Amount { get; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="transaction">用空格隔开的形如 “姓名 日期 金额” 的字符串。</param>
        public Transaction(string transaction)
        {
            var a = transaction.Split(' ');
            Who = a[0];
            When = new Date(a[1]);
            Amount = double.Parse(a[2]);
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="who">客户姓名。</param>
        /// <param name="when">交易日期。</param>
        /// <param name="amount">交易金额。</param>
        public Transaction(string who, Date when, double amount)
        {
            if (double.IsNaN(amount) || double.IsInfinity(amount))
            {
                throw new ArgumentException("Amount cannot be NaN or Infinity");
            }
            Who = who;
            When = when;
            Amount = amount;
        }

        /// <summary>
        /// 返回字符串形式的交易信息。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0, -10} {1, 10} {2, 8:F2}", Who, When, Amount);
        }

        /// <summary>
        /// 默认按照交易金额升序比较。
        /// </summary>
        /// <param name="other">比较的另一个对象。</param>
        /// <returns></returns>
        public int CompareTo(Transaction other)
        {
            if (Amount < other.Amount)
                return -1;
            if (Amount > other.Amount)
                return 1;
            return 0;
        }

        /// <summary>
        /// 按照客户姓名升序比较。
        /// </summary>
        public class WhoOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                Debug.Assert(x != null, nameof(x) + " != null");
                Debug.Assert(y != null, nameof(y) + " != null");
                return string.Compare(x.Who, y.Who, StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// 按照交易时间升序比较。
        /// </summary>
        public class WhenOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                Debug.Assert(x != null, nameof(x) + " != null");
                Debug.Assert(y != null, nameof(y) + " != null");
                return x.When.CompareTo(y.When);
            }
        }

        /// <summary>
        /// 按照交易金额升序比较。
        /// </summary>
        public class HowMuchOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                Debug.Assert(x != null, nameof(x) + " != null");
                Debug.Assert(y != null, nameof(y) + " != null");
                return x.Amount.CompareTo(y.Amount);
            }
        }

        /// <summary>
        /// 比较两笔交易是否相同。
        /// </summary>
        /// <param name="obj">另一个对象。</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            var that = (Transaction)obj;

            return
                (Math.Abs(that.Amount - Amount) < double.Epsilon * 5) &&
                (that.When.Equals(When)) &&
                (that.Who == Who);
        }

        /// <summary>
        /// 返回交易信息的哈希值。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hash = 31 + Who.GetHashCode();
            hash = 31 * hash + When.GetHashCode();
            hash = 31 * hash + Amount.GetHashCode();
            return hash;
        }
    }
}
