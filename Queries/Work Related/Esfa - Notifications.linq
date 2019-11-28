<Query Kind="Program" />

class VacancyRejectNotificationCommandHandler
{
    public void OnVacancyRejectedNotificationHandler(Guid vacancyId)
    {
        var vacancy = GetVacancy(vacancyId);
        var dbUsers = vacancy.VacancyOwner == "Employer"
            ? GetEmployerUsersWithRejectedNotificationAlerts(vacancy.EmployerAccountId)
            : GetProviderUsersWithRejectedNotificationAlerts(vacancy.TrainingProvider.Ukprn);


        foreach (var dbUser in dbUsers)
        {
            bool shouldSendNotification = false;
            // Should user submitted by user or created by user
            if (dbUser.IdamsUserId == vacancy.SubmittedByUser.UserId)
                shouldSendNotification = dbUser.NotificationOptions.OnVacancyRejected;
            else
                shouldSendNotification = dbUser.NotificationOptions.OnVacancyRejected && dbUser.NotificationOptions.UserSubmittedVacaciesOnly == false;a
            ///if (shouldSendNotification)
              ///mediator.send(new RejectedVacancyNotificationCommand(dbUser.Email, vacancy.Id);
        }
    }

    Vacancy GetVacancy(Guid vacancyId) => new Vacancy();

    IEnumerable<DbUser> GetEmployerUsersWithRejectedNotificationAlerts(string accountId)
    {
        var users = new List<DbUser>();
        /// How to filter users based on employerAccountId ?
        return users.Where(u => u.UserType == "employer" && u.NotificationOptions.OnVacancyRejected == true);
    }

    IEnumerable<DbUser> GetProviderUsersWithRejectedNotificationAlerts(long ukprn)
    {
        var users = new List<DbUser>();
        return users.Where(u => u.UserType == "provider" && u.Ukprn == ukprn && u.NotificationOptions.OnVacancyRejected == true);
    }
}

class Vacancy
{
    public Guid Id { get; set; }
    public string VacancyOwner { get; set; }
    public string EmployerAccountId { get; set; }
    public TrainingProvider TrainingProvider { get; set; }
    public User SubmittedByUser { get; set; }
}

class User
{
    public string UserId { get; set; }
}

class DbUser
{
    public string IdamsUserId { get; set; }
    public string UserType { get; set; }
    public NotificationOptions NotificationOptions { get; set; }
    public long Ukprn { get; set; }
    public string Email { get; set; }
}

class NotificationOptions
{
    public bool OnVacancyRejected { get; set; }
    
    public bool UserSubmittedVacaciesOnly { get; set; }
}

class TrainingProvider
{
    public long Ukprn { get; set; }
}

class RejectedVacancyNotificationCommand
{
    public RejectedVacancyNotificationCommand(string email, Guid vacancyId) {}
}
