<Query Kind="Program">
  <NuGetReference>Moq.Sequences</NuGetReference>
  <Namespace>Castle.DynamicProxy</Namespace>
  <Namespace>Castle.DynamicProxy.Generators</Namespace>
  <Namespace>Moq</Namespace>
  <Namespace>Moq.Language</Namespace>
  <Namespace>Moq.Language.Flow</Namespace>
  <Namespace>Moq.Protected</Namespace>
  <Namespace>Moq.Sequences</Namespace>
  <Namespace>Moq.Sequences.Test</Namespace>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnit.Framework.Constraints</Namespace>
  <Namespace>NUnit.Mocks</Namespace>
  <Namespace>PNUnit.Framework</Namespace>
</Query>

void Main()
{
	
	var moq = new Mock<IProvisioningService>();

	using (Sequence.Create())
	{
		moq.Setup(_ => _.StartBatch()).InSequence(Times.AtMostOnce());
		using (Sequence.Loop())
		{
			moq.Setup(_ => _.SendPacket(It.IsAny<string>())).InSequence(Times.AtLeastOnce());
		}
		moq.Setup(_ => _.EndPacket()).InSequence(Times.AtMostOnce());
		
		Process(moq.Object);
	}
}

private void Process(IProvisioningService service)
{
	var num = service.StartBatch();
	for (var i = 0; i <= 10; i++)
	{
		service.SendPacket(i.ToString());
	}
	service.EndPacket();
}

public interface IProvisioningService
{ 
	int StartBatch();
	void SendPacket(string packet);
	bool EndPacket();
}
