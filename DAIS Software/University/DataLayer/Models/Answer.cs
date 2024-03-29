﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answear { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; } = null!;
    }
}
