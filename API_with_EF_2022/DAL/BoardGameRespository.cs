using API_with_EF_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace API_with_EF_2022.DAL
{
    public class BoardGameRepository
    {
        private GameContext _dbContext = new GameContext();

        public BoardGame AddBoardGame(BoardGame game)
        {
            _dbContext.BoardGames.Add(game);
            _dbContext.SaveChanges();
            return GetLatestBoardGame();
        }

        public List<BoardGame> GetAllGames()
        {
            return _dbContext.BoardGames.ToList();
        }


        private BoardGame GetLatestBoardGame()
        {
            return _dbContext.BoardGames.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public BoardGame FindById(int id)
        {
            // AsNoTracking will not lock the ID allowing updating it after finding it
            return _dbContext.BoardGames.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteById(int id)
        {
            BoardGame boardGame = FindById(id);
            if (boardGame == null)
            {
                return false;
            }
            _dbContext.BoardGames.Remove(boardGame);
            _dbContext.SaveChanges();
            return true;
        }


    }
}
