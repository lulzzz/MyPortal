﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Logic.Extensions;
using MyPortal.Logic.Interfaces;
using MyPortal.Logic.Models.Entity;

namespace MyPortal.Logic.Services
{
    public class AttendanceWeekService : BaseService, IAttendanceWeekService
    {
        private readonly IAttendanceWeekRepository _attendanceWeekRepository;

        public AttendanceWeekService(IAttendanceWeekRepository attendanceWeekRepository) : base("Attendance week")
        {
            _attendanceWeekRepository = attendanceWeekRepository;
        }

        public async Task<AttendanceWeekModel> GetById(Guid attendanceWeekId)
        {
            var attendanceWeek = await _attendanceWeekRepository.GetById(attendanceWeekId);

            if (attendanceWeek == null)
            {
                throw NotFound();
            }

            return BusinessMapper.Map<AttendanceWeekModel>(attendanceWeek);
        }

        public async Task<AttendanceWeekModel> GetByDate(DateTime date, bool throwIfNotFound = true)
        {
            var week = await _attendanceWeekRepository.GetByDate(date);

            if (week == null && throwIfNotFound)
            {
                throw NotFound();
            }

            return BusinessMapper.Map<AttendanceWeekModel>(week);
        }

        public override void Dispose()
        {
            _attendanceWeekRepository.Dispose();
        }
    }
}