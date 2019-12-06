﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using MyPortal.Dtos;
using MyPortal.Exceptions;
using MyPortal.Extensions;
using MyPortal.Interfaces;
using MyPortal.Models.Database;

namespace MyPortal.Services
{
    public class StudentService : MyPortalService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public StudentService() : base()
        {

        }

        public async Task CreateStudent(Student student)
        {
            ValidationService.ValidateModel(student);

            UnitOfWork.Students.Add(student);

            await UnitOfWork.Complete();
        }

        public async Task DeleteStudent(int studentId)
        {
            var studentInDb = await GetStudentById(studentId);

            if (studentInDb == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Student not found");
            }

            UnitOfWork.AssessmentResults.RemoveRange(studentInDb.Results);
            UnitOfWork.AttendanceMarks.RemoveRange(studentInDb.AttendanceMarks);
            UnitOfWork.BehaviourAchievements.RemoveRange(studentInDb.Achievements);
            UnitOfWork.BehaviourIncidents.RemoveRange(studentInDb.Incidents);
            UnitOfWork.CurriculumEnrolments.RemoveRange(studentInDb.Enrolments);
            UnitOfWork.FinanceBasketItems.RemoveRange(studentInDb.FinanceBasketItems);
            UnitOfWork.FinanceSales.RemoveRange(studentInDb.Sales);
            UnitOfWork.MedicalEvent.RemoveRange(studentInDb.MedicalEvents);
            UnitOfWork.SenEvents.RemoveRange(studentInDb.SenEvents);
            UnitOfWork.SenProvisions.RemoveRange(studentInDb.SenProvisions);
            UnitOfWork.ProfileLogs.RemoveRange(studentInDb.ProfileLogs);
            UnitOfWork.SenGiftedTalented.RemoveRange(studentInDb.GiftedTalentedSubjects);

            UnitOfWork.Students.Remove(studentInDb);

            await UnitOfWork.Complete();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var result = await UnitOfWork.Students.GetAll();

            return result;
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await UnitOfWork.Students.GetById(studentId);

            if (student == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Student not found");
            }

            return student;
        }

        public async Task<Student> GetStudentByIdWithRelated(int studentId, params Expression<Func<Student, object>>[] includeProperties)
        {
            var student = await UnitOfWork.Students.GetByIdWithRelated(studentId, includeProperties);

            if (student == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Student not found");
            }

            return student;
        }

        public async Task<Student> GetStudentByUserId(string userId)
        {
            var student = await UnitOfWork.Students.GetByUserId(userId);

            if (student == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Student not found");
            }

            return student;
        }

        public async Task<Student> TryGetStudentByUserId(string userId)
        {
            var student = await UnitOfWork.Students.GetByUserId(userId);

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsByRegGroup(int regGroupId)
        {
            var students = await UnitOfWork.Students.GetByRegGroup(regGroupId);

            return students;
        }
        
        public async Task<IEnumerable<Student>> GetStudentsByYearGroup(int yearGroupId)
        {
            var students = await UnitOfWork.Students.GetByYearGroup(yearGroupId);

            return students;
        }

        public async Task UpdateStudent(Student student)
        {
            ValidationService.ValidateModel(student);

            var studentInDb = await GetStudentById(student.Id);

            studentInDb.HouseId = student.HouseId;
            studentInDb.Upn = student.Upn;
            studentInDb.CandidateNumber = student.CandidateNumber;
            studentInDb.FreeSchoolMeals = student.FreeSchoolMeals;
            studentInDb.GiftedAndTalented = student.GiftedAndTalented;
            studentInDb.PupilPremium = student.PupilPremium;
            studentInDb.RegGroupId = student.RegGroupId;
            studentInDb.YearGroupId = student.YearGroupId;
            studentInDb.SenStatusId = student.SenStatusId;
            studentInDb.Uci = student.Uci;

            studentInDb.Person.FirstName = student.Person.FirstName;
            studentInDb.Person.LastName = student.Person.LastName;
            studentInDb.Person.Gender = student.Person.Gender;
            studentInDb.Person.Dob = student.Person.Dob;
            studentInDb.Person.MiddleName = student.Person.MiddleName;
            studentInDb.Person.PhotoId = student.Person.PhotoId;
            studentInDb.Person.NhsNumber = student.Person.NhsNumber;
            studentInDb.Person.Deceased = student.Person.Deceased;

            await UnitOfWork.Complete();
        }
    }
}