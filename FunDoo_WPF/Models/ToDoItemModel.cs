﻿namespace FunDoo_WPF.Models
{
    public class ToDoItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Boolean IsCompleted { get; set; }

    }
}
