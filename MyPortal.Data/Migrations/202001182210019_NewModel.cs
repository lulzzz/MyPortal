﻿namespace MyPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "attendance.Mark", newName: "AttendanceMark");
            RenameTable(name: "attendance.Period", newName: "AttendancePeriod");
            RenameTable(name: "attendance.Week", newName: "AttendanceWeek");
            RenameTable(name: "medical.Event", newName: "MedicalEvent");
            RenameTable(name: "medical.Condition", newName: "MedicalCondition");
            RenameTable(name: "school.Type", newName: "SchoolType");
            RenameTable(name: "profile.LogNote", newName: "ProfileLogNote");
            RenameTable(name: "profile.LogNoteType", newName: "ProfileLogNoteType");
            RenameTable(name: "sen.Event", newName: "SenEvent");
            RenameTable(name: "sen.EventType", newName: "SenEventType");
            RenameTable(name: "sen.Provision", newName: "SenProvision");
            RenameTable(name: "sen.ProvisionType", newName: "SenProvisionType");
            RenameTable(name: "sen.Status", newName: "SenStatus");
            RenameTable(name: "attendance.CodeMeaning", newName: "AttendanceCodeMeaning");
            RenameTable(name: "attendance.Code", newName: "AttendanceCode");
            RenameTable(name: "communication.Log", newName: "CommunicationLog");
            RenameTable(name: "system.Area", newName: "SystemArea");
            RenameTable(name: "sen.ReviewType", newName: "SenReviewType");
            MoveTable(name: "curriculum.AcademicYear", newSchema: "dbo");
            MoveTable(name: "behaviour.Achievement", newSchema: "dbo");
            MoveTable(name: "school.Location", newSchema: "dbo");
            MoveTable(name: "behaviour.Incident", newSchema: "dbo");
            MoveTable(name: "behaviour.IncidentDetention", newSchema: "dbo");
            MoveTable(name: "behaviour.DetentionAttendanceStatus", newSchema: "dbo");
            MoveTable(name: "behaviour.Detention", newSchema: "dbo");
            MoveTable(name: "system.DiaryEvent", newSchema: "dbo");
            MoveTable(name: "person.StaffMember", newSchema: "dbo");
            MoveTable(name: "system.Bulletin", newSchema: "dbo");
            MoveTable(name: "curriculum.Class", newSchema: "dbo");
            MoveTable(name: "curriculum.Enrolment", newSchema: "dbo");
            MoveTable(name: "person.Student", newSchema: "dbo");
            MoveTable(name: "attendance.AttendanceMark", newSchema: "dbo");
            MoveTable(name: "attendance.AttendancePeriod", newSchema: "dbo");
            MoveTable(name: "curriculum.Session", newSchema: "dbo");
            MoveTable(name: "attendance.AttendanceWeek", newSchema: "dbo");
            MoveTable(name: "finance.BasketItem", newSchema: "dbo");
            MoveTable(name: "finance.Product", newSchema: "dbo");
            MoveTable(name: "finance.Sale", newSchema: "dbo");
            MoveTable(name: "finance.ProductType", newSchema: "dbo");
            MoveTable(name: "sen.GiftedTalented", newSchema: "dbo");
            MoveTable(name: "curriculum.Subject", newSchema: "dbo");
            MoveTable(name: "curriculum.SubjectStaffMember", newSchema: "dbo");
            MoveTable(name: "curriculum.SubjectStaffMemberRole", newSchema: "dbo");
            MoveTable(name: "curriculum.StudyTopic", newSchema: "dbo");
            MoveTable(name: "curriculum.LessonPlan", newSchema: "dbo");
            MoveTable(name: "pastoral.YearGroup", newSchema: "dbo");
            MoveTable(name: "pastoral.RegGroup", newSchema: "dbo");
            MoveTable(name: "pastoral.House", newSchema: "dbo");
            MoveTable(name: "medical.MedicalEvent", newSchema: "dbo");
            MoveTable(name: "person.Person", newSchema: "dbo");
            MoveTable(name: "communication.AddressPerson", newSchema: "dbo");
            MoveTable(name: "communication.Address", newSchema: "dbo");
            MoveTable(name: "person.Contact", newSchema: "dbo");
            MoveTable(name: "person.StudentContact", newSchema: "dbo");
            MoveTable(name: "medical.PersonDietaryRequirement", newSchema: "dbo");
            MoveTable(name: "medical.DietaryRequirement", newSchema: "dbo");
            MoveTable(name: "communication.EmailAddress", newSchema: "dbo");
            MoveTable(name: "communication.EmailAddressType", newSchema: "dbo");
            MoveTable(name: "medical.PersonCondition", newSchema: "dbo");
            MoveTable(name: "medical.MedicalCondition", newSchema: "dbo");
            MoveTable(name: "document.PersonAttachment", newSchema: "dbo");
            MoveTable(name: "document.Document", newSchema: "dbo");
            MoveTable(name: "document.DocumentType", newSchema: "dbo");
            MoveTable(name: "communication.PhoneNumber", newSchema: "dbo");
            MoveTable(name: "communication.PhoneNumberType", newSchema: "dbo");
            MoveTable(name: "school.School", newSchema: "dbo");
            MoveTable(name: "school.GovernanceType", newSchema: "dbo");
            MoveTable(name: "school.IntakeType", newSchema: "dbo");
            MoveTable(name: "school.LocalAuthority", newSchema: "dbo");
            MoveTable(name: "school.Phase", newSchema: "dbo");
            MoveTable(name: "school.SchoolType", newSchema: "dbo");
            MoveTable(name: "profile.ProfileLogNote", newSchema: "dbo");
            MoveTable(name: "profile.ProfileLogNoteType", newSchema: "dbo");
            MoveTable(name: "assessment.Result", newSchema: "dbo");
            MoveTable(name: "assessment.Aspect", newSchema: "dbo");
            MoveTable(name: "assessment.GradeSet", newSchema: "dbo");
            MoveTable(name: "assessment.Grade", newSchema: "dbo");
            MoveTable(name: "assessment.AspectType", newSchema: "dbo");
            MoveTable(name: "assessment.ResultSet", newSchema: "dbo");
            MoveTable(name: "sen.SenEvent", newSchema: "dbo");
            MoveTable(name: "sen.SenEventType", newSchema: "dbo");
            MoveTable(name: "sen.SenProvision", newSchema: "dbo");
            MoveTable(name: "sen.SenProvisionType", newSchema: "dbo");
            MoveTable(name: "sen.SenStatus", newSchema: "dbo");
            MoveTable(name: "personnel.Observation", newSchema: "dbo");
            MoveTable(name: "personnel.ObservationOutcome", newSchema: "dbo");
            MoveTable(name: "personnel.TrainingCertificate", newSchema: "dbo");
            MoveTable(name: "personnel.TrainingCertificateStatus", newSchema: "dbo");
            MoveTable(name: "personnel.TrainingCourse", newSchema: "dbo");
            MoveTable(name: "behaviour.DetentionType", newSchema: "dbo");
            MoveTable(name: "behaviour.IncidentType", newSchema: "dbo");
            MoveTable(name: "behaviour.AchievementType", newSchema: "dbo");
            MoveTable(name: "attendance.AttendanceCodeMeaning", newSchema: "dbo");
            MoveTable(name: "attendance.AttendanceCode", newSchema: "dbo");
            MoveTable(name: "profile.CommentBank", newSchema: "dbo");
            MoveTable(name: "profile.Comment", newSchema: "dbo");
            MoveTable(name: "communication.CommunicationLog", newSchema: "dbo");
            MoveTable(name: "communication.CommunicationType", newSchema: "dbo");
            MoveTable(name: "curriculum.LessonPlanTemplate", newSchema: "dbo");
            MoveTable(name: "person.RelationshipType", newSchema: "dbo");
            MoveTable(name: "system.Report", newSchema: "dbo");
            MoveTable(name: "system.SystemArea", newSchema: "dbo");
            MoveTable(name: "sen.SenReviewType", newSchema: "dbo");
            AddColumn("dbo.StudentContact", "RelationshipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentContact", "RelationshipTypeId");
            AddForeignKey("dbo.StudentContact", "RelationshipTypeId", "dbo.RelationshipType", "Id");
            DropColumn("dbo.StudentContact", "ContactTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentContact", "ContactTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentContact", "RelationshipTypeId", "dbo.RelationshipType");
            DropIndex("dbo.StudentContact", new[] { "RelationshipTypeId" });
            DropColumn("dbo.StudentContact", "RelationshipTypeId");
            MoveTable(name: "dbo.SenReviewType", newSchema: "sen");
            MoveTable(name: "dbo.SystemArea", newSchema: "system");
            MoveTable(name: "dbo.Report", newSchema: "system");
            MoveTable(name: "dbo.RelationshipType", newSchema: "person");
            MoveTable(name: "dbo.LessonPlanTemplate", newSchema: "curriculum");
            MoveTable(name: "dbo.CommunicationType", newSchema: "communication");
            MoveTable(name: "dbo.CommunicationLog", newSchema: "communication");
            MoveTable(name: "dbo.Comment", newSchema: "profile");
            MoveTable(name: "dbo.CommentBank", newSchema: "profile");
            MoveTable(name: "dbo.AttendanceCode", newSchema: "attendance");
            MoveTable(name: "dbo.AttendanceCodeMeaning", newSchema: "attendance");
            MoveTable(name: "dbo.AchievementType", newSchema: "behaviour");
            MoveTable(name: "dbo.IncidentType", newSchema: "behaviour");
            MoveTable(name: "dbo.DetentionType", newSchema: "behaviour");
            MoveTable(name: "dbo.TrainingCourse", newSchema: "personnel");
            MoveTable(name: "dbo.TrainingCertificateStatus", newSchema: "personnel");
            MoveTable(name: "dbo.TrainingCertificate", newSchema: "personnel");
            MoveTable(name: "dbo.ObservationOutcome", newSchema: "personnel");
            MoveTable(name: "dbo.Observation", newSchema: "personnel");
            MoveTable(name: "dbo.SenStatus", newSchema: "sen");
            MoveTable(name: "dbo.SenProvisionType", newSchema: "sen");
            MoveTable(name: "dbo.SenProvision", newSchema: "sen");
            MoveTable(name: "dbo.SenEventType", newSchema: "sen");
            MoveTable(name: "dbo.SenEvent", newSchema: "sen");
            MoveTable(name: "dbo.ResultSet", newSchema: "assessment");
            MoveTable(name: "dbo.AspectType", newSchema: "assessment");
            MoveTable(name: "dbo.Grade", newSchema: "assessment");
            MoveTable(name: "dbo.GradeSet", newSchema: "assessment");
            MoveTable(name: "dbo.Aspect", newSchema: "assessment");
            MoveTable(name: "dbo.Result", newSchema: "assessment");
            MoveTable(name: "dbo.ProfileLogNoteType", newSchema: "profile");
            MoveTable(name: "dbo.ProfileLogNote", newSchema: "profile");
            MoveTable(name: "dbo.SchoolType", newSchema: "school");
            MoveTable(name: "dbo.Phase", newSchema: "school");
            MoveTable(name: "dbo.LocalAuthority", newSchema: "school");
            MoveTable(name: "dbo.IntakeType", newSchema: "school");
            MoveTable(name: "dbo.GovernanceType", newSchema: "school");
            MoveTable(name: "dbo.School", newSchema: "school");
            MoveTable(name: "dbo.PhoneNumberType", newSchema: "communication");
            MoveTable(name: "dbo.PhoneNumber", newSchema: "communication");
            MoveTable(name: "dbo.DocumentType", newSchema: "document");
            MoveTable(name: "dbo.Document", newSchema: "document");
            MoveTable(name: "dbo.PersonAttachment", newSchema: "document");
            MoveTable(name: "dbo.MedicalCondition", newSchema: "medical");
            MoveTable(name: "dbo.PersonCondition", newSchema: "medical");
            MoveTable(name: "dbo.EmailAddressType", newSchema: "communication");
            MoveTable(name: "dbo.EmailAddress", newSchema: "communication");
            MoveTable(name: "dbo.DietaryRequirement", newSchema: "medical");
            MoveTable(name: "dbo.PersonDietaryRequirement", newSchema: "medical");
            MoveTable(name: "dbo.StudentContact", newSchema: "person");
            MoveTable(name: "dbo.Contact", newSchema: "person");
            MoveTable(name: "dbo.Address", newSchema: "communication");
            MoveTable(name: "dbo.AddressPerson", newSchema: "communication");
            MoveTable(name: "dbo.Person", newSchema: "person");
            MoveTable(name: "dbo.MedicalEvent", newSchema: "medical");
            MoveTable(name: "dbo.House", newSchema: "pastoral");
            MoveTable(name: "dbo.RegGroup", newSchema: "pastoral");
            MoveTable(name: "dbo.YearGroup", newSchema: "pastoral");
            MoveTable(name: "dbo.LessonPlan", newSchema: "curriculum");
            MoveTable(name: "dbo.StudyTopic", newSchema: "curriculum");
            MoveTable(name: "dbo.SubjectStaffMemberRole", newSchema: "curriculum");
            MoveTable(name: "dbo.SubjectStaffMember", newSchema: "curriculum");
            MoveTable(name: "dbo.Subject", newSchema: "curriculum");
            MoveTable(name: "dbo.GiftedTalented", newSchema: "sen");
            MoveTable(name: "dbo.ProductType", newSchema: "finance");
            MoveTable(name: "dbo.Sale", newSchema: "finance");
            MoveTable(name: "dbo.Product", newSchema: "finance");
            MoveTable(name: "dbo.BasketItem", newSchema: "finance");
            MoveTable(name: "dbo.AttendanceWeek", newSchema: "attendance");
            MoveTable(name: "dbo.Session", newSchema: "curriculum");
            MoveTable(name: "dbo.AttendancePeriod", newSchema: "attendance");
            MoveTable(name: "dbo.AttendanceMark", newSchema: "attendance");
            MoveTable(name: "dbo.Student", newSchema: "person");
            MoveTable(name: "dbo.Enrolment", newSchema: "curriculum");
            MoveTable(name: "dbo.Class", newSchema: "curriculum");
            MoveTable(name: "dbo.Bulletin", newSchema: "system");
            MoveTable(name: "dbo.StaffMember", newSchema: "person");
            MoveTable(name: "dbo.DiaryEvent", newSchema: "system");
            MoveTable(name: "dbo.Detention", newSchema: "behaviour");
            MoveTable(name: "dbo.DetentionAttendanceStatus", newSchema: "behaviour");
            MoveTable(name: "dbo.IncidentDetention", newSchema: "behaviour");
            MoveTable(name: "dbo.Incident", newSchema: "behaviour");
            MoveTable(name: "dbo.Location", newSchema: "school");
            MoveTable(name: "dbo.Achievement", newSchema: "behaviour");
            MoveTable(name: "dbo.AcademicYear", newSchema: "curriculum");
            RenameTable(name: "sen.SenReviewType", newName: "ReviewType");
            RenameTable(name: "system.SystemArea", newName: "Area");
            RenameTable(name: "communication.CommunicationLog", newName: "Log");
            RenameTable(name: "attendance.AttendanceCode", newName: "Code");
            RenameTable(name: "attendance.AttendanceCodeMeaning", newName: "CodeMeaning");
            RenameTable(name: "sen.SenStatus", newName: "Status");
            RenameTable(name: "sen.SenProvisionType", newName: "ProvisionType");
            RenameTable(name: "sen.SenProvision", newName: "Provision");
            RenameTable(name: "sen.SenEventType", newName: "EventType");
            RenameTable(name: "sen.SenEvent", newName: "Event");
            RenameTable(name: "profile.ProfileLogNoteType", newName: "LogNoteType");
            RenameTable(name: "profile.ProfileLogNote", newName: "LogNote");
            RenameTable(name: "school.SchoolType", newName: "Type");
            RenameTable(name: "medical.MedicalCondition", newName: "Condition");
            RenameTable(name: "medical.MedicalEvent", newName: "Event");
            RenameTable(name: "attendance.AttendanceWeek", newName: "Week");
            RenameTable(name: "attendance.AttendancePeriod", newName: "Period");
            RenameTable(name: "attendance.AttendanceMark", newName: "Mark");
        }
    }
}