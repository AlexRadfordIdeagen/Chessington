using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col + 1));
            legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col - 1));
            legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col + 1));
            legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col - 1));
            legalMoves.Add(new Square(myLocation.Row, myLocation.Col - 1));
            legalMoves.Add(new Square(myLocation.Row, myLocation.Col + 1));
            legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col));
            legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col));


            foreach (var item in legalMoves)
            {
                if (item.Col < 0)
                {
                    legalMoves.Remove(item);
                }
                if (item.Col > 7)
                {
                    legalMoves.Remove(item);
                }
                if (item.Row < 0)
                {
                    legalMoves.Remove(item);
                }
                if (item.Row > 7)
                {
                    legalMoves.Remove(item);
                }
            }

            return legalMoves;
        }
    }
}