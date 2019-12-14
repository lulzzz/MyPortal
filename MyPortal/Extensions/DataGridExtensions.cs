﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortal.BusinessLogic.Models;
using MyPortal.BusinessLogic.Models.Data;
using Syncfusion.EJ2.Base;

namespace MyPortal.Extensions
{
    public static class DataGridExtensions
    {
        public static ApiResponse<T> PerformDataOperations<T>(this IEnumerable<T> dataSource, DataManagerRequest dm)
        {
            DataOperations operation = new DataOperations();

            if (dm.Search != null && dm.Search.Count > 0)
            {
                dataSource = operation.PerformSearching(dataSource, dm.Search);
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                dataSource = operation.PerformSorting(dataSource, dm.Sorted);
            }

            if (dm.Where != null && dm.Where.Count > 0)
            {
                dataSource = operation.PerformFiltering(dataSource, dm.Where, dm.Where[0].Operator);
            }

            var count = dataSource.Count();

            if (dm.Skip != 0)
            {
                dataSource = operation.PerformSkip(dataSource, dm.Skip);
            }

            if (dm.Take != 0)
            {
                dataSource = operation.PerformTake(dataSource, dm.Take);
            }

            return new ApiResponse<T> { Count = count, Items = dataSource };
        }
    }
}