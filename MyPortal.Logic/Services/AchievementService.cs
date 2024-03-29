﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Entity;
using MyPortal.Database.Repositories;
using MyPortal.Logic.Exceptions;
using MyPortal.Logic.Extensions;
using MyPortal.Logic.Interfaces;
using MyPortal.Logic.Interfaces.Services;
using MyPortal.Logic.Models.Data;
using MyPortal.Logic.Models.Entity;
using MyPortal.Logic.Models.Requests.Behaviour;
using MyPortal.Logic.Models.Requests.Behaviour.Achievements;
using Task = System.Threading.Tasks.Task;

namespace MyPortal.Logic.Services
{
    public class AchievementService : BaseService, IAchievementService
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IAchievementTypeRepository _achievementTypeRepository;
        private readonly IAchievementOutcomeRepository _achievementOutcomeRepository;

        public AchievementService(IAcademicYearRepository academicYearRepository,
            IAchievementRepository achievementRepository, IAchievementTypeRepository achievementTypeRepository,
            IAchievementOutcomeRepository achievementOutcomeRepository)
        {
            _academicYearRepository = academicYearRepository;
            _achievementRepository = achievementRepository;
            _achievementTypeRepository = achievementTypeRepository;
            _achievementOutcomeRepository = achievementOutcomeRepository;
        }

        public override void Dispose()
        {
            _achievementRepository.Dispose();
            _achievementTypeRepository.Dispose();
            _achievementOutcomeRepository.Dispose();
        }

        public async Task<IEnumerable<AchievementModel>> GetByStudent(Guid studentId, Guid academicYearId)
        {
            var achievements = await _achievementRepository.GetByStudent(studentId, academicYearId);

            return achievements.Select(BusinessMapper.Map<AchievementModel>).ToList();
        }

        public async Task<AchievementModel> GetById(Guid achievementId)
        {
            var achievement = await _achievementRepository.GetById(achievementId);

            return BusinessMapper.Map<AchievementModel>(achievement);
        }

        public async Task<int> GetPointsByStudent(Guid studentId, Guid academicYearId)
        {
            var points = await _achievementRepository.GetPointsByStudent(studentId, academicYearId);

            return points;
        }

        public async Task<int> GetCountByStudent(Guid studentId, Guid academicYearId)
        {
            var count = await _achievementRepository.GetCountByStudent(studentId, academicYearId);

            return count;
        }

        public async Task CheckYearLock(Guid academicYearId)
        {
            if (await _academicYearRepository.IsLocked(academicYearId))
            {
                throw new InvalidDataException("Academic year is locked and cannot be modified.");
            }
        }

        public async Task Create(params AchievementModel[] requests)
        {
            foreach (var request in requests)
            {
                await AcademicYearModel.CheckLock(_academicYearRepository, request.AcademicYearId);
                
                var model = new Achievement
                {
                    AcademicYearId = request.AcademicYearId,
                    AchievementTypeId = request.AchievementTypeId,
                    LocationId = request.LocationId,
                    StudentId = request.StudentId,
                    Comments = request.Comments,
                    OutcomeId = request.OutcomeId,
                    Points = request.Points,
                    RecordedById = request.RecordedById,
                    CreatedDate = DateTime.Now
                };

                _achievementRepository.Create(model);
            }

            await _achievementRepository.SaveChanges();
        }

        public async Task Update(params UpdateAchievementModel[] requests)
        {
            foreach (var request in requests)
            {
                var achievementInDb = await _achievementRepository.GetByIdWithTracking(request.Id);

                if (achievementInDb == null)
                {
                    throw new NotFoundException("Achievement not found.");
                }

                await AcademicYearModel.CheckLock(_academicYearRepository, achievementInDb.AcademicYearId);

                achievementInDb.AchievementTypeId = request.AchievementTypeId;
                achievementInDb.LocationId = request.LocationId;
                achievementInDb.OutcomeId = request.OutcomeId;
                achievementInDb.Comments = request.Comments;
                achievementInDb.Points = request.Points;
            }

            await _achievementRepository.SaveChanges();
        }

        public async Task Delete(params Guid[] achievementIds)
        {
            foreach (var achievementId in achievementIds)
            {
                var achievement = await GetById(achievementId);

                await AcademicYearModel.CheckLock(_academicYearRepository, achievement.AcademicYearId);
                
                await _achievementRepository.Delete(achievementId);
            }

            await _achievementRepository.SaveChanges();
        }

        public async Task<IEnumerable<AchievementTypeModel>> GetTypes()
        {
            var types = await _achievementTypeRepository.GetAll();

            return types.Select(BusinessMapper.Map<AchievementTypeModel>).ToList();
        }

        public async Task<IEnumerable<AchievementOutcomeModel>> GetOutcomes()
        {
            var outcomes = await _achievementOutcomeRepository.GetAll();

            return outcomes.Select(BusinessMapper.Map<AchievementOutcomeModel>).ToList();
        }
    }
}
