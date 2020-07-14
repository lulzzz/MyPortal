﻿using System;
using System.ComponentModel.DataAnnotations;
using MyPortal.Logic.Models.ListModels;

namespace MyPortal.Logic.Models.Entity
{
    public class DocumentModel
    {
        public Guid Id { get; set; }

        public Guid TypeId { get; set; }

        public Guid DirectoryId { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public string FileId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Public { get; set; }

        public bool Approved { get; set; }

        public bool Deleted { get; set; }

        public virtual UserModel CreatedBy { get; set; }

        public virtual DirectoryModel Directory { get; set; }

        public virtual DocumentTypeModel Type { get; set; }

        public virtual HomeworkSubmissionModel HomeworkSubmission { get; set; }

        public DirectoryChildListModel GetListModel()
        {
            return new DirectoryChildListModel(this);
        }
    }
}