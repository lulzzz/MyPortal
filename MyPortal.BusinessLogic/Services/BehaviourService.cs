﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPortal.BusinessLogic.Dtos;
using MyPortal.BusinessLogic.Exceptions;
using MyPortal.BusinessLogic.Models;
using MyPortal.BusinessLogic.Models.Data;
using MyPortal.Data.Interfaces;
using MyPortal.Data.Models;

namespace MyPortal.BusinessLogic.Services
{
    public class BehaviourService : MyPortalService
    {
        public BehaviourService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public BehaviourService() : base()
        {

        }

        public async Task CreateAchievement(AchievementDto achievement)
        {
            achievement.Date = DateTime.Today;

            ValidationService.ValidateModel(achievement);

            UnitOfWork.Achievements.Add(Mapper.Map<Achievement>(achievement));
        }

        public async Task CreateDetention(DetentionDto detention)
        {
            ValidationService.ValidateModel(detention);

            detention.Event.Subject = $"detention_{detention.DetentionTypeId}_{detention.Id}";

            UnitOfWork.Detentions.Add(Mapper.Map<Detention>(detention));
        }

        public async Task UpdateDetention(DetentionDto detention)
        {
            var detentionInDb = await UnitOfWork.Detentions.GetById(detention.Id);

            if (detentionInDb == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Detention not found.");
            }

            detentionInDb.DetentionTypeId = detention.DetentionTypeId;
            detentionInDb.SupervisorId = detention.SupervisorId;
            detentionInDb.Event.StartTime = detention.Event.StartTime;
            detentionInDb.Event.EndTime = detention.Event.EndTime;
        }

        public async Task DeleteDetention(int detentionId)
        {
            var detentionInDb = await UnitOfWork.Detentions.GetById(detentionId);

            if (detentionInDb == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Detention not found.");
            }

            UnitOfWork.DiaryEvents.Remove(detentionInDb.Event);
            UnitOfWork.Detentions.Remove(detentionInDb);
        }

        public async Task CreateIncidentDetention(IncidentDetention entry)
        {
            ValidationService.ValidateModel(entry);

            UnitOfWork.IncidentDetentions.Add(entry);

            
        }

        public async Task DeleteIncidentDetention(int incidentDetentionId)
        {
            IncidentDetention detentionInDb = await UnitOfWork.IncidentDetentions.GetById(incidentDetentionId);

            if (detentionInDb == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Incident not found in detention.");
            }

            UnitOfWork.IncidentDetentions.Remove(detentionInDb);
        }

        public async Task UpdateIncidentDetention(IncidentDetention entry)
        {
            var detentionInDb = await UnitOfWork.IncidentDetentions.GetById(entry.Id);

            if (detentionInDb == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Incident not found in detention.");
            }

            detentionInDb.DetentionId = entry.DetentionId;
            detentionInDb.AttendanceStatusId = entry.AttendanceStatusId;
        }

        public async Task<Dictionary<int, string>> GetDetentionAttendanceStatusLookup()
        {
            return (await UnitOfWork.DetentionAttendanceStatus.GetAll(x => !x.Attended)).ToDictionary(x => x.Id,
                x => x.Description);
        }

        public async Task<IEnumerable<IncidentDetentionDto>> GetIncidentDetentionsNotAttended()
        {
            return (await UnitOfWork.IncidentDetentions.GetNotAttended()).Select(Mapper.Map<IncidentDetentionDto>).ToList();
        }

        public async Task<IEnumerable<IncidentDetentionDto>> GetIncidentDetentionsByStudent(int studentId)
        {
            return (await UnitOfWork.IncidentDetentions.GetByStudent(studentId)).Select(Mapper
                .Map<IncidentDetentionDto>).ToList();
        }

        public async Task CreateBehaviourIncident(IncidentDto incident)
        {
            incident.Date = DateTime.Today;

            ValidationService.ValidateModel(incident);

            UnitOfWork.Incidents.Add(Mapper.Map<Incident>(incident));
        }

        public async Task DeleteAchievement(int achievementId)
        {
            var achievement = await UnitOfWork.Achievements.GetById(achievementId);

            if (achievement == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Achievement not found.");
            }

            UnitOfWork.Achievements.Remove(achievement);
        }

        public async Task DeleteBehaviourIncident(int incidentId)
        {
            var incident = await UnitOfWork.Incidents.GetById(incidentId);

            if (incident == null)
            {
                throw new ServiceException(ExceptionType.NotFound, "Incident not found.");
            }

            UnitOfWork.Incidents.Remove(incident);
        }

        public async Task<AchievementDto> GetAchievementById(int achievementId)
        {
            var achievement = await UnitOfWork.Achievements.GetById(achievementId);

            if (achievement == null)
            {
                throw new ServiceException(ExceptionType.NotFound,"Achievement not found.");
            }

            return Mapper.Map<AchievementDto>(achievement);
        }

