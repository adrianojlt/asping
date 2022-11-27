  use AspingDb;
  -- SET IDENTITY_INSERT AspingDb.dbo.Distrito ON;
  select * from dbo.Predio;


  select * from dbo.Distrito;


  select * from dbo.Concelho;
  select * from dbo.Concelho where Nome like 'PORTO';
  select Id from dbo.Concelho where Nome like 'PORTO';


  select * from dbo.Freguesia;
  select * from dbo.Freguesia 
  join dbo.Concelho ON 
	dbo.Concelho.Id = 181 and 
	dbo.Concelho.Id = ConcelhoId;

  select * from dbo.Freguesia 
  join dbo.Concelho ON 
	dbo.Concelho.Id = ConcelhoId and
	dbo.Concelho.Id = (select Id from dbo.Concelho where Nome like 'PORTO');
	
  
  