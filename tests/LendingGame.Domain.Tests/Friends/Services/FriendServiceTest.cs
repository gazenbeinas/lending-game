using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Friends.Services.Implementations;
using Moq;
using NUnit.Framework;

namespace LendingGame.Domain.Tests.Friends.Services
{
    [TestFixture]
    public class FriendServiceTest
    {
        Mock<IUpdatableRepository<Friend>> _updatableRepositoryMock;
        Mock<IDeletable<Friend>> _deleteMock;
        Mock<IFindableId<Friend>> _findableIdMock;
        Mock<ILoadAll<Friend>> _loadAllMock;
        Mock<ICreatable<Friend>> _createMock;

        FriendService _friendService;
        Friend _testingFriend;

        [SetUp]
        public void SetUp()
        {
            _testingFriend = new Friend(
                "123", "Name", "email@domain.com");

            InializeMocks();

            _friendService = new FriendService(
                _updatableRepositoryMock.Object,
                _deleteMock.Object,
                _findableIdMock.Object,
                _loadAllMock.Object,
                _createMock.Object);
        }

        [Test]
        public void Create_CallsMock_ReturnsFriend()
        {
            _createMock.Setup(x => x.Create(It.IsAny<Friend>()))
                .Returns((Friend f) => f);

            var actualFriend = _friendService.Create(_testingFriend);

            _createMock.Verify(x => x.Create(_testingFriend),
                Times.Once);

            Assert.AreEqual(_testingFriend, actualFriend);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Delete_CallsMock_Returns(bool mockReturn)
        {
            _deleteMock.Setup(x => x.Delete(_testingFriend.Id))
                .Returns(mockReturn);

            var actualReturn = _friendService.Delete(
                _testingFriend.Id);

            _deleteMock.Verify(x => x.Delete(_testingFriend.Id),
                Times.Once);

            Assert.AreEqual(mockReturn, actualReturn);
        }

        [Test]
        public void FindById_CallsMock_ReturnsFriend()
        {
            _findableIdMock.Setup(x => x.FindById(_testingFriend.Id))
                .Returns(_testingFriend);

            var actualFriend = _friendService.FindById(_testingFriend.Id);

            _findableIdMock.Verify(x =>
                x.FindById(_testingFriend.Id), Times.Once);

            Assert.AreEqual(_testingFriend, actualFriend);
        }

        void InializeMocks()
        {
            _updatableRepositoryMock = new Mock<IUpdatableRepository<Friend>>();
            _deleteMock = new Mock<IDeletable<Friend>>();
            _findableIdMock = new Mock<IFindableId<Friend>>();
            _loadAllMock = new Mock<ILoadAll<Friend>>();
            _createMock = new Mock<ICreatable<Friend>>();
        }
    }
}