        public async Task<int> GetAchievementCountByStudent(int studentId, int academicYearId)
        {
            var achievementCount =
                await UnitOfWork.Achievements.GetCountByStudent(studentId, academicYearId);

            return achievementCount;
        }

        public async Task<int> GetAchievementPointsCountByStudent(int studentId, int academicYearId)
        {
            var points =
                await UnitOfWork.Achievements.GetPointsByStudent(studentId, academicYearId);

            return points;
        }

        public async Task<IncidentDto> GetBehaviourIncidentById(int incidentId)
        {
            var incident = await UnitOfWork.Incidents.GetById(incidentId);

            if (incident == null)
            {
                throw new ServiceException(ExceptionType.NotFound,"Incident not found.");
            }

            return Mapper.Map<IncidentDto>(incident);
        }

        public async Task<int> GetBehaviourIncidentCountByStudent(int studentId, int academicYearId)
        {
            var negPoints =
                await UnitOfWork.Incidents.GetCountByStudent(studentId, academicYearId);

            return negPoints;
        }

        public async Task<int> GetBehaviourPointsCountByStudent(int studentId, int academicYearId)
        {
            var points =
                await UnitOfWork.Incidents.GetPointsByStudent(studentId,
                    academicYearId);

            return points;
        }

        public async Task<IEnumerable<ChartDataCategoric>> GetChartDataAchievementsByType(int academicYearId)
        {
            var recordedAchievementTypes =
                await UnitOfWork.AchievementTypes.GetRecorded(academicYearId);

            return recordedAchievementTypes.Select(achievementType => new ChartDataCategoric(achievementType.Description, achievementType.Achievements.Count)).ToList();
        }

        public async Task<IEnumerable<ChartDataCategoric>> GetChartDataBehaviourIncidentsByType(int academicYearId)
        {
            var recordedBehaviourTypes =
                await UnitOfWork.IncidentTypes.GetRecorded(academicYearId);

            return recordedBehaviourTypes.Select(behaviourType => new ChartDataCategoric(behaviourType.Description, behaviourType.Incidents.Count)).ToList();
        }

        public async Task<int> GetTotalConductPointsByStudent(int studentId, int academicYearId)
        {
            var achievementPoints =
                await GetAchievementPointsCountByStudent(studentId, academicYearId);

            var behaviourPoints =
                await GetBehaviourPointsCountByStudent(studentId,
                    academicYearId);

            return achievementPoints - behaviourPoints;
        }

        public async Task<IEnumerable<AchievementDto>> GetAchievementsByStudent(int studentId, int academicYearId)
        {
            return (await UnitOfWork.Achievements.GetByStudent(studentId, academicYearId)).Select(Mapper.Map<AchievementDto>).ToList();
        }

        public async Task<IEnumerable<IncidentDto>> GetBehaviourIncidentsByStudent(int studentId,
            int academicYearId)
        {
            return (await UnitOfWork.Incidents.GetByStudent(studentId, academicYearId)).Select(Mapper.Map<IncidentDto>).ToList();
        }
        
        public async Task UpdateAchievement(AchievementDto achievement)
        {
            var achievementInDb = await UnitOfWork.Achievements.GetById(achievement.Id);

            achievementInDb.LocationId = achievement.LocationId;
            achievementInDb.Comments = achievement.Comments;
            achievementInDb.Points = achievement.Points;
            achievementInDb.Resolved = achievement.Resolved;
            achievementInDb.AchievementTypeId = achievement.AchievementTypeId;
        }

        public async Task UpdateBehaviourIncident(IncidentDto incident)
        {
            var incidentInDb = await UnitOfWork.Incidents.GetById(incident.Id);

            incidentInDb.LocationId = incident.LocationId;
            incidentInDb.Comments = incident.Comments;
            incidentInDb.Points = incident.Points;
            incidentInDb.Resolved = incident.Resolved;
            incidentInDb.BehaviourTypeId = incident.BehaviourTypeId;
        }

        public async Task<IEnumerable<AchievementTypeDto>> GetAchievementTypes()
        {
            return (await UnitOfWork.AchievementTypes.GetAll(x => x.Description)).Select(
                Mapper.Map<AchievementTypeDto>).ToList();
        }

        public async Task<IEnumerable<IncidentTypeDto>> GetBehaviourIncidentTypes()
        {
            return (await UnitOfWork.IncidentTypes.GetAll(x => x.Description)).Select(Mapper.Map<IncidentTypeDto>).ToList();
        }

        public async Task<int> GetAchievementPointsToday()
        {
            return await UnitOfWork.Achievements.GetPointsToday();
        }

        public async Task<int> GetBehaviourPointsToday()
        {
            return await UnitOfWork.Incidents.GetPointsToday();
        }
    }
}