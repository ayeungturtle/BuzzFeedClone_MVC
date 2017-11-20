using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuzzFeedAndy.Models
{
    public class QuizTitle
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public QuizTitle QuizTitle { get; set; }
    }

    public class Answer
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public Question Question { get; set; }
    }

    public class QuizDbContext : DbContext
        {
            public DbSet<QuizTitle> QuizTitles { get; set; }
            public DbSet<Question> Questions { get; set; }
            public DbSet<Answer> Answers { get; set; }
        }
}