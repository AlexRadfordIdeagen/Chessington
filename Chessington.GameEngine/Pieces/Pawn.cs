using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            switch (Player)
            {
                case Player.Black when myLocation.Row != 1:
                    legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col));
                    break;
                case Player.Black when myLocation.Row == 1:
                    legalMoves.Add(new Square(myLocation.Row + 2, myLocation.Col));
                    break;
                case Player.White when myLocation.Row != 7:
                    legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col));
                    break;
                case Player.White when myLocation.Row == 7:
                    legalMoves.Add(new Square(myLocation.Row - 2, myLocation.Col));
                    break;
            }


            return legalMoves;

        }
    }
}