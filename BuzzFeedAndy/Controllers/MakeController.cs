using BuzzFeedAndy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuzzFeedAndy.Controllers
{
    public class MakeController : Controller
    {
        QuizDbContext connection = new QuizDbContext();

        public class Data
        {
            public int currentQuizTitleID { get; set; }
            public int currentQuestionID { get; set; }
        }

        [HttpGet]
        public ActionResult AddQuizTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmQuizTitle(string title)
        {
            QuizTitle tempQuizTitle = new QuizTitle();
            tempQuizTitle.Title = title;
            connection.QuizTitles.Add(tempQuizTitle);
            connection.SaveChanges();
            return RedirectToAction("AddQuestion", new { currentQuizTitleID= tempQuizTitle.ID });
        }

        [HttpGet]
        public ActionResult AddQuestion(int currentQuizTitleID)
        {
            //list all questions
            return View(currentQuizTitleID);
        }

        [HttpPost]
        public ActionResult ConfirmQuestion(string question, int currentQuizTitleID)
        {
            QuizTitle currentQuizTitle = connection.QuizTitles.Find(currentQuizTitleID);
            Question tempQuestion = new Question() {QuizTitle = currentQuizTitle };
            tempQuestion.QuestionText = question;
            connection.Questions.Add(tempQuestion);
            connection.SaveChanges();
            Data IDHolder = new Data();
            IDHolder.currentQuizTitleID = currentQuizTitleID;
            IDHolder.currentQuestionID = tempQuestion.ID;
            TempData["IDHolder"] = IDHolder;
            return RedirectToAction("AddAnswer");
        }

        [HttpGet]
        public ActionResult AddAnswer()
        {
            //list all answers
            Data IDHolder = (Data)TempData["IDHolder"];
            return View(IDHolder);
        }

        [HttpPost]
        public ActionResult ConfirmAnswer(string answer, Data IDHolder)
        {
            int currentQuestionID = IDHolder.currentQuestionID;
            Question currentQuestion = connection.Questions.Find(currentQuestionID);
            Answer tempAnswer = new Answer() {Question = currentQuestion};
            tempAnswer.AnswerText = answer;
            connection.Answers.Add(tempAnswer);
            connection.SaveChanges();
            return RedirectToAction("AddAnswer");  //don't need to update TempData becuase IDHolder hasn't changed
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

    }
}