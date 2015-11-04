using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BoardServiceTests
    {
        [TestMethod]
        public void BoardServiceEnsureICanCreateInstance()
        {
            var some_context = new Mock<BoardContext>();
            BoardService board = new BoardService(some_context.Object);
            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void BoardServiceEnsureICanAddAList()
        {
            var some_context = new Mock<BoardContext>();
            BoardService board_service = new BoardService(some_context.Object);
            BrelloList list = new BrelloList();
            Board board = new Board();
            bool actual = board_service.AddList(board, list);
            board_service.AddList(board, list);
            Assert.AreEqual(1, board_service.GetAllLists().Count);
        }

        [TestMethod]
        public void BoardServiceEnsureThereAreZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardService board_service = new BoardService(some_context.Object);
            int expected = 0;
            int actual = board_service.GetAllLists().Count;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, board_service.GetAllLists().Count);
        }
    }
}
