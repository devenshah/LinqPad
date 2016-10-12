<Query Kind="SQL">
  <Connection>
    <ID>c2a40155-e022-4078-8135-6ef470ee9e01</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>SurveyHub</Database>
  </Connection>
</Query>

declare @jobId as uniqueidentifier = '63167C1D-F7A0-4C44-BE8D-C668E30A139E';

if (exists(select * from Domain.Job where Id = @jobId))
Begin
	delete from Domain.MilestoneEventMessage
	where MilestoneEventId in (select Id from Domain.MilestoneEvent where JobId = @jobId)
	
	delete from Domain.MilestoneItem
	where MilestoneId in (select Id from Domain.Milestone where JobId = @jobId)

	delete from Domain.MilestoneRequest
	where MilestoneId in (select Id from Domain.Milestone where JobId = @jobId)
	
	delete from Domain.MilestoneResponseMessage 
	where MilestoneResponseId in (
		select res.Id 
		from Domain.MilestoneResponse  res
		inner join Domain.MilestoneRequest req on res.MilestoneRequestId = req.Id
		inner join Domain.Milestone m on m.Id = req.MilestoneId
		where m.JobId = @jobId)
	
	delete from Domain.MilestoneResponse
	where Id in (
		select res.Id 
		from Domain.MilestoneResponse  res
		inner join Domain.MilestoneRequest req on res.MilestoneRequestId = req.Id
		inner join Domain.Milestone m on m.Id = req.MilestoneId
		where m.JobId = @jobId)

	update Domain.MilestoneEvent 
		set PreviousId = null,
		MilestoneId = null
	where JobId = @jobId
	
	delete from Domain.Milestone
	where JobId = @jobId

	delete from Domain.MilestoneEvent
	where JobId = @jobId
End