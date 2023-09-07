using La.Infra.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using La.Model.System;

namespace La.Tasks
{
	public interface ITaskSchedulerServer
	{
		Task<ApiResult> StartTaskScheduleAsync();

		Task<ApiResult> StopTaskScheduleAsync();

		Task<ApiResult> AddTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> PauseTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> ResumeTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> DeleteTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> RunTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> UpdateTaskScheduleAsync(SysTasks tasksQz);
	}
}
