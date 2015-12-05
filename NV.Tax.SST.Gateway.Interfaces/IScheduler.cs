using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV.Tax.SST.Gateway.Interfaces
{
    public interface Scheduler {

    // static readonly String DEFAULT_GROUP = "DEFAULT";
    // static readonly String DEFAULT_MANUAL_TRIGGERS = "MANUAL_TRIGGER";
    // static readonly String DEFAULT_RECOVERY_GROUP = "RECOVERING_JOBS";
    // static readonly String DEFAULT_FAIL_OVER_GROUP = "FAILED_OVER_JOBS";
    // static readonly String FAILED_JOB_ORIGINAL_TRIGGER_NAME = "QRTZ_FAILED_JOB_ORIG_TRIGGER_NAME";
    // static readonly String FAILED_JOB_ORIGINAL_TRIGGER_GROUP = "QRTZ_FAILED_JOB_ORIG_TRIGGER_GROUP";
    // static readonly String FAILED_JOB_ORIGINAL_TRIGGER_FIRETIME_IN_MILLISECONDS = "QRTZ_FAILED_JOB_ORIG_TRIGGER_FIRETIME_IN_MILLISECONDS_AS_STRING";

    String getSchedulerName();

    String getSchedulerInstanceId() ;

    SchedulerContext getContext() ;

    void start() ;

    void startDelayed(int i) ;

    Boolean isStarted() ;

    void standby() ;

    void pause() ;

    Boolean isInStandbyMode() ;

    Boolean isPaused() ;

    void shutdown() ;

    void shutdown(Boolean bln) ;

    Boolean isShutdown() ;

    SchedulerMetaData getMetaData() ;

    List<string> getCurrentlyExecutingJobs() ;

    void setJobFactory(JobFactory jf) ;

    DateTime scheduleJob(JobDetail jd, Trigger trgr) ;

    DateTime scheduleJob(Trigger trgr) ;

    Boolean unscheduleJob(String str1, String str2) ;

    DateTime rescheduleJob(String str, String str1, Trigger trgr) ;

    void addJob(JobDetail jd, Boolean bln) ;

    Boolean deleteJob(String str, String str1) ;

    void triggerJob(String str, String str1) ;

    void triggerJobWithVolatileTrigger(String str, String str1) ;

    void triggerJob(String str, String str1, JobDataMap jdm) ;

    void triggerJobWithVolatileTrigger(String str, String str1, JobDataMap jdm) ;

    void pauseJob(String str, String str1) ;

    void pauseJobGroup(String str) ;

    void pauseTrigger(String str, String str1) ;

    void pauseTriggerGroup(String str) ;

    void resumeJob(String str, String str1) ;

    void resumeJobGroup(String str) ;

    void resumeTrigger(String str, String str1) ;

    void resumeTriggerGroup(String str) ;

    void pauseAll() ;

    void resumeAll() ;

    String[] getJobGroupNames() ;

    String[] getJobNames(String str) ;

    Trigger[] getTriggersOfJob(String str, String str1) ;

    String[] getTriggerGroupNames() ;

    String[] getTriggerNames(String str) ;

    Set getPausedTriggerGroups() ;

    JobDetail getJobDetail(String str, String str1) ;

    Trigger getTrigger(String str, String str1) ;

    int getTriggerState(String str, String str1) ;

    void addCalendar(String str, Calendar clndr, Boolean bln, Boolean bln1) ;

    Boolean deleteCalendar(String str) ;

    Calendar getCalendar(String str) ;

    String[] getCalendarNames() ;

    Boolean interrupt(String str, String str1) ;

    void addGlobalJobListener(JobListener jl) ;

    void addJobListener(JobListener jl) ;

    Boolean removeGlobalJobListener(JobListener jl) ;

    Boolean removeGlobalJobListener(String str) ;

    Boolean removeJobListener(String str) ;

    List<string> getGlobalJobListeners() ;

    Set getJobListenerNames() ;

    JobListener getGlobalJobListener(String str) ;

    JobListener getJobListener(String str) ;

    void addGlobalTriggerListener(TriggerListener tl) ;

    void addTriggerListener(TriggerListener tl) ;

    Boolean removeGlobalTriggerListener(TriggerListener tl) ;

    Boolean removeGlobalTriggerListener(String str) ;

    Boolean removeTriggerListener(String str) ;

    List<string> getGlobalTriggerListeners() ;

    Set getTriggerListenerNames() ;

    TriggerListener getGlobalTriggerListener(String str) ;

    TriggerListener getTriggerListener(String str) ;

    void addSchedulerListener(SchedulerListener sl) ;

    Boolean removeSchedulerListener(SchedulerListener sl) ;

    List<string> getSchedulerListeners() ;
}

}
