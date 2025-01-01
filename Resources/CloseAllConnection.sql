Create Proc [dbo].[CloseAllConnection]
  @DB Sysname = Null
AS

if @DB Is Null 
begin
  print 'you must provide the db name'
  return
end
else if @DB = 'master'
begin
  print 'cann not run this procedure against the master DB'
  return 
end

Set NoCount On

-- Declare Variables

Declare @spid int , @q Nvarchar(1000)

Declare C_Users Cursor FAST_FORWARD  FOR
  Select spid From master..sysprocesses NoLock
  Where dbid = db_id(@DB)


Open C_Users

Fetch Next From C_Users Into @spid

While @@Fetch_Status = 0
Begin 
  Set @q = 'Kill ' + Cast( @spid AS Nvarchar(50) )
  Exec(@q)

  Fetch Next From C_Users Into @spid
End

Close C_Users
DeAllocate C_Users