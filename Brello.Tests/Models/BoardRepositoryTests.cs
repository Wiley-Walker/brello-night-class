using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
 

namespace Brello.Tests.Models 
{
    [TestClass]
    public class BoardRepositoryTests
    {
        private Mock<BoardContext> mock_context;

        [TestMethod]
        public void Cleanup()
        {
            mock_context = null;
        }
        [TestMethod]
        public void BoardRepositoryICanCreateInstance()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_rep = new BoardRepository(some_context.Object);
            BrelloList list = new BrelloList();
            Board board = new Board();
            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void BoardRepositoryEnsureICanAddAList()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            BrelloList list = new BrelloList();
            Board board = new Board();
            bool actual = board_repo.AddList(board, list);
            board_repo.AddList(board, list);
            Assert.AreEqual(1, board_repo.GetAllLists().Count);
        }

        [TestMethod]
        public void BoardRepositoryEnsureThereAreZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            Board board = new Board();
            int expected = 0;
            int actual = board_repo.GetAllLists().Count;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, board_repo.GetAllLists(board));
        }
        [TestMethod]
        public void BoardRepositoryEnsureABoardHasZeroLists()
        {
        var some_context = new Mock<BoardContext>();
        BoardRepository board_repo = new BoardRepository(some_context.Object);
        Board board = new Board();
        int expected = 0;
        Assert.AreEqual(expected, board_repo.GetAllLists(board).Count);
        }
        [TestMethod]
        public void BoardRepositoryCanGetABoard()
        {
        
        }
        [TestMethod]
        public void BoardRepositoryCanCreateBoard()
        {
             
            var mock_boards = new Mock<DbSet<Board>>();
            var data = mock_boards.Object.AsQueryable();
            mock_context.Setup(m => m.Boards).Returns(mock_boards.Object);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.Expression).Returns(data.Expression);
            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            string title = "My Awesome Board";
            ApplicationUser owner = new ApplicationUser();
           
            Board added_board = board_repo.CreateBoard(title ,owner);
            Assert.IsNotNull(added_board);
            mock_boards.Verify(m => m.Add(It.IsAny<Board>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.IsTrue(added_board.BoardId > 0);
        }
        [TestMethod]
        public void BoardRepositoryEnsureICanGetAllBoards()
        {
            var mock_context = new Mock<BoardContext>();
            var mock_boards = new Mock<DbSet<Board>>();
            mock_context.Setup(m => m.Boards).Returns(mock_boards.Object);
            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            ApplicationUser owner = new ApplicationUser();

            Board added_board = board_repo.CreateBoard(title, owner); 
            //board_repo.CreateBoard("My Awesome Board", owner);
            //board_repo.CreateBoard("My Other Awesome Board", owner);
            var data = new List<Board> {
                new Board {Title = "My Board", Owner = owner }
            }.AsQueryable();
            mock_boards.As<IQueryable<Board>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.Expression).Returns(data.Expression);

            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            List<Board> boards = board_repo.GetAllBoards();
            Assert.AreEqual(2, boards.Count);
        }
    }
}
