namespace _1._3._35
{
    /// <summary>
    /// 扑克牌类。
    /// </summary>
    class Card
    {
        readonly Suit _suit;
        readonly int _number;

        public Card(Suit suit, int number)
        {
            _suit = suit;
            _number = number;
        }

        public override string ToString()
        {
            string num;
            if (_number == 1)
            {
                num = "Ace";
            }
            else if (_number == 11)
            {
                num = "Jack";
            }
            else if (_number == 12)
            {
                num = "Queen";
            }
            else if (_number == 13)
            {
                num = "King";
            }
            else
            {
                num = _number.ToString();
            }

            return num + " of the " + _suit.ToString();
        }
    }

    enum Suit
    {
        Clubs = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3
    };
}
