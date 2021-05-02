using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Commercial
{
    /// <summary>
    /// 交易记录类。
    /// </summary>
    public class Transaction : IComparable<Transaction>
    {
        /// <summary>
        /// 客户姓名。
        /// </summary>
        /// <value>客户姓名。</value>
        public string Who { get; }
        /// <summary>
        /// 交易日期。
        /// </summary>
        /// <value>交易日期。</value>
        /// <seealso cref="Date"/>
        public Date When { get; }
        /// <summary>
        /// 交易金额。
        /// </summary>
        /// <value>交易金额。</value>
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
            /// <summary>
            /// 比较两个 <see cref="Transaction"/> 的姓名。
            /// </summary>
            /// <param name="x">需要比较的第一个记录。</param>
            /// <param name="y">需要比较的第二个记录。</param>
            /// <returns><paramref name="x"/> 姓名靠后时返回大于 0 的数，反之返回小于 0 的数，相等返回 0。</returns>
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                return string.Compare(x?.Who, y?.Who, StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// 按照交易时间升序比较。
        /// </summary>
        public class WhenOrder : IComparer<Transaction>
        {
            /// <summary>
            /// 比较两个 <see cref="Transaction"/> 的交易时间。
            /// </summary>
            /// <param name="x">需要比较的第一个记录。</param>
            /// <param name="y">需要比较的第二个记录。</param>
            /// <returns><paramref name="x"/> 时间靠后时返回大于 0 的数，反之返回小于 0 的数，相等返回 0。</returns>
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
            /// <summary>
            /// 比较两个 <see cref="Transaction"/> 的交易金额。
            /// </summary>
            /// <param name="x">需要比较的第一个记录。</param>
            /// <param name="y">需要比较的第二个记录。</param>
            /// <returns><paramref name="x"/> 金额较大时返回大于 0 的数，反之返回小于 0 的数，相等返回 0。</returns>
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
                Math.Abs(that.Amount - Amount) < float.Epsilon * 5 &&
                that.When.Equals(When) &&
                that.Who == Who;
        }

        /// <summary>
        /// 返回交易信息的哈希值。
        /// </summary>
        /// <returns>交易信息的哈希值。</returns>
        public override int GetHashCode()
        {
            var hash = 31 * + Who.GetHashCode();
            hash = 31 * hash + When.GetHashCode();
            hash = 31 * hash + Amount.GetHashCode();
            return hash;
        }
    }
}
