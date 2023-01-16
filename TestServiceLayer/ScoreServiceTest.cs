using System.ComponentModel.DataAnnotations;
using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

[TestClass]
public class ScoreServiceTest
{
    private Score score;

    private Score nullScore = null;

    private ScoreDto scoreDto;

    private ScoreDto notFoundScoreDto;

    private User reviewerUser;

    private User receiverUser;

    private IScoreService scoreService;

    private Mock<IScoreDataServices> scoreDataServicesMock;

    private Mock<ILogger<ScoreServiceImpl>> loggerMock;

    private MyConfiguration myConfiguration;

    private Mock<IUserDataServices> userDataServicesMock;

    [TestInitialize]
    public void Setup()
    {
        receiverUser = new User
        {
            Id = 1
        };

        reviewerUser = new User
        {
            Id = 2
        };

        score = new Score
        {
            Id = 1,
            Receiver = receiverUser,
            Reviewer = reviewerUser,
            ReceiverId = receiverUser.Id,
            ReviewerId = reviewerUser.Id,
            Value = 10
        };


        scoreDto = new ScoreDto(score);

        notFoundScoreDto = new ScoreDto
        {
            Id = int.MaxValue,
            ReceiverId = int.MaxValue,
            ReviewerId = int.MaxValue,
            Value = 10
        };

        scoreDataServicesMock = new Mock<IScoreDataServices>();
        loggerMock = new Mock<ILogger<ScoreServiceImpl>>();
        myConfiguration = new MyConfiguration
        {
            K = 5,
            P = 5,
            S = 5,
            Z = 5
        };
        userDataServicesMock = new Mock<IUserDataServices>();

        scoreService = new ScoreServiceImpl(
            scoreDataServicesMock.Object,
            loggerMock.Object,
            userDataServicesMock.Object,
            new ScoreDtoValidator(),
            Options.Create(myConfiguration));
    }

    [TestMethod]
    public void TestScoreGetAll()
    {
        scoreDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Score> { score });
        var result = scoreService.GetAll();

        CollectionAssert.AreEquivalent(new List<ScoreDto> { scoreDto }, result.ToList());
    }

    [TestMethod]
    public void TestScoreGetByIdValid()
    {
        scoreDataServicesMock.Setup(x => x.GetById(score.Id)).Returns(score);
        var result = scoreService.GetById(scoreDto.Id);

        Assert.AreEqual(scoreDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreGetByIdNotFound()
    {
        scoreDataServicesMock.Setup(x => x.GetById(notFoundScoreDto.Id)).Returns(nullScore);
        scoreService.GetById(notFoundScoreDto.Id);
    }

    [TestMethod]
    public void TestScoreInsertValid()
    {
        scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(score);
        userDataServicesMock.Setup(x => x.GetById(score.ReceiverId)).Returns(score.Receiver);
        userDataServicesMock.Setup(x => x.GetById(score.ReviewerId)).Returns(score.Reviewer);
        var result = scoreService.Insert(scoreDto);

        Assert.AreEqual(scoreDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestScoreInsertNotFoundReceiver()
    {
        scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(score);
        userDataServicesMock.Setup(x => x.GetById(score.ReceiverId)).Returns((User)null);
        userDataServicesMock.Setup(x => x.GetById(score.ReviewerId)).Returns(score.Reviewer);

        scoreService.Insert(scoreDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestScoreInsertNotFoundReviewer()
    {
        scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(score);
        userDataServicesMock.Setup(x => x.GetById(score.ReceiverId)).Returns(score.Receiver);
        userDataServicesMock.Setup(x => x.GetById(score.ReviewerId)).Returns((User)null);

        scoreService.Insert(scoreDto);
    }

    [TestMethod]
    [ExpectedException(typeof(FluentValidation.ValidationException))]
    public void TestScoreUpdateInvalid()
    {
        scoreService.Update(new ScoreDto());
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreUpdateNotFound()
    {
        scoreService.Update(notFoundScoreDto);
    }

    [TestMethod]
    public void TestScoreUpdateValid()
    {
        scoreDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(score);
        scoreDataServicesMock.Setup(x => x.Update(It.IsAny<Score>())).Returns(score);

        var result = scoreService.Update(scoreDto);

        Assert.AreEqual(scoreDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreDeleteNotFound()
    {
        scoreService.DeleteById(notFoundScoreDto.Id);
    }

    [TestMethod]
    public void TestScoreDeleteValid()
    {
        scoreDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(score);
        scoreService.DeleteById(scoreDto.Id);

        Assert.IsTrue(true);
    }

    [TestMethod]
    public void TestScoreGetUserScoreDefault()
    {
        scoreDataServicesMock.Setup(x => x.GetUserScore(It.IsAny<int>())).Returns(-1);
        var result = scoreService.GetUserScore(scoreDto.ReceiverId);

        Assert.AreEqual(result, myConfiguration.S);
    }

    [TestMethod]
    public void TestScoreGetUserScore()
    {
        scoreDataServicesMock.Setup(x => x.GetUserScore(It.IsAny<int>())).Returns(10);
        var result = scoreService.GetUserScore(scoreDto.ReceiverId);

        Assert.AreEqual(result, 10);
    }
}