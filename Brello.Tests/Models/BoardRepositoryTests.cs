using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BoardRepositoryTests
    {
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
        [TestClass]
        public class BoardRepositoryCanGetABoard()
        {

        }
        [TestMethod]
        public void BoardRepositoryCanCreateBoard()
        {
        var mock_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            string title = "My Awesome Board";
            ApplicationUser owner = new ApplicationUser();
           
            Board added_board = board_repo.CreateBoard(title ,owner);
            Assert.IsNotNull(added_board);
            Assert.IsTrue(added_board.BoardId > 0);
        }
    }
}
