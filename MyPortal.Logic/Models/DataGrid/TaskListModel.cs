﻿using System;
using MyPortal.Logic.Models.Entity;

namespace MyPortal.Logic.Models.DataGrid
{
    public class TaskListModel
    {
        public Guid Id { get; set; }
        public DateTime? DueDate { get; set; }
        public string AssignedByName { get; set; }
        public string TaskTypeName { get; set; }
        public string TaskTypeColourCode { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public bool CanEdit { get; set; }

        public TaskListModel(TaskModel model, bool editPersonalOnly)
        {
            Id = model.Id;
            DueDate = model.DueDate;
            AssignedByName = model.AssignedBy.GetDisplayName(true);
            TaskTypeName = model.Type?.Description;
            TaskTypeColourCode = model.Type?.ColourCode;
            Title = model.Title;
            Completed = model.Completed;

            if (model.Type != null)
            {
                CanEdit = !model.Type.Reserved && (!editPersonalOnly || model.Type.Personal);
            }
        }

        public bool Overdue
        {
            get { return !Completed && DueDate <= DateTime.Today; }
        }
    }
}
