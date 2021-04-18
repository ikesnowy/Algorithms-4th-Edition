namespace _1._3._36
{
    /// <summary>
    /// 扑克牌类。
    /// </summary>
    class Card
    {
        readonly Suit suit;
        readonly int number;

        public Card(Suit suit, int number)
        {
            this.suit = suit;
            this.number = number;
        }

        public override string ToString()
        {
            string num;
            if (number == 1)
            {
                num = "Ace";
            }
            else if (number == 11)
            {
                num = "Jack";
            }
            else if (number == 12)
            {
                num = "Queen";
            }
            else if (number == 13)
            {
                num = "King";
            }
            else
            {
                num = number.ToString();
            }

            return num + " of the " + suit.ToString();
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
