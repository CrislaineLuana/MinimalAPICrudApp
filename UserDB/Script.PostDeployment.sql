
if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values('Crislaine','Luana'),
		  ('Lucas', 'Fernandes'),
		  ('Mary', 'Jones'),
		  ('Sue', 'Storm');
end