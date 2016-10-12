<Query Kind="Statements">
  <Connection>
    <ID>60408c34-3117-44f3-909d-bba77b66afde</ID>
    <Persist>true</Persist>
    <Server>etech-dev01</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8JEdqNgoLEKFrbDwxk5wUgAAAAACAAAAAAADZgAAwAAAABAAAADRyYe4ia2HQxFuFkTq62t5AAAAAASAAACgAAAAEAAAAF2N0QU/OLRKMrr9YS/jJt4QAAAAykMZSyropwoSpYbjs6AqAxQAAAD+zUzq6Vt/7kizl6VoEEzya5DU8Q==</Password>
    <Database>SPHEC_DS</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var emails = "d.s@c.co;m.d@g.in,osdfg@sddf.gg";
//emails = "d.s@dsfdf.vd";

var delimeters = ";,".ToCharArray();

Func<string,bool> isValid = (str) => 
	Regex.Match(str,@"^[-+.\w]{1,64}@[-.\w]{1,64}\.[-.\w]{2,6}$").Success;

foreach (var email in emails.Split(delimeters))
{
	Console.WriteLine(email + " is " + isValid(email.Trim()));
}

